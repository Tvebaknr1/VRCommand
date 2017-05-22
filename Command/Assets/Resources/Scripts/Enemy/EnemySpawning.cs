using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawning : NetworkBehaviour {

    public GameObject enemyPrefab;
    public int numberOfEnemies;
    public float spawnAreaSize;
    public override void OnStartServer()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            var spawnPosition = new Vector3(
                gameObject.transform.position.x +Random.Range(-spawnAreaSize, spawnAreaSize),
                gameObject.transform.position.y,
                gameObject.transform.position.z  +Random.Range(-spawnAreaSize, spawnAreaSize));

            var spawnRotation = Quaternion.Euler(
                0.0f,
                Random.Range(0, 180),
                0.0f);

            var enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(enemy);
        }
    }
}
