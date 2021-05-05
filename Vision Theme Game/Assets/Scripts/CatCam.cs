using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CatCam : MonoBehaviour


    
{

    public GameObject catcam;
    public float test = 1;
    public GameObject catTrigger;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("cats");
            catcam.SetActive(true);
            player.GetComponent<SecondPlayerMovement>().enabled = false;
            StartCoroutine(coroutineCat());

        }
    }

    IEnumerator coroutineCat()
    {
     
        while (test <= 1)
        {

        yield return new WaitForSeconds(3f);
        catcam.SetActive(false);
            player.GetComponent<SecondPlayerMovement>().enabled = true;
            catTrigger.SetActive(false);

        StopCoroutine(coroutineCat());

            }
        }
}

    
