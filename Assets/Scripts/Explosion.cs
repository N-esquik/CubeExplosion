using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Explosion : MonoBehaviour
{
    public void Explode(List<GameObject> cubes,float force)
    {
        foreach (GameObject cube in cubes)
        {
            Rigidbody rigidbody = cube.GetComponent<Rigidbody>();
            Vector3 directionRandom = Random.insideUnitSphere;

            rigidbody.AddForce(directionRandom * force);
        }
    }
}
