using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOneCameraController : MonoBehaviour
{
    Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.Find("RoyRooster").GetComponent<Transform>();
        GetComponent<Camera>().orthographicSize = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.x < -0.61f)
        {
            return;
        }

        transform.position = new Vector3(
            playerTransform.position.x,
            playerTransform.position.y + 0.8f,
            transform.position.z
        );
    }
}
