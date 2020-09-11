using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private GameObject player;
    public FireAtPlayer enemyFire;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (player.transform.position.z - 5 > transform.position.z || (GetComponent<BoxCollider>().enabled == false));
        // {
        //     //transform.rotation = originalRot;

        //     if (enemyFire.currentKunai != null)
        //     {
        //         Destroy(enemyFire.currentKunai);
        //     }
        //     Destroy(gameObject);
        // }
    }
}
