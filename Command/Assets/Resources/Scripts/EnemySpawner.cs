using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class EnemySpawner : NetworkBehaviour {
    public Vector3[] spawnPoints;
    public float[] spawnSizes;
    public GameObject Enemy;
    public float spawnCooldown = 0;
    public float spawnsPerMinute;
    public GameObject player;
    public float spawnRange;
	// Use this for initialization
	public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
    // Update is called once per frame
    void Update () {
        if(player != null)
        { 
        spawnCooldown -= Time.deltaTime;
            if (0 > spawnCooldown)
            {
                int spawn = Random.Range(0, spawnPoints.Length);


                /* var spawnPosition = new Vector3(
                    spawnPoints[spawn].x + Random.Range(-spawnSizes[spawn], spawnSizes[spawn]),
                    spawnPoints[spawn].y,
                    spawnPoints[spawn].z + Random.Range(-spawnSizes[spawn], spawnSizes[spawn]));
 */
                var spawnRotation = Quaternion.Euler(
                    0.0f,
                    Random.Range(0, 180),
                    0.0f);
                   
                var spawnPosition = spawnPoints[0];
                RaycastHit hit;
                
                if (Physics.Raycast(spawnPosition, player.transform.position- spawnPosition, out hit, 10000f))
                {
                    if ((hit.collider.gameObject == null ||
                        hit.collider.gameObject != player)

                        && Vector3.Distance(spawnPoints[spawn], player.transform.position) > spawnRange)
                    {
                        GameObject enemy = Instantiate(Enemy, spawnPosition, spawnRotation);
                        NetworkServer.Spawn(enemy);
                        spawnCooldown += 60 / spawnsPerMinute;
                    }
                }
                Debug.DrawRay(spawnPosition, player.transform.position - spawnPosition, Color.green);
                Debug.Log(player);
                Debug.Log(player.transform.position);
                Debug.Log(hit.collider.gameObject);
               
            }
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("playerModel");
        }

    }
}
