using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Essay : MonoBehaviour
{

    public GameObject noteDino;
    public GameObject notePaper;
    public GameObject noteHeart;
    public GameObject firstNote;
   


    void Awake()
    {
        Time.timeScale = 0f;

    }
    void update()
    {
        noteDino = GameObject.Find("noteDino");
        noteDino = GameObject.Find("notePaper");
        noteDino = GameObject.Find("noteHeart");
        firstNote = GameObject.Find("firstNote");
        

    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Dino")
        {
          
            noteDino.SetActive(true);
            Time.timeScale = 0f;
           // Debug.Log("Dino"); 

        }
        if (other.gameObject.tag == "Paper")
        {
            notePaper.SetActive(true);
            Time.timeScale = 0f;
          //  Debug.Log("Paper");
        }
        if (other.gameObject.tag == "Heart")
        {
            noteHeart.SetActive(true);
            Time.timeScale = 0f;
           // Debug.Log("Heart");
        }
       

        if (other.gameObject.tag == "finish")
        {
            SceneManager.LoadScene("end");
        }



    }

    public void resume()
    {
        Time.timeScale = 1f;
        noteDino.SetActive(false);
        notePaper.SetActive(false);
        noteHeart.SetActive(false);
        firstNote.SetActive(false);
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
