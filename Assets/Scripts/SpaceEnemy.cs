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
    [SerializeField] Canvas canvasTikTakToe;
    string frase = "Now Jhon is in a coma...he couldn't beat the spaceman... \nIn his dream, Jhon is playing tic-tac-toe, try to help him \n ...This is your last chance to win...";
    public Text texto;
    bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<JhonMove>().transform;
        canvasTikTakToe.enabled = false;
        enemy.enabled = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction * Time.deltaTime * speed;

        float horiontal = Input.GetAxis("Horizontal");

        if(horiontal > 0){
            enemy.flipX = false;
        }
        if(horiontal < 0){
            enemy.flipX = true;
        }

        if(canvasTikTakToe.enabled = true && flag){
            flag = false;
            StartCoroutine(Clock());
        }
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            Invoke("PlayTictactoe", 0.3f);
        }
    }

    void PlayTictactoe(){
        canvasTikTakToe.enabled = true;
        transform.localScale = new Vector3(0, 0, 0);
        enemy.enabled = false;
    }

    IEnumerator Clock()
    {
        foreach(char i in frase){
            texto.text += i;
            yield return new WaitForSeconds(0.08f);
        }
    }

    /* -Algun enemigo toca al jugador
        -Se abre el canvas explicando lo que paso
        -Se juega el triki imp hasta que se haga trampa
        -Cuando gana, se muestra you win y se dice que jhon desperto del coma
        -Se quita el canvvas del triki
        -Aparece otra ves los enemigos y explotan con la animacion
        -aparece un canvas negro con jhon y el barco completado con el you win, tambien un boton de back to menu */

} 
