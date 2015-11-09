using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR;
using System.Collections;

public class PlayerControllerOculus : MonoBehaviour
{

    public float movementSpeed;
    public float rotationSpeed;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float rotateHorizontal = Input.GetAxis("Horizontal");
        float oculusRotation = InputTracking.GetLocalRotation(VRNode.Head).eulerAngles.y;
        float rotation = transform.rotation.eulerAngles.y;

        Vector3 movementForward = new Vector3(moveVertical * Mathf.Sin((rotation + oculusRotation) * Mathf.Deg2Rad), 0.0f, moveVertical * Mathf.Cos((rotation + oculusRotation) * Mathf.Deg2Rad));

        Quaternion turnVertical = transform.rotation * Quaternion.Euler(0.0f, rotateHorizontal * rotationSpeed, 0.0f);

        rb.MovePosition(transform.position + movementForward * movementSpeed);
        rb.MoveRotation(turnVertical);
    }
}
