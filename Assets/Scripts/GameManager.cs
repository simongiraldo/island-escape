using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* public enum GameState{
    menu,
    intro,
    levelTrans, 
    level1,
    level2, 
    level3, 
    gameOver
}  */


public class GameManager : MonoBehaviour
{

/*     [SerializeField] public GameState currentGameState = GameState.menu; */
    public static GameManager shareInstance;

    [SerializeField] public int sceneNumber;
    public void ChangeScene(){
        SceneManager.LoadScene(sceneNumber);
    }

    void Awake(){
        if(shareInstance == null){
            shareInstance = this;
        }
    }
    public void ExitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else 
            Application.Quit();
        #endif
    }

    /* public void StartIntro(){
        SetGameState(GameState.intro);
    }

    public void StartLevelTrans(){
        SetGameState(GameState.levelTrans);
    }

    public void StartLevel1(){
        SetGameState(GameState.level1);
    }

    public void StartLevel2(){
        SetGameState(GameState.level1);
    }

    public void StartLevel3(){
        SetGameState(GameState.level1);
    }
    public void GameOver(){
        SetGameState(GameState.gameOver);

    }
    public void BackToMenu(){
        SetGameState(GameState.menu);

    } */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* if(Input.GetKeyDown(KeyCode.C) && currentGameState == GameState.intro){
            StartLevelTrans();
        }
        else if(Input.GetKeyDown(KeyCode.E)){
            BackToMenu();
        }
        else if(Input.GetButtonDown("Submit") && currentGameState == GameState.levelTrans){
            StartLevel1();
        } */

        /* if(currentGameState == GameState.menu){
            BackToMenu();
        }
        else if(currentGameState == GameState.intro){
            StartIntro();
        }
        else if(currentGameState == GameState.levelTrans){
            StartLevelTrans();
        }
        else if(currentGameState == GameState.level1){
            StartLevel1();
        }
        else if(currentGameState == GameState.level2){
            StartLevel2();
        }
        else if(currentGameState == GameState.level3){
            StartLevel3();
        }
        else if(currentGameState == GameState.gameOver){
            GameOver();
        }

    }

    private void SetGameState(GameState newGameState){
        if (newGameState == GameState.menu){
            MenuManager.sharedInstance.ShowMainMenu();
        }
        else if(newGameState == GameState.intro){
            MenuManager.sharedInstance.ShowIntro();
        }
        else if(newGameState == GameState.levelTrans){
            MenuManager.sharedInstance.ShowTransLevel();
        }
        else if(newGameState == GameState.level1){
            MenuManager.sharedInstance.ShowLevel1();
        }
        else if(newGameState == GameState.level2){
            MenuManager.sharedInstance.ShowLevel2();
        }
        else if(newGameState == GameState.level3){
            MenuManager.sharedInstance.ShowLevel3();
        } 
        else if(newGameState == GameState.gameOver){
            //TODO: hacer codigo game over
        }
        
        this.currentGameState = newGameState;*/
    } 
}