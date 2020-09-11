using UnityEngine;

public class FireShuriken : MonoBehaviour
{
    public GameObject player;
    public GameObject shuriken;
    bool fired = false;
    bool move = false;
    public float velocity = 10f;
    private Rigidbody shurikenRB;
    private GameObject currentShuriken;
    private float offset = 0.3f;

    void Start()
    {
        shurikenRB = shuriken.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (fired && currentShuriken != null)
        {
            move = true;
        }
    }

    void FixedUpdate()
    {
        if (move)
        {
            moveShuriken();
        }
    }

    public void Fire()
    {

        //Debug.Log("Fired");
            
        currentShuriken = Instantiate(shuriken, Heighten(player.transform.position - new Vector3(0,0,offset)), 
                                                    shuriken.transform.rotation);
        fired = true;
    }

    Vector3 Heighten(Vector3 pos)
    {
        float raiseFactor = 2f;
        Vector3 temp = pos;
        temp.y += raiseFactor;
        return temp;
    }

    void moveShuriken()
    {
        if (currentShuriken != null)
        {
            currentShuriken.GetComponent<Rigidbody>().MovePosition
            (currentShuriken.transform.position + (new Vector3(0,0,velocity)) * Time.deltaTime);
        }
    }

}