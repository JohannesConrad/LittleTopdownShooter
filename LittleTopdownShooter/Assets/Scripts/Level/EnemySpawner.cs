using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour{
    public GameObject[] enemies;
    public int[] enemyAmoutns;

    public static int enemyAmount = 0;
    private bool aboutToLeave = false;

    public void spawnEnemies(GameObject player) {
        for(int e = 0; e < enemies.Length; e++){
            for(int i = 0; i < enemyAmoutns[e]; i++){
                Vector3 spawnPoint = gameObject.GetComponent<LevelGenerator>().getRandomFreeTilePositionExceptRootMinDistance(3);
                Vector3 smallTandomOffset = new Vector3(Random.Range(-0.3f, 0.3f),Random.Range(-0.3f, 0.3f),0);
                GameObject spawned = Instantiate(enemies[e], spawnPoint + smallTandomOffset, Quaternion.identity);
                ReferencingPlayer scriptReverencingPlayer = spawned.GetComponent<ReferencingPlayer>();
                enemyAmount++;
                if(scriptReverencingPlayer != null){
                    scriptReverencingPlayer.setPlayer(player);
                }
            }
        }
    }

    void Update(){
        Debug.Log("" + enemyAmount);
        if(enemyAmount == 0 && !aboutToLeave){
            aboutToLeave = true;
            StartCoroutine(leaveToDeadOrFinishScreen());
        }
    }

    IEnumerator leaveToDeadOrFinishScreen(){
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("DeadOrFinish");

    }
}
