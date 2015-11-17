using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllerTest : MonoBehaviour {

    public Sprite button_0, button_1;
    
	void Start () {

	}
	
    void Update () {
        for (int i = 0; i < transform.childCount; ++i)
        {
            Transform category = transform.GetChild(i);
            for (int j = 0; j < category.transform.childCount; ++j)
            {
                Transform child = category.transform.GetChild(j);
                if (category.name == "Buttons")
                {
                    if (Input.GetButton(child.name))
                    {
                        child.GetComponent<Image>().sprite = button_1;
                    }
                    else
                    {
                        child.GetComponent<Image>().sprite = button_0;
                    }
                }
                else if (category.name == "Axes")
                {
                    child.GetComponent<Slider>().value = Input.GetAxis(child.name);
                }
            }
        }
    }
}
