using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3 (0, 0, 0); 
	public GameObject bulletPrefab;
	public float fireDelay = 0.25f;
	float cooldownTimer = 0;

	// Update is called once per frame
	void Update () {

		cooldownTimer -= Time.deltaTime;

		if (Input.GetButton ("Fire2") && cooldownTimer <=0) {
			Debug.Log ("Pew");
			cooldownTimer = fireDelay;
			Vector3 offset = transform.rotation * bulletOffset;
			Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
		}

	}
}
