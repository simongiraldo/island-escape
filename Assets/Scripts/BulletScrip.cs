using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScrip : MonoBehaviour
{
    public float Speed;

        private Rigidbody2D Rigidbody2D; 
         private Vector3 Direction;




    void Start()
    {
         Rigidbody2D = GetComponent<Rigidbody2D>();   
    }

    
    private void FixedUpdate()
    {   
        Rigidbody2D.velocity = Direction * Speed;
    }


    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }


    public void DestroyBullet()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Grunt1 grunt = collision.GetComponent<Grunt1>();
       Grunt2 grunt2 = collision.GetComponent<Grunt2>();
        Grunt3 grunt3 = collision.GetComponent<Grunt3>();
        GruntBoss gruntboss = collision.GetComponent<GruntBoss>();

       if (grunt != null)
        {
            grunt.Hit();
        }

        if (grunt2 != null)
        {
            grunt2.Hit();
        }

         if (grunt3 != null)
        {
            grunt3.Hit();
        }

        if (gruntboss != null)
        {
            gruntboss.Hit();
        }
    }

}
