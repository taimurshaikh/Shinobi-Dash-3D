using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtPlayer : MonoBehaviour
{
    public GameObject kunai;
    private GameObject player;
    private bool firedOnce = false;
    public GameObject currentKunai;
    public float distance = 5f;
    public float velocityDamping = 0.5f;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    void Update()
    {
        if ((transform.position.z - player.transform.position.z) <= distance && player.transform.position.z < transform.position.z) // Only attack if player is close enough and is in front of enemies
        {                                                    
            Vector3 directionToFace = player.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(directionToFace);
            
            if (!firedOnce)
            {
                Debug.Log("Enemy attack");
                Fire();
                firedOnce = true;
            }
            
            if (currentKunai != null)
            {
                moveKunai();
            }    
        }

    }

    void Fire()
    {
        currentKunai = Instantiate(kunai, Heighten(transform.position), kunai.transform.rotation);
        //Vector3 directionToFace = player.transform.position - currentKunai.transform.position;
        //currentKunai.transform.rotation = Quaternion.LookRotation(directionToFace);
        currentKunai.transform.LookAt(player.transform);
        currentKunai.transform.Rotate(0,-90,0);
        
    }

    void moveKunai()
    {
        currentKunai.GetComponent<Rigidbody>().MovePosition(currentKunai.transform.position + ((player.transform.position - transform.position) * velocityDamping * Time.deltaTime));
    }

    Vector3 Heighten(Vector3 pos)
    {
        float raiseFactor = 1.5f;
        Vector3 temp = pos;
        temp.y += raiseFactor;
        return temp;
    }
}
