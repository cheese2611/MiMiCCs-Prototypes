using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EyeController : MonoBehaviour {

    RawImage lidUpper;
    RawImage lidLower;

    public bool visible;
    public float occlusion;

	void Start () {
        lidUpper = transform.GetChild(0).GetComponent<RawImage>();
        lidLower = transform.GetChild(1).GetComponent<RawImage>();
    }

    void Update () {
	    lidUpper.rectTransform.sizeDelta = new Vector2(0, visible ? occlusion * 270 : 0);
        lidLower.rectTransform.sizeDelta = new Vector2(0, visible ? occlusion * 270 : 0);
    }
}
