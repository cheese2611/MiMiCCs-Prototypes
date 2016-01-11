using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

    public GameObject spawnObject;
    public string spawnTag;

	public void Spawn () {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnTag);
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(spawnObject, spawnPoints[spawnPointIndex].transform.position, spawnPoints[spawnPointIndex].transform.rotation);
    }
}
