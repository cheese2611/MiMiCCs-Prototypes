using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

    public float interactionRange;
	
	// Update is called once per frame
	void Update () {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, interactionRange) && (hit.collider.gameObject.name != "Player"))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            Debug.Log("Collider of object " + hit.collider.gameObject.name + " hit!");
            // call hit.collider.GetComponent<ObjectInteraction>().Highlight(); to activate highlight function of hit object (check if null/exists first!)
            if (hit.collider.GetComponent<ObjectInteraction>()) {
                hit.collider.GetComponent<ObjectInteraction>().Highlight();

                if (Input.GetButton("Interaction"))
                {
                    hit.collider.GetComponent<ObjectInteraction>().PickUp();
                }
            }
        }
    }
}