using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {

	void Update () {
		transform.Rotate (new Vector3 (180, 0, 0) * Time.deltaTime);
	}
}
