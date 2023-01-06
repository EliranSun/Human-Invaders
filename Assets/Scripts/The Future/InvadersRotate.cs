using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvadersRotate : MonoBehaviour
{
    float speed = 8;


    void Update()
    {
        Transform oroborosTransform = GameObject.Find("Invaders").GetComponent<Transform>();
        oroborosTransform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
