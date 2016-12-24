using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMe : MonoBehaviour {

	private Vector3 position;

	void Start () {
		
	}

	void Update () {
		
	}

	public void BeginDrag() {
		position = GetComponent<RectTransform>().position;
	}

	public void OnDrag(){ transform.position = Input.mousePosition; }

	public void EndDrag() {
		GetComponent<RectTransform>().position = position;
	}
}
