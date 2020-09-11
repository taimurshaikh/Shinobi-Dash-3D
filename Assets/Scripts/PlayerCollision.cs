using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMove movement;
    public PlayerAttackAndDefense defense;
    public Score score;
    private Animator anim;
    private Rigidbody rb;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        score = FindObjectOfType<Score>();
    }

    void OnCollisionEnter (Collision collided)
    {
        if (collided.collider.tag == "Spike" || collided.collider.tag == "Boombox" || 
            collided.collider.tag == "Enemy" || (collided.collider.tag == "Kunai" && !defense.blocking))
        {
           // rb.AddForce(0,0,-5);
            
            FindObjectOfType<AudioManager>().Play("Die");
            transform.Rotate(0,35,0);

            anim.SetBool("Alive", false);
            anim.SetBool("Fall", false);
            anim.SetBool("Run", false);
            anim.SetBool("Jump", false);
            anim.SetBool("Slide", false);
            anim.SetBool("Flip", false);
            score.enabled = false;
            movement.enabled = false;

            if (collided.collider.tag == "Kunai")
            {
                Destroy(collided.gameObject);
            }

            FindObjectOfType<GameManager>().EndGame();
        }

        else if (collided.collider.tag == "Kunai" && defense.blocking)
        {
            FindObjectOfType<AudioManager>().Play("Block");
            score.extraPoints += 5;
        }
    }
}
