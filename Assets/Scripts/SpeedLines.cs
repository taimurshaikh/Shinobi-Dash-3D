using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLines : MonoBehaviour
{
    public PlayerMove movement;
    public ParticleSystem speedLines;

    // Start is called before the first frame update
    void Start()
    {  
        speedLines.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.forwardSpeed >= movement.slideSpeed)
        {
            FindObjectOfType<AudioManager>().Play("Slide");
            speedLines.Play();
        }
        else
        {
            speedLines.Stop();
        }

        if (!movement.enabled)
        {
            speedLines.Stop();
        }
    }
}
