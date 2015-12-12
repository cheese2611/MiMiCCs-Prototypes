using UnityEngine;
using System.Collections;
using UnityEngine.VR;
using System;

public class PlayerController_Xbox : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;

    private CharacterController character;
    private Camera pov;

    // Use this for initialization
    void Start () {
        character = GetComponent<CharacterController>();
        pov = GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveCharacter();
        MoveCamera();
    }

    void MoveCharacter()
    {
        float movementInput = Input.GetAxis("MovementWalk");
        float rotationInput = Input.GetAxis("MovementTurn");
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        transform.Rotate(0, rotationInput * rotationSpeed, 0);
        float movement = movementInput * movementSpeed;
        character.SimpleMove(forward * movement);
    }

    private void MoveCamera()
    {
        float xAxis = Input.GetAxis("RightHandVertical");

        pov.transform.Rotate(xAxis, 0.0F, 0.0F);
    }
}