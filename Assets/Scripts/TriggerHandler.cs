using UnityEngine;
using System.Collections;

public class TriggerHandler : MonoBehaviour {
    
    public MusicController musicController;

    private bool musicPlayed = false;
	
	void OnTriggerEnter (Collider other) {
        if (!musicPlayed)
        {
            musicController.playMusic();
            musicPlayed = true;
        }
        
	}
}