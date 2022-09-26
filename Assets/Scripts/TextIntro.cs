using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextIntro : MonoBehaviour
{
    string frase = "The story begins when Jhon was in a \n furious sea...unfortunately it came out to \n be a castaway on a dessert island...at \n least that's what he thought... \n \n Can you help Jhon to fix his boat?";
    public Text texto;

    void Start()
    {
        StartCoroutine(Clock());
    }

    IEnumerator Clock()
    {
        foreach(char i in frase){
            texto.text += i;
            yield return new WaitForSeconds(0.06f);
        }
    }
}