using UnityEngine;
using System.Collections;

public class Terminal : MonoBehaviour {

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            GameObject.Find("LevelController").GetComponent<Animator>().SetTrigger("IsAtTerminal");
        }
    }

}
