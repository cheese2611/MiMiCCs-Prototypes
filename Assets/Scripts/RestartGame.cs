using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {
	
	void Update () {
        if (Input.GetKey(KeyCode.L))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel(0);
        }
        if (Input.GetKey(KeyCode.F1))
        {
            Application.LoadLevel(0);
        }
        if (Input.GetKey(KeyCode.F2))
        {
            Application.LoadLevel(1);
        }
        if (Input.GetKey(KeyCode.F3))
        {
            Application.LoadLevel(2);
        }
        if (Input.GetButton("Interaction"))
        {
            GameObject.Find("LevelController").GetComponent<Animator>().SetTrigger("KeyPressed");
        }
    }
}
