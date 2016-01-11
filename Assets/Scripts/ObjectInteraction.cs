using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {

    private Behaviour halo;
    private bool playerInteracts;

    void Start()
    {
        halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false;
        playerInteracts = false;
    }

    void Update()
    {
        // turn off highlight if player didn't look at it in previous frame
        if (!playerInteracts)
        {
            halo.enabled = false;
        }
        else
        {
            playerInteracts = false;
        }
    }

    public void Highlight()
    {
        halo.enabled = true;
        Debug.Log(this.name + " highlighted!");
        playerInteracts = true;
    }

    public void PickUp()
    {
        Destroy(gameObject);
    }
}