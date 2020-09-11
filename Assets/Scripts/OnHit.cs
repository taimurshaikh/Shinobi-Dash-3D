using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    private FireAtPlayer fap;
    private Score score;

    void Awake()
    {
        score = FindObjectOfType<Score>();
    }


    void OnCollisionEnter(Collision collided)
    {
        if (collided.gameObject.tag == "Enemy")
        {
            collided.gameObject.transform.Rotate(0,50,0);
            anim = collided.gameObject.GetComponent("Animator") as Animator;
            anim.SetBool("Alive", false);

            fap = collided.gameObject.GetComponent("FireAtPlayer") as FireAtPlayer;
            fap.enabled = false;
            Rigidbody enemyRB = collided.gameObject.GetComponent<Rigidbody>();
            //enemyRB.isKinematic = true;
            collided.gameObject.tag = "Dead Enemy";
            score.extraPoints += 10; 
            FindObjectOfType<AudioManager>().Play("Die");
            Destroy(collided.gameObject, 0.95f);
        }

        Destroy(gameObject);

    }

    void DestroyObj(GameObject obj)
    {
        Destroy(obj);
    }
}
