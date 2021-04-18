using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{

    public Animator spikes;

    // Start is called before the first frame update
   public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            spikes.SetBool("PlaySpike",true);
            Debug.Log("walked into spikes");

        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            spikes.SetBool("PlaySpike", false);
            Debug.Log("left spikes");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
