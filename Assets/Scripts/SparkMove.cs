using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 2f, 0) * Time.deltaTime;

        //íeÇÃîÕàÕêßå¿
        if (transform.position.x < -8.5 || transform.position.x > 8.5 ||
            transform.position.y < -4.5 || transform.position.y > 4.5)
        {
            Destroy(gameObject);
        }
    }
}
