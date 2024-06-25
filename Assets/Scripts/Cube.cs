using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Explosion))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _chanceSpanwn = 100;
    [SerializeField] private float _focreExplosion = 1000;

    private Spawner _spawner;
    private Explosion _explosion;

    private int _maxChanceSpawn = 100;
    private int _dividerSpawn = 2;

    private int _minCountObjects = 2;
    private int _maxCountObjects = 6;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        _explosion = GetComponent<Explosion>();
    }

    private void OnMouseDown()
    {
        int chanceRandom = Random.Range(0, _maxChanceSpawn + 1);

        if (chanceRandom <= _chanceSpanwn)
        {
            _chanceSpanwn /= _dividerSpawn;
            List<GameObject> newCubes = _spawner.SpawnObjects(gameObject, _minCountObjects, _maxCountObjects + 1);
            _explosion.Explode(newCubes, _focreExplosion);
        }

        Destroy(gameObject);
    }
}
