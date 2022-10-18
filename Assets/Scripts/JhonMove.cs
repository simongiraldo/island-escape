using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class JhonMove : MonoBehaviour
{



public float Speed;
public float JumpForce;


private Rigidbody2D Rigidbody2D;
private float Horizontal;
private bool Grounded;
private Animator Animator;
public int vidaQueQuitaEnemigo;
public SpriteRenderer jhonsito;
[SerializeField] Slider sliderVida;
[SerializeField] Text textoVida;
private int vidasJugador;
private string vidaPrefsname = "Vida";
private int levelActual;
[SerializeField] RectTransform fader;
[SerializeField] RectTransform text_transition;
[SerializeField] RectTransform text_Restart;
[SerializeField] Text vidasRestart;
[SerializeField] Text corason;
private bool sliderFlag;
private bool invulnerable;

    void Awake(){
        LoadVida();
    }

    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        textoVida.text = ""+vidasJugador;
        sliderVida.value = 100;

        fader.gameObject.SetActive(false);
        text_transition.gameObject.SetActive(false);
        text_Restart.gameObject.SetActive(false);
        corason.enabled = false;
        vidasRestart.enabled = false;

        sliderFlag = true;
    }

    void OnDestroy(){
        SaveVida();
    }

    void OnLevelWasLoaded(int level){
        if(level == 1){
            vidasJugador = 3;
            SaveVida();
        }
        levelActual = level;
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

        if(sliderVida.value <= 0 && sliderFlag){
            sliderFlag = false;
            vidasJugador--;
            textoVida.text = ""+vidasJugador;
            SaveVida();
            /* LLamar a una funcion con la animacion de muerte (Si es que la ponemos) */
            if(vidasJugador <= 0){
                textoVida.text = "0";
                Debug.Log("Estoy morido");
                RestartGame();
            }
            else {
                StartCoroutine(AnimacionMuerte());
            }
        }
    }

    IEnumerator AnimacionMuerte(){
        Destroy(jhonsito);
        yield return new WaitForSeconds(2f);
        MuertePersonaje();
    }

    public void MuertePersonaje()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setOnComplete(() =>
        {
            Invoke("MostrarVidas", 0.5f);
        });
    }

    private void MostrarVidas()
    {
        text_Restart.gameObject.SetActive(true);
        vidasRestart.text += textoVida.text;
        vidasRestart.enabled = true;
        corason.enabled = true;
        LeanTween.alpha(text_Restart, 0, 0f);
        LeanTween.alpha(text_Restart, 1, 2f).setOnComplete(() =>
        {
            Invoke("RestartScene", 0.4f);
            text_Restart.gameObject.SetActive(false);
            corason.enabled = false;
            vidasRestart.enabled = false;

        });
    }

    public void RestartScene(){
        SceneManager.LoadScene(levelActual);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
 
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed , Rigidbody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Enemigo")){
            QuitarVida(vidaQueQuitaEnemigo);
        }
    }

    /* Funcion para quitar vida a jhon */
    private void QuitarVida(int cantidad){
        if(invulnerable){
            return;
        }
        
        sliderVida.value -= cantidad;
        if(sliderVida.value > 0){
            invulnerable = true;
            StartCoroutine(MakeVulnerable());
        }
    }

    IEnumerator MakeVulnerable(){
        for(int i = 0; i < 12; i++){
            if(i % 2 == 0){
                jhonsito.enabled = false;
            }
            else {
                jhonsito.enabled = true;
            }
            yield return new WaitForSeconds(0.1f);
        }
        invulnerable = false;
    }

    private void SaveVida(){
        PlayerPrefs.SetInt(vidaPrefsname, vidasJugador);
    }

    private void LoadVida(){
        vidasJugador = PlayerPrefs.GetInt(vidaPrefsname);
    }

    public void RestartGame()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setOnComplete(() =>
        {
            Invoke("LoadText", 0.5f);
        });
    }

    private void LoadText()
    {
        text_transition.gameObject.SetActive(true);
        LeanTween.alpha(text_transition, 0, 0f);
        LeanTween.alpha(text_transition, 1, 2f).setOnComplete(() =>
        {
            Invoke("LoadScene", 0.4f);
            text_transition.gameObject.SetActive(false);

        });
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

}