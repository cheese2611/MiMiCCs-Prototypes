using UnityEngine;
using System.Collections;

public class ElectricCellWallAnimator : MonoBehaviour {

    public void SparkEnabled(bool b)
    {
        ElectricLineAnimator[] anims = GetComponentsInChildren<ElectricLineAnimator>();
        foreach (ElectricLineAnimator anim in anims)
        {
            anim.SparkEnabled(b);
        }
    }

}
