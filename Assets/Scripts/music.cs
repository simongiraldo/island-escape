using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private music instance;
    public music Instance {
        get{
            return instance;
        }
    }
    void Awake()
    {
        if(FindObjectsOfType(GetType()).Length > 1){
            Destroy(gameObject);
        }

        if(instance != null && instance != this){
            Destroy(gameObject);
            return;
        }
        else {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
        
    }
}