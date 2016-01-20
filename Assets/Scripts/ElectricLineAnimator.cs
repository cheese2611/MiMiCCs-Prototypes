using UnityEngine;
using System.Collections;

public class ElectricLineAnimator : MonoBehaviour {

    public bool playSound = true;
    public AudioClip clipOn;
    public AudioClip clipOff;

    public void SparkEnabled(bool b)
    {
        ElectricityAnimator[] anims = GetComponentsInChildren<ElectricityAnimator>();
        foreach (ElectricityAnimator anim in anims)
        {
            anim.SparkEnabled(b);
        }
        if (playSound)
        {
            AudioSource audioSrc = GetComponent<AudioSource>();
            audioSrc.Stop();
            if (b)
                audioSrc.clip = clipOn;
            else
                audioSrc.clip = clipOff;
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
    }

}
