using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level2StateController : StateMachineBehaviour {

    PlayerController player;
    InventoryController inventory;
    GameObject levelController;
    VoiceController voice;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (stateInfo.IsName("Start"))
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            inventory = GameObject.Find("Inventory").GetComponent<InventoryController>();
            levelController = GameObject.Find("LevelController");
            voice = GameObject.Find("Voice").GetComponent<VoiceController>();

            GameObject.Find("Intro").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
        else if (stateInfo.IsName("Monolog"))
        {
            //voice.
        }
        else if (stateInfo.IsName("FindExit"))
        {
            GameObject.Find("FindExit").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
        else if (stateInfo.IsName("FindKeycard"))
        {
            voice.Play("door_closed_00");
            GameObject.Find("FindKeycard").GetComponent<Animator>().SetTrigger("PlayAnimation");
            levelController.GetComponent<ObjectSpawner>().Spawn();
        }
        else if (stateInfo.IsName("GoToTerminal"))
        {
            voice.Play("keycard_00");
            GameObject.Find("GoToTerminal").GetComponent<Animator>().SetTrigger("PlayAnimation");
            inventory.keycardFound();
        }
        else if (stateInfo.IsName("GoToExit"))
        {
            voice.Play("door_open_00");
            GameObject.Find("Escape").GetComponent<Animator>().SetTrigger("PlayAnimation");
            GameObject.Find("Exit").GetComponentInChildren<DoorController>().Open();
        }
        else if (stateInfo.IsName("Escaped"))
        {
            GameObject.Find("Outro").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
        else if (stateInfo.IsName("LevelChange"))
        {
            Application.LoadLevel("Fadeout");
        }
    }

}
