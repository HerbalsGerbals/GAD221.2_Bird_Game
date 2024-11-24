using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    //defines offset from camera to player
    private float smoothTime = 0.25f;
    //time it takes for camera to catch up to player
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetposition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothTime);
        //moves the camera with the player
    }
}
