using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScene : MonoBehaviour
{
    // Start is called before the first frame update
    string frase = "You helped Jhon fixing his boat, now he can leave the island to go back home";
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
