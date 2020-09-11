using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaBlock : MonoBehaviour
{
    public GameObject player;
    public GameObject katanaL;
    public GameObject katanaR;
    public bool blocking = false;
    private Rigidbody katanaRB;
    private GameObject currentKatana1;
    private GameObject currentKatana2;
    private float offset = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        if (blocking && currentKatana1 != null && currentKatana2 != null)
        {
            currentKatana1.transform.parent = gameObject.transform;
            currentKatana2.transform.parent = gameObject.transform;
        }
    }

    public void Block()
    {
        Debug.Log("Blocking");
        
        currentKatana1 = Instantiate(katanaL, Heighten(player.transform.position + new Vector3(0,0,offset)), 
                                                katanaL.transform.rotation);

        currentKatana2 = Instantiate(katanaR, Heighten(player.transform.position + new Vector3(0,0,offset)), 
                                                katanaR.transform.rotation);
        blocking = true;
    }

    public void stopBlock()
    {
        Debug.Log("Stop Block");

        Destroy(currentKatana1);
        Destroy(currentKatana2);

        blocking = false;
    }

    Vector3 Heighten(Vector3 pos)
    {
        float raiseFactor = 1f;
        Vector3 temp = pos;
        temp.y += raiseFactor;
        return temp;
    }


}
