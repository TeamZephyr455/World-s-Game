﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {
	[SerializeField]
	private float fillAmount;
	public float lerpSpeed;
	public Image content;
	public Text valueText;
	public float MaxValue { get; set; }

	public float Value {
		set {
			string[] tmp = valueText.text.Split (':');
			valueText.text = tmp [0] + ": " + value;
			fillAmount = Map(value, 0, MaxValue, 0, 1);
		}
	}

	void Update () {
		HandleBar();
	}

	private void HandleBar() {
		if (fillAmount != content.fillAmount)
			content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);	
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax) {
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
