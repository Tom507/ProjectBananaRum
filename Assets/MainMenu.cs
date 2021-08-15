using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGame ()
    {
        SceneManager.LoadScene("WorldScene");
    }
    
    public void How2Play ()
    {
        SceneManager.LoadScene("How2PlayScene");
    }

    public void Options ()
    {

    }

    public void Credits ()
    {
        SceneManager.LoadScene("WorldScene");
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
