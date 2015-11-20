using UnityEngine;
using System.Collections;

public class TorchController : MonoBehaviour {

    public Light torch;
    public float horizontalFOV;
    public float verticalFOV;
    public float rotationSpeed;
    public bool absoluteRotation;
    public bool invertY;

    private Quaternion originalRotation;

    void Start ()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // rotationY == rotation along y-axis, meaning "horizontal"
        float rotationY = Input.GetAxis("RightHandHorizontal");
        float rotationX = Input.GetAxis("RightHandVertical");

        if (invertY)
        {
            rotationX = -rotationX;
        }

        Vector3 rotation = new Vector3(rotationX, rotationY);
        Vector3 FOV = new Vector3(verticalFOV, horizontalFOV);

        if (absoluteRotation)
        {
            transform.Rotate(rotation * rotationSpeed);
        }
        else
        {
            // multiply components of rotation and FOV vector (Vector3.Scale), transform to Quaternion (Quaternion.Euler)
            transform.rotation = Quaternion.Slerp(originalRotation, Quaternion.Euler(Vector3.Scale(rotation, FOV)), Time.time * rotationSpeed);
        }

        // toggle light
        if (Input.GetButtonDown("Flashlight"))
        {
            ToggleTorch();
        }
    }

    void ToggleTorch ()
    {
        torch.enabled = !torch.enabled;
    }
}