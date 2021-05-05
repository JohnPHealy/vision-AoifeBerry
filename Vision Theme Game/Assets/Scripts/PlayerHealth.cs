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
    public GameObject GreenKey;
    public GameObject BlueKey;
    public GameObject RedKey;
    public Animator playerAnimator;
    public GameObject player;
    public GameObject Blood;


    public Transform SpawnPoint;
    public int GreenKeys = 0;
    public int RedKeys = 0;
    public int BlueKeys = 0;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerAnimator = GetComponentInChildren<Animator>();
        Blood.SetActive(false);



    }

  

  
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpikeDamage")
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            Blood.SetActive(true);
            StartCoroutine(coroutineBlood());

        }
        else
        {
            playerAnimator.SetBool("Damage", false);
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
            StartCoroutine(coroutineBlood());
        }

        if (other.gameObject.tag == "GreenKey")
        {
            GreenKeys++;
            GreenKey.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "RedKey")
        {
            RedKeys++;
            RedKey.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "BlueKey")
        {
            BlueKeys++;
            BlueKey.SetActive(true);
            Destroy(other.gameObject);
        }


        if (other.gameObject.tag == "GreenDoor" && GreenKeys >= 1)
        {
            Debug.Log("open");
            GreenKey.SetActive(false);
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
            BlueKey.SetActive(false);
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
            RedKey.SetActive(false);
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
            playerAnimator.SetBool("dead", true);
            Debug.Log("dead");
            player.GetComponent<SecondPlayerMovement>().enabled = false;
            StartCoroutine(coroutineB());

        }
    }

    IEnumerator coroutineB()
    {
        // wait for 1 second
        while (currentHealth <= 0)
        {
            
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("SampleScene");

        }



    }
    IEnumerator coroutineBlood()
    {
        // wait for 1 second
        while (currentHealth >=1)
        {
            
            yield return new WaitForSeconds(1f);
            Blood.SetActive(false);
            StopCoroutine(coroutineBlood());

        }



    }
}