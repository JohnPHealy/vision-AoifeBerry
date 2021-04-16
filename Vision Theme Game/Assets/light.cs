using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{

    public float lightAmount = 5;
    public float lightIntensity = 2;
    public float addRange = 5;
    public float addIntens = 2;
    
    // Start is called before the first frame update
    void Start()
    {
     
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

 
}
