using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public static void Print(params object[] args)
    {
        string concat = "";

        foreach (object argument in args)
        {
            concat += argument + " ";
        }

        print(concat);
    }
}
