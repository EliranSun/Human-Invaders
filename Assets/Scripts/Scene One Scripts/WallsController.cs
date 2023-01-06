using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    BoxCollider2D wallCollider;

    private void Start()
    {
        wallCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Physics2D.IgnoreCollision(collision.collider, wallCollider);
        }
    }
}
