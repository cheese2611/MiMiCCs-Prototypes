using UnityEngine;
using System.Collections;

public class ElectricLineAnimator : MonoBehaviour {

    public void SparkEnabled(bool b)
    {
        ElectricityAnimator[] anims = GetComponentsInChildren<ElectricityAnimator>();
        foreach (ElectricityAnimator anim in anims)
        {
            anim.SparkEnabled(b);
        }
    }

}
