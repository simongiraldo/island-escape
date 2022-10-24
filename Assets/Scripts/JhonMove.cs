using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JhonMove : MonoBehaviour
{



public float Speed;
public float JumpForce;
public GameObject BulletPrefab;


    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool Grounded;
    private Animator Animator;
    private float LastShoot;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3 (-10.80244f, 10.72041f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3 (10.80244f, 10.72041f, 1.0f);

        Animator.SetBool ("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
            
             if (Physics2D.Raycast(transform.position, Vector3.down, 1.5f))
        {
            Grounded= true;
        }
           else  Grounded= false;


            if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }


            if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time; 
        }
    }


    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    
    private void Shoot()
    {
        Vector3 direction;

        if (transform.localScale.x == 10.80244f ) direction = Vector3.right;
        else direction= Vector3.left;

        GameObject Bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f , Quaternion.identity);
        Bullet.GetComponent<BulletScrip>().SetDirection(direction);
    }


    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed , Rigidbody2D.velocity.y);
    }
}

