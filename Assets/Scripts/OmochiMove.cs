using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmochiMove : MonoBehaviour
{

    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            gameController.AddScore();
        }

        Destroy(gameObject);
    }

}
