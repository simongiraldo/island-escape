using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager sharedInstance;

    void Awake(){
        if(sharedInstance == null){
            sharedInstance = this;
        }
    }
    
}
