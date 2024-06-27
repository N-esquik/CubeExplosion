using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public void ScatterObject(Rigidbody rigidbody, float force)
    {
        Vector3 directionRandom = Random.insideUnitSphere;
        rigidbody.AddForce(directionRandom * force);
    }

    public void Explode(float radius, float force)
    {
        foreach(Rigidbody exploadableObject in GetExploadableObjects(radius))
        {
            float distance = Vector3.Distance(transform.position, exploadableObject.transform.position);
            float effect = 1 - (distance / radius);

            exploadableObject.AddExplosionForce(force * effect,transform.position,radius);
        }
    }

    public void CreateEffectExplode()
    {
        Instantiate(_effect, transform.position, transform.rotation);
    }

    private List<Rigidbody> GetExploadableObjects(float radius)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        List<Rigidbody> gameObject = new();

        foreach (Collider hit in hits)
        {
            if(hit.attachedRigidbody != null)
            {
                gameObject.Add(hit.attachedRigidbody);
            }
        }

        return gameObject;
    }
}
