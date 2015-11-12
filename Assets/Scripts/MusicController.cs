using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour
{
    public AudioClip roomMusic;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void playMusic()
    {
        source.PlayOneShot(roomMusic, 1F);
    }
}