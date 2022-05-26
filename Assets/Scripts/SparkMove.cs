using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 2f, 0) * Time.deltaTime;
    }
}
