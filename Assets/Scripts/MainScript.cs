using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainScript : MonoBehaviour {
	private static int speed;
	public static int coins;
	public static int dollars;
	private static bool isPaused;
	public GameObject businessman;
	public GameObject alien;
	public GameObject woman;
	public AudioClip coinSound;
	public AudioClip dollarSound;
	private GameObject instObj;
	public List<GameObject> prefabList = new List<GameObject>();
	private LinkedList<GameObject> roads = new LinkedList<GameObject>();

	void Start() {
		speed = 12;
		if(GameOver.continuedRun == false) {
			coins = 0;
		}
		dollars = 0;
		PlayerPrefs.SetInt("Level Index", Application.loadedLevel);
		isPaused = false;
		if(PlayerPrefs.GetString("Character") == "alien") {
			alien.SetActive(true);
			woman.SetActive(false);
			businessman.SetActive(false);
		}
		if(PlayerPrefs.GetString("Character") == "woman") {
			woman.SetActive(true);
			alien.SetActive(false);
			businessman.SetActive(false);
		}
		if(PlayerPrefs.GetString("Character") == "businessman") {
			businessman.SetActive(true);
			alien.SetActive(false);
			woman.SetActive(false);
		}
		instObj = (GameObject) Instantiate(prefabList[UnityEngine.Random.Range(0,prefabList.Count)], new Vector3(1.492092f, 11.034f, 43f),Quaternion.identity);
		roads.AddLast(instObj);
		instObj = (GameObject) Instantiate(prefabList[UnityEngine.Random.Range(0,prefabList.Count)], new Vector3(1.492092f, 11.034f, 243f),Quaternion.identity);
		roads.AddLast(instObj);
		InvokeRepeating ("IncreaseSpeed", 30, 60);
	}
	
	void Update() {	
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel(0);
			Time.timeScale=1;
			if(Application.loadedLevel==5) {
				PhotonNetwork.Disconnect();
			}
		}		
		GameObject firstRoad = roads.First.Value;
		if (firstRoad.transform.position.z < -156.8f) {
				instObj = (GameObject)Instantiate (prefabList[UnityEngine.Random.Range(0,prefabList.Count)], new Vector3 (1.492092f, 11.034f, 243f), Quaternion.identity);
				roads.AddLast(instObj);
				roads.Remove (firstRoad);
				Destroy (firstRoad);
		}
		foreach (GameObject road in roads) {
				road.transform.Translate (0, 0, -Time.deltaTime * speed);
		}	
	}

	void OnTriggerEnter(Collider other) {		
		if(other.name == "Capsule") {
			speed += 5;
			Destroy(other.gameObject);
			StartCoroutine(CapsuleBooster());
		}
		
		if(other.name == "Lava"){
			Application.LoadLevel(3);
			if(PlayerPrefs.GetInt("Level Index") == 5) {
				PhotonNetwork.Disconnect();
			}
		}
		
		if(other.name == "Coin") {
			Destroy(other.gameObject);
			audio.PlayOneShot(coinSound);
			if(PlayerPrefs.GetString("Character") == "businessman") {
				coins += 10;
			} else {
				coins += 5;
			}
		}
		
		if(other.name == "Dollar") {
			Destroy(other.gameObject);
			audio.PlayOneShot(dollarSound);
			if(PlayerPrefs.GetString("Character") == "businessman") {
				dollars += 2;
			} else {
				dollars += 1;
			}
		}
		
		if(other.name == "Clock") {
			Time.timeScale = 0.5f;
			Destroy(other.gameObject);
			StartCoroutine(ClockBooster());

		}
	}
	
	void OnGUI() {
		GUILayout.Label("<size=20>Coins: " + coins + "</size>");
		if(Application.loadedLevel==1 || Application.loadedLevel==2) {
			GUI.backgroundColor = Color.black;
			if(isPaused == false) {
				if(GUI.Button(new Rect(Screen.width*(90f/100f), 0, Screen.width*(10f/100f), Screen.height*(5.625f/100f)), "<size=150>║</size>")) {
						isPaused = true;
						Time.timeScale = 0;
				}
			} else {
				if(GUI.Button(new Rect(Screen.width*(90f/100f), 0, Screen.width*(10f/100f), Screen.height*(5.625f/100f)), "<size=50>►</size>")) {
					isPaused = false;
					Time.timeScale = 1;
				}
			}
		}
	}

	void IncreaseSpeed() {
		speed += 1;
	}
	
	IEnumerator CapsuleBooster() {
		yield return new WaitForSeconds(2.5f);
		speed -= 5;
	}

	IEnumerator ClockBooster() {
		yield return new WaitForSeconds(2.5f);
		Time.timeScale = 1f;
	}


}