using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static System.Random;
using UnityEngine.SceneManagement;

public class Triki : MonoBehaviour
{
    [SerializeField] Canvas trikiCanvas;
    [SerializeField] Canvas backgroundCanvas;
    [SerializeField] Canvas stuffCanvas;
    [SerializeField] RectTransform background;
    [SerializeField] Button corner1;
    [SerializeField] Button edge1;
    [SerializeField] Button corner2;
    [SerializeField] Button edge2;
    [SerializeField] Button center;
    [SerializeField] Button edge3;
    [SerializeField] Button corner3;
    [SerializeField] Button edge4;
    [SerializeField] Button corner4;

    [SerializeField] Text cor1;
    [SerializeField] Text edg1;
    [SerializeField] Text cor2;
    [SerializeField] Text edg2;
    [SerializeField] Text cntr;
    [SerializeField] Text edg3;
    [SerializeField] Text cor3;
    [SerializeField] Text edg4;
    [SerializeField] Text cor4;
    [SerializeField] Text whoText;

    string wins = "";
    List<int> winNumbers = new List<int>();
    private bool stillplaying = true;
    bool userWins = false;
    List<int> voidPositions = new List<int>(){1, 2, 3, 4, 5, 6, 7, 8, 9};
    List<Text> textList = new List<Text>();/* Aca voy */
    List<Button> buttonsList = new List<Button>();
    List<int> selectedPositionsU = new List<int>();
    List<int> selectedPositionsM = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        backgroundCanvas.enabled = false;
        buttonsList.Add(corner1);
        buttonsList.Add(edge1);
        buttonsList.Add(corner2);
        buttonsList.Add(edge2);
        buttonsList.Add(center);
        buttonsList.Add(edge3);
        buttonsList.Add(corner3);
        buttonsList.Add(edge4);
        buttonsList.Add(corner4);

        textList.Add(cor1);
        textList.Add(edg1);
        textList.Add(cor2);
        textList.Add(edg2);
        textList.Add(cntr);
        textList.Add(edg3);
        textList.Add(cor3);
        textList.Add(edg4);
        textList.Add(cor4);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(int botonEscogido){
        if (stillplaying){
            UserMove(botonEscogido, textList[botonEscogido - 1]);
            Validatewin(selectedPositionsU);
        }

        if (stillplaying){
            int mmove = RandomSelection();
            MachineMove(mmove, textList[mmove - 1]);
        }
    }

    private void UserMove(int num, Text texto){
        selectedPositionsU.Add(num);
        voidPositions.Remove(num);
        texto.text = "X";
        texto.color = Color.red;
        buttonsList[num - 1].enabled = false;
    }

    private void MachineMove(int num, Text texto){
        selectedPositionsM.Add(num);
        voidPositions.Remove(num);
        texto.text = "O";
        texto.color = Color.blue;
        buttonsList[num - 1].enabled = false;
        Validatewin(selectedPositionsM);
    }

    private void Validatewin(List<int> selections){
        for (int sumPattern = 1; sumPattern <= 4; sumPattern++){
            foreach (int i in selections){
                int j = i + sumPattern;
                int k = j + sumPattern;
                if(sumPattern >= 3){ /* Vertical and 1 diagonal */
                    if(selections.Contains(i) && selections.Contains(j) && selections.Contains(k)){
                        stillplaying = false;
                        winNumbers.Add(i);
                        winNumbers.Add(j);
                        winNumbers.Add(k);
                        gameOver(selections, winNumbers);
                        break;
                    }
                }
                else if(sumPattern < 3){ /* Horizontal and 1 diagonal */
                    if(selections.Contains(i) && selections.Contains(j) && selections.Contains(k) && ((i + j + k) == 6 || (i + j + k) == 15 || (i + j + k) == 24)){
                        stillplaying = false; 
                        winNumbers.Add(i);
                        winNumbers.Add(j);
                        winNumbers.Add(k);
                        gameOver(selections, winNumbers);
                        break;
                    }
                }
            }
        }
        if(voidPositions.Count == 0 && stillplaying){
            stillplaying = false;
            winNumbers.Add(10);
            gameOver(winNumbers, winNumbers);
            Debug.Log("Game over");
        }
    }

    private int RandomSelection(){
        System.Random rnd = new System.Random();
        int number = rnd.Next(1, 10);
        if(voidPositions.Contains(number)){
            return number;
        }
        else if(voidPositions.Count == 0){
            return 999999;
        }
        else {
            return RandomSelection();
        }
    }

    public void SetGame(){
        stillplaying = true;
        userWins = false;
        whoText.text = "";
        wins = "";
        winNumbers.Clear();
        selectedPositionsU.Clear();
        selectedPositionsM.Clear();
        voidPositions.Clear();
        voidPositions.Add(1);
        voidPositions.Add(2);
        voidPositions.Add(3);
        voidPositions.Add(4);
        voidPositions.Add(5);
        voidPositions.Add(6);
        voidPositions.Add(7);
        voidPositions.Add(8);
        voidPositions.Add(9);
        for(int i = 0; i < buttonsList.Count; i++){
            textList[i].text = "";
            buttonsList[i].enabled = true;
        }
    }

    private void gameOver(List<int> who, List<int>numbers){
        bool winner = false;
        if(who == selectedPositionsU){
            winner = true;
            userWins = true;
            wins = "You win...";
            Debug.Log("Gano con: "+numbers[0]+numbers[1]+numbers[2]);
        }
        else if(who == selectedPositionsM){
            winner = true;
            wins = "You lose...try again";
            Debug.Log("perdio con: "+numbers[0]+numbers[1]+numbers[2]);
        }
        else {
            wins = "Tie...try again";
        }

        StartCoroutine(whoWins());

        if(winner){
            for(int i = 1; i <= textList.Count; i++){
                if(numbers.Contains(i)){
                    textList[i-1].color = Color.green;
                }
            }
            
        }
    }
    
    IEnumerator whoWins()
    {
        yield return new WaitForSeconds(1.5f);
        whoText.text = wins;
        if(userWins){
            StartCoroutine(HideTriki());
        }
    }
    IEnumerator HideTriki()
    {
        yield return new WaitForSeconds(2f);
        trikiCanvas.enabled = false;
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
            SceneManager.LoadScene(5);
        });
    }
    private void ShowFinalScene()
    {
        SceneManager.LoadScene(5);
        backgroundCanvas.enabled = false;

    }


    
    
}

/* -Terminar la funcion setGame y ponercela a un boton de restart, el icono esta en la carpeta de icons creo
    -Hacer el validateWin y mostrar si el usuario perdio o empato
    -Hacer el impossibleselection
    
    Para el MARTES:
    -Solo tenerlo en modo easySelection y mostrar la animacion de cuando mueren los spacemans, arma el barco y muestra que gana */
