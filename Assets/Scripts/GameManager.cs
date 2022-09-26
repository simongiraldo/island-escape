using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Este script es solo para el menu */


public class GameManager : MonoBehaviour
{

    public static GameManager shareInstance;

    [SerializeField] public Canvas menuCanvas;
    [SerializeField] public Canvas settingsCanvas;
    [SerializeField] public Canvas infoCanvas;
    [SerializeField] public Canvas controlsCanvas;

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

    void Start(){
        menuCanvas.enabled = true;
        settingsCanvas.enabled = false;
        infoCanvas.enabled = false;
        controlsCanvas.enabled = false;
    }
}