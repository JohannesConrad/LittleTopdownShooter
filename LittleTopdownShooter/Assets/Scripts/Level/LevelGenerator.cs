using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject smartWall;
    

    public float wallProbablility = 0.07f;
    public float wallProbablilityIncrease = 0.05f;

    Dictionary<(float,float),GameObject> map = new Dictionary<(float,float),GameObject>();

    void Start()
    {
        GameObject root = Instantiate(smartWall, new Vector2(0, 0), Quaternion.identity);
        root.GetComponent<WallScript>().setEmpty();
        (float,float) keyRoot = (root.transform.position.x, root.transform.position.y);
        map.Add(keyRoot, root);
        processTile(root, wallProbablility);
        Debug.Log("Done processing tiles, start postprocessing!");
        makeInnerWallsBreakable();
    }

    void processTile(GameObject parent, float newWallProbability) {

        GameObject newTile1 = null;
        GameObject newTile2 = null;
        GameObject newTile3 = null;
        GameObject newTile4 = null;

        Vector2 parentPosition = parent.transform.position;
        //generate towards down
        Vector2 newPositionDown = new Vector2(parentPosition.x, parentPosition.y -1);
        (float,float) keyHereDown = (newPositionDown.x, newPositionDown.y);
        if(!map.ContainsKey(keyHereDown)){
            if(Random.Range(0.0f,1.0f) > newWallProbability){
                newTile1 = Instantiate(smartWall, newPositionDown, Quaternion.identity);
                map.Add(keyHereDown, newTile1);
                newTile1.GetComponent<WallScript>().setEmpty();
            }else{
                GameObject newWallTile1 = Instantiate(smartWall, newPositionDown, Quaternion.identity);
                map.Add(keyHereDown, newWallTile1);
                newWallTile1.GetComponent<WallScript>().setUnbreakable();
            }
        }
        //generate towards top
        Vector2 newPositionUp = new Vector2(parentPosition.x, parentPosition.y + 1);
        (float,float) keyHereUp = (newPositionUp.x, newPositionUp.y);
        if(!map.ContainsKey(keyHereUp)){
            if(Random.Range(0.0f,1.0f) > newWallProbability){
                newTile2 = Instantiate(smartWall, newPositionUp, Quaternion.identity);
                map.Add(keyHereUp, newTile2);
                newTile2.GetComponent<WallScript>().setEmpty();
            }else{
                GameObject newWallTile2 = Instantiate(smartWall, newPositionUp, Quaternion.identity);
                map.Add(keyHereUp, newWallTile2);
                newWallTile2.GetComponent<WallScript>().setUnbreakable();
            }
        }
        //generate towards left
        Vector2 newPositionLeft = new Vector2(parentPosition.x - 1, parentPosition.y);
        (float,float) keyHereLeft = (newPositionLeft.x, newPositionLeft.y);
        if(!map.ContainsKey(keyHereLeft)){
            if(Random.Range(0.0f,1.0f) > newWallProbability){
                newTile3 = Instantiate(smartWall, newPositionLeft, Quaternion.identity);
                map.Add(keyHereLeft, newTile3);
                newTile3.GetComponent<WallScript>().setEmpty();
            }else{
                GameObject newWallTile3 = Instantiate(smartWall, newPositionLeft, Quaternion.identity);
                map.Add(keyHereLeft, newWallTile3);
                newWallTile3.GetComponent<WallScript>().setUnbreakable();
            }
        }
        //generate towards right
        Vector2 newPositionRight = new Vector2(parentPosition.x + 1, parentPosition.y);
        (float,float) keyHereRight = (newPositionRight.x, newPositionRight.y);
        if(!map.ContainsKey(keyHereRight)){
            if(Random.Range(0.0f,1.0f) > newWallProbability){
                newTile4 = Instantiate(smartWall, newPositionRight, Quaternion.identity);
                map.Add(keyHereRight, newTile4);
                newTile4.GetComponent<WallScript>().setEmpty();
            }else{
                GameObject newWallTile4 = Instantiate(smartWall, newPositionRight, Quaternion.identity);
                map.Add(keyHereRight, newWallTile4);
                newWallTile4.GetComponent<WallScript>().setUnbreakable();
            }
        }
        if(newTile1 != null) processTile(newTile1, newWallProbability += wallProbablilityIncrease);
        if(newTile2 != null) processTile(newTile2, newWallProbability += wallProbablilityIncrease);
        if(newTile3 != null) processTile(newTile3, newWallProbability += wallProbablilityIncrease);
        if(newTile4 != null) processTile(newTile4, newWallProbability += wallProbablilityIncrease);
    }

    private void makeInnerWallsBreakable(){
        var enumerator = map.GetEnumerator();
        while(enumerator.MoveNext()){
            GameObject currentWall = enumerator.Current.Value;
            if(isUnbreakable(currentWall)){
                if(isNotEdge(currentWall)){
                    Debug.Log("Blarg3");
                    currentWall.GetComponent<WallScript>().setBreakable();
                }
            }
        }
    }

    private bool isUnbreakable(GameObject obj) {
        bool a = obj.GetComponent<WallScript>().isUnbreakable();
        Debug.Log(a);
        return obj.GetComponent<WallScript>().isUnbreakable();
    }

    private bool isNotEdge(GameObject obj){
        Vector2 pos = obj.transform.position;
        (float,float) upN = (pos.x,pos.y +1);
        (float,float) rightN = (pos.x +1,pos.y);
        (float,float) downN = (pos.x,pos.y -1);
        (float,float) leftN = (pos.x -1,pos.y);
        return map.ContainsKey(upN) && map.ContainsKey(rightN) && map.ContainsKey(downN) && map.ContainsKey(leftN);
    }
}
