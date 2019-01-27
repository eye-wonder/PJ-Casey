using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Mathf.PingPong(Time.time, 2) + this.transform.position.x, Mathf.PingPong(Time.time, 8) + this.transform.position.y, 0.0f);        
    }
}
