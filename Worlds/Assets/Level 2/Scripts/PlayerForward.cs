using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForward : MonoBehaviour {

	public float maxSpeed = 8f;
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.x += maxSpeed * Time.deltaTime;
		transform.position = pos;
	}
}
