using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesBar : MonoBehaviour {

	[SerializeField]
	private Text valueText;

	public float Value {
		set {

			valueText.text = "x ";
		}
	}

	void Start () {
		
	}

	void Update () {
		// HandleBar();
	}

	// private void HandleBar() {

	// 	if (fillAmount != content.fillAmount) {
	// 		content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
	// 	}
	// }

	// private float Map(float value, float inMin, float inMax, float outMin, float outMax) {

	// 	return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	// }
}
