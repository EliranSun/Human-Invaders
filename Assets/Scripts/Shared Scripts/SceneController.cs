using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    Camera mainCamera;
    Transform playerTransform;
    float initCameraOrthographicSize;

    private void Start()
    {
        if (SceneNames.isScene(SceneNames.STARBUCK_POST_NUKE))
        {
            mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            initCameraOrthographicSize = mainCamera.orthographicSize;
            playerTransform = GameObject.Find("RoyRooster").GetComponent<Transform>();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == SceneNames.STARBUCK_POST_NUKE)
        {
            // TODO: Should be elsewhere
            float playerYPosition = playerTransform.position.y;
            float nextCameraSize = playerYPosition / 4;
            bool isPlayerReachedSpace = playerYPosition >= 50;
            bool isCameraZoomPassedBoundaries = nextCameraSize <= initCameraOrthographicSize || nextCameraSize >= 7;

            if (isPlayerReachedSpace)
            {
                SceneManager.LoadScene(SceneNames.ON_THE_WAY_TO_SELF);
                return;
            }

            if (isCameraZoomPassedBoundaries)
            {
                return;
            }

            mainCamera.orthographicSize = nextCameraSize;
        }
    }

    public static void NextScene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case var value when value == SceneNames.STARBUCK_PRE_NUKE:
                {
                    SceneManager.LoadScene(SceneNames.MOON_GAZING);
                    break;
                }

            case var value when value == SceneNames.MOON_GAZING:
                {
                    SceneManager.LoadScene(SceneNames.ZOOM_ON_SELF);
                    break;
                }

            case var value when value == SceneNames.ZOOM_ON_SELF:
                {

                    SceneManager.LoadScene(SceneNames.ZOOM_ON_ROY);
                    break;
                }

            case var value when value == SceneNames.ZOOM_ON_ROY:
                {

                    SceneManager.LoadScene(SceneNames.STARBUCK_POST_NUKE);
                    break;
                }

            case var value when value == SceneNames.STARBUCK_POST_NUKE:
                {

                    SceneManager.LoadScene(SceneNames.ON_THE_WAY_TO_SELF);
                    break;
                }

            case var value when value == SceneNames.ON_THE_WAY_TO_SELF:
                {

                    SceneManager.LoadScene(SceneNames.PROTECTING_SELF);
                    break;
                }

            case var value when value == SceneNames.PROTECTING_SELF:
                {

                    SceneManager.LoadScene(SceneNames.UTTERLY_DEFEATED);
                    break;
                }

            case var value when value == SceneNames.UTTERLY_DEFEATED:
                {

                    SceneManager.LoadScene(SceneNames.FUTURE_ONE);
                    break;
                }

            case var value when value == SceneNames.FUTURE_ONE:
                {

                    SceneManager.LoadScene(SceneNames.FUTURE_TWO);
                    break;
                }

            case var value when value == SceneNames.FUTURE_TWO:
                {

                    SceneManager.LoadScene(SceneNames.FUTURE_THREE);
                    break;
                }

            case var value when value == SceneNames.FUTURE_THREE:
                {

                    SceneManager.LoadScene(SceneNames.FUTURE_FOUR);
                    break;
                }


            case var value when value == SceneNames.FUTURE_FOUR:
                {

                    SceneManager.LoadScene(SceneNames.DEMO_END);
                    break;
                }

            default:
                {
                    break;
                }
        }
    }
}
