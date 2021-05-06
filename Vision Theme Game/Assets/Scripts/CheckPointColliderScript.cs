using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float X;
    public float Y;
    public float Z;


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            X = GameObject.Find("PlayerController").transform.position.x;
            Y = GameObject.Find("PlayerController").transform.position.y;
            Z = GameObject.Find("PlayerController").transform.position.z;
            GameObject.Find("PlayerController").SendMessage("CPsetX", X);
            GameObject.Find("PlayerController").SendMessage("CPsetY", Y);
            GameObject.Find("PlayerController").SendMessage("CPsetZ", Z);
        }
    }
}
