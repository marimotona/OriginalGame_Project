using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody2D playerRigidbody;

    //Vector3 inputDirection;

    //float moveSpeed = 4.0f;

    public Transform sparkPoint; //球を発射する位置

    public GameObject sparkPrefab;

    public GameObject explosion;

    GameController gameController;

    AudioSource audioSource;
    public AudioClip shotSE;

    public AudioClip scoreSE;

    
    // Start is called before the first frame update
    void Start()
    {
        //inputDirection = new Vector3(1, 0, 0);

        playerRigidbody = this.gameObject.GetComponent<Rigidbody2D>();

        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 4.0f;
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -8.5f, 8.5f),
            Mathf.Clamp(nextPosition.y, -4.5f, 4.5f),
            nextPosition.z
            );

        transform.position = nextPosition;


        //transform.position += new Vector3(x, y, 0) * Time.deltaTime * 4.0f;
        /*
        inputDirection = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
            );
        */
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(sparkPrefab, sparkPoint.position, Quaternion.Euler(0, 0, 90));
            audioSource.PlayOneShot(shotSE);

        }


    }

    /*
    private void FixedUpdate()
    {
        playerRigidbody.velocity = inputDirection * moveSpeed;
    }
    */

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
