using UnityEngine;

[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Explosion))]
[RequireComponent(typeof (Renderer))]
[RequireComponent (typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _chanceSpanwn = 100;
    [SerializeField] private float _focreExplosion = 1000;
    [SerializeField] private float _radiusExplosion = 50;

    private Spawner _spawner;
    private Rigidbody _rigidbody;
    private Explosion _explosion;
    private Renderer _renderer;

    private int _maxChanceSpawn = 100;
    private int _dividerSpawn = 2;

    private int _minCountObjects = 2;
    private int _maxCountObjects = 6;

    private float _multiplierParametrExplosion = 1.2f;

    public void SetColor()
    {
        _renderer.material.color = Random.ColorHSV();
    }

    public void SetScatterObject()
    {
        _explosion.ScatterObject(_rigidbody, _focreExplosion);
    }

    public void IncreaseExplosionParameters()
    {
        _focreExplosion *= _multiplierParametrExplosion;
        _radiusExplosion *= _multiplierParametrExplosion;
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
        else
        {
            _explosion.Explode(_radiusExplosion,_focreExplosion);
            _explosion.CreateEffectExplode();
        }

        Destroy(gameObject);
    }
}
