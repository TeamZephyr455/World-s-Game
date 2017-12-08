using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour {

	float invulTime = 30;

	void Update () {
		invulTime -= Time.deltaTime;
		if (invulTime <= 0)
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
