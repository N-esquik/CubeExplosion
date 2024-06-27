using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void Explode(Rigidbody rigidbody, float force)
    {
        Vector3 directionRandom = Random.insideUnitSphere;
        rigidbody.AddForce(directionRandom * force);
    }
}
