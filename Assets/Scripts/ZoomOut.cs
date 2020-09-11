using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    public PlayerMove movement;
    public float camMoveRate;
    private FollowPlayer cam;
    public float desiredZ;
    public float desiredY;
    float originalZ;
    float originalY;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<FollowPlayer>();
        originalZ = cam.offset.z;
        originalY = cam.offset.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.isSliding)
        {
            while (cam.offset.z < desiredZ)
            {
                cam.offset.z -= camMoveRate; //* Time.deltaTime;
            }

            while (cam.offset.y < desiredY)
            {
                cam.offset.y += camMoveRate; //* Time.deltaTime;
            }
        }

        else
        {
            while (cam.offset.z > originalZ)
            {
                cam.offset.z += camMoveRate; //* Time.deltaTime;
            }

            while (cam.offset.y > originalY)
            {
                cam.offset.y -= camMoveRate; //* Time.deltaTime;
            }
        }

    }
}
