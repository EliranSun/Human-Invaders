using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatsController : MonoBehaviour
{
    public static long eggsCount = 7836630792;
    public TextMeshProUGUI eggsRemainingTextMesh = null;

    void Update()
    {
        if (eggsRemainingTextMesh == null)
        {
            return;
        }

        eggsRemainingTextMesh.text =
             "Eggs Remaining:\n" + (GameStatsController.eggsCount).ToString("N");
    }
}
