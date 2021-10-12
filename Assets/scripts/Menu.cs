using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void PLayeGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
    }


    public void EndGame() {

        Application.Quit();
    }

}
