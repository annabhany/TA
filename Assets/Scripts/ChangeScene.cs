using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	//game manager


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeTo(string sceneName){
		Application.LoadLevel (sceneName);
	}



}
