using UnityEngine;
using System.Collections;

public class Level1Controller : StateMachineBehaviour {

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (stateInfo.IsName("FindExit"))
        {
            GameObject.Find("FindExit").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
        else if (stateInfo.IsName("FindKeycard"))
        {
            GameObject.Find("FindKeycard").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
        else if (stateInfo.IsName("GoToTerminal"))
        {
            GameObject.Find("GoToTerminal").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
        else if (stateInfo.IsName("Escape"))
        {
            GameObject.Find("Escape").GetComponent<Animator>().SetTrigger("PlayAnimation");
            GameObject.Find("Exit").GetComponentInChildren<Door>().Open();
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
