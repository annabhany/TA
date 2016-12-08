using UnityEngine;
using System.Collections;

public class TombolBuah : MonoBehaviour {

	public Buah buah;
	public bool warna = true;

	AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	void Update () {
	
	}

	public void PlayAudio() {
		audioSource.clip = buah.clipNama;
		audioSource.Play ();
	}

	public void Jawab() {
		if (warna) {
			if (QuestionGenerator.Instance != null)
				QuestionGenerator.Instance.Jawab (buah);
		} else {
			if(QuestionBuah.Instance != null)
				QuestionBuah.Instance.Jawab (buah);
		}
	}
}
