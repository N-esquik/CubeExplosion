using UnityEngine;

[RequireComponent(typeof(Explosion))]
[RequireComponent(typeof(Spawner))]

public class MainObject : MonoBehaviour
{
    [SerializeField] private int _chance = 100;

    private Spawner _spawner;

    private int _maxChance = 100;
    private int _chanceRandom;
    private int _divider = 2;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    private void OnMouseDown()
    {
        _chanceRandom = Random.Range(0, _maxChance + 1);

        if (_chanceRandom <= _chance)
        {
            _chance /= _divider;
            _spawner.CreateSmallCloneObjects();
        }

        Destroy(gameObject);
    }
}
