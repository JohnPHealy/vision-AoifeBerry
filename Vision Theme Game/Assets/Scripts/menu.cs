using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject Info;
    public GameObject Controls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
       //Info = GameObject.Find("Info");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void RestartGame()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene("SampleScene");
        
    }
    public void Information()
    {
        Info.SetActive(true);

    }
    public void backInformation()
    {
        Info.SetActive(false);
        Controls.SetActive(false);

    }
    public void backtoMenu()
    {
        SceneManager.LoadScene("Menu");

    }
    public void menuControls()
    {
        Controls.SetActive(true);

    }
}
