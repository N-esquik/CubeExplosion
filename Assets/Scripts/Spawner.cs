using System;
using UnityEngine;

[RequireComponent (typeof(MainObject))]
[RequireComponent(typeof(Renderer))]

public class Spawner : MonoBehaviour
{
    private MainObject _mainObject;

    private int _minCountObject = 2;
    private int _maxCountObject = 6;

    private float _scaleSplit = 2f;

    public event Action ObjectExploded;

    private void Awake()
    {
        _mainObject = GetComponent<MainObject>();
    }

    private void OnEnable()
    {
        _mainObject.ObjectsSpawned += SpawnObjects;
    }

    private void OnDisable()
    {
        _mainObject.ObjectsSpawned -= SpawnObjects;
    }

    private void SpawnObjects()
    {
        int countObjects = UnityEngine.Random.Range(_minCountObject, _maxCountObject + 1);

        for (int i = 0; i < countObjects; i++)
        {
            GameObject newObject = Instantiate(gameObject, transform.position, UnityEngine.Random.rotation);
            newObject.transform.localScale = gameObject.transform.localScale / _scaleSplit;

            newObject.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
            newObject.GetComponent<Spawner>().ObjectExploded?.Invoke();
        }
    }
}

