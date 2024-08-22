using UnityEngine;

public class BallController : MonoBehaviour
{
    public float destroyAfterSeconds = 10f; // Time after which the ball will be destroyed

    private void Start()
    {
        // Destroy the ball after a certain amount of time to clean up the scene.
        Destroy(gameObject, destroyAfterSeconds);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Handle ball collisions here, e.g., increase score when hitting the bucket.
    }
}
