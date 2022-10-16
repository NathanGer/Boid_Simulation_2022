using System.Collections.Generic;
using UnityEngine;

public class RayCastCollisionBehaviour : MonoBehaviour
{
    List<Vector3> spherePoints = SphereCreator.CreateSpherePoint();

    public delegate void OnCollisionDetectedDelegate(float resultanteForce);
    public OnCollisionDetectedDelegate OnCollisionDetected;

    private void Update()
    {
        foreach (var point in spherePoints)
        {
            DetectCollision(point);
        }
    }

    private void DetectCollision(Vector3 direction)
    {
        RaycastHit hit;
        var spherePointPosition = transform.position + direction * Settings.DETECTION_DISTANCE;

        if (Physics.Raycast(transform.position, direction, out hit, Settings.DETECTION_DISTANCE))
        {
            var distance = Vector3.Distance(transform.position, hit.point);
            CalculForce(distance);
        }
    }
    private void CalculForce(float distance)
    {
        float a = 1.3f;
        float b = -2f;
        float c = 5.5f;
        float w = 1f;
        var force = Mathf.Exp(-a) * (b * Mathf.Cos(w * distance) + c * Mathf.Cos(w * distance));
        OnCollisionDetected?.Invoke(force);
    }
}
