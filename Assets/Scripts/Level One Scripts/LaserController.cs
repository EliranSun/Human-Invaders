using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    Transform enemyRotation;
    int force = 400;

    private void Start()
    {
        enemyRotation = GameObject.Find("HumanInvader").GetComponent<Transform>();
        transform.rotation = enemyRotation.rotation;
        Vector2 directedForce = Vector2.down;


        if (enemyRotation.rotation.z == 0)
            directedForce = Vector2.down;

        if (enemyRotation.rotation.z <= -0.6f && enemyRotation.rotation.z >= -0.8f)
            directedForce = Vector2.left;

        if (enemyRotation.rotation.z >= 0.6f && enemyRotation.rotation.z <= 0.8f)
            directedForce = Vector2.right;

        if (enemyRotation.rotation.z == -1)
            directedForce = Vector2.up;

        GetComponent<Rigidbody2D>().AddForce(directedForce * force);
        Destroy(gameObject, 4);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyAttack") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<CapsuleCollider2D>());
            return;
        }

        Destroy(gameObject);
    }
}
