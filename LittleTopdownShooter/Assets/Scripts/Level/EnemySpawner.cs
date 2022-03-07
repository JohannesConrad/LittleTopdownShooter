using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public GameObject[] enemies;
    public int[] enemyAmoutns;

    public void spawnEnemies(GameObject player) {
        for(int e = 0; e < enemies.Length; e++){
            for(int i = 0; i < enemyAmoutns[e]; i++){
                Vector3 spawnPoint = gameObject.GetComponent<LevelGenerator>().getRandomFreeTilePositionExceptRootMinDistance(3);
                Vector3 smallTandomOffset = new Vector3(Random.Range(-0.3f, 0.3f),Random.Range(-0.3f, 0.3f),0);
                GameObject spawned = Instantiate(enemies[e], spawnPoint + smallTandomOffset, Quaternion.identity);
                ReferencingPlayer scriptReverencingPlayer = spawned.GetComponent<ReferencingPlayer>();
                if(scriptReverencingPlayer != null){
                    scriptReverencingPlayer.setPlayer(player);
                }
            }
        }
    }
}
