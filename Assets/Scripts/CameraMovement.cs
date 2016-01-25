using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    float speed = 0;
    Quaternion rotationSpeed;

	void FixedUpdate () {
        transform.rotation *= rotationSpeed;
        transform.position += transform.forward * speed;
	}

    public void Set(Vector3 vector, Quaternion quaternion, float speed, Quaternion rotationSpeed)
    {
        SetPosition(vector);
        SetRotation(quaternion);
        SetSpeed(speed);
        SetRotationSpeed(rotationSpeed);
    }

    public void SetPosition(Vector3 vector)
    {
        transform.position = vector;
    }

    public void SetRotation(Quaternion quaternion)
    {
        transform.rotation = quaternion;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetRotationSpeed(Quaternion rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }
}
