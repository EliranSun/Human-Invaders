using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Egg : MonoBehaviour
{
    int force = 400;
    Transform enemyTransform;
    CapsuleCollider2D eggCollider;
    Rigidbody2D rigidEgg;
    public float playerDirectionX;
    public float playerDirectionY;

    void Start()
    {
        eggCollider = GetComponent<CapsuleCollider2D>();
        rigidEgg = GetComponent<Rigidbody2D>();

        if (SceneNames.isScene(SceneNames.PROTECTING_SELF))
        {
            enemyTransform = GameObject.Find("HumanInvader").GetComponent<Transform>();
            Vector3 normalizedForce = Vector3.Normalize(transform.position - enemyTransform.position);
            Utils.Print(normalizedForce * 400);
            rigidEgg.AddForce(normalizedForce * 400);
        } else
        {
            playerDirectionX = PlayerMovement.directionX;
            playerDirectionX = PlayerMovement.directionY;

            rigidEgg.gravityScale = -1;

            float forceX = playerDirectionX * force;
            float forceY = playerDirectionY * force;

            rigidEgg.AddForce(new Vector2(forceX, forceY));
        }


        Invoke("DestroyEgg", 4);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" ||
            collision.gameObject.tag == "Egg" ||
            collision.gameObject.tag == "Rooster")
        {
            Physics2D.IgnoreCollision(collision.collider, eggCollider);
            return;
        }

        Invoke("DestroyEgg", 0.1f);
        Physics2D.IgnoreCollision(collision.collider, eggCollider);
    }

    void DestroyEgg()
    {
        GameStatsController.eggsCount--;
        Destroy(gameObject);
    }

    void Print(params object[] args)
    {
        string concat = "";

        foreach (object argument in args)
        {
            concat += argument + " ";
        }

        print(concat);
    }
}
