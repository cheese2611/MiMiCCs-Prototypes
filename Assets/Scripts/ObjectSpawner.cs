using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

    public GameObject spawnObject;
    public string spawnTag;
    public string objectName;

	public void Spawn () {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnTag);
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject spawnedObject = (GameObject)Instantiate(spawnObject, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
        spawnedObject.name = objectName;
        spawnedObject.transform.parent = spawnPoints[spawnPointIndex].transform;
    }
}
