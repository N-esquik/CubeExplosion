using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Spawner))]

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _force;

    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    private void OnEnable()
    {
        _spawner.ObjectExploded += Explode;
    }

    private void OnDisable()
    {
        _spawner.ObjectExploded -= Explode;
    }

    private void Explode()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 directionRandom = Random.insideUnitSphere;
        rigidbody.AddForce(directionRandom * _force);
    }
}
