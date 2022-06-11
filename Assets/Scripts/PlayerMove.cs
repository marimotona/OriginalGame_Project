using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody2D playerRigidbody;

    Vector3 inputDirection;

    float moveSpeed = 4.0f;

    public Transform sparkPoint; //‹…‚ð”­ŽË‚·‚éˆÊ’u

    public GameObject sparkPrefab;

    public GameObject explosion;

    GameController gameController;

    AudioSource audioSource;
    public AudioClip shotSE;

    public AudioClip scoreSE;


    // Start is called before the first frame update
    void Start()
    {
        inputDirection = new Vector3(1, 0, 0);

        playerRigidbody = this.gameObject.GetComponent<Rigidbody2D>();

        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        inputDirection = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
            );
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(sparkPrefab, sparkPoint.position, Quaternion.Euler(0, 0, 90));
            audioSource.PlayOneShot(shotSE);

        }


    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = inputDirection * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Omochi") == true)
        {
            audioSource.PlayOneShot(scoreSE);
            return;
        }
        else if (collision.CompareTag("SpecialOmochi") == true)
        {
            audioSource.PlayOneShot(scoreSE);
            return;
        }
        else if (collision.CompareTag("Spark") == true)
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(gameObject);
        Destroy(collision.gameObject);

        gameController.GameOver();
    }


}
