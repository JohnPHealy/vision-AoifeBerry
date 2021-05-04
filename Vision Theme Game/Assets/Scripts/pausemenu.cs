using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
       if (Input.GetButtonDown("Cancel"))
        {
           // Debug.Log("Pressing escape");
            if(GameIsPaused)
         {
               Resume();
             Debug.Log("Paused");

           }else{

                Debug.Log("notPaused");
              Pause();
         }
        }
    }

   public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

        void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        SceneManager.LoadScene("menu");
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Debug.Log("Restart");
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
       
    }
}
