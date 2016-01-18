using UnityEngine;
using System.Collections;

public class Electricity : MonoBehaviour
{

    public float dist = -0.07462686f;
    public float mag = 6.910449f;
    public float width = 0.4618358f;

	void Start ()
	{		
		Material newMat = GetComponent<Renderer>().material;
		newMat.SetFloat("_StartSeed", Random.value * 1000);
		GetComponent<Renderer>().material = newMat;
	}

    void Update()
    {
        Material newMat = GetComponent<Renderer>().material;
        newMat.SetFloat("_SparkDist", dist);
        newMat.SetFloat("_SparkMag", mag);
        newMat.SetFloat("_SparkWidth", width);
        GetComponent<Renderer>().material = newMat;
    }
}

