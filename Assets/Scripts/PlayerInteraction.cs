using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

    public float interactionRange;
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange/*, -1, QueryTriggerInteraction.Ignore*/) && (hit.collider.gameObject.tag != "Player"))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            Debug.Log("Collider of object '" + hit.collider.gameObject.name + "' hit!");
            ObjectInteraction objInteract = hit.collider.GetComponent<ObjectInteraction>();
            if (objInteract)
            {
                objInteract.Highlight();
                if (Input.GetButton("Interaction"))
                {
                    objInteract.PickUp();
                    Debug.Log("Picked up " + objInteract.gameObject.name);
                    if (objInteract.gameObject.name == "Keycard")
                    {
                        GameObject.Find("LevelController").GetComponent<Animator>().SetTrigger("KeycardTaken");
                    }
                }
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + interactionRange * transform.forward, Color.red);
        }
    }
}