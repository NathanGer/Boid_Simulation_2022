using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirection : MonoBehaviour
{
    void Update()
    {
        var newPos = this.transform.position + new Vector3(Random.value-0.5f, Random.value - 0.5f, Random.value - 0.5f)*5f;

        if (newPos.y < -50 || newPos.y > 150) return;
        if (newPos.x < -100 || newPos.x > 100) return;
        if (newPos.z < -100 || newPos.z > 100) return;

        this.transform.position = newPos;
    }
}
