using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private float t;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        t+= 0.1f;
        this.transform.position = new Vector3(Mathf.Sin(t), startPosition.y + Mathf.Sin(t), 0.0f);        
    }
}
