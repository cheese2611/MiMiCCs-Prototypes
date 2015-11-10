using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputController : MonoBehaviour {
    public Text uhr;

    void Start () {
	}
	
	void Update () {
        System.TimeSpan t = System.TimeSpan.FromSeconds(Time.realtimeSinceStartup);
        uhr.text = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", t.Hours, t.Minutes, t.Seconds);
	}
}
