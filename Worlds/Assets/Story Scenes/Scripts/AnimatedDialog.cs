using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class AnimatedDialog : MonoBehaviour {

	public float letterPaused = 0.01f;
	public string message;
	public Text textComp;

	void Start () {
		textComp = GetComponent<Text> ();
		message = textComp.text;
		textComp.text = "";
		StartCoroutine (TypeText ());
	}

	IEnumerator TypeText() {
		foreach (char letter in message.ToCharArray()) {
			textComp.text += letter;
			yield return 0;
			yield return new WaitForSeconds(letterPaused);
		}
	}
}
