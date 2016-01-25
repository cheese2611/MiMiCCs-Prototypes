using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTrailerStateController : StateMachineBehaviour {

    CameraMovement camera;
    EyeController eyes;
    Image blackScreen;
    Light torch;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (stateInfo.IsName("Start"))
        {
            camera = GameObject.Find("Camera").GetComponent<CameraMovement>();
            eyes = GameObject.Find("Eyes").GetComponent<EyeController>();
            blackScreen = GameObject.Find("BlackScreen").GetComponent<Image>();
            torch = GameObject.Find("Torch").GetComponent<Light>();
        }
        else if (stateInfo.IsName("WaitForEyes"))
        {
            camera.Set(new Vector3(0.0f, 1.75f, 3.5f), Quaternion.Euler(0.0f, 180.0f, 0.0f), 0.0f, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            eyes.visible = true;
        }
        else if (stateInfo.IsName("OpenEyes"))
        {
            GameObject.Find("Eyes").GetComponent<Animator>().SetBool("IsOpen", true);
            GameObject.Find("Camera").GetComponent<BlurController>().TurnOff();
            blackScreen.enabled = false;
        }
        else if (stateInfo.IsName("Black0"))
        {
            blackScreen.enabled = true;
        }
        else if (stateInfo.IsName("Scene1"))
        {
            camera.Set(new Vector3(-1.5f, 2.0f, -1.5f), Quaternion.Euler(10.0f, 0.0f, 0.0f), 0.0f, Quaternion.Euler(0.0f, 0.1f, 0.0f));
            blackScreen.enabled = false;
        }
        else if (stateInfo.IsName("Black1"))
        {
            blackScreen.enabled = true;
        }
        else if (stateInfo.IsName("Scene2"))
        {
            camera.Set(new Vector3(-12.0f, 1.75f, -5.0f), Quaternion.Euler(0.0f, 90.0f, 0.0f), 0.05f, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            blackScreen.enabled = false;
        }
        else if (stateInfo.IsName("Scene2DoorOpen"))
        {
            GameObject.Find("Exit1").GetComponentInChildren<DoorController>().Open();
        }
        else if (stateInfo.IsName("Black2"))
        {
            blackScreen.enabled = true;
        }
        else if (stateInfo.IsName("Scene3"))
        {
            camera.Set(new Vector3(10.0f, -8.25f, -10.0f), Quaternion.Euler(30.0f, 45.0f, 0.0f), 0.0f, Quaternion.Euler(-0.1f, 0.0f, 0.0f));
            torch.enabled = true;
            blackScreen.enabled = false;
        }
        else if (stateInfo.IsName("Black3"))
        {
            blackScreen.enabled = true;
            torch.enabled = false;
        }
    }

}
