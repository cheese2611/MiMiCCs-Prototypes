using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class CameraController : MonoBehaviour {

    Camera pov;

    void Start () {
        pov = GetComponentInChildren<Camera>();
    }

    void Update () {
        if (VRSettings.enabled & Input.GetButton("RecenterCamera"))
        {
            InputTracking.Recenter();
        }

        Quaternion rotation = new Quaternion();
        if (VRSettings.enabled)
        {
            rotation = InputTracking.GetLocalRotation(VRNode.Head);
        }
        else
        {
            float rotationXInput = Input.GetAxis("RightHandHorizontal");
            float rotationYInput = Input.GetAxis("RightHandVertical");
            rotation.SetLookRotation(new Vector3(rotationXInput, rotationYInput, 1));
        }
        pov.transform.rotation = transform.parent.rotation * rotation;
    }
}
