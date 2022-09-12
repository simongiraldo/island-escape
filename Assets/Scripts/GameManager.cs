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
    [SerializeField] public Canvas menuCanvas;
    [SerializeField] public Canvas settingsCanvas;
    [SerializeField] public Canvas infoCanvas;
    [SerializeField] public Canvas controlsCanvas;

    public void ChangeScene(){
        SceneManager.LoadScene(sceneNumber);
    }

    public void ShowSettings(){
        menuCanvas.enabled = false;
        settingsCanvas.enabled = true;
    }

    public void ShowInfo(){
        menuCanvas.enabled = false;
        infoCanvas.enabled = true;
    }

    public void ShowControls(){
        menuCanvas.enabled = false;
        controlsCanvas.enabled = true;
    }

    public void SettingsToMenu(){
        menuCanvas.enabled = true;
        settingsCanvas.enabled = false;
    }

    public void InfoToMenu(){
        menuCanvas.enabled = true;
        infoCanvas.enabled = false;
    }

    public void ControlsToMenu(){
        menuCanvas.enabled = true;
        controlsCanvas.enabled = false;
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

    }

    private void SetGameState(GameState newGameState){
        if (newGameState == GameState.menu){
            MenuManager.sharedInstance.ShowMainMenu();
        }
        
        this.currentGameState = newGameState;*/
    } 
    void Start(){
        menuCanvas.enabled = true;
        settingsCanvas.enabled = false;
        infoCanvas.enabled = false;
        controlsCanvas.enabled = false;
    }
}