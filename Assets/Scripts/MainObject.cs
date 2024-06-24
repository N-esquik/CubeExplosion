using System;
using UnityEngine;

public class MainObject : MonoBehaviour
{
    [SerializeField] private int _chance = 100;

    private int _maxChance = 100;
    private int _chanceRandom;
    private int _divider = 2;

    public event Action ObjectsSpawned;

    private void OnMouseDown()
    {
        _chanceRandom = UnityEngine.Random.Range(0, _maxChance + 1);

        if (_chanceRandom <= _chance)
        {
            _chance /= _divider;
            ObjectsSpawned?.Invoke();
        }

        Destroy(gameObject);
    }
}
