using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour
{
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void playMusic()
    {
        source.Play();
    }
}