using UnityEngine;
using System.Collections;

public class SendTriggerToLevelController : MonoBehaviour {

    public string trigger;

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            GameObject.Find("LevelController").GetComponent<Animator>().SetTrigger(trigger);
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            GameObject.Find("LevelController").GetComponent<Animator>().ResetTrigger(trigger);
        }
    }
}
