using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndgameWin : MonoBehaviour {
    public void Back2Menu ()
    {
        SceneManager.LoadScene("Main Screen");
    }
}
