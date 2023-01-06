using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    Transform playerTransform;
    Rigidbody2D rigidPlayer;

    float maxGravity = 0.6f;
    float maxGravityDistance = 10;
    Vector2 addedForce;

    private void Start()
    {
        playerTransform = GameObject.Find("RoyRooster").GetComponent<Transform>();
        rigidPlayer = GameObject.Find("RoyRooster").GetComponent<Rigidbody2D>();

        float scale = Random.Range(0.3f, 3f);
        transform.localScale *= scale;

        if (scale >= 2.5f)
        {
            //gameObject.AddComponent<OrbitalGravity>();
            GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.3f;
        }
    }

    private void Update()
    {
        if (transform.localScale.x >= 3)
        {
            PullPlayer();
        }

        DestroyIfOutOfScene();
    }

    void DestroyIfOutOfScene()
    {
        if (Mathf.Abs(transform.position.x) > 12 || Mathf.Abs(transform.position.y) > 7)
        {
            StopPullingPlayer();
            Destroy(gameObject);
        }
    }

    void StopPullingPlayer()
    {
        //rigidPlayer.AddForce(-addedForce);
        rigidPlayer.velocity = Vector2.zero;
    }

    void PullPlayer()
    {
        float distance = Vector2.Distance(transform.position, playerTransform.position);
        Vector3 vector = transform.position - playerTransform.position;

        Vector2 force = vector.normalized * (1 * distance / maxGravityDistance) * maxGravity;
        addedForce += force;
        rigidPlayer.AddForce(force);

        //lookDirection = playerTransform.position - transform.position;
        //lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        //playerTransform.rotation = Quaternion.Euler(0, 0, lookAngle);
    }
}
