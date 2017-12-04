using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour {

	[SerializeField]
	private Stat healthStat;
	public float invulPeriod = 0;
	float invulnTimer = 0;
	int correctLayer;

	private void Awake() {
		healthStat.Initialize();
	}

	void OnTriggerEnter2D() {
		Debug.Log ("Trigger");
		healthStat.CurrentVal -=10;
		invulnTimer = invulPeriod;
		gameObject.layer = 10;
	}

	void Update () {
		invulnTimer -= Time.deltaTime;
		if (invulnTimer <=0)
			gameObject.layer = correctLayer;

		if (healthStat.CurrentVal <= 0)
			Die ();
	}

	void Die() {
		Destroy(gameObject);
	}
}

