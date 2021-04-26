using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{ 

    public LayerMask PlayerCanWalk;

private NavMeshAgent myAgent;

    // Start is called before the first frame update
    void Start()
    {
    myAgent = GetComponent<NavMeshAgent>();

     
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetMouseButtonDown(0))
    {
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if(Physics.Raycast (myRay, out hitInfo, 300, PlayerCanWalk))
        {
            myAgent.SetDestination(hitInfo.point);
        }
    }
    }
}
