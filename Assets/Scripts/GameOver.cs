using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	private static int totalCoins;
	private static int totalDollars;
	private static int numberOfTries=1;
	private static bool highScore;
	public static bool continuedRun;
	public Texture logo;

	void Start () {
		highScore = false;
		continuedRun = false;
		Time.timeScale = 1f;
		PlayerPrefs.SetInt("Total Coins", PlayerPrefs.GetInt("Total Coins") + MainScript.coins);
		PlayerPrefs.SetInt("Total Dollars", PlayerPrefs.GetInt("Total Dollars") + MainScript.dollars);
		
		if(MainScript.coins>PlayerPrefs.GetInt("Best Score")) {
			PlayerPrefs.SetInt("Best Score", MainScript.coins);
			highScore = true;
		}

		PlayerPrefs.Save();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel(0);
		}
	}

	void OnGUI () {
		if (highScore) {
			GUI.color = Color.green;
			GUIStyle style = GUI.skin.GetStyle ("label");
			style.fontSize = (int)(34.0f + 20.0f * Mathf.Sin (Time.time));
			GUI.Label(new Rect (Screen.width*(12.5f/100f), Screen.height*(5f/100f), Screen.width*(75f/100f), Screen.height), "NEW RECORD!");
		} else {
			GUI.DrawTexture(new Rect(Screen.width*(50f/100f)-320, Screen.height*(-5f/100f), 640, 480), logo);
		}
		GUI.color = Color.white;
		GUI.Label(new Rect (Screen.width*(12.5f/100f), Screen.height*(25f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>This run: " + MainScript.coins + "</size>");
		GUI.Label(new Rect (Screen.width*(12.5f/100f), Screen.height*(30f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Best run: " + PlayerPrefs.GetInt("Best Score") + "</size>");
		GUI.Label(new Rect (Screen.width*(12.5f/100f), Screen.height*(35f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Total: " + PlayerPrefs.GetInt("Total Coins") + "</size>");
		GUI.Label(new Rect (Screen.width*(12.5f/100f), Screen.height*(40f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Dollars: " + PlayerPrefs.GetInt("Total Dollars") + "</size>");

		GUI.color = Color.magenta;

		if(GUI.Button(new Rect(Screen.width*(12.5f/100f), Screen.height*(50f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Retry</size>")) {
			Application.LoadLevel(PlayerPrefs.GetInt("Level Index"));
			numberOfTries = 1;
		}
		if(GUI.Button(new Rect(Screen.width*(12.5f/100f), Screen.height*(62.5f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Share score</size>")) {
			Application.OpenURL("http://www.facebook.com/dialog/feed?app_id=900841676606193&display=popup&redirect_uri=http://www.facebook.com&picture=http://i.imgur.com/A6x1VnB.png&caption=Lost In Space&name=Can you beat me?&description=My score is: " + MainScript.coins);
		}
		if(GUI.Button(new Rect(Screen.width*(12.5f/100f), Screen.height*(75f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Main menu</size>")) {
			Application.LoadLevel(0);
			numberOfTries = 1;
		}
		if(PlayerPrefs.GetInt("Level Index") == 1 || PlayerPrefs.GetInt("Level Index") == 2) {
			if(PlayerPrefs.GetInt("Total Dollars")>=numberOfTries*5) {
				if(GUI.Button(new Rect(Screen.width*(12.5f/100f), Screen.height*(87.5f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Continue: " + numberOfTries*5 + " dollars</size>")) {
					Application.LoadLevel(PlayerPrefs.GetInt("Level Index"));
					continuedRun = true;
					PlayerPrefs.SetInt("Total Dollars", PlayerPrefs.GetInt("Total Dollars") - numberOfTries*5);
					numberOfTries++;
				}
			} else {
				GUI.backgroundColor = Color.clear;
				GUI.Button(new Rect(Screen.width*(12.5f/100f), Screen.height*(87.5f/100f), Screen.width*(75f/100f), Screen.height*(10f/100f)), "<size=48>Insufficient dollars</size>");
			}
		}
	}
}