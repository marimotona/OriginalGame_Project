using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefabs, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
