using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float waitTime = 5;
    public GameObject EnemyPrefab;
    public GameObject[] SpawnPoints;
    public GameObject[] ExtraSpawn;
    int SpawnPointIndex = 0;
    int ExtraSpawnIndex = 0;
    float speedMultiplier = 2;
    float airSpawnRatio = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTimer());
        StartCoroutine(AirSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        speedMultiplier += Time.deltaTime/20f;
    }
    IEnumerator SpawnTimer()
    {
        waitTime = Random.Range(3f, 4f);
        yield return new WaitForSeconds(waitTime);
        // Randomly select between ground and air spawn points based on the given ratio
        SpawnPointIndex = Random.Range(0, SpawnPoints.Length);
        SpawnObjectScript sp = Instantiate(EnemyPrefab, SpawnPoints[SpawnPointIndex].transform.position, Quaternion.identity).GetComponent<SpawnObjectScript>();
        sp.speed = speedMultiplier;

        StartCoroutine(SpawnTimer());
    }
    IEnumerator AirSpawn()
    {
        waitTime = Random.Range(6f, 10f);
        yield return new WaitForSeconds(waitTime);
        SpawnPointIndex = Random.Range(0, ExtraSpawn.Length);
        SpawnObjectScript sp = Instantiate(EnemyPrefab, ExtraSpawn[SpawnPointIndex].transform.position, Quaternion.identity).GetComponent<SpawnObjectScript>();
        sp.speed = speedMultiplier;
        StartCoroutine(AirSpawn());
    }
}
