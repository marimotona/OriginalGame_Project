using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip startSE;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //StartCoroutine(DelayCoroutine());
        //Invoke("Update", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(startSE);
            SceneManager.LoadScene("Main");
            
        }
                
    }

    /*
    private IEnumerator DelayCoroutine()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(startSE);
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Main");

        }
    }
    */
}
