using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    bool isGrounded = false;
    float basedSpeed = 15f;
    float boostSpeed = 25f;
    bool canMove=true;

    [SerializeField] float torqueForce=1f;

    [SerializeField] ParticleSystem particleSkate;

    [SerializeField] SurfaceEffector2D surfaceEffector;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            addTorque();
            addVelocity();
        }
       
      
    }

    void addTorque()
    {
       
        
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddTorque(torqueForce);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb.AddTorque(-torqueForce);
            }
        
    
    }

    void addVelocity()
    {
     
        
            if (Input.GetKey(KeyCode.W))
            {
                surfaceEffector.speed = boostSpeed;

            }
            else
            {
                surfaceEffector.speed = basedSpeed;
            }
        
       

    }

    public  void DisableMovement()
    {
        canMove = false;
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snow"))
        {
            isGrounded = true;
            particleSkate.Play();
        }
    }

     void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Snow"))
        {
            isGrounded = true;
            particleSkate.Stop();
        }
    }
}
