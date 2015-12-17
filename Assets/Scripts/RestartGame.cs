using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {
	
	void Update () {
    	if (Input.GetButton("RestartGame"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	}
}
