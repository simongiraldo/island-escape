using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    /* [SerializeField] public Canvas menuCanvas;
    [SerializeField] public SpriteRenderer backgroundIntro;
    [SerializeField] public Canvas transLevelCanvas;
    [SerializeField] public SpriteRenderer backgroundLevel1;
    [SerializeField] public SpriteRenderer backgroundLevel2;
    [SerializeField] public SpriteRenderer backgroundLevel3; */
    /* Background1 2 y 3 son SpriteRenderer, canvas es solo para el ejemplo */
    /* [SerializeField] public Canvas gameOverCanvas; */
    public static MenuManager sharedInstance;

   /*  public List<MenuManager> stateTypes = new List<MenuManager>() {
        menuCanvas,
        backgroundIntro,
        transLevelCanvas,
        backgroundLevel1,
        backgroundLevel2,
        backgroundLevel3,
        gameOverCanvas};  */

    /* public List<GameManager.GameState> gameStates = new list<GameManager.GameState>(){
        GameManager.shareInstance.GameState.menu, 
        GameManager.shareInstance.GameState.intro, 
        GameManager.shareInstance.GameState.levelTrans, 
        GameManager.shareInstance.GameState.level1, 
        GameManager.shareInstance.GameState.level2, 
        GameManager.shareInstance.GameState.level3, 
        GameManager.shareInstance.GameState.gameOver}; */

    void Awake(){
        if(sharedInstance == null){
            sharedInstance = this;
        }
    }

    /* public void Show(GameState state){
        for(int i = 0; i < stateTypes.Count(); i++)
        {
         if(stateTypes[i] == state){
            stateTypes[i-1].enabled = true;
         }   
         else {
            stateTypes[i].enabled = false;
         }
        }
    } */

   /*  public void ShowMainMenu(){
        menuCanvas.enabled = true;
        backgroundIntro.enabled = false;
        transLevelCanvas.enabled = false;
        backgroundLevel1.enabled = false;
        backgroundLevel2.enabled = false;
        backgroundLevel3.enabled = false;
        gameOverCanvas.enabled = false;
    }

    public void ShowIntro(){
        menuCanvas.enabled = false;
        backgroundIntro.enabled = true;
        transLevelCanvas.enabled = false;
        backgroundLevel1.enabled = false;
        backgroundLevel2.enabled = false;
        backgroundLevel3.enabled = false;
        gameOverCanvas.enabled = false;
    }
    public void ShowTransLevel(){
        menuCanvas.enabled = false;
        backgroundIntro.enabled = false;
        transLevelCanvas.enabled = true;
        backgroundLevel1.enabled = false;
        backgroundLevel2.enabled = false;
        backgroundLevel3.enabled = false;
        gameOverCanvas.enabled = false;
    }
    public void ShowLevel1(){
        menuCanvas.enabled = false;
        backgroundIntro.enabled = false;
        transLevelCanvas.enabled = false;
        backgroundLevel1.enabled = true;
        backgroundLevel2.enabled = false;
        backgroundLevel3.enabled = false;
        gameOverCanvas.enabled = false;
    }
    public void ShowLevel2(){
        menuCanvas.enabled = false;
        backgroundIntro.enabled = false;
        transLevelCanvas.enabled = false;
        backgroundLevel1.enabled = false;
        backgroundLevel2.enabled = true;
        backgroundLevel3.enabled = false;
        gameOverCanvas.enabled = false;
    }
    public void ShowLevel3(){
        menuCanvas.enabled = false;
        backgroundIntro.enabled = false;
        transLevelCanvas.enabled = false;
        backgroundLevel1.enabled = false;
        backgroundLevel2.enabled = false;
        backgroundLevel3.enabled = true;
        gameOverCanvas.enabled = false;
    }
    public void ShowGameOver(){
        menuCanvas.enabled = false;
        backgroundIntro.enabled = false;
        transLevelCanvas.enabled = false;
        backgroundLevel1.enabled = false;
        backgroundLevel2.enabled = false;
        backgroundLevel3.enabled = false;
        gameOverCanvas.enabled = true;
    }
 */
    

}
