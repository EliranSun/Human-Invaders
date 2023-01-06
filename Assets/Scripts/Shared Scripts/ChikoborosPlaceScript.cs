using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChikoborosPlaceScript : MonoBehaviour
{
    Transform playerTransform;
    bool isTransported = false;
    DialogSystem dialogSystem;

    void Start()
    {
        dialogSystem = GameObject.Find("DialogObject").GetComponent<DialogSystem>();
        playerTransform = GameObject.Find("RoyRooster").GetComponent<Transform>();
    }

    void Update()
    {
        //if (LevelController.IsFlag(LevelController.OROBOROS_SHENANIGANS))
        //{
        //    TransportIslandInfrontOfPlayer();
        //}

    }

    void TransportIslandInfrontOfPlayer()
    {
        float distance = Vector2.Distance(transform.position, playerTransform.position);

        if (Mathf.Abs(distance) < 10 && isTransported)
        {
            Utils.Print("RESET");
            isTransported = false;
            //dialogSystem.NextLine();
        }

        if (isTransported)
        {
            return;
        }

        if (Mathf.Abs(distance) > 25)
        {
            int x = PlayerMovement.directionX == 0
                ? 0
                : PlayerMovement.directionX > 0
                    ? 30
                    : -30;
            int y = PlayerMovement.directionY == 0
                ? 0
                : PlayerMovement.directionY > 0
                    ? 30
                    : -30;

            if (PlayerMovement.directionX == 0 && PlayerMovement.directionY == 0)
            {
                return;
            }

            Utils.Print("NEW POSITION", playerTransform.position.x + x, playerTransform.position.y + y);
            transform.position = new Vector2(
                playerTransform.position.x + x,
                playerTransform.position.y + y
            );
            isTransported = true;
        }
    }
}
