using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{

    [SerializeField]
    private Earth_Enemy enemy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hero")
        {
            enemy.Target = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Hero")
        {
            enemy.Target = null;
        }
    }

}