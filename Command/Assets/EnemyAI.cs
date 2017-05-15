using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    public GameObject player;
    NavMeshAgent agent;
    // Use this for initialization
    void Awake () {
        agent = gameObject.GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update() {
        player = GameObject.FindGameObjectWithTag("playerModel");
        if (player != null)
        {
            agent.SetDestination(player.transform.position);
            return;
        }
        
        

    }
}
