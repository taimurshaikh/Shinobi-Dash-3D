
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceForce = 10f;
    private GameObject player;
    private Rigidbody rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collided)
    {
        if (collided.transform.tag == "Player")
        {
            //Debug.Log("PLAYER COLLIDED");
            player.GetComponent<Rigidbody>().velocity = Vector3.up * bounceForce; // Basically a B I G jump
            anim.SetBool("Bounce", true);
            FindObjectOfType<AudioManager>().Play("BouncePad");
        }
    }
}
