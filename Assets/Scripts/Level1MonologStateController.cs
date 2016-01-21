using UnityEngine;
using System.Collections;

public class Level1MonologStateController : StateMachineBehaviour {

    VoiceController voice;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	    if (stateInfo.IsName("Start"))
        {
            voice = GameObject.Find("Voice").GetComponent<VoiceController>();
        }
        else if (stateInfo.IsName("Wait"))
        {

        }
        else
        {
            for (int i = 0; i < 6; ++i)
            {
                string intro = "intro_0" + i.ToString();
                if (stateInfo.IsName(intro))
                {
                    voice.Play(intro);
                }
            }
        }
	}

}
