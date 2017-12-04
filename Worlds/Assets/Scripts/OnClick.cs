using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This Script attaches to buttons and gives them common functions
public class OnClick : MonoBehaviour {


    public void LoadNewScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Debug.Log("has quit game");
        Application.Quit();
    }
}
