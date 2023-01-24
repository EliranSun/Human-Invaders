using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class DialogueSystemSupport : MonoBehaviour
{
    InMemoryVariableStorage variableStorage;
    DialogueRunner dialogueRunner;

    void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        dialogueRunner.Stop();

        switch (SceneManager.GetActiveScene().name)
        {
            case var value when value == SceneNames.STARBUCK_PRE_NUKE:
            {
                dialogueRunner.StartDialogue("Start");
                break;
            }

            case var value when value == SceneNames.MOON_GAZING:
            {
                dialogueRunner.StartDialogue("TelescopeGazing");
                break;
            }
        }
    }
}
