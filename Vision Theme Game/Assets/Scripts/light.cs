using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class light : MonoBehaviour
{

    public float lightAmount = 10;
    public float lightIntensity = 4;
    public float addRange = 5;
    public float addIntens = 2;
    public float fallOff = - -1f;
    public float fallOff2 = -0.2f;
  
    


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
      //GetComponent<NavMeshObstacle>().radius = lightAmount/10;
        GetComponent<NavMeshObstacle>().radius = lightIntensity/1.2f;



    }

  

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "light" && lightAmount <= 40)
        {
            lightAmount += addRange;
          
        }

        if (other.gameObject.tag == "light" && lightIntensity <= 10)
        {
          
            lightIntensity += addIntens;
        }


    }

    IEnumerator coroutineA()
    {
        // wait for 1 second
      while(lightAmount >= 0)
        {
            lightAmount += fallOff;
            lightIntensity += fallOff2;
            yield return new WaitForSeconds(2f);
        }
        
        
        
    }

 

}
