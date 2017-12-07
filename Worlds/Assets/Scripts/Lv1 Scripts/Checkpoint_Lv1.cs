using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_Lv1 : MonoBehaviour {

    private bool hasPlayerPassed;
    private Transform checkpoint;

	// Use this for initialization
	void Start () {
        checkpoint = gameObject.GetComponent<Transform>();
        hasPlayerPassed = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            if (!hasPlayerPassed)
            {
                collision.gameObject.GetComponent<Player_Lv1>().NewCheckpoint(checkpoint);
            }
        }
    }
}
