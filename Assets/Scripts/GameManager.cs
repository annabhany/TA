using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

	public int level{ get; set;}

	void Awake(){
		level = PlayerPrefs.GetInt ("Level");
	}

	// Use this for initialization
	void Start () {
	
	}


	
	// Update is called once per frame
	void Update () {
		if (level == 0) {
				
		}
	}


}
