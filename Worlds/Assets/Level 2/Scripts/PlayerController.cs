using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float maxSpeed;
	public float rotSpeed;
	public float shipRadius;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// transform.Translate( new Vector3(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime,0));
		///*
		Vector3 pos = transform.position;
		pos.x += Input.GetAxis ("Horizontal") * maxSpeed * Time.deltaTime;
		pos.y += Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime;
		transform.position = pos;
		//*/

		/*
		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z;
		z += Input.GetAxis ("Vertical") * rotSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0, 0, z);
		transform.rotation = rot;


		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3(0, Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime,0);
		pos -= rot * velocity;
		*/

		if (pos.y+shipRadius > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - shipRadius;
		}
		if (pos.y-shipRadius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize  + shipRadius;
		}

		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = (Camera.main.orthographicSize * screenRatio) - .5f;

		if (pos.x - shipRadius < -widthOrtho) {
			pos.x = -widthOrtho + shipRadius;
		}
		if (pos.x + shipRadius > widthOrtho) {
			pos.x = widthOrtho  - shipRadius;
		}

		transform.position = pos;
	
	}
}
