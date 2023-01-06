using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class HumanInvaderMovement : MonoBehaviour
{
    float speed = 80f;
    public static float health = 10000;

    Rigidbody2D invaderRigidBody;
    Transform playerTransform;
    PolygonCollider2D invaderCollider;
    DialogSystem dialogSystem;
    public GameObject laser;
    public GameObject powerfulLaser;
    public static Transform enemyTransform;
    

    int powerfulLaserThreshold = 200;
    bool isResetPosition = false;
    bool isInitialLaserShot = false;
    bool isStartedScriptAttack = false;
    bool isDeathBehviour = false;
    bool isPositioned = false;

    int attacksCount = 0;
    int previousAttackCount = -1;

    void Start()
    {
        enemyTransform = transform;
        playerTransform = GameObject.Find("RoyRooster").transform;
        dialogSystem = GameObject.Find("DialogObject").GetComponent<DialogSystem>();
        // TODO: rotate roy and move moon/sun up so it will "fall down"
        invaderRigidBody = GetComponent<Rigidbody2D>();
        invaderCollider = GetComponent<PolygonCollider2D>();

        if (SceneNames.isScene(SceneNames.PROTECTING_SELF))
        {
            StartCoroutine(ScriptedAttack());
        }
    }

    private void Update()
    {
        // TODO: use flags instead of scenes
        if (SceneNames.isScene(SceneNames.ON_THE_WAY_TO_SELF)) {
            ScriptedBehaviour();
        }

        if (SceneNames.isScene(SceneNames.PROTECTING_SELF))
        {

            if (Input.GetKeyDown(KeyCode.K))
            {
                AvoidRoosterFire();
            }

            //if (Input.GetKeyDown(KeyCode.J))
            //{
            //    StartCoroutine(Position(new Vector3(playerTransform.position.x, 3, 0)));
            //}

            //if (Input.GetKeyDown(KeyCode.H))
            //{
            //    int attackType = Random.Range(1, 5);
            //    StartCoroutine(HorizontalAttack(attackType));
            //}

            //if (Input.GetKeyDown(KeyCode.L))
            //{
            //    StartCoroutine(HorizontalAttack(5));
            //}

            if (PlayerMovement.life == 0 && !isDeathBehviour)
            {
                isDeathBehviour = true;
                StartCoroutine(Position(new Vector3(0, 0, 0)));
                Invoke("EndScene", 3);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(collision.collider, invaderCollider);

        if (collision.gameObject.tag == "Egg")
        {
            Physics2D.IgnoreCollision(collision.collider, invaderCollider);
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void EndScene()
    {
        invaderRigidBody.velocity = Vector3.zero;
        invaderRigidBody.gravityScale = 0;

        if (PlayerMovement.life == 0)
        {
            //LevelController.SetFlag(LevelController.ROY_IS_DEFEATED);
            Invoke("BlastOff", 3);
        }
    }

    void FacePlayer()
    {
        Vector2 lookDirection = playerTransform.position - transform.position;
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        if (lookAngle < 0 && lookAngle >= -45)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (lookAngle < -45 && lookAngle >= -90)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        if (lookAngle < -90 && lookAngle >= -180)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (lookAngle > 0 && lookAngle <= 45)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    IEnumerator ScriptedAttack()
    {
        while (true)
        {
            if (PlayerMovement.life == 0)
            {
                break;
            }

            int attackType = Random.Range(1, 5);
            Utils.Print("ATTACK NO.", attacksCount);

            if (attacksCount == previousAttackCount)
            {
                yield return new WaitForSeconds(attacksCount == 8 ? 5 : 2);
            }

            if (attacksCount > 0 && (attacksCount % 8 == 0 ||
                                    attacksCount % 9 == 0 ||
                                    attacksCount % 10 == 0))
            {
                StartCoroutine(Attack(5));
                yield return new WaitForSeconds(5);
            }

            StartCoroutine(Attack(attackType));
            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator DirectedAttack()
    {
        Vector2 lookDirection = playerTransform.position - transform.position;
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, lookAngle + 90);

        while (true)
        {
            Fire(laser, 0);
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator Attack(int type)
    {
        int initX = 0;
        int initY = 0;
        int directionX = 0;
        int directionY = 0;
        int rotation = 0;
        int iterations = 0;

        switch (type)
        {
            case 1:
                {
                    initX = -8;
                    initY = 5;
                    directionX = 1;
                    rotation = 0;
                    iterations = 5;
                    break;
                }

            case 2:
                {
                    initX = 8;
                    initY = -5;
                    directionX = -1;
                    rotation = 180;
                    iterations = 5;
                    break;
                }

            case 3:
                {
                    initX = -8;
                    initY = 5;
                    directionY = -1;
                    rotation = 90;
                    iterations = 3;
                    break;
                }

            case 4:
                {
                    initX = 8;
                    initY = -5;
                    directionY = 1;
                    rotation = -90;
                    iterations = 3;
                    break;
                }

            case 5:
                {
                    initX = (int)playerTransform.position.x;
                    initY = 6;
                    directionY = 0;
                    rotation = 0;
                    iterations = 1;
                    break;
                }
        }

        StartCoroutine(Position(new Vector3(initX, initY, 0)));

        while (!isPositioned)
        {
            yield return null;
        }

        isPositioned = false;

        if (PlayerMovement.life == 0)
        {
           yield return null;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        previousAttackCount = attacksCount;

        if (type == 5)
        {
            powerfulLaserThreshold = 200;
            while (powerfulLaserThreshold > 0)
            {
                PowerfulLaserAttack();
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            for (int i = 0; i <= iterations; i++)
            {
                invaderRigidBody.AddForce(new Vector2(
                    directionX * speed * 3,
                    directionY * speed * 3
                ));

                yield return new WaitForSeconds(0.5f);

                invaderRigidBody.velocity = Vector2.zero;
                FireOnce(laser);
            }
        }

        invaderRigidBody.velocity = Vector2.zero;
        isStartedScriptAttack = false;
        attacksCount++;
    }

    void ScriptedBehaviour()
    {
        // TODO: decorator? or switching scripts upon death or something
        // else that can branch this across the invader behaviour.
        if (PlayerMovement.life == 0)
        {
            return;
        }

        float distanceFromPlayer = transform.position.y - playerTransform.position.y;

        if (distanceFromPlayer < 30 && powerfulLaserThreshold > 0)
        {
            invaderRigidBody.gravityScale = 0;
            invaderRigidBody.velocity = Vector3.zero;

            GameObject.Find("Audio Source").GetComponent<AudioSource>().Stop();
            PowerfulLaserAttack();
            return;
        }

        if (powerfulLaserThreshold == 0 && !isInitialLaserShot)
        {
            invaderRigidBody.gravityScale = 0.8f;
            isInitialLaserShot = true;
        }

        if (distanceFromPlayer < -10 && distanceFromPlayer < 0 && !isResetPosition)
        {
            Vector2 targetPosition = new Vector3(0, 2, 0);
            StartCoroutine(Position(targetPosition));
            isResetPosition = true;
        }
    }

    IEnumerator Position(Vector3 targetPosition)
    {
        while (true)
        {
            float distanceY = Mathf.Abs(transform.position.y - targetPosition.y);
            float distanceX = Mathf.Abs(transform.position.x - targetPosition.x);

            if (distanceY < 0.4f && distanceX < 0.4f)
            {
                isPositioned = true;
                OnTargetPosition();
                break;
            }

            Vector2 direction = targetPosition - transform.position;
            direction.Normalize();
            invaderRigidBody.velocity = Vector2.zero;
            invaderRigidBody.AddForce(direction * speed * 2);

            yield return new WaitForEndOfFrame();
        }
    }

    void OnTargetPosition()
    {
        if (SceneNames.isScene(SceneNames.ON_THE_WAY_TO_SELF))
        {
            invaderRigidBody.velocity = Vector3.zero;
            invaderRigidBody.gravityScale = 0;
            //LevelController.SetFlag(LevelController.INVADER_POSITIONED);
            //dialogSystem.SetActiveIndex(DialogSystem.INVADER_SAW_ROY);
        }
    }

    void BlastOff()
    {
        invaderRigidBody.gravityScale = 0.5f;
    }

    IEnumerator RandomMovement()
    {
        // TODO: rotate Y a bit on movement so it'll look like the enemy is turning
        while (true)
        {
            // TODO: decorator? or switching scripts upon death or something
            // else that can branch this across the invader behaviour.
            if (PlayerMovement.life == 0)
            {
                break;
            }

            float forceY = Random.Range(2f, 4f);
            float forceX = Random.Range(2f, 4f);
            float directionY = Random.Range(-1f, 1f);
            float directionX = Random.Range(-1f, 1f);

            float y = speed * forceY;
            float x = speed * forceX;

            invaderRigidBody.AddForce(new Vector2(directionX * x, directionY * y));
            yield return new WaitForSeconds(3);

            invaderRigidBody.AddForce(new Vector2(-directionX * x, -directionY * y));
            yield return new WaitForSeconds(4);
        }
    }

    IEnumerator ZeroInOn(Transform target)
    {
        while (true)
        {
            // TODO: decorator? or switching scripts upon death or something
            // else that can branch this across the invader behaviour.
            if (PlayerMovement.life == 0)
            {
                break;
            }

            if (isStartedScriptAttack)
            {
                break;
            }

            if (transform.position.y > 3)
            {
                Vector2 direction = target.position - transform.position;
                direction.Normalize();
                invaderRigidBody.velocity = Vector2.zero;
                invaderRigidBody.AddForce(direction * speed * 3);
                yield return new WaitForSeconds(2);
            } else
            {
                invaderRigidBody.velocity = Vector2.zero;
                invaderRigidBody.AddForce(new Vector2(speed, speed * 4));
                yield return new WaitForSeconds(2);
            }
        }
    }

    void PowerfulLaserAttack()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, -6);
        Instantiate(powerfulLaser, position, powerfulLaser.transform.rotation);
        powerfulLaserThreshold--;
    }

    void FireOnce(GameObject attack)
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, -6);
        Instantiate(attack, position, attack.transform.rotation);
    }

    IEnumerator Fire(GameObject attack, int waitFor = 3)
    {
        while (true)
        {
            if (PlayerMovement.life == 0)
            {
                break;
            }

            if (isStartedScriptAttack)
            {
                break;
            }

            yield return new WaitForSeconds(waitFor);

            Vector3 position = new Vector3(transform.position.x, transform.position.y - 3, -6);
            FireOnce(attack);
        }
    }

    void AvoidRoosterFire()
    {
        // TODO: tilt animation
        bool isPlayerAboveInvader = playerTransform.position.y > transform.position.y;
        float distanceX = Mathf.Abs(playerTransform.position.x - transform.position.x);
        Utils.Print(distanceX > 1, isPlayerAboveInvader);

        if (distanceX > 1 || isPlayerAboveInvader)
        {
            return;
        }

        float forceX = Random.Range(-2, 2); // like a goal keeper
        if (transform.position.x <= -6)
        {
            forceX = 2;
        } else if (transform.position.x >= 6)
        {
            forceX = -2;
        }

        invaderRigidBody.AddForce(new Vector2(forceX * speed * 4, 0));
        Invoke("Halt", 1);
    }

    void HomingMissle()
    {

    }

    void NetOfFire()
    {
        // bullet hell
    }

    void Halt()
    {
        invaderRigidBody.velocity = Vector2.zero;
    }

    void RunOffScreen()
    {

    }

    void CollectPowerup()
    {

    }
}
