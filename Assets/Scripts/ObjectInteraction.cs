using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {

    private Behaviour halo;
    private int timeoutCounter;

    void Start()
    {
        halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false;
        timeoutCounter = 60;
    }

    void Update()
    {
        Debug.Log("timeoutCounter: " + timeoutCounter);

        if (timeoutCounter == 0)
        {
            halo.enabled = false;
        }
        else if (timeoutCounter > 0)
        {
            timeoutCounter--;
        }
    }

    public void Highlight()
    {
        halo.enabled = true;
        Debug.Log(this.name + " highlighted!");
        timeoutCounter++;
    }

    public void PickUp()
    {
        Destroy(gameObject);
    }
}