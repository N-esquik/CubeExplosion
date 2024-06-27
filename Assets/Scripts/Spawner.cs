using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float _scaleSplit = 2;

    public void SpawnObjects(Cube cube,int minCountObject, int maxCountObject)
    {
        int countObjects = Random.Range(minCountObject, maxCountObject);

        for (int i = 0; i < countObjects; i++)
        {
            Cube newCube = Instantiate(cube, transform.position, Random.rotation);
            newCube.transform.localScale = cube.transform.localScale / _scaleSplit;
            newCube.SetColor();
            newCube.SetExplode();
        }
    }
}

