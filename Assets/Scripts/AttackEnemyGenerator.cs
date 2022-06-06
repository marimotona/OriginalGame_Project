using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyGenerator : MonoBehaviour
{

    public GameObject attackenemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1f, 1.5f);
    }

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), transform.position.y, transform.position.z);

        Instantiate(attackenemyPrefabs, spawnPosition, transform.rotation);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
