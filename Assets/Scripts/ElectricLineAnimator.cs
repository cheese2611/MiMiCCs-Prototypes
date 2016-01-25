using UnityEngine;
using System.Collections;

public class ElectricLineAnimator : MonoBehaviour {

    public bool playSound = true;
    AudioSource audioSrc;
    public AudioClip clipOn;
    public AudioClip clipSwitchOn;
    public AudioClip clipSwitchOff;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void SparkEnabled(bool b)
    {
        ElectricityAnimator[] anims = GetComponentsInChildren<ElectricityAnimator>();
        foreach (ElectricityAnimator anim in anims)
        {
            anim.SparkEnabled(b);
        }
        if (playSound)
        {
            audioSrc.Stop();
            audioSrc.loop = false;
            audioSrc.volume = 0.5f;
            if (b)
                audioSrc.clip = clipSwitchOn;
            else
                audioSrc.clip = clipSwitchOff;
            audioSrc.Play();
        }
        StartCoroutine(BoolDelay(2.0f, CapsuleColliderEnable, b));
    }

    delegate void BoolCallback(bool b);
    IEnumerator BoolDelay(float delay, BoolCallback cb, bool b)
    {
        yield return new WaitForSeconds(delay);
        cb(b);
    }

    void CapsuleColliderEnable(bool b)
    {
        GetComponent<CapsuleCollider>().enabled = b;
        if (b)
        {
            audioSrc.Stop();
            audioSrc.loop = true;
            audioSrc.volume = 0.1f;
            audioSrc.clip = clipOn;
            audioSrc.Play();
        }
    }

}
