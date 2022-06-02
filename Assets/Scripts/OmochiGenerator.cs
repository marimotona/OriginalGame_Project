using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmochiGenerator : MonoBehaviour
{

    public GameObject omochiPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 4f, 2.5f);
    }

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-6f, 6f), transform.position.y, transform.position.z);

        Instantiate(omochiPrefabs, spawnPosition, transform.rotation);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
