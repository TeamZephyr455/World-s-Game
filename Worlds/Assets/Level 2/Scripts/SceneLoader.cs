using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public GameObject monsterPrefab;
	public GameObject playerPrefab;
	float invulTime = 3;
	void Update () {
		if (monsterPrefab == null) {
			invulTime -= Time.deltaTime;
			if (invulTime <= 0)
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		}
		if (playerPrefab == null) {
			invulTime -= Time.deltaTime;
			if (invulTime <= 0)
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}
}
