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
        //InvokeRepeating("Shot", 2f, 3f);
        //Shot(Mathf.PI / 4f);
        //Shot(-Mathf.PI / 4f);

        StartCoroutine(ShotNWaveM(4, 8));       

        omochiGenerator = GameObject.Find("OmochiGenerator").GetComponent<OmochiGenerator>();
    }

    void Shot(float angle, float speed)
    {
        
        BulletMove bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);
        bullet.Setting(angle, speed);
        //bullet.Setting(Mathf.PI / 4f);
    }

    IEnumerator ShotNWaveM(int n, int m)
    {
        for (int w = 0; w < n; w++)
        {
            ShotN(m, 2);
            yield return new WaitForSeconds(2f);
        }
    }
    
    void ShotN(int count, float speed)
    {
        int bulletCount = 8;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount);
            Shot(angle, speed);
        }
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
