using UnityEngine;

[RequireComponent(typeof(Explosion))]
[RequireComponent(typeof(Spawner))]

public class MainObject : MonoBehaviour
{
    [SerializeField] private int _chance = 100;

    private int _maxChance = 100;
    private int _chanceRandom;

    private void OnMouseDown()
    {
        _chanceRandom = Random.Range(0, _maxChance + 1);

        if (_chanceRandom <= _chance)
        {
            _chance /= 2;
            gameObject.GetComponent<Spawner>().InvokeSpawnObjects();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
