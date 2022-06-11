using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialOmochiMove : MonoBehaviour
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
            //Debug.Log("“Á•Ê‚È‚¨–Ý");
            gameController.AddScore2();
        }
        else if (collision.CompareTag("Spark") == true)
        {
            return;
        }
        else if (collision.CompareTag("Bullet") == true)
        {
            return;
        }

        Destroy(gameObject);
    }
}
