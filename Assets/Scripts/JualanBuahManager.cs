using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JualanBuahManager : MonoBehaviour {

	public GameObject panelBuah;
	public GameObject tombolBuah;

	private List<Buah> daftarBuah = new List<Buah>();

	void Start () {
		InitiateBuah();
		InitiateButton();
	}
	
	void Update () {
		
	}

	void InitiateBuah() {
		for(int i = 0; i < 14; i++) {
			Buah tmpBuah = DatabaseBuah.Instance.GetRandomBuah();
			daftarBuah.Add(tmpBuah);
		}
	}

	void InitiateButton() {
		for(int i = 0; i < 14; i++) {
			GameObject go = Instantiate(tombolBuah, Vector3.zero, Quaternion.identity) as GameObject;
			go.transform.SetParent(panelBuah.transform);
			go.transform.localScale = new Vector3(1f, 1f, 1f);
			go.GetComponent<Image>().sprite = daftarBuah[i].sprite;
		}
	}
}
