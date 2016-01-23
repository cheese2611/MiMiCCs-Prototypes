using UnityEngine;
using System.Collections;

public class Level3DialogStateController : StateMachineBehaviour {

    InventoryController inventory;
    VoiceController voice;
    HeadsetController headset;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (stateInfo.IsName("Start"))
        {
            inventory = GameObject.Find("Inventory").GetComponent<InventoryController>();
            voice = GameObject.Find("Voice").GetComponent<VoiceController>();
            headset = GameObject.Find("Headset").GetComponent<HeadsetController>();
        }
        else if (stateInfo.IsName("Wait"))
        {
        }
        else
        {
            for (int i = 0; i < 7; ++i)
            {
                string sarah = "sarah_0" + i.ToString();
                string john = "john_0" + i.ToString();
                if (stateInfo.IsName(sarah))
                {
                    headset.Play(sarah);
                }
                else if (stateInfo.IsName(john))
                {
                    voice.Play(john);
                }
            }
        }
    }

}
