using UnityEngine;
using System.Collections;

public class GUI_Button : MonoBehaviour {

	private Vector3 moveDirection = Vector3.zero;
	public float speed=3.0f;
	public GameObject player;
	private bool hasdied = false;
	public AudioClip WilhelmScream;


	void Update () {
		player.transform.position += transform.forward * 0;
		if (player.transform.position.y < 1.05f) {
			if(!hasdied) {
				audio.PlayOneShot(WilhelmScream);
				hasdied=true;
				if(Application.loadedLevel == 5) {
					PhotonNetwork.Disconnect();
				}
			}
		}
		if (player.transform.position.y < -2.0f) {
			Application.LoadLevel(3);
		}
	}


	void OnGUI() {
		GUI.backgroundColor = Color.clear;
		if (GUI.RepeatButton (new Rect (0, 0, Screen.width*(.5f), Screen.height), "")) {
			moveDirection.x = speed;
			player.transform.position -= (moveDirection * Time.deltaTime);
		}
		if (GUI.RepeatButton (new Rect (Screen.width - Screen.width*(.5f), Screen.height*(5.625f/100f), Screen.width*(.5f), Screen.height), "")) {
			moveDirection.x = speed;
			player.transform.position += (moveDirection * Time.deltaTime);
		}
	}
}
