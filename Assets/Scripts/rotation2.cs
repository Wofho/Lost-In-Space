using UnityEngine;
using System.Collections;

public class rotation2 : MonoBehaviour {
	void Update () {
		transform.Rotate (new Vector3 (0, 90, 0) * Time.deltaTime);
	}
}
