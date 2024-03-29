using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerObject;
    // The distance between the camera and the player.
    private Vector3 cameraDistanceOffset;
    void Start()
    {
        cameraDistanceOffset = transform.position - playerObject.transform.position;
    }



    private void LateUpdate()
    {
        // Maintain the same cameraDistanceOffset between the camera and player throughout the game.
        transform.position = playerObject.transform.position + cameraDistanceOffset;
    }
}
