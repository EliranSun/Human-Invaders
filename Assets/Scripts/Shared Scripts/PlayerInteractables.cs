using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractables : MonoBehaviour
{
    Transform playerTransform;
    public Sprite royJetpack;

    void Start()
    {
        playerTransform = GameObject.Find("RoyRooster").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            float distanceFromPlayer = Math.Abs(transform.position.x - playerTransform.position.x);

            if (distanceFromPlayer <= 0.5f)
            {
                Utils.Print("you can do something with me!", gameObject.name);
                DoSomethingWith(gameObject.name);
            }
        }
    }

    void DoSomethingWith(string gameObjectName)
    {
        switch (gameObjectName)
        {
            case "Jetpack":
                {
                    Utils.Print(SceneManager.GetActiveScene().name);
                    if (SceneManager.GetActiveScene().name == SceneNames.STARBUCK_POST_NUKE)
                    {
                        GameObject.Find("RoyRooster").GetComponent<RoyRoosterController>().FlyRoyFly();
                        Destroy(gameObject);
                    }

                    break;
                }

            case "Telescope":
                {
                    // Self moon name is totally accidental I swear
                    if (SceneManager.GetActiveScene().name == SceneNames.STARBUCK_PRE_NUKE)
                    {
                        SceneController.NextScene();
                    }

                    break;
                }
        }
    }
}
