using System.Collections.Generic;
using UnityEngine;

public class SphereCreator
{
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
                spherePoints.Add(Vector3.right * x + Vector3.forward * y + Vector3.up * z);
            }
        }
        return spherePoints;
    }
}