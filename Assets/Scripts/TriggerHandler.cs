using UnityEngine;
using System.Collections;

public class TriggerHandler : MonoBehaviour {
    
    public GameObject music;

    private bool musicPlayed = false;
	
	void OnTriggerEnter (Collider other) {
        if (!musicPlayed)
        {
            music.GetComponent<MusicController>().playMusic();
            musicPlayed = true;
        }
        
	}
}