using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoosterController : MonoBehaviour
{
    Rigidbody2D rigidRooster;
    Transform enemyTransform;
    PolygonCollider2D roosterCollider;
    public GameObject egg;
    bool isEggFired = false;

    void Start()
    {
        rigidRooster = GetComponent<Rigidbody2D>();
        roosterCollider = GetComponent<PolygonCollider2D>();
        GameObject enemy = GameObject.Find("HumanInvader");

        if (enemy)
        {
            enemyTransform = enemy.GetComponent<Transform>();
        }
    }

    private void Update()
    {
        if (!isEggFired && (rigidRooster.velocity.x != 0 || rigidRooster.velocity.y != 0))
        {
            StartCoroutine(FireEgg());
            isEggFired = true;
        }
    }

    IEnumerator FireEgg()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            Instantiate(egg, transform.position, egg.transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Egg" ||
            collision.gameObject.tag == "Rooster" ||
            collision.gameObject.tag == "Player" ||
            !isEggFired)
        {
            Physics2D.IgnoreCollision(collision.collider, roosterCollider);
            return;
        }

        Destroy(gameObject);
    }
}
