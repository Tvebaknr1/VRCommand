using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    public GameObject player;
    NavMeshAgent agent;
    float cooldown;
    public int damage;
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
            
        }
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 20 )
        {
            
            if (cooldown < 0)
            {
                player.GetComponent<Health>().TakeDamage(damage);
                Debug.Log("hitler did nothing wrong");
                cooldown = 1;
            }
           
                cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = 1;
        }
            

        

    }
}
