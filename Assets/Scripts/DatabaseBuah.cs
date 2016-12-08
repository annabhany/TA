using UnityEngine;
using System.Collections;

public enum Warna {
	Merah, Kuning, Hijau, Ungu, Cokelat, Putih, MerahMuda, Oranye 
}

public enum Vitamin {
	A, B, C, E, K
}

[System.Serializable]
public class Buah {
	public string nama;
	public Sprite sprite;
	public Warna warna;
	public string manfaat;
	public Vitamin[] vitamin;
	public AudioClip clipNama;
	public AudioClip clipManfaat;
	public AudioClip clipSoal;
}

public class DatabaseBuah : Singleton<DatabaseBuah> {
	public Buah[] daftarBuah;

	void Awake() {
		instance = this;
		DontDestroyOnLoad (this);
	}

	public Buah GetRandomBuah() {
		return daftarBuah [Random.Range (0, daftarBuah.Length)];
	}

	public int GetLenght() {
		return daftarBuah.Length;
	}
}
