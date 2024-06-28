using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private float _focre = 1000;
    [SerializeField] private float _radius = 50;

    private float _multiplierParametrExplosion = 1.2f;

    public void ScatterObject(Rigidbody rigidbody)
    {
        Vector3 directionRandom = Random.insideUnitSphere;
        rigidbody.AddForce(directionRandom * _focre);
    }

    public void Explode()
    {
        foreach(Rigidbody exploadableObject in GetExploadableObjects())
        {
            float distance = Vector3.Distance(transform.position, exploadableObject.transform.position);
            float effect = 1 - (distance / _radius);

            exploadableObject.AddExplosionForce(_focre * effect,transform.position,_radius);
        }

        CreateEffectExplode();
    }

    public void IncreaseExplosionParameters()
    {
        _focre *= _multiplierParametrExplosion;
        _radius *= _multiplierParametrExplosion;
    }

    private void CreateEffectExplode()
    {
        Instantiate(_effect, transform.position, transform.rotation);
    }


    private List<Rigidbody> GetExploadableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);

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
