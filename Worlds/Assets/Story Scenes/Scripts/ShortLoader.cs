using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShortLoader : MonoBehaviour {

	float invulTime = 20;

	void Update () {
		invulTime -= Time.deltaTime;
		if (invulTime <= 0)
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}

