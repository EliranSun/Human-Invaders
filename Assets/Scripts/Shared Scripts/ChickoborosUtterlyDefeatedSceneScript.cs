using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickoborosUtterlyDefeatedSceneScript : MonoBehaviour
{
    bool isScriptBegan = false;
    Transform chickoborosPlace;
    DialogSystem dialogSystem;

    // Start is called before the first frame update
    void Start()
    {
        dialogSystem = GameObject.Find("DialogObject").GetComponent<DialogSystem>();
        chickoborosPlace = GameObject.Find("ChickoborosPlace").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chickoborosPlace.position.y >= 0 && !isScriptBegan)
        {
            isScriptBegan = true;
            Invoke("LookAtPlayer", 2);
        }
    }

    void LookAtPlayer()
    {
        transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        //dialogSystem.SetActiveIndex(DialogSystem.CHICKOBOROS_SCRIPT_START);
    }
}
