using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JusHandler : MonoBehaviour {

	public Animator jusAnim;

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void OpenJus(PointerEventData data) {
		jusAnim.SetBool("isOpen", true);
	}

	public void CloseJus(PointerEventData data) {
		jusAnim.SetBool("isOpen", false);
	}

	public void TaruhBuah(PointerEventData data) {
		CloseJus(data);
		data.pointerDrag.GetComponent<Animator>().enabled = true;
		JustBuahManager.Instance.SetBuah(data.pointerDrag);
	}
}
