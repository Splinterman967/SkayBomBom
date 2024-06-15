using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public float time = 2f;

    [SerializeField] ParticleSystem particleFinish;
    [SerializeField] AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            particleFinish.Play();
            Invoke("loadScene", time);
        }
    }


    void loadScene()
    {
        SceneManager.LoadScene(0);
    }
}
