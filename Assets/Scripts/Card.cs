using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

	public Sprite front;
	public Sprite back;
	Image image;
	Button button;

	bool isOpen = false;

	void Awake () {
		image = GetComponent<Image> ();
		button = GetComponent<Button> ();
	}

	void Update () {
		
	}

	public void Open() {
		image.sprite = front;
		isOpen = true;
		button.interactable = false;
	}

	public void Close() {
		image.sprite = back;
		isOpen = false;
		button.interactable = true;
	}

	public void Toggle() {
		if (isOpen) {
			Close ();
		} else {
			CocokKartuManager.Instance.CardChoose (this);
			Open ();
		}
	}
}
