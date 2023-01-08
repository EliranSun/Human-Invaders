using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenController : MonoBehaviour
{
    Rigidbody2D characterRigidbody2D;
    Transform characterTransform;
    public float xSwitch;
    public float xForce = 0.3f;
    public float yForce = 1.6f;
    public float jumpEvery = 0.8f;
    public int restEvery = 3;

    void Start()
    {
        xSwitch = Random.Range(-3, 1);
        characterRigidbody2D = GetComponent<Rigidbody2D>();
        characterTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk(characterTransform);
    }

    void Walk(Transform characterTransform) {
        FlipAvatar();

        // walk randomaly left/right and switch direction
        if (
            (characterTransform.position.x <= xSwitch && xForce < 0) ||
            (characterTransform.position.x >= xSwitch && xForce > 0)
        ) {
            xForce = -xForce;
            xSwitch = Random.Range(-3, 1);
        }
        
        // Add a small vertical force, as if the character was jumping
        if (Time.time % jumpEvery < 0.1f) {
            characterRigidbody2D.AddForce(new Vector2(xForce, yForce));
        }
    }

    void FlipAvatar() {
        if (Time.time % restEvery < 2f) {
            restEvery = Random.Range(2, 5);
            print($"resting {Time.time}, {Time.time % restEvery}");
            if (characterTransform.localScale.x > 0) {
                characterTransform.localScale = new Vector3(
                    -characterTransform.localScale.x,
                    characterTransform.localScale.y,
                    characterTransform.localScale.z
                );
            }
            return;
        }

        if (characterTransform.localScale.x < 0) {
            characterTransform.localScale = new Vector3(
                -characterTransform.localScale.x,
                characterTransform.localScale.y,
                characterTransform.localScale.z
            );
        }
    }
}
