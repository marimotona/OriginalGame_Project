using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody playerRigidbody;

    Vector3 inputDirection;

    float moveSpeed = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        inputDirection = new Vector3(1, 0, 0);


        playerRigidbody = this.gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        inputDirection = new Vector3(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
            ,0

            );


    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = inputDirection * moveSpeed;
    }
}
