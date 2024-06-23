using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _force;

    public event Action ObjectExploded;

    public void InvokeExplode()
    {
        ObjectExploded?.Invoke();
    }

    private void Awake()
    {
        ObjectExploded += Explode;
    }

    private void Explode()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 directionRandom = UnityEngine.Random.insideUnitSphere;
        rigidbody.AddForce(directionRandom * _force);
    }
}
