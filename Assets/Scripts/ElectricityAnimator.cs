using UnityEngine;
using System.Collections;

public class ElectricityAnimator : MonoBehaviour {

    public void SparkEnabled(bool b)
    {
        Animator[] anims = GetComponentsInChildren<Animator>();
        foreach (Animator anim in anims)
        {
            anim.SetBool("SparkEnabled", b);
        }
    }

}
