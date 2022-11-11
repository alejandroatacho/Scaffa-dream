using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour {

	// Use this for initialization
	void OnGUI ()
    {
	    if (GUI.Button(new Rect(Screen.width/2.5f ,Screen.height/3,Screen.width/5,Screen.height/10), "Start Game"))
        {
            Application.LoadLevel(1);
        }

        if (GUI.Button(new Rect(Screen.width / 2.5f ,Screen.height / 2, Screen.width / 5, Screen.height/10), "Quit Game"))
        {
            Application.Quit();
        }
    }
}
