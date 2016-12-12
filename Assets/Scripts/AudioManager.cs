using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip clipBenar;
	public AudioClip clipSalah;

	AudioSource audioSource;


	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayAudioBenar(){
		audioSource.clip = clipBenar;
		audioSource.Play ();
	}

	public void PlayAudioSalah(){
		audioSource.clip = clipSalah;
		audioSource.Play ();
	}
}
