using UnityEngine;
using System.Collections;

public class MoveRight : MonoBehaviour {
	private Vector3 moveDirection = Vector3.zero;
	public float speed=3.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController player = GetComponent<CharacterController>();
		moveDirection.x = speed;
		player.Move(moveDirection * Time.deltaTime);
	}
}
