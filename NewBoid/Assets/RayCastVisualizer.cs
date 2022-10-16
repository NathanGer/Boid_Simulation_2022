using System.Collections.Generic;
using UnityEngine;

public class RayCastVisualizer : MonoBehaviour
{
    List<Vector3> spherePoints = SphereCreator.CreateSpherePoint();

    private void Update()
    {
        foreach (var point in spherePoints)
        {
            TraceRaycast(point);
        }
    }

    private void TraceRaycast(Vector3 direction)
    {
        RaycastHit hit;
        var spherePointPosition = transform.position + direction * Settings.DETECTION_DISTANCE;

        if (Physics.Raycast(transform.position, direction, out hit, Settings.DETECTION_DISTANCE))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.localPosition, spherePointPosition, Color.yellow);
        }
    }
}