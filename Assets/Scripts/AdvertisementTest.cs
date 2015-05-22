using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementTest : MonoBehaviour {
	private static int totalDollars;

	void Start() {
		totalDollars = PlayerPrefs.GetInt("Total Dollars");
	}

void Awake() {
	if (Advertisement.isSupported) {
		Advertisement.allowPrecache = true;
		Advertisement.Initialize("131623348"); //UNITYADS GAME ID
	} else {
		Debug.Log("Platform not supported");
	}
}
	
	void OnGUI() {
		if(MenuScreen.options==false) {
			GUI.color = Color.magenta;
			if(Advertisement.isReady()) {
				if(GUI.Button(new Rect(Screen.width*(12.5f/100f), Screen.height*(87.5f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)),"<size=48>Get 10 dollars</size>")) {
					Advertisement.Show(null, new ShowOptions {
						pause = true,
						resultCallback = result => {
							Debug.Log(result.ToString());
							PlayerPrefs.SetInt("Total Dollars", totalDollars + 10);
						}
					});
				}
			} else {
				GUI.backgroundColor = Color.clear;
				GUI.Button(new Rect(Screen.width*(12.5f/100f), Screen.height*(87.5f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Waiting for ads</size>");
			}
		}
	}
}