using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    void Start()
    {
        GetComponent<Yarn.Unity.DialogueRunner>()
            .AddFunction(
                "CoinToss",
                () =>
                {
                    return CoinToss();
                }
            );
    }

    // Update is called once per frame
    void Update() { }

    public float GetRandomValue()
    {
        return Random.Range(0, 1); // return a random number between 0 and 99 (will never return 100)
    }
    public string CoinToss()
    {
        // Random.Range() returns a value between 0 and 1.
        // 0 is Heads, 1 is Tails.
        // We use the value returned by Random.Range() to determine Heads or Tails.
        if (Random.Range(0, 2) == 0)
        {
            return "Heads";
        }
        else
        {
            return "Tails";
        }
    }
}
