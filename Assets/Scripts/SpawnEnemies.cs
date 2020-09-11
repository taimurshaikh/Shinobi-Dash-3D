using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject plane;
    public GameObject enemy;

    public float LOffset = 5f;
    public float ROffset = 5f;
    public float heightOffset = 0.2f;

    // Start is called before the first frame update
    void Awake()
    {
        float prob1 = Random.value;
        float prob2 = Random.value;

        if (prob1 >= 0.5) // 50% chance
        {
            Debug.Log("Left enemy");
            GameObject enemyL = Instantiate(enemy, Left(transform.position), 
                                            enemy.transform.rotation);
            
            enemyL.transform.parent = gameObject.transform;
        }

        if (prob2 >= 0.5)
        {
            Debug.Log("Right enemy");
            GameObject enemyR = Instantiate(enemy, Right(transform.position), 
                                            enemy.transform.rotation);
            
            enemyR.transform.parent = gameObject.transform;
        }
    }

    // void Update()
    // {
    //     float prob1 = Random.value;
    //     float prob2 = Random.value;

    //     if (prob1 > 0.8) // 20% chance
    //     {
    //         Debug.Log("Left enemy");
    //         GameObject enemyL = Instantiate(enemy, Left(transform.position), 
    //                                         transform.rotation);
            
    //         enemyL.transform.parent = gameObject.transform;
    //     }

    //     if (prob2 > 0.8)
    //     {
    //         Debug.Log("Right enemy");
    //         GameObject enemyR = Instantiate(enemy, Right(transform.position), 
    //                                         transform.rotation);
            
    //         enemyR.transform.parent = gameObject.transform;
    //     }
    // }

    Vector3 Left(Vector3 pos)
    {
        Vector3 temp = pos;
        temp.x -= LOffset;
        temp.y -= heightOffset;
        return temp;
    }

    Vector3 Right(Vector3 pos)
    {
        Vector3 temp = pos;
        temp.x += ROffset;
        temp.y -= heightOffset;
        return temp;
    }
}
