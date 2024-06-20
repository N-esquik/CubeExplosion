using UnityEngine;

public class ColorRandom : MonoBehaviour
{
    private void Start()
    {
        AssignRandomColor();
    }

    private void AssignRandomColor()
    {
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            renderer.material.color = randomColor;
        }
    }
}
