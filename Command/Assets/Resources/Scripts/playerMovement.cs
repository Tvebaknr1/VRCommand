using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class playerMovement : NetworkBehaviour {
    [SyncVar]
    public Vector3 goal;

    NavMeshAgent agent;

    // Use this for initialization
    void Start () {

        
         agent = GetComponent<NavMeshAgent>();
       
    
}
    public void Update()
    {
        agent.destination = goal;
    }
    
    public void giveTarget( Vector3 target)
    {
        goal = target;
    }
    
}
