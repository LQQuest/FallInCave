using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject GameOverUI;

    public static bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false); 
        GameOverUI.SetActive(false); 
    }

    void Update()
    {
        if(Input.GetButtonDown("Pause")){
            paused = !paused;
        }
        if (paused){
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if(!paused){
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
        StartCoroutine(GameOverMenu());
    }

    public void PauseGame()
    {
        paused = true;
    }

    public void Resume ()
    {
        paused = false;
    }
    public void Restart()
    {
        
        SceneManager.LoadScene(1);
        Player.lose = false;
        paused = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }


    private IEnumerator GameOverMenu()
    {
        if (Player.lose)
        {
            yield return new WaitForSeconds(2f);
            GameOverUI.SetActive(true);
        }
        
    }
}
