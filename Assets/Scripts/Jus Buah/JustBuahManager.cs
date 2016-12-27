using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JustBuahManager : Singleton<JustBuahManager> {

	public GameObject[] gambarBuah;
	public Image water;
	private GameObject buah;

	void Awake() {
		instance = this;
	}

	void Start () {
		InitiateBuah();
	}
	
	void Update () {
		
	}

	void InitiateBuah() {
		foreach(GameObject go in gambarBuah) {
			Buah buah = DatabaseBuah.Instance.GetRandomBuah();
			go.GetComponent<Image>().sprite = buah.sprite;
		}
	}

	public void SetBuah(GameObject buah) {
		this.buah = buah;
	}

	public void Blend() {
		StartCoroutine(Blending());
	}

	IEnumerator Blending() {
		buah.GetComponent<Animator>().SetBool("isBlend", true);
		for(int i = 1; i < 100; i++) {
			water.fillAmount = (float)i / 100f;
			yield return new WaitForSeconds(0.1f);
		}
		buah.GetComponent<Animator>().SetBool("isBlend", false);
	}
}
