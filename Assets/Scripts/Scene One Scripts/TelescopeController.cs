using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelescopeController : MonoBehaviour
{
    int speed = 2;
    Transform moonTransform;

    // Start is called before the first frame update
    void Start()
    {
        moonTransform = GameObject.Find("Moon").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float x = transform.position.x + -horizontalInput * speed * Time.deltaTime;
        float y = transform.position.y + verticalInput * speed * Time.deltaTime;

        transform.position = new Vector3(x, y, transform.position.z);


        if (Input.GetKeyDown(KeyCode.X))
        {
            bool isMoonCentered =
                (moonTransform.position.x - transform.position.x) < 0.8f &&
                (moonTransform.position.y - transform.position.y) < 0.8f;

            if (isMoonCentered) {
                SceneController.NextScene();
            }
        }
    }
}
