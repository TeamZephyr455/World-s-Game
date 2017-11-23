using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
	[SerializeField]
	private Stat healthStat;

	private void Awake() {
		healthStat.Initialize();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
			healthStat.CurrentVal -= 10;
		}

		if (Input.GetKeyDown(KeyCode.W)) {
			healthStat.CurrentVal += 10;
		}
	}
}
