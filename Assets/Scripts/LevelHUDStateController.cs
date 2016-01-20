using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelHUDStateController : StateMachineBehaviour {

    PlayerController player;
    InventoryController inventory;
    GameObject levelController;
    HeadsetController headset;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (stateInfo.IsName("Start"))
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            inventory = GameObject.Find("Inventory").GetComponent<InventoryController>();
            levelController = GameObject.Find("LevelController");
            headset = GameObject.Find("Headset").GetComponent<HeadsetController>();

            player.movementSpeed = 1.5f;
            player.rotationSpeed = 0.5f;
        }
        else if (stateInfo.IsName("Intro"))
        {
            GameObject.Find("Intro").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
        else if (stateInfo.IsName("OpenEyes"))
        {
            GameObject.Find("Eyes").GetComponent<Animator>().SetBool("IsOpen", true);
            GameObject.Find("CenterEyeAnchor").GetComponent<BlurController>().TurnOff();
        }
        else if (stateInfo.IsName("ItsDark"))
        {
            headset.PlayRandomWhichStartsWith("dark");
        }
        else if (stateInfo.IsName("CellJitter"))
        {
            GameObject cell = GameObject.Find("ElectricLine");
            cell.GetComponent<ElectricLineAnimator>().SparkEnabled(false);
            player.movementSpeed = 5.0f;
            player.rotationSpeed = 1.5f;
        }
        else if (stateInfo.IsName("FindExit"))
        {
            GameObject.Find("FindExit").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
        else if (stateInfo.IsName("FindKeycard"))
        {
            GameObject.Find("FindKeycard").GetComponent<Animator>().SetTrigger("PlayAnimation");
            levelController.GetComponent<ObjectSpawner>().Spawn();
        }
        else if (stateInfo.IsName("GoToTerminal"))
        {
            GameObject.Find("GoToTerminal").GetComponent<Animator>().SetTrigger("PlayAnimation");
            inventory.keycardFound();
        }
        else if (stateInfo.IsName("Escape"))
        {
            GameObject.Find("Escape").GetComponent<Animator>().SetTrigger("PlayAnimation");
            GameObject.Find("Exit").GetComponentInChildren<DoorController>().Open();
        }
        else if (stateInfo.IsName("GameOver"))
        {
            GameObject.Find("GameOver").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMachineEnter is called when entering a statemachine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
    //
    //}

    // OnStateMachineExit is called when exiting a statemachine via its Exit Node
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
        Application.LoadLevel(Application.loadedLevel);
    }
}
