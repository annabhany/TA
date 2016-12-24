using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JustBuahManager : MonoBehaviour {

	public GameObject[] gambarBuah;

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
}
