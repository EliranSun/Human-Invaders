using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ChildrenController : MonoBehaviour
{
    public GameObject[] characters;
    Dictionary<string, float>[] characterProps = new Dictionary<string, float>[2]
    {
        new Dictionary<string, float>(),
        new Dictionary<string, float>()
    };

    void Start()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characterProps[i].Add("xSwitch", Random.Range(-3, 1));
            characterProps[i].Add("xForce", Random.Range(0.3f, 0.5f));
            characterProps[i].Add("yForce", Random.Range(1.9f, 2.2f));
            characterProps[i].Add("jumpEvery", Random.Range(1f, 1.2f));
            characterProps[i].Add("restEvery", Random.Range(2, 5));
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            Walk(characters[i], i);
        }
    }

    void Walk(GameObject character, int index)
    {
        Transform characterTransform = character.transform;
        Rigidbody2D characterRigidBody = character.GetComponent<Rigidbody2D>();
        float xSwitch = characterProps[index]["xSwitch"];
        float xForce = characterProps[index]["xForce"];
        float yForce = characterProps[index]["yForce"];
        float jumpEvery = characterProps[index]["jumpEvery"];
        int restEvery = (int)characterProps[index]["restEvery"];

        FlipAvatar(characterTransform, restEvery);

        // walk randomaly left/right and switch direction
        if (
            (characterTransform.position.x <= xSwitch && xForce < 0)
            || (characterTransform.position.x >= xSwitch && xForce > 0)
        )
        {
            xForce = -xForce;
            xSwitch = Random.Range(-3, 1);
        }

        // Add a small vertical force, as if the character was jumping
        if (Time.time % jumpEvery < 0.1f)
        {
            characterRigidBody.AddForce(new Vector2(xForce, yForce));
        }
    }

    void FlipAvatar(Transform characterTransform, float restEvery)
    {
        if (Time.time % restEvery < 2f)
        {
            restEvery = Random.Range(2, 5);
            if (characterTransform.localScale.x > 0)
            {
                characterTransform.localScale = new Vector3(
                    -characterTransform.localScale.x,
                    characterTransform.localScale.y,
                    characterTransform.localScale.z
                );
            }
            return;
        }

        if (characterTransform.localScale.x < 0)
        {
            characterTransform.localScale = new Vector3(
                -characterTransform.localScale.x,
                characterTransform.localScale.y,
                characterTransform.localScale.z
            );
        }
    }
}
