using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingPlatform : MonoBehaviour
{
    public Transform origin;

    public float swingRightAngle;
    public float swingLeftAngle;

    [SerializeField]
    private bool swingingRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(origin.rotation.z * 180 > swingRightAngle)
        {
            swingingRight = false;
        }else if(origin.rotation.z * 180 < -swingLeftAngle)
        {
            swingingRight = true;
        }

        if (swingingRight)
        {
            origin.Rotate(new Vector3(0, 0, 1));
        }
        else
        {
            origin.Rotate(new Vector3(0, 0, -1));
        }
    }
}
