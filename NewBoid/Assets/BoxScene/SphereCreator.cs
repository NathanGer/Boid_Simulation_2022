using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.GraphicsBuffer;

public class SphereCreator : MonoBehaviour
{
    public GameObject Prefab;
    public float distance;
    [Range(0, 1)] public float timeSpawn;
    [Range(0, 2)] public float increm;
    [Range(1, 1000)] public float nbrPoint;
    [Range(1, 180)] public float minAngle;
    [Range(1, 1000)] public float speed;
    public List<(GameObject,Vector3)> values = new List<(GameObject, Vector3)>();
    public List<Vector3> SphereDiscretisationValue = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ICreateSphere());
 
    }

    IEnumerator ICreateSphere()
    {
        for (int i = 0; i < nbrPoint; i++)
        {
            float dst = i / (nbrPoint - 1);
            float angleDelta = (Mathf.Acos(2*dst-1)*2)-Mathf.PI;
            float angleTheta = 2 * Mathf.PI * increm * i;
            if (Mathf.Abs(angleDelta) * Mathf.Rad2Deg>minAngle || Mathf.Abs(angleTheta%(2*Mathf.PI)) * Mathf.Rad2Deg>minAngle)
            {
                float x = Mathf.Cos(angleDelta) * Mathf.Cos(angleTheta);
                float y = Mathf.Cos(angleDelta) * Mathf.Sin(angleTheta);
                float z = Mathf.Sin(angleDelta);
                var go = Instantiate(Prefab);
                values.Add((go, (Vector3.right * x + Vector3.forward * y + Vector3.up * z) * distance));
                SphereDiscretisationValue.Add(((Vector3.right * x + Vector3.forward * y + Vector3.up * z) * distance)); yield return new WaitForSeconds(timeSpawn);

            }
            yield return new WaitForSeconds(timeSpawn);
        }
    }

    private void Update()
    {

        var step = speed * Time.deltaTime; // calculate distance to move
        foreach (var item in values)
        {
            item.Item1.transform.position = Vector3.MoveTowards(item.Item1.transform.position, item.Item2, step);
        }
        //OnDrawGizmos();
    }

    private void TraceRaycast()
    {
        
    }

    void OnDrawGizmos()
    {
        // Draws a 5 unit long red line in front of the object
        foreach (var item in SphereDiscretisationValue)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(Vector3.zero, item);
        }
    }

}
