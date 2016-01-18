using UnityEngine;
using System.Collections;

public class PositionController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        for (int idx = 0; idx < 10; ++idx)
        {
            if (Input.GetKey(idx.ToString()))
            {
                GameObject spot = GameObject.Find("PlayerPosition" + idx.ToString());
                if (spot)
                {
                    Transform player = GameObject.Find("Player").transform;
                    player.position = spot.transform.position;
                    player.rotation = spot.transform.rotation;
                }
                else
                {
                    Debug.LogWarning("No spot with name 'PlayerPosition" + idx.ToString() + "' found");
                }
            }
        }
    }
}
