using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 20f;
    public float shakeMagnitude = 0.05f;
    public float dampingSpeed = 1f;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.localPosition;
        Invoke("NextScene", 10);
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake()
    {
        shakeDuration = 0.5f;
    }

    void NextScene()
    {
        // TODO: find a static way. problem is I want current scene to be public for better control
        SceneController.NextScene();
    }
}