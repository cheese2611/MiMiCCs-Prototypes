using UnityEngine;
using System.Collections;

public class HeadsetController : MonoBehaviour {

    public AudioClip[] clips;
    AudioSource audioSrc;

    void Start ()
    {
        audioSrc = GetComponent<AudioSource>();
	}
	
    public void Test(string clipStr)
    {
        foreach (AudioClip clip in clips) {
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
}
