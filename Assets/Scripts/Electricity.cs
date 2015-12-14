using UnityEngine;
using System.Collections;

public class LightningBolt : MonoBehaviour
{
	
	void Start ()
	{		
		Material newMat = GetComponent<Renderer>().material;
		newMat.SetFloat("_StartSeed", Random.value * 1000);
		GetComponent<Renderer>().material = newMat;
	}
}

