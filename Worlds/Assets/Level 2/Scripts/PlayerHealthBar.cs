using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {
	public Stat healthStat;
	public int numLives = 3;
	public Text countText;
	public Text gameText;
	Vector3 pos = new  Vector3(-18,0,0);

	void Start() {
		Handler();
	}

	private void Awake() {
		healthStat.Initialize();
	}

	void OnTriggerEnter2D() {
		healthStat.CurrentVal -=10;
	}

	void Update () {
		if (healthStat.CurrentVal <= 0) {
			Die ();
			Handler();
		}
	}

	void Handler() {
		countText.text = "x " + numLives.ToString();
	}
		
	void Die() {
		numLives--;
		if (numLives > 0) {
			transform.position = pos;
			healthStat.CurrentVal = healthStat.MaxVal;
		} else {
			healthStat.CurrentVal = 0;
			gameText.text = "Game Over";
			Destroy(gameObject);
		}
	}
}

