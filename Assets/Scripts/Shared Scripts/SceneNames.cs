using System;
using UnityEngine.SceneManagement;

// TODO: Should be in SceneController?
public class SceneNames
{
    public static string STARBUCK_PRE_NUKE = "1. Starbuck - Pre Nuke";
    public static string MOON_GAZING = "2. Moon Gazing";
    public static string ZOOM_ON_SELF = "3. Zoom on Self";
    public static string ZOOM_ON_ROY = "4. Zoom on Roy's Eye - Nuke";
    public static string STARBUCK_POST_NUKE = "5. Starbuck - Post Nuke";
    public static string ON_THE_WAY_TO_SELF = "6. On the way to Self";
    public static string PROTECTING_SELF = "7b. Protecting Self";
    public static string UTTERLY_DEFEATED = "8. Utterly Defeated";
    public static string FUTURE_ONE = "8a. Future 1";
    public static string FUTURE_TWO = "8b. Future 2";
    public static string FUTURE_THREE = "8c. Future 3";
    public static string FUTURE_FOUR = "8d. Future 4";
    public static string DEMO_END = "9. Demo End";

    public static bool isScene(string sceneName)
    {
        return SceneManager.GetActiveScene().name == sceneName;
    }
}

