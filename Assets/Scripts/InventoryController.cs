using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    public bool communicationEnabled = true;
    public bool batteryFull = true;
    public bool hasKeycard = false;

    void Update()
    {
        Color col1 = transform.GetChild(0).GetComponent<Image>().color;
        col1.a = communicationEnabled ? 1.0f : 0.4f;
        transform.GetChild(0).GetComponent<Image>().color = col1;
        Color col2 = transform.GetChild(1).GetComponent<Image>().color;
        col2.a = batteryFull ? 1.0f : 0.4f;
        transform.GetChild(1).GetComponent<Image>().color = col2;
        Color col3 = transform.GetChild(2).GetComponent<Image>().color;
        col3.a = hasKeycard ? 1.0f : 0.4f;
        transform.GetChild(2).GetComponent<Image>().color = col3;
   }

    public void hasCommunication()
    {
        communicationEnabled = false;
    }

    public void lostCommunication()
    {
        communicationEnabled = true;
    }

    public void batteryLow()
    {
        batteryFull = false;
    }

    public void batteryCharged()
    {
        batteryFull = true;
    }

    public void keycardFound()
    {
        hasKeycard = true;
    }

    public void keycardLost()
    {
        hasKeycard = false;
    }
}
