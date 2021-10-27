using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastLevelLoader : MonoBehaviour
{
    public Animator Transition;

    public float LoadingTime = 3.0f;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextLevel() //this weill call in the Unity level manager and load the next scene
    {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));       //The order of the levels can be set in the project build

    }

    IEnumerator LoadLevel(int levelIndex)
    {     //loading in the animation for the level transition


        yield return new WaitForSeconds(LoadingTime);

        Transition.SetTrigger("Start");

        SceneManager.LoadScene(levelIndex);

    }

    public bool IsEnemyAlive()
    {
        return GameObject.FindGameObjectWithTag("Enemy");


    }
}