using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{

    [SerializeField]
    private Transform[] positions;

    [SerializeField]
    private float maxDistance;

    [SerializeField]
    private LayerMask layerMask;

    private Transform groundedObjectTransform;
    private Vector3? groundedObjectLastPosition;

    public bool IsGrounded { get; private set; }
    public Vector2 GroundedDirection { get; private set; }

    // Update is called once per frame
    private void Update()
    {
        foreach (var position in positions)
        {
            CheckFootForGrounding(position);
            if (IsGrounded)
                break;
        }

        StickToMovingObjects();
    }

    private void StickToMovingObjects()
    {
        if(groundedObjectTransform != null)
        {
            if (groundedObjectLastPosition.HasValue && 
                groundedObjectLastPosition != groundedObjectTransform.position)
            {
                //Debug.Log("Repositioned " + groundedObject.gameObject + ", " + groundedObject.position + "," + groundedObjectLastPosition);
                Vector3 delta = groundedObjectTransform.position - groundedObjectLastPosition.Value;
                transform.position += delta;
            }
            groundedObjectLastPosition = groundedObjectTransform.position;
        }
        else
        {
            groundedObjectLastPosition = null;
        }
    }

    private void CheckFootForGrounding(Transform foot)
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(foot.position, foot.forward, maxDistance, layerMask);
        Debug.DrawRay(foot.position, foot.forward * maxDistance, Color.red);
        if (raycastHit.collider != null)
        {
            if( groundedObjectTransform != raycastHit.collider.transform)
            {
                groundedObjectLastPosition = raycastHit.collider.transform.position;
            }
            groundedObjectTransform = raycastHit.collider.transform;
            IsGrounded = true;
            GroundedDirection = foot.forward;
        }
        else
        {
            groundedObjectTransform = null;
            IsGrounded = false;
        }
    }
}
