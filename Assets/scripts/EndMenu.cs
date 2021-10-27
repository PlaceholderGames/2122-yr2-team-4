using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{


    public GameObject EnMenuUI;


    // Update is called once per frame
    void Update()
    {

        if (!IsEnemyAlive()) 
        {
            EnMenuUI.SetActive(true);
            //Time.timeScale = 0f;

        }
        
    }


    public bool IsEnemyAlive()
    {
        return GameObject.FindGameObjectWithTag("Enemy");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");

    }
}
