using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // TODO: move to another file, and rethink architecture
    // after the demo is complete and you know all the pieces
    public static int life = 20;
    int invulnerabilitySeconds = 2;
    bool isInvulnerable = false;
    bool healedRoy = false;
    public GameObject heart;
    GameObject[] hearts = new GameObject[20];
    public Sprite walkingSprite;
    public Sprite flyingSprite;
    SpriteRenderer roySpriteRenderer;

    public static float directionX;
    public static float directionY;

    public int force = 400;
    readonly float speed = 20f;
    public int eggDeployedCount = 0;

    public float amplitude = 0.1f;
    public float frequency = 1f;
    int flapForce = 10;

    Rigidbody2D rigidPlayer;
    public GameObject egg;

    bool isFlipped = false;

    private void Start()
    {
        if (SceneNames.isScene(SceneNames.UTTERLY_DEFEATED))
        {
            life = 0;
        }

        roySpriteRenderer = GetComponent<SpriteRenderer>();
        rigidPlayer = GetComponent<Rigidbody2D>();
        StartCoroutine(FlapWings()); // FIXME: FlapWings bugs with asteroids I think
        DrawHearts();
    }

    private void Update()
    {
        //if (!healedRoy && LevelController.flags[LevelController.HEAL_ROY])
        //{
        //    healedRoy = true;
        //    life = 10;
        //    transform.rotation = Quaternion.identity;
        //    roySpriteRenderer.sprite = walkingSprite;
        //    DrawHearts();
        //}

        if (Input.GetKeyDown(KeyCode.R))
        {
            life = 10;
            transform.rotation = Quaternion.identity;
            DrawHearts();
        }

        if (life == 0)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Random.Range(-500, 500);
            rigidPlayer.AddForce(new Vector2(x, 0));
        }

        //LookAtEnemy();
        Movement();
        FireEgg();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
            return;
        }

        // TODO: animation/impact effect/sound/invulenrability frames
        if (life > 0)
        {
            life--;
            Destroy(hearts[life]);
            isInvulnerable = true;
            Invoke("MakeInvulnerable", invulnerabilitySeconds);
        }
    }

    void MakeInvulnerable()
    {
        isInvulnerable = true;
    }

    void DrawHearts()
    {
        // 0 - 9
        for (int i = 0; i < 10; i++)
        {
            GameObject newHeart = Instantiate(heart, new Vector3(-8 + i * 0.8f, 4, -6), heart.transform.rotation);
            newHeart.transform.SetParent(GameObject.Find("Main Camera").GetComponent<Transform>());
            hearts[i] = newHeart;
        }

        for (int i = 0; i < 10; i++)
        {
            GameObject newHeart = Instantiate(heart, new Vector3(-8 + i * 0.8f, 4, -6), heart.transform.rotation);
            newHeart.transform.SetParent(GameObject.Find("Main Camera").GetComponent<Transform>());
            hearts[i + 10] = newHeart;
        }
    }

    void LookAtEnemy()
    {
        //transform.LookAt(HumanInvaderMovement.enemyTransform);
        if (!GameObject.Find("HumanInvader"))
        {
            return;
        }

        float y = HumanInvaderMovement.enemyTransform.position.y - transform.position.y;
        float x = HumanInvaderMovement.enemyTransform.position.x - transform.position.x;
        float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

        //print(angle);
        //bool shouldFlipY = false;
        //bool shouldFlipX = false;

        //if (angle >= 90 && angle < 180 || angle > -180 && angle <= -90)
        //{
        //    if (!isFlipped)
        //    {
        //        transform.localScale = new Vector2(
        //            transform.localScale.x,
        //            transform.localScale.y * -1
        //        );
        //        isFlipped = true;
        //    }
        //} else
        //{
        //    if (isFlipped)
        //    {
        //        transform.localScale = new Vector2(
        //            transform.localScale.x,
        //            transform.localScale.y * -1
        //        );
        //        isFlipped = false;
        //    }
        //}

        //Utils.Print("isFlipped?", isFlipped, angle);
        //transform.eulerAngles = new Vector3(0, 0, angle);
    }

    void Movement()
    {
        directionX = Input.GetAxis("Horizontal");
        directionY = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Chicken should stay put when firing egg
            rigidPlayer.velocity = Vector2.zero;
            transform.rotation = Quaternion.identity;
            return;
        }

        float x = transform.position.x + directionX * speed * Time.deltaTime;
        float y = transform.position.y + directionY * speed * Time.deltaTime;

        transform.position = new Vector3(x, y, -6);
    }

    IEnumerator FlapWings()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            rigidPlayer.velocity = new Vector2(0, 0);
            rigidPlayer.AddForce(new Vector2(0, -flapForce));

            yield return new WaitForSeconds(1);

            rigidPlayer.velocity = new Vector2(0, 0);
            rigidPlayer.AddForce(new Vector2(0, flapForce));
        }
    }

    void FireEgg()
    {
        // TODO: add back when final
        //if (!LevelController.IsFlag(LevelController.EGGS_ENABLED))
        //{
        //    return;
        //}

        if (eggDeployedCount == GameStatsController.eggsCount)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject newEgg = Instantiate(
                egg,
                new Vector3(transform.position.x, transform.position.y + 1, -6),
                egg.transform.rotation
            );
            eggDeployedCount++;
        }
    }

    bool isOutOfBounds(float x, float y)
    {
        return
            x < -8.4f ||
            x > 8.4f ||
            y < -4.4f ||
            y > 4.4f;
    }


}
