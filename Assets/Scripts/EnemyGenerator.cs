using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 1.5f);
    }

    void Spawn()
    {

        Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f),transform.position.y, transform.position.z);

        Instantiate(enemyPrefabs, spawnPosition, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
