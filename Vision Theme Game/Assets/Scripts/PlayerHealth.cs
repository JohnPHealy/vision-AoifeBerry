using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour


{

    public int maxHealth = 10;
    public int currentHealth;
    public int damage = 1;
    public healthBar healthBar;
    public Transform SpawnPoint;
    public int GreenKeys = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame

  
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
            Destroy(other.gameObject);
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