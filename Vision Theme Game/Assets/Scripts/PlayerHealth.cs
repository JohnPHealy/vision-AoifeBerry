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
    public Animator gateOpen;
    public GameObject Text;



    public Transform SpawnPoint;
    public int GreenKeys = 0;
    public int RedKeys = 0;
    public int BlueKeys = 0;


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
        if (other.gameObject.tag == "Lever")
        {

            gateOpen.SetBool("GateOpen", true);
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
        if (other.gameObject.tag == "RedKey")
        {
            RedKeys++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BlueKey")
        {
            BlueKeys++;
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

        if (other.gameObject.tag == "BlueDoor" && BlueKeys >= 1)
        {
            Debug.Log("open1");
            DoorOpen.SetBool("Open1", true);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "BlueDoor" && BlueKeys >= 0)
        {
            Text.SetActive(true);
        }

        if (other.gameObject.tag == "RedDoor" && RedKeys >= 1)
        {
            Debug.Log("open2");
            DoorOpen.SetBool("Open2", true);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "RedDoor" && RedKeys >= 0)
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
        if (other.gameObject.tag == "BlueDoor")
        {

            Text.SetActive(false);
        }
        if (other.gameObject.tag == "RedDoor")
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