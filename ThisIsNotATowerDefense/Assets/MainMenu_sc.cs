using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_sc : MonoBehaviour
{
   public void playGame()
    {
        SceneManager.LoadScene("Main");
    }
}
