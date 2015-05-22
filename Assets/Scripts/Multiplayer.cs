using UnityEngine;
using System.Collections;

public class Multiplayer : Photon.MonoBehaviour {
	private static bool winner;
	private static string status;

	void Start () {
		winner = false;
		Time.timeScale = 0;
		PhotonNetwork.automaticallySyncScene = true;
		PhotonNetwork.ConnectUsingSettings ("v4.2");
	}


	void OnGUI() {
		status = PhotonNetwork.connectionStateDetailed.ToString();
		if(Time.timeScale == 0 && status != "Joined") {
			GUIStyle rightStyle = new GUIStyle(GUI.skin.label);
			rightStyle.alignment = TextAnchor.UpperRight;
			GUI.Label(new Rect (0, 0, Screen.width, Screen.height),"<size=20>Connecting</size>", rightStyle);
		}
		if(Time.timeScale == 0 && status == "Joined") {
			GUIStyle rightStyle = new GUIStyle(GUI.skin.label);
			rightStyle.alignment = TextAnchor.UpperRight;
			GUI.Label(new Rect (0, 0, Screen.width, Screen.height),"<size=20>Waiting for a player to join</size>", rightStyle);
		}

		if (winner) {
			GUIStyle centeredStyle = new GUIStyle(GUI.skin.label);
			centeredStyle.alignment = TextAnchor.MiddleCenter;
			GUI.color = Color.yellow;
			GUI.Label(new Rect (0, 0, Screen.width, Screen.height),"<size=118>WINNER</size>", centeredStyle);
		}
	}

	void OnJoinedLobby() {
		RoomOptions roomOptions = new RoomOptions() { isVisible = true, maxPlayers = 2 };
		PhotonNetwork.JoinOrCreateRoom("LostInSpace", roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom() {
		if(PhotonNetwork.countOfPlayers==2) {
			Time.timeScale = 1;
		}
	}

	void OnPhotonPlayerConnected(PhotonPlayer other){
		Time.timeScale = 1;
	}

	void OnPhotonPlayerDisconnected(PhotonPlayer other){
		PhotonNetwork.Disconnect();
		winner = true;
		StartCoroutine(WinTimer());
		Time.timeScale = 0.01f;
	}

	IEnumerator WinTimer() {
		yield return new WaitForSeconds(.05f);
		Time.timeScale=1f;
		Application.LoadLevel(3);
		winner = false;
	}
}