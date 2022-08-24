using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private AnimationClip animationToIntro;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(ChangeScene());
        } */
        
    }

    /* IEnumerator ChangeScene(){
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(animationToIntro.length);

        SceneManager.LoadScene(1);
    } */
}
