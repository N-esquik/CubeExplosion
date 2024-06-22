using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    public event Action ObjectExploded;

    public void InvokeExplode()
    {
        ObjectExploded?.Invoke();
    }

    private void OnEnable()
    {
        ObjectExploded += Explode;
    }

    private void OnDisable()
    {
        ObjectExploded -= Explode;
    }

    private void Explode()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (rigidbody != null)
        {
            rigidbody.AddExplosionForce(_force, transform.position, _radius);
        }
    }
}
