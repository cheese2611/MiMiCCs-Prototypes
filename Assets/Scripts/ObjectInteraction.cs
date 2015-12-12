using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {

    private Behaviour halo;

    void Start()
    {
        halo = (Behaviour)GetComponent("Halo");
        halo.enabled = false;
    }

    void Update()
    {
        halo.enabled = false;
    }

    public void Highlight()
    {
        halo.enabled = true;
    }
}