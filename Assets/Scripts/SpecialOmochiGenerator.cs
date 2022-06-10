using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialOmochiGenerator : MonoBehaviour
{

    public GameObject specialomochiPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-6f, 6f), transform.position.y, transform.position.z);

        Instantiate(specialomochiPrefabs, spawnPosition, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
