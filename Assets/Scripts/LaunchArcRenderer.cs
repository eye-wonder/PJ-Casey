using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaunchArcRenderer : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    [SerializeField]
    private float angle;
    [SerializeField]
    [Range(1, 20)]
    private int resolution = 10;

    [SerializeField]
    private float xStartPosition;
    [SerializeField]
    private float yStartPosition;

    private float gravity; // force of gravity on y axis
    //private float radianAngle;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        gravity = Mathf.Abs(Physics2D.gravity.y);
    }

    // Calculates angle from Velocity Vector2
    public void RenderArc(Vector2 Velocity, int Resolution, float xStartPosition, float yStartPosition)
    {
        _lineRenderer.positionCount = Resolution + 1;

        float totalVelocityMagnitude = Mathf.Sqrt((Velocity.x * Velocity.x) + (Velocity.y * Velocity.y));
        float angleInDegrees = Mathf.Rad2Deg * (Mathf.Atan(Velocity.y / Velocity.x));

        _lineRenderer.SetPositions(CalculateArcArray(totalVelocityMagnitude, angleInDegrees, Resolution, xStartPosition, yStartPosition));
    }

    // Give line renderer the right settings
    public void RenderArc(float Velocity, float AngleDegrees, int Resolution, float xStartPosition, float yStartPosition)
    {
        _lineRenderer.positionCount = Resolution + 1;
        _lineRenderer.SetPositions(CalculateArcArray(Velocity, AngleDegrees, Resolution, xStartPosition, yStartPosition));
    }

    // Return array of positions for the line renderer
    private Vector3[] CalculateArcArray(float Velocity, float AngleInDegrees, int Resolution, float xStartPosition, float yStartPosition)
    {
        Vector3[] arcArray = new Vector3[Resolution + 1];

        float tempRadianAngle = Mathf.Deg2Rad * AngleInDegrees;
        float maxDist = (Velocity * Velocity * Mathf.Sin(2 * tempRadianAngle)) / gravity;

        for (int i = 0; i <= Resolution; i++)
        {
            float t = (float)i / (float)Resolution;
            arcArray[i] = CalculateArcPoint(t, maxDist, Velocity, tempRadianAngle, xStartPosition, yStartPosition);
        }

        return arcArray;
    }

    // Calculate height and distance of each vertex
    private Vector3 CalculateArcPoint(float t, float maxDist, float Velocity, float radianAngle, float xStartPosition, float yStartPosition)
    {
        float x = t * maxDist;
        float y = yStartPosition + ((x * Mathf.Tan(radianAngle)) - ((gravity * x * x) / (2 * Velocity * Velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle))));
        x += xStartPosition;

        return new Vector3(x, y, -1f);

    }
}
