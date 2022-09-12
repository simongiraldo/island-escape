using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{

    private Animator animator;
    [SerializeField] private AnimationClip introToLvel;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /* 
        -Cambiar las funciones y todas la funcionalidades del menu con un script propio para la escena, me la puede chupar el game manager
        -Mrar y volver a poner lo nesesario de cada escena en los niveles para no generar conflicto con los scripts, como el game manager, es mejor un script por escena
        -Hacer las transiciones de cada nivel, primero la del incio del menu hacia la intro. Ver video de gringo, el malparido latino es una mierda
        -Tal vez agregar el canvas donde van las piezas del barco en cada nivel
         */
        
    }

    public void StartTransIntroToLevel1(){
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene(){
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(introToLvel.length);

        SceneManager.LoadScene(2);
    }
}
