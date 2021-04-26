using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{ 

    public Animator DoorOpen;
    public int pickup = 0;
    public GameObject LastNote;
    public Rigidbody arrow;




    void start()
    {
        
    }

    void update()
    {
        LastNote = GameObject.Find("LastNote");
      
          

    }
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Door" && pickup >= 3)
        {

           
            //  Debug.Log("walked into door");
            DoorOpen.SetBool("Open", true);
            

        }

        if (col.gameObject.tag == "Arrow" && pickup >= 3)
        {

            Instantiate(arrow);


        }
    }

    public void OnTriggerExit(Collider col)
    {
     

        if (col.gameObject.tag == "Arrow" && pickup >= 3)
        {

            Instantiate(arrow);


        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Dino")
        {
           // Debug.Log("Dino");
           pickup++;
        }
        if (other.gameObject.tag == "Last" && pickup >= 3)
        {
            LastNote.SetActive(true);
            Time.timeScale = 0f;
            // Debug.Log("Dino");
           
        }
        if (other.gameObject.tag == "Paper")
        {
          //  Debug.Log("Paper");
            pickup++;
        }
        if (other.gameObject.tag == "Heart")
        {
           // Debug.Log("Heart");
                pickup++;
        }




    }
    public void resume()
    {
        Time.timeScale = 1f;
        LastNote.SetActive(false);
    }


}
