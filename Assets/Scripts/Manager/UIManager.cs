using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void ActiveGameObject(GameObject go) {
		go.SetActive(true);
	}

	public void DeactiveGameObject(GameObject go) {
		go.SetActive(false);
	}

	public void ChangeScene(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}
}
