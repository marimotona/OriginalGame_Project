using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyMove : MonoBehaviour
{

    public BulletMove bulletPrefabs;

    public GameObject explosion;

    OmochiGenerator omochiGenerator;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shot", 2f, 3f);
        //Shot(Mathf.PI / 4f);
        //Shot(-Mathf.PI / 4f);

        omochiGenerator = GameObject.Find("OmochiGenerator").GetComponent<OmochiGenerator>();
    }

    void Shot()
    {
        BulletMove bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);
        bullet.Setting(-Mathf.PI / 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spark") == true)
        {
            omochiGenerator.Spawn();
        }
        else if (collision.CompareTag("Bullet") == true)
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
