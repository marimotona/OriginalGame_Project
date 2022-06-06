using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyMove : MonoBehaviour
{

    public GameObject bulletPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shot", 2f, 2f);        
        //Shot();
    }

    void Shot()
    {
        Instantiate(bulletPrefabs, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime, 0);
    }
}
