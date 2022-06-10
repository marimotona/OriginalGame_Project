using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyMove : MonoBehaviour
{

    public BulletMove bulletPrefabs;

    public GameObject explosion;

    SpecialOmochiGenerator specialomochiGenerator;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Shot", 2f, 3f);
        //Shot(Mathf.PI / 4f);
        //Shot(-Mathf.PI / 4f);

        //StartCoroutine(WaveNShotM(4, 8));
        StartCoroutine(CPU());

        specialomochiGenerator = GameObject.Find("SpecialOmochiGenerator").GetComponent<SpecialOmochiGenerator>();
    }

    void Shot(float angle, float speed)
    {
        
        BulletMove bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);
        bullet.Setting(angle, speed);
        //bullet.Setting(Mathf.PI / 4f);
    }

    IEnumerator CPU()
    {
        while (true)
        {
            yield return WaveNShotM(1, 8);
            yield return new WaitForSeconds(1f);
            yield return WaveNShotM(1, 6);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator WaveNShotM(int n, int m)
    {
        for (int w = 0; w < n; w++)
        {
            ShotN(m, 2);
            yield return new WaitForSeconds(2f);
        }
    }
    
    
    void ShotN(int count, float speed)
    {
        int bulletCount = count;
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

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spark") == true)
        {
            specialomochiGenerator.Spawn();
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
