using UnityEngine;
using System.Collections;

public class TorchController : MonoBehaviour {

    public bool invertY;

    Light torch;

    void Start ()
    {
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
            ToggleTorch();
        }
    }

    void ToggleTorch ()
    {
        torch.enabled = !torch.enabled;
    }
}