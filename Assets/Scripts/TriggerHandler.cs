using UnityEngine;
using System.Collections;

public class TriggerHandler : MonoBehaviour {
    
    public MusicController musicController;

	void OnTriggerEnter (Collider other) {
        musicController.playMusic();
	}
}