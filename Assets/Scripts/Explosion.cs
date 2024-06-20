using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private bool _isDestroyed = false;

    public bool IsDestroyed => _isDestroyed;

    private void OnMouseDown()
    {
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (Rigidbody exploadableObject in GetExploadableObjects())
        {
            exploadableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        _isDestroyed = true;
    }

    private List<Rigidbody> GetExploadableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> gameObject = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                gameObject.Add(hit.attachedRigidbody);
            }
        }

        return gameObject;
    }
}
