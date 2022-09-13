using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    [SerializeField] public int sceneNumber;

    /* public Animator animator;
    void Start()
    {
        
    }

    public void FadeOut(){
        animator.Play("FadeOut");
    } */

    public void ChangeScene(){
        SceneManager.LoadScene(sceneNumber);
    }


    
}
