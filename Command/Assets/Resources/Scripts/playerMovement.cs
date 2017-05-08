using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class playerMovement : NetworkBehaviour {
    [SyncVar]
    public Vector3 goal;

    NavMeshAgent agent;
    public GameObject parent;

    // Use this for initialization
    void Start () {

        
         agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        //agent.updatePosition = false;
        //parent = GetComponentInParent<Transform>().gameObject;
       
    
}
    public void Update()
    {
        agent.destination = goal;
        //parent.transform.position += transform.forward * agent.speed * Time.deltaTime;

    }
    [Command]
    public void CmdgiveTarget( Vector3 target)
    {
        goal = target;
    }
}
