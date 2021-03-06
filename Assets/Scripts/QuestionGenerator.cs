﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Level {
	public int lvl;
	public Warna[] warna;
	public int bintang1;
	public int bintang2;
	public int bintang3;
}


public class QuestionGenerator : Singleton<QuestionGenerator> {

	public Text soalText;
	public GameObject pilihanBuahPanel;
	public GameObject rewardPanel;
	public GameObject informasiPanel;
	public GameObject informasiGambar;
	public GameObject informasiButtonClose;
	public GameObject[] bintang;
	public GameObject[] buahPilihan;
	public GameObject pause;
	public AudioClip clipBenar;
	public AudioClip clipSalah;
	public Level[] level;
	int salah = 0;
	int benar;

	List<Buah> buahLoaded = new List<Buah> ();
	Warna jawaban;
	int currentLevel = 0;
	int currentPhase = 0;

	void Awake() {
		instance = this;
	}

	void Start () {
		GeneratingQuestion ();
	}

	void Update () {
	
	}

	public void aktifPause(){
		pause.SetActive (true);
	}

	public void nonaktifPause(){
		pause.SetActive (false);
	}


	public void GeneratingQuestion(){
		soalText.text = level [currentLevel].warna[currentPhase].ToString();
		DatabaseSuara.instance.PlaySuara (level [currentLevel].warna[currentPhase]);
		jawaban = level [currentLevel].warna [currentPhase];

		buahLoaded.Clear ();
		for (int i = 0; i < buahPilihan.Length; i++) {
			Buah buah = DatabaseBuah.Instance.GetRandomBuah ();

			// Biar gak ada buah yang sama
			while (buahLoaded.Exists (x => x.nama == buah.nama)) {
				buah = DatabaseBuah.Instance.GetRandomBuah ();
			}

			// Biar gak ada dua jawaban
			if (buahLoaded.Exists (x => x.warna == jawaban)) {
				while (buah.warna == jawaban) {
					buah = DatabaseBuah.Instance.GetRandomBuah ();
				}
			}

			buahLoaded.Add (buah);
			buahPilihan [i].GetComponent<TombolBuah> ().buah = buah;
			buahPilihan [i].GetComponent<Image> ().sprite = buah.sprite;
		}

		// Generate ulang apabila tidak ada jawaban yang benar
		if (!buahLoaded.Exists (x => x.warna == jawaban)) {
			GeneratingQuestion ();
		}


			
		/*if (GameManager.Instance.level == 1) {
			soalText.text = namaWarnaLevel1 [0];
		}
		else if (GameManager.Instance.level == 2) {
			soalText.text = namaWarnaLevel2 [0];
		}
		else if (GameManager.Instance.level == 3) {
			soalText.text = namaWarnaLevel3 [0];
		}
		else if (GameManager.Instance.level == 4) {
			soalText.text = namaWarnaLevel4 [0];
		}
		else if (GameManager.Instance.level == 5) {
			soalText.text = namaWarnaLevel5 [0];
		}
		else {
			soalText.text = "sasa";
		}*/
	}

	IEnumerator PreparingSuaraBenar() {
		yield return new WaitForSeconds (2.0f);
		playClipBenar ();
	}

	IEnumerator PreparingSuaraSalah() {
		yield return new WaitForSeconds (2.0f);
		playClipSalah ();
	}
		
	public void playClipBenar(){
		GetComponent<AudioSource> ().clip = clipBenar;
		GetComponent<AudioSource> ().Play();
	}

	public void playClipSalah(){
		GetComponent<AudioSource> ().clip = clipSalah;
		GetComponent<AudioSource> ().Play();
	}

	public void Jawab(Buah buah) {
		if (buah.warna == jawaban) {
			Debug.Log ("Benar");
			benar++;
			StartCoroutine (PreparingSuaraBenar ());

			if (currentPhase < level [currentLevel].warna.Length - 1) {
				currentPhase++;
				GeneratingQuestion ();
			} else {
				ShowReward ();
			}
		} else {
			Debug.Log ("Salah");
			salah++;
			StartCoroutine (PreparingSuaraSalah ());
			GetComponent<AudioSource> ().clip = clipSalah;
			GetComponent<AudioSource> ().Play();
			GeneratingQuestion ();
		}
	}

	void ShowReward() {
		rewardPanel.SetActive (true);
		if (salah <= level [currentLevel].bintang3) {
			bintang [0].SetActive (true);
			bintang [1].SetActive (true);
			bintang [2].SetActive (true);
		} else if (salah <= level [currentLevel].bintang2) {
			bintang [0].SetActive (true);
			bintang [1].SetActive (true);
		} else if (salah >= level [currentLevel].bintang1) {
			bintang [0].SetActive (true);
		}

		StartCoroutine (PreparingInformasi ());
	}

	IEnumerator PreparingInformasi() {
		yield return new WaitForSeconds (3.0f);
		ShowInformasi (DatabaseBuah.instance.GetRandomBuah ());
	}

	void ShowInformasi(Buah buah) {
		informasiPanel.SetActive (true);
		informasiGambar.GetComponent<Image> ().sprite = buah.sprite;
		GetComponent<AudioSource> ().clip = buah.clipManfaat;
		GetComponent<AudioSource> ().Play ();
		StartCoroutine (ShowCloseButton (buah.clipManfaat.length));
	}

	IEnumerator ShowCloseButton(float duration) {
		yield return new WaitForSeconds (duration);
		informasiButtonClose.SetActive (true);
	}

	public void NextLevel() {
		if (currentPhase < level [currentLevel].warna.Length - 1) {
			currentPhase++;
			GeneratingQuestion ();
		} else {
			if (currentLevel < level.Length - 1) {
				currentLevel++;
				GeneratingQuestion ();
			}
		}

		rewardPanel.SetActive (false);
	}
}
