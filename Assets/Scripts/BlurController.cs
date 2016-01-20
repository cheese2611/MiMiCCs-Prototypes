using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class BlurController : MonoBehaviour {

    BlurOptimized blur;

	public void TurnOff() {
        blur = GetComponent<BlurOptimized>();
        blur.enabled = true;
        blur.blurSize = 2.5f;
        StartCoroutine(Delay(2.0f, Blur0));
    }

    delegate void Callback();
    IEnumerator Delay(float delay, Callback cb)
    {
        yield return new WaitForSeconds(delay);
        cb();
    }

    void Blur0()
    {
        blur.blurSize = 1.0f;
        StartCoroutine(Delay(3.0f, BlurOff));
    }

    void BlurOff()
    {
        blur.enabled = false;
    }
}
