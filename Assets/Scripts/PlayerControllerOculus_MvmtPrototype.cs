using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;
using System.Collections;

public class PlayerControllerOculus_MvmtPrototype : MonoBehaviour
{

    public float movementSpeed;
    public float rotationSpeed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (VRSettings.enabled & Input.GetKey("RecenterCamera") )
        {
            InputTracking.Recenter();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("MovementWalk");
        float rotateHorizontal = Input.GetAxis("MovementTurn");
        float rotation = transform.rotation.eulerAngles.y;
        
        if (VRSettings.enabled)
        {
            float oculusRotation = InputTracking.GetLocalRotation(VRNode.Head).eulerAngles.y;
            rotation += oculusRotation;
        }
        
        Vector3 movementForward = new Vector3(moveVertical * Mathf.Sin(rotation * Mathf.Deg2Rad), 0.0f, moveVertical * Mathf.Cos(rotation * Mathf.Deg2Rad));

        Quaternion turnVertical = transform.rotation * Quaternion.Euler(0.0f, rotateHorizontal * rotationSpeed, 0.0f);

        rb.MovePosition(transform.position + movementForward * movementSpeed);
        rb.MoveRotation(turnVertical);
    }
}
