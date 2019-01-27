using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMe : MonoBehaviour
{
    //[SerializeField]
    //[Tooltip("These vectors only affect ThrowLeft/ThrowRight Functions")]
    private Vector2 _forceAppliedRight = new Vector2(5f, 5f);
    private Vector2 _forceAppliedLeft;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _forceAppliedLeft = new Vector2(_forceAppliedRight.x * -1f, _forceAppliedRight.y);
    }

    public void Throw(Vector2 _forceVector) // Use this when throwing
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(_forceVector, ForceMode2D.Impulse);
    }

    public void ThrowWithVelocity(Vector2 _velocity)
    {
        _rigidbody2D.velocity = _velocity;
    }


    // Depricated
    private void ThrowRight()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(_forceAppliedRight, ForceMode2D.Impulse);
    }

    // Depricated
    private void ThrowLeft()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(_forceAppliedLeft, ForceMode2D.Impulse);
        //_rigidbody2D.AddTorque(90.0f, ForceMode2D.Impulse);
    }

}
