using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesPlayer : MonoBehaviour {

	Transform player;
	public float rotSpeed = 90f;
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			// find the player's ship
			GameObject go = GameObject.Find("Player");

			if (go != null) {
				player = go.transform;
			}
		}

		// at this point we have found the player or doesnt exist.

		if (player == null) {
			return;
		}

		// HERE we know we have a player. Turn to face it

		Vector3 dir = player.position - transform.position;
		dir.Normalize ();

		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;

		Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);

	}
}
