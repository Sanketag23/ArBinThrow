using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARRaycastPlace : MonoBehaviour
{
    public ARRaycastManager raycastManager;  // Reference to the ARRaycastManager component
    public GameObject bucketPrefab;  // Reference to the bucket prefab
    public Camera arCamera;  // Reference to the AR Camera

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();  // List to store the ARRaycastHits
    private GameObject spawnedBucket;  // Instance of the bucket in the scene
    private bool isBucketPlaced = false;  // Flag to check if the bucket is placed

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = arCamera.ScreenPointToRay(touch.position);

            if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;

                if (touch.phase == TouchPhase.Began)
                {
                    if (!isBucketPlaced)
                    {
                        // Instantiate the bucket prefab at the hit position
                        spawnedBucket = Instantiate(bucketPrefab, hitPose.position, hitPose.rotation);

                        // Set the flag to indicate the bucket has been placed
                        isBucketPlaced = true;
                    }
                }
            }
        }
    }
}
