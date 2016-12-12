using UnityEngine;
using System.Collections;

[System.Serializable]
public class SuaraWarna {
	public Warna warna;
	public AudioClip clip;
}

public class DatabaseSuara : Singleton<DatabaseSuara> {

	public SuaraWarna[] suaraWarna;

	void Awake() {
		instance = this;
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySuara(Warna warna) {
		foreach (SuaraWarna suara in suaraWarna) {
			if (suara.warna == warna) {
				GetComponent<AudioSource> ().clip = suara.clip;
				GetComponent<AudioSource> ().Play ();
			}
		}
	}
}
