using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider col;
    public LayerMask groundLayers;
    public KatanaBlock defense;

    public float forwardSpeed = 10f;
    public float sideSpeed = 10f;
    public float moveSpeed = 10f;

    public float speedMultiplier = 1f;
    public float speedIncrement = 0.001f;

    private bool isJumpPressed = false;
    public float jumpSpeed = 10f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public bool isSliding = false;
    private bool slideStopped = true;
    public float slideSpeed;
    private float speedDifference;

    private Vector3 moveHorizontal;
    private Vector3 moveForward;
    private Vector3 movement;

    private Animator anim;
    bool rotated;
    //public GameObject score;
    //private Animation slideAnim;

    void Awake()
    {
        rotated = false;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
        slideSpeed = forwardSpeed * 2f;
        speedDifference = slideSpeed - forwardSpeed;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        isJumpPressed = Input.GetButtonDown("Jump");

        isSliding = Input.GetKey("s");
        slideStopped = Input.GetKeyUp("s");

        moveHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0 , 0) * sideSpeed;
        moveForward = new Vector3(0, 0 , forwardSpeed) * speedMultiplier; // Multiplier will increase speed over time
        movement = moveHorizontal + moveForward;

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !isJumpPressed)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (isSliding && IsGrounded() && !defense.blocking)
        {
            //if (!rotated){ transform.Rotate(0,-45, 0); }
            
            //rotated = true;
            if (!isJumpPressed)
            {
                anim.SetBool("Slide", true);
                anim.SetBool("Run", false);
            }
            
            else
            {
                anim.SetBool("Slide", false);
            }
            
            Slide();
        }

        else if (slideStopped)
        {
            //transform.Rotate(0,45, 0);
            //rotated = false;
            anim.SetBool("Slide", false);
            anim.SetBool("Run", true);
            resetSlide();
        }

        if (forwardSpeed <= 0)
        {
            forwardSpeed += 2;
        }



    }

    void FixedUpdate() 
    {

        if (IsGrounded() && !isSliding)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
            anim.SetBool("Slide", false);
            anim.SetBool("Flip", false);
        }

        else if (IsGrounded() && isSliding)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
            anim.SetBool("Slide", true);
            anim.SetBool("Flip", false);
        }

        //JUMPING
        if (IsGrounded() && isJumpPressed)
        { 
            if (isSliding)
            {
                anim.SetBool("Run", false);
                anim.SetBool("Slide", false);
                anim.SetBool("Fall", false);
                anim.SetBool("Flip", true); 
            }

            else
            {
                anim.SetBool("Run", false);
                anim.SetBool("Slide", false);
                anim.SetBool("Jump", true);
            }


            rb.velocity = Vector3.up * jumpSpeed;
            FindObjectOfType<AudioManager>().Play("Jump");
        
        } 

 
        else if (!IsGrounded() && !anim.GetBool("Jump"))
        {

            anim.SetBool("Run", false);
            anim.SetBool("Slide", false);
            anim.SetBool("Fall", true);

        }
        //if (IsGrounded())
        //{
          //  anim.SetBool("Jump", false);
        //}
        
        //anim.SetBool("Run", true);
        

       moveCharacter(movement);              
    }

    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.size.x * .9f, groundLayers);
    }

    void Slide()
    {   
       // slideAnim.Play("ScoreOnSlide");
        col.center = new Vector3(0f ,0.4f, 0f);
        col.size = new Vector3(1f, 0.8f, 1f);
        //transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        forwardSpeed = slideSpeed;      
    }

    void resetSlide()
    {
        col.center = new Vector3(0f, 0.9f, 0);
        col.size = new Vector3(1f, 1.8f, 1f);

        //transform.localScale = new Vector3(1f, 1f, 1f);

        if (forwardSpeed > 0)
        {
            forwardSpeed -= speedDifference;
        }      
    }

}
