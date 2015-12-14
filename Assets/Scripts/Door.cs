using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    Animation anim;
    bool isInRange = false;
    bool isOpen = false;

    void Start()
    {
        anim = transform.parent.GetChild(1).gameObject.GetComponent<Animation>();
    }

    void Update()
    {
        if (!anim.isPlaying)
        {
            if (isInRange != isOpen)
            {
                if (isInRange)
                {
                    anim.Play("Door_Open");
                    isOpen = true;
                }
                else
                {
                    anim.Play("Door_Close");
                    isOpen = false;
                }
            }
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        isInRange = true;
    }

    void OnTriggerExit(Collider obj)
    {
        isInRange = false;
    }
}
