using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OroborosZoomOut : MonoBehaviour
{
    public float oroborosRotateSpeed = 8f; 
    Camera mainCamera;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.fieldOfView < 100)
        {
            mainCamera.fieldOfView = mainCamera.fieldOfView * 1.05f;
        }

        Transform oroborosTransform = GameObject.Find("Oroboros").GetComponent<Transform>();
        oroborosTransform.Rotate(Vector3.forward, oroborosRotateSpeed * Time.deltaTime);
    }
}
