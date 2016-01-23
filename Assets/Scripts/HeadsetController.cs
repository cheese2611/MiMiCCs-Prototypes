using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeadsetController : MonoBehaviour {

    public AudioClip[] clips;
    AudioSource audioSrc;
    InventoryController inventory;

    void Start ()
    {
        audioSrc = GetComponent<AudioSource>();
        inventory = GameObject.Find("Inventory").GetComponent<InventoryController>();
	}
	
    void Update()
    {
        inventory.communicationEnabled = audioSrc.isPlaying;
    }

    public void Play(string clipStr)
    {
        foreach (AudioClip clip in clips)
        {
            if (clip.name == clipStr)
            {
                audioSrc.Stop();
                audioSrc.clip = clip;
                audioSrc.Play();
                return;
            }
        }
        Debug.LogWarning("No clip with name '" + clipStr + "' found");
    }

    public void PlayRandomWhichStartsWith(string clipStr)
    {
        List<string> matchingClips = new List<string>();
        foreach (AudioClip clip in clips)
        {
            if (clip.name.StartsWith(clipStr))
            {
                matchingClips.Add(clip.name);
            }
        }
        if (matchingClips.Count == 0)
        {
            Debug.LogWarning("No clip with name '" + clipStr + "' found");
        }
        else
        {
            Play(matchingClips[Random.Range(0, matchingClips.Count)]);
        }
    }
}
