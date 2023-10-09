using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float waitTime = 3;
    public GameObject EnemyPrefab;
    public GameObject[] SpawnPoints;
    int SpawnPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTimer()
    {
        waitTime = Random.Range(1f, 3f);
        yield return new WaitForSeconds(waitTime);
        SpawnPointIndex = Random.Range(0, 3);
        Instantiate(EnemyPrefab, SpawnPoints[SpawnPointIndex]. transform.position, Quaternion.identity);
        StartCoroutine(SpawnTimer());
    }
}
