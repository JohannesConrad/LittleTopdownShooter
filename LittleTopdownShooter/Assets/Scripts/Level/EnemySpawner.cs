using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public GameObject[] enemies;

    public int spawnAmountEnemy1;

    public void spawnEnemies() {
        for(int i = 0; i < spawnAmountEnemy1; i++){
            Vector3 spawnPoint = gameObject.GetComponent<LevelGenerator>().getRandomFreeTilePositionExceptRootMinDistance(3);
            Instantiate(enemies[0], spawnPoint, Quaternion.identity);
        }
    }
}
