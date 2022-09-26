using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    [SerializeField] public int sceneNumber;
    [SerializeField] RectTransform fader;
    [SerializeField] RectTransform text_transition;



    void Start()
    {
        fader.gameObject.SetActive(true);
        text_transition.gameObject.SetActive(false);

        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });
    }


    public void ChangeScene()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setOnComplete(() =>
        {
            Invoke("LoadText", 0.5f);
        });
    }

    private void LoadText()
    {
        text_transition.gameObject.SetActive(true);
        LeanTween.alpha(text_transition, 0, 0f);
        LeanTween.alpha(text_transition, 1, 2f).setOnComplete(() =>
        {
            Invoke("LoadScene", 0.4f);
            text_transition.gameObject.SetActive(false);

        });
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }



}
