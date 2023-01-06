using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoonSceneController : MonoBehaviour
{
    bool isTheMoonNuked = false;
    bool isRedFalloutInvoked = false;
    public Sprite chickenMeat;
    public GameObject redFallout;
    public GameObject nuclearBomb;
    GameObject roosterA;
    GameObject roosterB;
    GameObject roosterC;
    Camera mainCamera;

    void Start()
    {
        // FIXME: Why is this loading in the first scene?
        // TODO: Probably becasue Start method is being called anyway.
        // we need Awake/Enable instead?
        if (SceneNames.isScene(SceneNames.ZOOM_ON_SELF)) {
            mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            roosterA = GameObject.Find("RoosterA");
            roosterB = GameObject.Find("RoosterB");
            roosterC = GameObject.Find("RoosterC");
        }
    }

    void Update()
    {
        if (!mainCamera)
        {
            return;
        }

        if (mainCamera.fieldOfView < 6.66f && !isTheMoonNuked)
        {
            Invoke("NukeTheMoon", 5);
        }

        if (isTheMoonNuked && !isRedFalloutInvoked)
        {
            StartCoroutine(ProgressRedFalloutAndBurnRoosters());
            isRedFalloutInvoked = true;
        }

    }

    void NukeTheMoon()
    {
        nuclearBomb.SetActive(true);
        redFallout.SetActive(true);
        isTheMoonNuked = true;

        Invoke("ChangeScene", 18);
    }

    IEnumerator ProgressRedFalloutAndBurnRoosters()
    {
        yield return new WaitForSeconds(6);

        while (true)
        {
            GameObject[] roosters = GameObject.FindGameObjectsWithTag("Rooster");
            foreach (GameObject rooster in roosters)
            {
                rooster.GetComponent<SpriteRenderer>().sprite = chickenMeat;
                rooster.transform.localScale *= 4;
                yield return new WaitForSeconds(0.3f);
            }
        }
    }

    void ChangeScene()
    {
        SceneController.NextScene();
    }
}
