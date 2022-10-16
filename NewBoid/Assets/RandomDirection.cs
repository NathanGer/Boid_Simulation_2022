using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirection : MonoBehaviour
{
    void Update()
    {
        var newPos = this.transform.position + new Vector3(Random.value-0.5f, Random.value - 0.5f, Random.value - 0.5f);

        if (newPos.y < -50 || newPos.y > 50) return;
        if (newPos.x < -50 || newPos.x > 50) return;
        if (newPos.z < -50 || newPos.z > 50) return;

        this.transform.position = newPos;
    }
}
