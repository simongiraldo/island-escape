using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubSettings : MonoBehaviour
{
    [SerializeField] public Canvas submenuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        submenuCanvas.enabled = false;
    }

    public void SubmenuActive(){
        submenuCanvas.enabled = true;
    }
    public void SubmenuInactive(){
        submenuCanvas.enabled = false;
    }
    public void GoMenu(){
        SceneManager.LoadScene(0);
    }
}
