using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerMovement : MonoBehaviour {
    NavMeshAgent agent;

    // Use this for initialization
    void Start () {

        
         agent = GetComponent<NavMeshAgent>();
       
    
}

    public void giveTarget( Vector3 target)
    {
        agent.destination = target;
    }
    
}
