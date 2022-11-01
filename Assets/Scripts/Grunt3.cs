using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt3 : MonoBehaviour
{
    public GameObject Jhon;
    public GameObject BulletPrefab;


        private float LastShoot;
        private int Health = 4;
        private Animator Animator;

     void Start()
    {
        Animator= GetComponent<Animator>();
    }
    
    
    private void Update()
    {
        
        if (Jhon == null) return;

        Vector3 direction = Jhon.transform.position - transform.position;
        if (direction.x >= 0.0f)  transform.localScale = new Vector3(10.80244f, 10.72041f, 1.0f);
        else transform.localScale = new Vector3(-10.80244f, 10.72041f, 1.0f);

        float distance = Mathf.Abs(Jhon.transform.position.x - transform.position.x);

        if (distance < 6.0f && Time.time > LastShoot + 0.75f)
        {
            Shoot();
            LastShoot = Time.time;
        }

    }


    private void Shoot()
    {
        Vector3 direction;

        if (transform.localScale.x == 10.80244f ) direction = Vector3.right;
        else direction= Vector3.left;

        GameObject Bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f , Quaternion.identity);
        Bullet.GetComponent<GruntBullet>().SetDirection(direction);
    }

    public void Hit()
    {
        Health = Health - 2;
        if (Health == 0) 
        {   
            Animator.SetBool("isnotdead", Health==0 );
        }
    }


    public void Destroy()
    {
       // if (Health== 0)
        //{
          //  Destroy(gameObject);
        //}
       Destroy(gameObject);
    }
}
