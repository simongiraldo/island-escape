using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour
{
    public GameObject player;  

    private void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        if(direction.x >= 0.0f) transform.localScale = new Vector3(5.106079f, 5.476141f, 1.0f);
        else transform.localScale = new Vector3(-5.106079f, 5.476141f, 1.0f);

    } 
        
    
}
