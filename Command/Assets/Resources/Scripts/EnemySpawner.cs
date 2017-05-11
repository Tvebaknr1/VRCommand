using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class EnemySpawner : NetworkBehaviour {
    public Vector3[] spawnPoints;
    public float[] spawnSizes;
    public GameObject Enemy;
    float spawnCooldown = 0;
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
        spawnCooldown -= Time.deltaTime;
        if (0 > spawnCooldown)
        {
            int spawn = Random.Range(0, spawnPoints.Length - 1);


                var spawnPosition = new Vector3(
                    spawnPoints[spawn].x + Random.Range(-spawnSizes[spawn], spawnSizes[spawn]),
                    spawnPoints[spawn].y,
                    spawnPoints[spawn].z + Random.Range(-spawnSizes[spawn], spawnSizes[spawn]));

                var spawnRotation = Quaternion.Euler(
                    0.0f,
                    Random.Range(0, 180),
                    0.0f);
            RaycastHit hit;
            if (Physics.Raycast(spawnPosition,player.transform.position, out hit ))
            {
                if (hit.collider.gameObject != player 
                    && Vector3.Distance(spawnPoints[spawn], player.transform.position) > spawnRange)
                {
                    GameObject enemy = Instantiate(Enemy, spawnPosition, spawnRotation);
                    NetworkServer.Spawn(enemy);
                    spawnCooldown += 60 / spawnsPerMinute;
                }
            }
        }

    }
}
