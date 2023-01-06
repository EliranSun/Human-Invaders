using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSceneCameraController : MonoBehaviour
{
    Camera moonCamera;
    public float zoomLevel = 0.95f;
    public float cameraPan = 0.02f;
    void Start()
    {
        moonCamera = GetComponent<Camera>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) {
            if (moonCamera.fieldOfView <= 6.66f)
            {
                return;
            }

            transform.Translate(new Vector2(0, cameraPan));
            moonCamera.fieldOfView = moonCamera.fieldOfView * zoomLevel;
            Transform BGTransform = GameObject.Find("BG").GetComponent<Transform>();
            BGTransform.localScale = new Vector2(
                BGTransform.localScale.x + 0.01f,
                BGTransform.localScale.y + 0.01f
            );
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            moonCamera.fieldOfView = 60;
            transform.position = new Vector3(0, 0, -10);
            Transform BGTransform = GameObject.Find("BG").GetComponent<Transform>();
            BGTransform.localScale = new Vector2(0.03f, 0.03f);
        }
    }
}
