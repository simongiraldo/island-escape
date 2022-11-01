using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class coma : MonoBehaviour
{
    string frase = "Now Jhon is in a coma...he couldn't beat the spaceman... \nIn his dream, Jhon is playing tic-tac-toe, try to help him \n ...This is your last chance to win...";
    public Text texto;
    [SerializeField] Image corner1;
    [SerializeField] Image edge1;
    [SerializeField] Image corner2;
    [SerializeField] Image edge2;
    [SerializeField] Image center;
    [SerializeField] Image edge3;
    [SerializeField] Image corner3;
    [SerializeField] Image edge4;
    [SerializeField] Image corner4;
    [SerializeField] Image panelTriki;
    [SerializeField] Image enemigoImg;
    [SerializeField] Image jhonImg;
    [SerializeField] Image restartButton;
    [SerializeField] Image settingButton;


    // Start is called before the first frame update
    void Start()
    {
        corner1.enabled = false;
        edge1.enabled = false;
        edge2.enabled = false;
        edge3.enabled = false;
        center.enabled = false;
        edge4.enabled = false;
        corner2.enabled = false;
        corner3.enabled = false;
        corner4.enabled = false;
        panelTriki.enabled = false;
        enemigoImg.enabled = false;
        jhonImg.enabled = false;
        restartButton.enabled = false;
        settingButton.enabled = false;
        StartCoroutine(Clock());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Clock()
    {
        yield return new WaitForSeconds(1f);
        foreach(char i in frase){
            texto.text += i;
            yield return new WaitForSeconds(0.06f);
        }

        jhonImg.enabled = true;
        enemigoImg.enabled = true;
        yield return new WaitForSeconds(1f);
        corner1.enabled = true;
        edge1.enabled = true;
        edge2.enabled = true;
        edge3.enabled = true;
        center.enabled = true;
        edge4.enabled = true;
        corner2.enabled = true;
        corner3.enabled = true;
        corner4.enabled = true;
        panelTriki.enabled = true;
        restartButton.enabled = true;
        settingButton.enabled = true;
    }
}
