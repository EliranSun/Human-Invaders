using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOneController : MonoBehaviour
{
    public float acceleration = 3.0f;
    public float speed = 10.0f;
    public float maxSpeed = 100.0f;

    Rigidbody2D invaderRigidBody;
    Transform invaderTransform;

    void Start()
    {
        GameObject spaceshipObject = GameObject.Find("InvaderSpaceship");
        if (!spaceshipObject)
        {
            return;
        }

        invaderRigidBody = spaceshipObject.GetComponent<Rigidbody2D>();
        invaderTransform = spaceshipObject.GetComponent<Transform>();

    }

    private void Update()
    {
        MoveInvader();
    }

    void MoveInvader()
    {
        //// Update the speed of the object based on the acceleration
        //speed += acceleration * Time.deltaTime;

        //// Limit the speed to the maximum speed
        //speed = Mathf.Min(speed, maxSpeed);

        //// Transform the object based on the current speed
        //humanInvaderTransform.Translate(new Vector2(-speed * Time.deltaTime, 0));

        //invaderTransform.localScale = invaderTransform.localScale * 0.99f;

        //var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        //invaderRigidBody.AddRelativeForce(new Vector2(-1, 0), ForceMode2D.Force);
    }
}
