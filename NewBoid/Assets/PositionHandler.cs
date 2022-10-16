using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RayCastCollisionBehaviour))]
public class PositionHandler : MonoBehaviour
{
    void Awake()
    {
        this.GetComponent<RayCastCollisionBehaviour>().OnCollisionDetected += ApplyForce;
    }

    void OnDestroy()
    {
        this.GetComponent<RayCastCollisionBehaviour>().OnCollisionDetected -= ApplyForce;
    }

    void ApplyForce(float force)
    {
        this.transform.forward 
    }
}
