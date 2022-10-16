using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public static class Settings
{
    public static float ANGLE_INCREM = 1.61f;
    public static float NBR_POINT = 666;
    public static float MIN_ANGLE = 15f;
    public static float DETECTION_DISTANCE = 100f;

    public static List<Vector3> CreateSpherePoint()
    {
        var spherePoints = new List<Vector3>();
        for (int i = 0; i < Settings.NBR_POINT; i++)
        {
            float dst = i / (Settings.NBR_POINT - 1);
            float angleDelta = (Mathf.Acos(2 * dst - 1) * 2) - Mathf.PI;
            float angleTheta = 2 * Mathf.PI * Settings.ANGLE_INCREM * i;
            if (Mathf.Abs(angleDelta) * Mathf.Rad2Deg > Settings.MIN_ANGLE || Mathf.Abs(angleTheta % (2 * Mathf.PI)) * Mathf.Rad2Deg > Settings.MIN_ANGLE)
            {
                float x = Mathf.Cos(angleDelta) * Mathf.Cos(angleTheta);
                float y = Mathf.Cos(angleDelta) * Mathf.Sin(angleTheta);
                float z = Mathf.Sin(angleDelta);
                spherePoints.Add(new Vector3(x, z, y));
            }
        }
        return spherePoints;
    }
}

public class RayCastHandler : MonoBehaviour
{
    List<Vector3> spherePoints = Settings.CreateSpherePoint();

    void Update()
    {
        foreach (var point in spherePoints)
        {
            TraceRaycast(point);
        }
    }

    private void TraceRaycast(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.position + direction, out hit, Settings.DETECTION_DISTANCE))
        {
            Debug.DrawLine(transform.position,  hit.point , Color.yellow);
            CalculForce(hit.distance);
        }
    }

    private void CalculForce(float distance)
    {
        float a = 1.3f;
        float b = -2f;
        float c = 5.5f;
        float w = 1f;
        var force = Mathf.Exp(-a) * (b * Mathf.Cos(w * distance) + c * Mathf.Cos(w * distance));
        Debug.Log(force);
    }
}
