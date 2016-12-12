using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LevelKartu {
	public int jumlahKartu;
}

public class CocokKartuManager : Singleton<CocokKartuManager> {

	public GameObject card;
	public GameObject cardPanel;
	public GridLayoutGroup gridLayout;
	public LevelKartu[] levels;

	private List<Card> cards = new List<Card>();
	private List<Buah> buah = new List<Buah>();

	Card chosenCard1;
	Card chosenCard2;

	int currentLevel = 1;

	void Awake() {
		instance = this;
	}

	void Start () {
		LoadLevel (currentLevel);
	}

	void Update () {
		
	}

	void LoadLevel(int level) {
		level -= 1;
		buah.Clear ();
		cards.Clear ();
		int count = levels [level].jumlahKartu;

		for (int i = 0; i < count / 2; i++) {
			buah.Add (DatabaseBuah.Instance.GetRandomBuah ());
		}
		SpawnCard (count);
	}

	void SpawnCard(int count) {
		gridLayout.constraintCount = count / 2;
		for(int i = 0; i < count; i++) {
			GameObject newCard = Instantiate (card, Vector3.zero, Quaternion.identity) as GameObject;
			newCard.transform.SetParent (cardPanel.transform);
			newCard.transform.localScale = new Vector3 (1, 1, 1);
			Card tmpCard = newCard.GetComponent<Card> ();
			tmpCard.front = buah [i % (count / 2)].sprite;
			cards.Add (tmpCard);
		}

		StartCoroutine (ShowCard (3f));
	}


	IEnumerator ShowCard(float duration) {
		yield return new WaitForSeconds (1f);

		foreach (Card c in cards) {
			c.Open ();
		}

		yield return new WaitForSeconds (duration);

		foreach (Card c in cards) {
			c.Close ();
		}
	}

	public void CardChoose(Card c) {
		if (chosenCard1 == null)
			chosenCard1 = c;
		else if (chosenCard2 == null)
			chosenCard2 = c;

		if(chosenCard1 != null && chosenCard2 != null)
			StartCoroutine(Check ());
	}

	IEnumerator Check() {
		yield return new WaitForSeconds (1f);
		if (chosenCard1 != null && chosenCard2 != null) {
			if (chosenCard1.front == chosenCard2.front) {
				chosenCard1 = null;
				chosenCard2 = null;
			}
			else {
				chosenCard1.Close ();
				chosenCard1 = null;
				chosenCard2.Close ();
				chosenCard2 = null;
			}
		}

		bool winCondition = true;
		foreach (Card c in cards) {
			if (c.GetComponent<Image> ().sprite != c.front) {
				winCondition = false;
			}
		}

		if (winCondition) {
			Debug.Log ("WIN");
			currentLevel++;
			yield return new WaitForSeconds (2f);

			foreach (Transform t in cardPanel.GetComponentsInChildren<Transform>()) {
				if(t != cardPanel.transform)
					Destroy (t.gameObject);
			}
			LoadLevel (currentLevel);
		}
	}

}
