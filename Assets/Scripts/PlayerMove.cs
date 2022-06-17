using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    Rigidbody2D playerRigidbody;

    public Transform sparkPoint; //球を発射する位置

    public GameObject sparkPrefab;

    public GameObject explosion;

    GameController gameController;

    AudioSource audioSource;
    public AudioClip shotSE;

    public AudioClip scoreSE;

    public float time;

    
    // Start is called before the first frame update
    void Start()
    {       

        playerRigidbody = this.gameObject.GetComponent<Rigidbody2D>();

        gameController = GameObject.Find("GameController").GetComponent<GameController>();

        audioSource = GetComponent<AudioSource>();

        time = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        //プレイヤーの移動制限
        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 4.0f;
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -8.5f, 8.5f),
            Mathf.Clamp(nextPosition.y, -4.5f, 4.5f),
            nextPosition.z
            );

        transform.position = nextPosition;

        //弾の発射制限
        time += Time.deltaTime;
        if (time >= 1.0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(sparkPrefab, sparkPoint.position, Quaternion.Euler(0, 0, 90));
                audioSource.PlayOneShot(shotSE);
                time = 0.0f;
            }
        }
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
