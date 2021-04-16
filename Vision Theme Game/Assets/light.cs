using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{

    public float lightAmount = 5;
    public float lightIntensity = 2;
    public float addRange = 5;
    public float addIntens = 2;
    public float fallOff = - 1f;
    public float fallOff2 = -0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(coroutineA());

    }

 

    // Update is called once per frame
    void Update()
    {
        GetComponent<Light>().range = lightAmount;
        GetComponent<Light>().intensity = lightIntensity;


    }

  

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "light")
        {
            lightAmount += addRange;
            lightIntensity += addIntens;
        }
    

    }

    IEnumerator coroutineA()
    {
        // wait for 1 second
        Debug.Log("coroutineA created");
        yield return new WaitForSeconds(.5f);
        yield return StartCoroutine(coroutineB());
        Debug.Log("coroutineA running again");
    }

    IEnumerator coroutineB()
    {
        Debug.Log("coroutineB created");
        yield return new WaitForSeconds(1f);
        lightAmount -= fallOff;
        lightIntensity += fallOff2;
        yield return StartCoroutine(coroutineA());
        
        Debug.Log("coroutineB enables coroutineA to run");
    }

}
