using UnityEngine;

[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Explosion))]
[RequireComponent(typeof (Renderer))]
[RequireComponent (typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _chanceSpanwn = 100;

    private Spawner _spawner;
    private Rigidbody _rigidbody;
    private Explosion _explosion;
    private Renderer _renderer;

    private int _maxChanceSpawn = 100;
    private int _dividerSpawn = 2;

    private int _minCountObjects = 2;
    private int _maxCountObjects = 6;

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
            _explosion.Explode();
        }

        Destroy(gameObject);
    }

    public void Init(Cube cube,float scaleSplit)
    {
        cube.transform.localScale = this.transform.localScale / scaleSplit;
        _renderer.material.color = Random.ColorHSV();
        _explosion.ScatterObject(_rigidbody);
        _explosion.IncreaseExplosionParameters();
    }
}
