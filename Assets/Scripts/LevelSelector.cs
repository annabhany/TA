using UnityEngine;
using System.Collections;

public class LevelSelector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void selectLevel(int levelSelection) {
		PlayerPrefs.SetInt("Level", levelSelection);
	}
}

