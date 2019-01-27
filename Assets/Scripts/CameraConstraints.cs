using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConstraints : MonoBehaviour
{
    [Header("Camera Constraints")]
    public int bottomYValue;
    public int topYValue;

    [Tooltip("How far out the camera can zoom")]
    public float maxZoomOut;
    public bool zooming;
    public float timeToReachTarget = 50.0f;
    public float desiredZoom;

    private Camera cam;

    [SerializeField]
    private Vector3 dest;

    [SerializeField]
    private float defaultZDistance;
    private float cameraWidth;
    private float cameraHeight;
    private float zDistanceFromPlayer = 6.0f;

    [SerializeField]
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
        defaultZDistance = pos.z;
        cam = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = this.gameObject.transform.position;


    }


    /*float t = 0;
    t += Time.deltaTime / timeToReachTarget;
    cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, desiredZoom, t);

    if (Mathf.Abs(cam.orthographicSize - desiredZoom) > 1)
    {
        GameObject.Find("Player").GetComponent<Player>().canMove = false;
        //Stop the player from moving when you are transitioning with the camera 
        GameObject.Find("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }
    else
    {
        GameObject.Find("Player").GetComponent<Player>().canMove = true;
        //Give player the contraints on all rotations + Z axis position
        GameObject.Find("Player").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }



    if (Input.GetKeyDown(KeyCode.Space))
    {
        desiredZoom = 10;
    }
    */
    /*
    if (!zooming && (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) )
    { 
        zooming = true;
        GameObject.Find("Player").GetComponent<Player>().canMove = false;
    }

    if (zooming && cam.orthographicSize < maxZoomOut)
    {
        cam.orthographicSize += Mathf.MoveTowards(cam.orthographicSize, maxZoomOut, 0.1f);
    }else if(zooming && cam.orthographicSize > maxZoomOut)
    {
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, defaultZDistance, 1.0f);
    }

    if (zooming && (cam.orthographicSize == maxZoomOut || cam.orthographicSize == defaultZDistance) )
    {
        zooming = false;
        GameObject.Find("Player").GetComponent<Player>().canMove = true;
    }
    */

}

