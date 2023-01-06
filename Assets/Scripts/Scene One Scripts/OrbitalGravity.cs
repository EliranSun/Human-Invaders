using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalGravity : MonoBehaviour
{

    Transform playerTransform;
    Rigidbody2D rigidPlayer;

    float maxGravity = 1;
    float maxGravityDistance = 10;

    float lookAngle;
    Vector3 lookDirection;

    void Start()
    {
        playerTransform = GameObject.Find("RoyRooster").GetComponent<Transform>();
        rigidPlayer = GameObject.Find("RoyRooster").GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
}
