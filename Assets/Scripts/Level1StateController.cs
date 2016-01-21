using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level1StateController : StateMachineBehaviour {

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

            player.movementSpeed = 0.0f;
            player.rotationSpeed = 0.0f;
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
        else if (stateInfo.IsName("Monolog"))
        {
            //voice.

            player.movementSpeed = 0.5f;
            player.rotationSpeed = 0.5f;
        }
        else if (stateInfo.IsName("ItsDark"))
        {
            voice.PlayRandomWhichStartsWith("dark");
        }
        else if (stateInfo.IsName("CellJitter"))
        {
            GameObject.Find("ElectricCellWall").GetComponent<ElectricCellWallAnimator>().SparkEnabled(false); ;
            player.movementSpeed = 5.0f;
            player.rotationSpeed = 1.5f;
        }
        else if (stateInfo.IsName("FindExit"))
        {
            GameObject.Find("FindExit").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
        else if (stateInfo.IsName("Escaped"))
        {
            Application.LoadLevel("Demo");
        }
    }

}
