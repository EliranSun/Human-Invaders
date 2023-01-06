using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoyRoosterController : MonoBehaviour
{
    Transform telescopeTransform;
    Animator walkingAnimation;
    Rigidbody2D rigidRoy;
    public Sprite royJetpack;
    bool isFlying = false;
    int speed = 5;
    public int jetpackForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        rigidRoy = GetComponent<Rigidbody2D>();
        walkingAnimation = GetComponent<Animator>();
        telescopeTransform = GameObject.Find("Telescope").GetComponent<Transform>();
    }

    
    void Update()
    {
        if (isFlying)
        {
            Fly();
        } else
        {
            Walk();
        }
    }

    void Walk()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        walkingAnimation.SetBool("isWalking", Math.Abs(horizontalInput) > 0.1);

        float x = transform.position.x + horizontalInput * speed * Time.deltaTime;
        float y = transform.position.y;

        transform.position = new Vector3(x, y, -3);
    }

    void Fly()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float x = transform.position.x + horizontalInput * speed * Time.deltaTime;
        if (verticalInput > 0)
        {
            rigidRoy.AddForce(new Vector2(0, verticalInput * jetpackForce));
        }

        transform.position = new Vector3(x, transform.position.y, -3);
    }

    public void FlyRoyFly()
    {
        walkingAnimation.enabled = false;
        GetComponent<SpriteRenderer>().sprite = royJetpack;
        isFlying = true;
    }
}
