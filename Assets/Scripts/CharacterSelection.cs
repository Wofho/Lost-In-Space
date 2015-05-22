using UnityEngine;
using System.Collections;

public class CharacterSelection : MonoBehaviour {
	private static int totalCoins;
	public AudioClip dollarSound;
	
	void Update() {
		totalCoins = PlayerPrefs.GetInt("Total Coins");
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel(0);
		}
	}

	void OnGUI() {
		GUILayout.Label("<size=32>Coins: " + totalCoins + "</size>");
		GUI.color = Color.magenta;
		if(PlayerPrefs.GetString("Character") != "alien") {
			if(GUI.Button(new Rect(Screen.width*(5f/100f), Screen.height*(70f/100f), Screen.width*(25f/100f), Screen.height*(7.5f/100f)), "<size=28>Select</size>")){
				PlayerPrefs.SetString("Character", "alien");
			}
		} else {
			if(GUI.Button(new Rect(Screen.width*(5f/100f), Screen.height*(70f/100f), Screen.width*(25f/100f), Screen.height*(7.5f/100f)), "<size=28>Selected</size>")){
				Application.LoadLevel(0);
			}
		}

		if(PlayerPrefs.GetString("womanunlocked") != "true") {
			if(GUI.Button(new Rect(Screen.width*(37.5f/100f), Screen.height*(70f/100f), Screen.width*(25f/100f), Screen.height*(7.5f/100f)), "<size=28>200 coins</size>")){
				if(totalCoins>=200) {
					PlayerPrefs.SetString("womanunlocked", "true");
					PlayerPrefs.SetInt("Total Coins", totalCoins-200);
					audio.PlayOneShot(dollarSound);
				}
			}
		} else {
			if(PlayerPrefs.GetString("Character") != "woman") {
				if(GUI.Button(new Rect(Screen.width*(37.5f/100f), Screen.height*(70f/100f), Screen.width*(25f/100f), Screen.height*(7.5f/100f)), "<size=28>Select</size>")){
					PlayerPrefs.SetString("Character", "woman");
				}
			} else {
				if(GUI.Button(new Rect(Screen.width*(37.5f/100f), Screen.height*(70f/100f), Screen.width*(25f/100f), Screen.height*(7.5f/100f)), "<size=28>Selected</size>")){
					Application.LoadLevel(0);
				}
			}
		}

		GUI.Box(new Rect(Screen.width*(66.67f/100f), Screen.height*(25f/100f), Screen.width*(33.33f/100f), Screen.height*(4.5f/100f)), "<size=28>Double coins</size>");
		if(PlayerPrefs.GetString("businessunlocked") != "true") {
			if(GUI.Button(new Rect(Screen.width*(70f/100f), Screen.height*(70f/100f), Screen.width*(25f/100f), Screen.height*(7.5f/100f)), "<size=28>999 coins</size>")){
				if(totalCoins>=999) {	
					PlayerPrefs.SetString("businessunlocked", "true");
					PlayerPrefs.SetInt("Total Coins", totalCoins-999);
					audio.PlayOneShot(dollarSound);
				}
			}
		} else {
			if(PlayerPrefs.GetString("Character") != "businessman") {
				if(GUI.Button(new Rect(Screen.width*(70f/100f), Screen.height*(70f/100f), Screen.width*(25f/100f), Screen.height*(7.5f/100f)), "<size=28>Select</size>")){
					PlayerPrefs.SetString("Character", "businessman");
				}
			} else {
				if(GUI.Button(new Rect(Screen.width*(70f/100f), Screen.height*(70f/100f), Screen.width*(25f/100f), Screen.height*(7.5f/100f)), "<size=28>Selected</size>")){
					Application.LoadLevel(0);
				}
			}
		}

		if(GUI.Button(new Rect(Screen.width*(70f/100f), Screen.height*(95f/100f), Screen.width*(30f/100f), Screen.height*(5f/100f)), "<size=20>Main Menu</size>")){
			Application.LoadLevel(0);
		}
	}
}