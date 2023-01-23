using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueSystemSupport : MonoBehaviour
{
    InMemoryVariableStorage variableStorage;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        // TODO: This did not work and I resorted to use one script.
        // will be nice to understand why this did not work.
        // variableStorage = GameObject
        //     .Find("Dialogue System")
        //     .GetComponent<InMemoryVariableStorage>();

        // GetComponent<Yarn.Unity.DialogueRunner>()
        //     .AddFunction(
        //         "UpdateVariables",
        //         () =>
        //         {
        //             return UpdateVariables();
        //         }
        //     );
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: This did not work and I resorted to use one script.
        // will be nice to understand why this did not work.

        // variableStorage = GameObject
        //     .Find("Dialogue System")
        //     .GetComponent<InMemoryVariableStorage>();
        // variableStorage.TryGetValue("$telescopeControlledBy", out telescopeControlledBy);
        // print($"$telescopeControlledBy: {telescopeControlledBy}");
    }

    // [YarnCommand("update_variables")]
    // public void UpdateVariables()
    // {
    //     print($"Updating variables... $telescopeControlledBy: {telescopeControlledBy}");
    //     variableStorage.SetValue("$telescopeControlledBy", telescopeControlledBy);
    // }
}
