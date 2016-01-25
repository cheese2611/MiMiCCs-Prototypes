using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level1StateController : StateMachineBehaviour {

    PlayerController player;
    InventoryController inventory;
    GameObject levelController;
    VoiceController voice;
    EyeController eyes;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (stateInfo.IsName("Start"))
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            inventory = GameObject.Find("Inventory").GetComponent<InventoryController>();
            levelController = GameObject.Find("LevelController");
            voice = GameObject.Find("Voice").GetComponent<VoiceController>();
            eyes = GameObject.Find("Eyes").GetComponent<EyeController>();

            eyes.visible = false;
        }
        else if (stateInfo.IsName("Intro"))
        {
            OVRManager.DismissHSWDisplay();
            GameObject.Find("Intro").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
        else if (stateInfo.IsName("WaitForEyes"))
        {
            eyes.visible = true;
        }
        else if (stateInfo.IsName("OpenEyes"))
        {
            GameObject.Find("Eyes").GetComponent<Animator>().SetBool("IsOpen", true);
            GameObject.Find("CenterEyeAnchor").GetComponent<BlurController>().TurnOff();
            GameObject.Find("ElectricLine5").GetComponent<AudioSource>().Play();
        }
        else if (stateInfo.IsName("ItsDark"))
        {
            //voice.Play("dark_03");
        }
        else if (stateInfo.IsName("CellJitter"))
        {
            GameObject.Find("ElectricCellWall").GetComponent<ElectricCellWallAnimator>().SparkEnabled(false); ;
        }
        else if (stateInfo.IsName("CellOff"))
        {
            voice.Play("intro_06");
        }
        else if (stateInfo.IsName("FindExit"))
        {
            voice.Play("intro_07");
            GameObject.Find("FindExit").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
        else if (stateInfo.IsName("Escaped"))
        {
            GameObject.Find("Outro").GetComponent<Animator>().SetTrigger("PlayAnimation");
        }
        else if (stateInfo.IsName("LevelChange"))
        {
            Application.LoadLevel("Demo");
        }
    }

}
