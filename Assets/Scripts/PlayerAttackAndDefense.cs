using UnityEngine;

public class PlayerAttackAndDefense : MonoBehaviour
{

    public FireShuriken shuriken;
    public KatanaBlock katana;
    public PlayerMove movement;
    public bool blocking = false;
 
    public float coolDown = 1f;
    public float coolDownTimer;

    void Update()
    {
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        else if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
        }

        if (Input.GetMouseButtonDown(0) && coolDownTimer == 0 && !movement.isSliding)
        {
            if (coolDownTimer == 0)
            {
                shuriken.Fire();
                coolDownTimer = coolDown;
            }
        }    

        else if (Input.GetMouseButtonDown(1) && !movement.isSliding)
        {
            katana.Block(); 
            blocking = true;      
        }

        else if (Input.GetMouseButtonUp(1))
        {
            katana.stopBlock();
            blocking = false;        
        }
    }
}
