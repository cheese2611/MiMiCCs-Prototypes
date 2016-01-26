using UnityEngine;
using System.Collections;

public class TorchController : MonoBehaviour {

    public bool isEnabled = true;
    public bool isOn = true;
    public bool invertY = false;

    Animator levelController;
    Light torch;

    void Start ()
    {
        levelController = GameObject.Find("LevelController").GetComponent<Animator>();
        torch = gameObject.GetComponent<Light>();
    }

    void Update()
    {
        float rotationX = Input.GetAxis("RightHandHorizontal");
        float rotationY = Input.GetAxis("RightHandVertical");

        if (invertY)
        {
            rotationY = -rotationY;
        }

        transform.rotation = transform.parent.rotation * Quaternion.FromToRotation(Vector3.forward, new Vector3(rotationX, rotationY, 1));

        // toggle light
        if (Input.GetButtonDown("RightHandAction"))
        {
            isOn = !isOn;
            levelController.SetBool("TorchEnabled", isOn);
        }

        torch.enabled = isEnabled & isOn;
    }

}