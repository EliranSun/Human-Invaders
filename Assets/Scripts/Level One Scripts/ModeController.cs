using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    bool isRooster = true;
    string roosterModeText = "Mode:\nRooster";
    string commanderModeText = "Mode:\nCommander";

    public void OnModeChange(TextMeshProUGUI buttonTestMesh)
    {
        isRooster = !isRooster;
        GameObject modeButton = GameObject.Find("ModeButton");
        
        buttonTestMesh.text = isRooster
            ? roosterModeText
            : commanderModeText;
    }
}
