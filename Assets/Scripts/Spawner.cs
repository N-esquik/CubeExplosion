using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private float s_chance = 10.0f;

    private Explosion _explosion;
    private Vector3 _positionRandom;

    private float _radius = 1.3f;
    private float _minChance = 1.0f;
    private float _chanceDecrease = 2.0f;

    private int _countObjects;
    private int _minCountObject = 2;
    private int _maxCountObject = 7;

    private void Start()
    {
        _explosion = GetComponent<Explosion>();
    }

    private void OnDestroy()
    {
        if (_explosion.IsDestroyed == true)
        {
            if (s_chance > _minChance)
            {
                SpawnObject();
            }
        }
    }

    private void SpawnObject()
    {
        _countObjects = Random.Range(_minCountObject, _maxCountObject);

        for (int i = 0; i < _countObjects; i++)
        {
            _positionRandom = transform.position + Random.insideUnitSphere * _radius;

            Instantiate(_gameObject, _positionRandom, Quaternion.identity);
        }

        s_chance /= _chanceDecrease;
    }
}

