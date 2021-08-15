using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndgameLose : MonoBehaviour {
    public void Back2Menu ()
    {
        SceneManager.LoadScene("Main Screen");
    }
}