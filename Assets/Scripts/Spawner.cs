using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Spawner : MonoBehaviour
{
    private float _scaleSplit = 2;

    public List<GameObject> SpawnObjects(GameObject cube, int minCountObject, int maxCountObject)
    {
        List<GameObject> cubes = new List<GameObject>();

        int countObjects = Random.Range(minCountObject, maxCountObject);

        for (int i = 0; i < countObjects; i++)
        {
            GameObject newObject = Instantiate(cube, transform.position, Random.rotation);
            newObject.transform.localScale = cube.transform.localScale / _scaleSplit;

            newObject.GetComponent<Renderer>().material.color = Random.ColorHSV();

            cubes.Add(newObject);

        }

        return cubes;
    }
}

