using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;
using System.Collections;

public class PlayerControllerOculus : MonoBehaviour
{

    public float movementSpeed;
    public float rotationSpeed;

    private CharacterController character;
    private Camera pov;

    void Start()
    {
        character = GetComponent<CharacterController>();
        pov = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        MoveCharacter();
        MoveCamera();
    }

    void MoveCharacter()
    {
        float movementInput = Input.GetAxis("MovementWalk");
        float rotationInput = Input.GetAxis("MovementTurn");
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        float movement = movementInput * movementSpeed;
        float rotation = rotationInput * rotationSpeed;
        transform.Rotate(0, rotation, 0);
        character.SimpleMove(forward * movement);
    }

    private void MoveCamera()
    {
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
        pov.transform.rotation = transform.rotation * rotation;
    }
}
