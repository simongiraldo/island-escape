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
    public bool userWins = false;
    List<int> voidPositions = new List<int>(){1, 2, 3, 4, 5, 6, 7, 8, 9};
    List<Text> textList = new List<Text>();
    List<Button> buttonsList = new List<Button>();
    List<int> selectedPositionsU = new List<int>();
    List<int> selectedPositionsM = new List<int>();
    List<List<int>> where = new List<List<int>>();
    int mmove;

    // Start is called before the first frame update
    void Start()
    {
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
            mmove = impossibleSelection(selectedPositionsU);
            StartCoroutine(tiempoTrampa());
        }
    }

    IEnumerator tiempoTrampa(){
        yield return new WaitForSeconds(0.8f);
        MachineMove(mmove, textList[mmove - 1]);
    }

    private int impossibleSelection(List<int> used){
        if(used.Count == 1){
            /* When user starts on corner */
            if (used[0] % 2 != 0 && used[0] != 5) {
                where = setImpossible(used[0]);
                return 5;
            }
            else if (used[0] % 2 == 0) {/* When user starts on edge */
                where = setImpossible(used[0]);
                return where[1][0];
            }
            else if (used[0] == 5) {/* When user starts on center */
                where = setImpossible(used[0]);
                return 7;
            }
        }
        if(used.Count > 1){
            bool win = almostWinB(selectedPositionsM);
            bool block = almostWinB(used);
            bool trick = analyzeImpossibleB(used);

            if (win) {
                int numbersito = almostWinI(selectedPositionsM);
                return numbersito;
            }
            else if (block) {
                int numbersito = almostWinI(used);
                return numbersito;
            }
            else if (trick) {
                int numbersito = analyzeImpossibleI(used);
                return numbersito;
            }
            else {
                return RandomSelection();
            }
        }
        return 10;  /* esto es temporal para que unity no joda */
        
        /* Aca voyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy  */
        /* if(used.Count > 1){
            let win = almostWin(selectedPositionsM);
            if (win == true) {
                let win = almostWin(selectedPositionsM);
                return win[0]; 
        }
            -Separar almostwin en dos iguaes, una con bool y otra con int, si true ent se analisa int
            -Lo mismo con analiseimpossible de dos iguales, si true, se analisa int 
            -Primero llamar los 3 booleanos


            Si el codigo tiene errores, puede ser porque hay que hacerle reverse a la selestedpositionsU

        } */
    }

    private bool almostWinB(List<int> used){
        for (int j = 1; j <= 4; j++) {
            for (int k = 1; k <= 7;) {
                if (j == 2) {
                    k = 3;
                }
                if (used.Contains(k) && used.Contains(k + j)) {
                    if (voidPositions.Contains((k + (2 * j)))) {
                        return true;
                    }
                }
                else if (used.Contains(k) && used.Contains(k + (2 * j))) {
                    if (voidPositions.Contains((k + j))) {
                        return true;
                    }
                }
                else if (used.Contains(k + j) && used.Contains(k + (2 * j))) {
                    if (voidPositions.Contains((k))) {
                        return true;
                    }
                }   
                if (j == 1) {
                    k += 3;
                }
                else if (j == 2) {
                    break;
                }
                else if (j == 3) {
                    k++;
                    if (k > 3) {
                        break;
                    }
                }   
                else if (j == 4) {
                    return false;
                }
            }
        }
        return false;
    }
    private int almostWinI(List<int> used){
        for (int j = 1; j <= 4; j++) {
            for (int k = 1; k <= 7;) {
                if (j == 2) {
                    k = 3;
                }
                if (used.Contains(k)  && used.Contains(k + j)) {
                    if (voidPositions.Contains((k + (2 * j)))) {
                        return (k + (2 * j));
                    }
                }
                else if (used.Contains(k)  && used.Contains(k + (2 * j)) ){
                    if (voidPositions.Contains((k + j)) ) {
                        return (k + j);
                    }
                }
                else if (used.Contains(k + j)  && used.Contains(k + (2 * j))) {
                    if (voidPositions.Contains((k))) {
                        return (k);
                    }
                }   
                if (j == 1) {
                    k += 3;
                }
                else if (j == 2) {
                    break;
                }
                else if (j == 3) {
                    k++;
                    if (k > 3) {
                        break;
                    }
                } 
            }
        }
        return 10;
    }

    private bool analyzeImpossibleB(List<int> user){
        /* CORNER: */
    if (where[0].Count == 1) {
        if (user.Count == 2) {
            if(user[0] == where[0][0] || user[0] == where[3][0]){
                Debug.Log("funciona");
                return true;
            }
            else if (user[0] == where[3][1]) {
                return true;
            }
        }
        else if (user.Count == 3) {
            if (user[0] == where[3][1]) {
                return true;
            }
            else if (user[0] == where[3][0]) {
                return true;
            }
        }
        else {
            return false;
        }
    }
    /* EDGE: */
    else if (where[0].Count == 2) {
        if (user.Count == 2) {
            if (user[0] == where[1][1] || user[0] == where[4][0] || user[0] == where[4][1] || user[0] == where[0][0] || user[0] == where[0][1]) {
                return true;
            }
        }
        else {
            return false;
        }

    }
    /* CENTER: */
    else if(where[0].Count == 4){
        if(user.Count == 2){
            if(user[0] == where[0][1]){
                return true;
            }
        }
        else {
            return false;
        }
    }

    return false;
    }

    private int analyzeImpossibleI(List<int> user){
    if (where[0].Count == 1) {
        if (user.Count == 2) {
            if (user[0] == where[0][0] || user[0] == where[3][0]) {
                return where[4][0];
            }
            else if (user[0] == where[3][1]) {
                return where[4][1];
            }
        }
        else if (user.Count == 3) {
            if (user[0] == where[3][1]) {
                return where[1][1];
            }
            else if (user[0] == where[3][0]) {
                return where[1][0];
            }
        }
    }
    /* EDGE: */
    else if (where[0].Count == 2) {
        if (user.Count == 2) {
            if (user[0] == where[1][1] || user[0] == where[4][0] || user[0] == where[4][1] || user[0] == where[0][0] || user[0] == where[0][1]) {
                return 5;
            }
        }

    }
    /* CENTER: */
    else if(where[0].Count == 4){
        if(user.Count == 2){
            if(user[0] == where[0][1]){
                return where[0][3];
            }
        }
    }

    return 10;
    }

    private List<List<int>> setImpossible(int x){
        List<int> oppCorners = new List<int>();
        List<int> adjCorners = new List<int>();
        List<int> adjEdges = new List<int>();
        List<int> oppEdges = new List<int>();
        List<int> setCenter = new List<int>{5};

        switch(x){
            case 1:
                oppCorners.Add(9);
                adjCorners.Add(3);
                adjCorners.Add(7);
                oppEdges.Add(6);
                oppEdges.Add(8);
                adjEdges.Add(2);
                adjEdges.Add(4);
                break;
            case 2:
                oppCorners.Add(7);
                oppCorners.Add(9);
                adjCorners.Add(1);
                adjCorners.Add(3);
                oppEdges.Add(8);
                adjEdges.Add(4);
                adjEdges.Add(6);
                break;
            case 3:
                oppCorners.Add(7);
                adjCorners.Add(1);
                adjCorners.Add(9);
                oppEdges.Add(4);
                oppEdges.Add(8);
                adjEdges.Add(2);
                adjEdges.Add(6);
                break;
            case 4:
                oppCorners.Add(3);
                oppCorners.Add(9);
                adjCorners.Add(1);
                adjCorners.Add(7);
                oppEdges.Add(8);
                adjEdges.Add(2);
                adjEdges.Add(8);
                break;
            case 5:
                oppCorners.Add(1);
                oppCorners.Add(3);
                oppCorners.Add(7);
                oppCorners.Add(9);
                break;
            case 6:
                oppCorners.Add(1);
                oppCorners.Add(7);
                adjCorners.Add(3);
                adjCorners.Add(9);
                oppEdges.Add(4);
                adjEdges.Add(2);
                adjEdges.Add(8);
                break;
            case 7:
                oppCorners.Add(3);
                adjCorners.Add(1);
                adjCorners.Add(9);
                oppEdges.Add(2);
                oppEdges.Add(6);
                adjEdges.Add(4);
                adjEdges.Add(8);
                break;
            case 8:
                oppCorners.Add(1);
                oppCorners.Add(3);
                adjCorners.Add(7);
                adjCorners.Add(9);
                oppEdges.Add(2);
                adjEdges.Add(4);
                adjEdges.Add(6);
                break;
            case 9:
                oppCorners.Add(1);
                adjCorners.Add(3);
                adjCorners.Add(7);
                oppEdges.Add(2);
                oppEdges.Add(4);
                adjEdges.Add(6);
                adjEdges.Add(8);
                break;
            default:
                break;  
        }
        List<List<int>> finalList = new List<List<int>>();
        finalList.Add(oppCorners);
        finalList.Add(adjCorners);
        finalList.Add(setCenter);
        finalList.Add(oppEdges);
        finalList.Add(adjEdges);
        return finalList;
    }

    private void UserMove(int num, Text texto){
        selectedPositionsU.Add(num);
        selectedPositionsU.Reverse();
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


    /* Saber si un jugador gana */
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

    /* Escoge aleatorio una posicion */
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

    /* setea los calores iniciales */
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
        where.Clear();
        for(int i = 0; i < buttonsList.Count; i++){
            textList[i].text = "";
            buttonsList[i].enabled = true;
        }
    }

    /* Cuando se acaba el juego, muestra quien gana */
    private void gameOver(List<int> who, List<int>numbers){
        bool winner = false;
        if(who == selectedPositionsU){
            winner = true;
            userWins = true;
            wins = "You win";
            Debug.Log("Gano con:  "+numbers[0]+numbers[1]+numbers[2]);
        }
        else if(who == selectedPositionsM){
            winner = true;
            wins = "You lose";
            Debug.Log("perdio con: "+numbers[0]+numbers[1]+numbers[2]);
        }
        else {
            wins = "Tie";
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
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(4);
    }
    


    
    
}
