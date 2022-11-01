using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpaceEnemy : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 1;
    [SerializeField] SpriteRenderer enemy;
    [SerializeField] Slider sliderVida;

    [SerializeField] Canvas backgroundCanvas;
    [SerializeField] Canvas stuffCanvas;
    [SerializeField] RectTransform background; 
    private string ganoPrefsname = "Gano";
    private int ganoo = 0;
    private int levelActual;
    [SerializeField] Slider sliderBoleano;

    // Start is called before the first frame update

    void Awake(){
        LoadGano();
        if(sliderBoleano.value == 50 && ganoo == 3){
            Debug.Log("coronation");
            StartCoroutine(mostrarFinal());
        } 
        else if(sliderBoleano.value == 40){
            ganoo = 3;
            SaveGano();
        }

    }

    void OnDestroy(){
        SaveGano();
    }


    void OnLevelWasLoaded(int level){
        if(level == 4){
            ganoo = 0;
            SaveGano();
        }
        levelActual = level;
    }
    void Start()
    {
        if(levelActual == 4){
            backgroundCanvas.enabled = false;
            player = FindObjectOfType<JhonMove>().transform;
            enemy.enabled = true;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(levelActual == 4){
            Vector2 direction = player.position - transform.position;
            transform.position += (Vector3)direction * Time.deltaTime * speed;

            float horiontal = Input.GetAxis("Horizontal");

            if(horiontal > 0){
                enemy.flipX = false;
            }
            if(horiontal < 0){
                enemy.flipX = true;
            }
        }

    }

    private void SaveGano(){
        PlayerPrefs.SetInt(ganoPrefsname, ganoo);
    }

    private void LoadGano(){
        ganoo = PlayerPrefs.GetInt(ganoPrefsname, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            if(sliderVida.value <= 10){
                SceneManager.LoadScene(5);
            }
        }
    }

    IEnumerator mostrarFinal(){
        if(sliderBoleano.value == 50){
            Debug.Log("Confirmamos coronation");
            yield return new WaitForSeconds(2f);
            Destroy(enemy);
            enemy.enabled = false;
        }
        StartCoroutine(PrepareTransitionScene());
    }

    IEnumerator PrepareTransitionScene()
    {
        yield return new WaitForSeconds(2f);
        backgroundCanvas.enabled = true;
        stuffCanvas.enabled = false;
        background.gameObject.SetActive(true);
        StartCoroutine(TransitionWin());
        
    }
    IEnumerator TransitionWin()
    {
        yield return new WaitForSeconds(1.5f);
        background.gameObject.SetActive(true);
        LeanTween.scale(background, new Vector3(1, 1, 1), 0f);
        LeanTween.scale(background, new Vector3(250, 250, 250), 4.5f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
        {
            SceneManager.LoadScene(6);
        });
    }
    private void ShowFinalScene()
    {
        SceneManager.LoadScene(6);
        backgroundCanvas.enabled = false;

    }

    

    /* -Algun enemigo toca al jugador
        -Se abre el canvas explicando lo que paso
        -Se juega el triki imp hasta que se haga trampa
        -Cuando gana, se muestra you win y se dice que jhon desperto del coma
        -Se quita el canvvas del triki
        -Aparece otra ves los enemigos y explotan con la animacion
        -aparece un canvas negro con jhon y el barco completado con el you win, tambien un boton de back to menu */

} 
