using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level3StateController : StateMachineBehaviour {

    PlayerController player;
    InventoryController inventory;
    GameObject levelController;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (stateInfo.IsName("Start"))
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            inventory = GameObject.Find("Inventory").GetComponent<InventoryController>();
            levelController = GameObject.Find("LevelController");
        }
        else if (stateInfo.IsName("Intro"))
        {
            GameObject.Find("Intro").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
        else if (stateInfo.IsName("Dialog"))
        {
        }
        else if (stateInfo.IsName("GoToExit"))
        {
            GameObject.Find("Escape").GetComponent<Animator>().SetTrigger("PlayAnimation");
            GameObject.Find("Exit").GetComponentInChildren<DoorController>().Open();
        }
        else if (stateInfo.IsName("Escaped"))
        {
            GameObject.Find("Outro").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
    }

}
