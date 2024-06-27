using UnityEngine;

[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Explosion))]
[RequireComponent(typeof (Renderer))]
[RequireComponent (typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _chanceSpanwn = 100;
    [SerializeField] private float _focreExplosion = 1000;

    private Spawner _spawner;
    private Rigidbody _rigidbody;
    private Explosion _explosion;
    private Renderer _renderer;

    private int _maxChanceSpawn = 100;
    private int _dividerSpawn = 2;

    private int _minCountObjects = 2;
    private int _maxCountObjects = 6;

    public void SetColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }

    public void SetExplode()
    {
        _explosion.Explode(_rigidbody, _focreExplosion);
    }

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        _explosion = GetComponent<Explosion>();
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        int chanceRandom = Random.Range(0, _maxChanceSpawn + 1);

        if (chanceRandom <= _chanceSpanwn)
        {
            _chanceSpanwn /= _dividerSpawn;
            _spawner.SpawnObjects(this,_minCountObjects, _maxCountObjects + 1);
        }

        Destroy(gameObject);
    }
}
