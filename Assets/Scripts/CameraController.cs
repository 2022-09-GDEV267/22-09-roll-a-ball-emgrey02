using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // get offset by subtracting the player's position from the camera's position
        // only need to do this once at the start of the game because this is a set distance
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame, after all other Updates
    void LateUpdate()
    {
        // assign new position to the camera every frame
        transform.position = player.transform.position + offset;
    }
}
