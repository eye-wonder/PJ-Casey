using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowToKnockOver : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pillow")
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }
}
