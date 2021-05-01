using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour


{
    //health
    public int maxHealth = 10;
    public int currentHealth;
    public int damage = 1;
    public healthBar healthBar;
    public Animator DoorOpen;
    public GameObject Text;



    public Transform SpawnPoint;
    public int GreenKeys = 0;

    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

   

    }

  

  
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpikeDamage")
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

        }

        if (other.gameObject.tag == "Fall")
        {
            SceneManager.LoadScene("SampleScene");

        }
        if (other.gameObject.tag == "Enemy")
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }

        if (other.gameObject.tag == "GreenKey")
        {
            GreenKeys++;
            Destroy(other.gameObject);
        }


        if (other.gameObject.tag == "GreenDoor" && GreenKeys >= 1)
        {
            Debug.Log("open");
                    DoorOpen.SetBool("Open", true);

        }
        else if (other.gameObject.tag == "GreenDoor" && GreenKeys >= 0)
        {
            Text.SetActive(true);
        }


    

    }

   public void OnTriggerExit(Collider other)
    {
     

       if (other.gameObject.tag == "GreenDoor")
       {
           


          Text.SetActive(false);

       }

  }


    void Update()
    {
        if (currentHealth <= 0)
        {

            SceneManager.LoadScene("SampleScene");
        }
    }
}