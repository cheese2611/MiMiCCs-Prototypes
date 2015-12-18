using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClockController : MonoBehaviour {
    public Text uhr;

	void Update () {
        System.TimeSpan t = System.TimeSpan.FromSeconds(Time.timeSinceLevelLoad);
        uhr.text = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
	}
}
