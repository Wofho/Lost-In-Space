using UnityEngine;
using System.Collections;

public class MenuScreen : MonoBehaviour {
	public Texture logo;
	public static bool options = false;
	private static float hSliderValue;
	
	void Start () {
		if(PlayerPrefs.GetString("Character")=="") {
			PlayerPrefs.SetString("Character", "alien");
		}
		hSliderValue = PlayerPrefs.GetFloat("Volume");
	}
	
	void Update () {
		AudioListener.volume = hSliderValue;
		if (Input.GetKeyDown(KeyCode.Escape) && options == true) {
				options = false;			 
		} else {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				Application.Quit();
			}
		}
	}

	void OnGUI () {
		GUI.DrawTexture(new Rect(Screen.width*(50f/100f)-320, Screen.height*(-5f/100f), 640, 480), logo);
		GUI.color = Color.magenta;
		if(!options) {
			if(GUI.Button(new Rect(Screen.width*(12.5f/100f), Screen.height*(25f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Singleplayer</size>")) {
				Application.LoadLevel(Random.Range(1, 3));
			}
			if(GUI.Button(new Rect(Screen.width*(12.5f/100f), Screen.height*(37.5f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Multiplayer</size>")) {
				Application.LoadLevel(5);
			}
			if(GUI.Button(new Rect(Screen.width*(12.5f/100f), Screen.height*(50f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Characters</size>")) {
				Application.LoadLevel(4);
			}
			if(GUI.Button(new Rect(Screen.width*(12.5f/100f), Screen.height*(62.5f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Options</size>")) {
				options = true;
			}
			if(GUI.Button(new Rect(Screen.width*(12.5f/100f), Screen.height*(75f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Quit</size>")) {
				Application.Quit();
			}
		} else {
			hSliderValue = GUI.HorizontalSlider(new Rect(Screen.width*(12.5f/100f), Screen.height*(55f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), hSliderValue, 0.0f, 1.0f);
			PlayerPrefs.SetFloat("Volume", hSliderValue);
			GUIStyle centeredStyle = new GUIStyle(GUI.skin.label);
			centeredStyle.alignment = TextAnchor.MiddleCenter;
			GUI.Label(new Rect (0, 0, Screen.width, Screen.height),"<size=48>Volume</size>", centeredStyle);
			if(GUI.Button(new Rect(Screen.width*(12.5f/100f), Screen.height*(62.5f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Restore unlocks</size>")) {
				PlayerPrefs.SetString("Character", "alien");
				if(PlayerPrefs.GetString("businessunlocked") == "true") {
					PlayerPrefs.SetString("businessunlocked", "");
				}
				if(PlayerPrefs.GetString("womanunlocked") == "true") {
					PlayerPrefs.SetString("womanunlocked", "");
				}			}
			if(GUI.Button(new Rect(Screen.width*(12.5f/100f), Screen.height*(75f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Back</size>")) {
				options = false;
			}
		}
	}
}