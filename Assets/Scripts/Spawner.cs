using System;
using UnityEngine;

[RequireComponent(typeof(Explosion))]
[RequireComponent(typeof(Renderer))]

public class Spawner : MonoBehaviour
{
    public event Action ObjectsSpawned;

    private int _countObjects;
    private int _minCountObject = 2;
    private int _maxCountObject = 6;

    private float _scaleSplit = 2f;

    public void CreateSmallCloneObjects()
    {
        ObjectsSpawned?.Invoke();
    }

    private void OnEnable()
    {
        ObjectsSpawned += SpawnObjects;
    }

    private void OnDisable()
    {
        ObjectsSpawned -= SpawnObjects;
    }

    private void SpawnObjects()
    {
        _countObjects = UnityEngine.Random.Range(_minCountObject, _maxCountObject + 1);

        for (int i = 0; i < _countObjects; i++)
        {
            GameObject newObject = Instantiate(gameObject, transform.position, UnityEngine.Random.rotation);
            newObject.transform.localScale = gameObject.transform.localScale / _scaleSplit;

            newObject.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
            newObject.GetComponent<Explosion>().InvokeExplode();
        }
    }
}

