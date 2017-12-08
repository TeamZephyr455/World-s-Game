using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel1 : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
