using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuLoader : MonoBehaviour {

	float invulTime = 40;

	void Update () {
		invulTime -= Time.deltaTime;
		if (invulTime <= 0)
			SceneManager.LoadScene (0);
	}
}
