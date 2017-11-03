using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeleporter_Lv3 : MonoBehaviour {

    [SerializeField]
    private Transform destination;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Transform>().position = destination.position;
        }
    }
}
