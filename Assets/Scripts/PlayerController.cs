using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    public float rotationSpeed;

    CharacterController character;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        float movementInput = Input.GetAxis("MovementWalk");
        float rotationInput = Input.GetAxis("MovementTurn");

        float movement = movementInput * movementSpeed;
        float rotation = rotationInput * rotationSpeed;
        transform.Rotate(0, rotation, 0);
        character.SimpleMove(transform.forward * movement);
    }
}
