using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float maxSpeed;
	public float shipRadius;

	void Update () {

		Vector3 pos = transform.position;
		pos.x += Input.GetAxis ("Horizontal") * maxSpeed * Time.deltaTime;
		pos.y += Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime;
		transform.position = pos;

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
