using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    public float time=2f;


    [SerializeField] ParticleSystem particleBlood;
    [SerializeField] AudioClip crashClip;
    bool crashOnce = true;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snow")&& crashOnce)
        {           
                GetComponent<AudioSource>().PlayOneShot(crashClip);
                particleBlood.Play();
                GetComponent<PlayerController>().DisableMovement();
                Invoke("loadScene", time);
                Debug.Log("Hit my Head");
                crashOnce = false;
            
        
        }
    }
    void loadScene()
    {
        SceneManager.LoadScene(0);
    }
}
