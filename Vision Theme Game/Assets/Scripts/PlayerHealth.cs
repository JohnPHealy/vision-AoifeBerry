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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }

     
        
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "SpikeDamage")
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

        }

        if (col.gameObject.tag == "Fall")
        {
            SceneManager.LoadScene("SampleScene");

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