using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint; // Assign the empty GameObject here
    public float throwForce = 10f;
    public float spawnDelay = 1f;
    public int maxThrows = 100;
    public RawImage ballImage; // Reference to the Raw Image

    private int currentThrows = 0;

    private void Start()
    {
        if (ballImage != null) 
        {
            ballImage.GetComponent<Button>().onClick.AddListener(OnBallImageClick);
        }
        else
        {
            Debug.LogError("Ball image reference is missing in BallLauncher script.");
        }
    }

    public void OnBallImageClick()
    {
        if (currentThrows < maxThrows)
        {
            StartCoroutine(SpawnAndThrowBall()); 
        }
    }
    private IEnumerator SpawnAndThrowBall()
    {
        yield return new WaitForSeconds(spawnDelay); 

        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation); // Spawn the ball which means create a new instance of the ballPrefab
        Rigidbody rb = ball.GetComponent<Rigidbody>(); // 
        rb.AddForce(spawnPoint.forward * throwForce, ForceMode.Impulse);
        currentThrows++;
    }
}
