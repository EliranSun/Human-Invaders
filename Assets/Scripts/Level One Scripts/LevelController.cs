using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum SceneEvents {
    OnTheWayToSelf,
    JazzIsHelping,
    EnemyDistanceHUDEnabled,
    EggsEnabled,
    CommanderModeEnabled,
    InvaderPositioned,
    StartBattle,
    RoyIsDefeated,
    RoyIsVictorious,
    JazzInstalledTranslator,
    HitTheGround,
    HealRoy,
    OroborosShenanigans,
    FutureOne,
    FutureTwo,
    FutureThree,
    FutureFour,
    DemoEnd
};

public class LevelController : MonoBehaviour
{
    public GameObject asteroid;
    public Slider TTLSlider;
    public GameObject eggsRemaining;
    public GameObject commanderLines;
    public GameObject modeButton;
    public GameObject invaderEnemy;
    public GameObject UI;

    bool isHudEnabled = false;
    bool playerTorqueAdded = false;
    bool isCameraAdded = false;
    bool isNextSceneLoaded = false;
    bool isBattleStarted = false;

    bool isSeenFutureOne = false;
    bool isSeenFutureTwo = false;
    bool isSeenFutureThree = false;
    bool isSeenFutureFour = false;

    bool isSeenDemoEndText = false;

    Rigidbody2D playerRigidBody;
    Transform moonTransform;
    Transform blackHoleTransform;
    Transform chickoborosPlace;
    DialogSystem dialogSystem;

    // TODO: ObjectableScript?
    public static Dictionary<SceneEvents, bool> flags = new Dictionary<SceneEvents, bool>()
    {
        { SceneEvents.OnTheWayToSelf, false },
        { SceneEvents.JazzIsHelping, false },
        { SceneEvents.EnemyDistanceHUDEnabled, false },
        { SceneEvents.EggsEnabled, false },
        { SceneEvents.CommanderModeEnabled, false },
        { SceneEvents.InvaderPositioned, false },
        { SceneEvents.StartBattle, false },
        { SceneEvents.RoyIsDefeated, false },
        { SceneEvents.RoyIsVictorious, false },
        { SceneEvents.JazzInstalledTranslator, false },
        { SceneEvents.HealRoy, false },
        { SceneEvents.OroborosShenanigans, false },
        { SceneEvents.FutureOne, false },
        { SceneEvents.FutureTwo, false },
        { SceneEvents.FutureThree, false },
        { SceneEvents.FutureFour, false },
        { SceneEvents.DemoEnd, false },
    };

    private void Start()
    {
        GameObject dialogObject = GameObject.Find("DialogObject");
        if (dialogObject)
        {
            dialogSystem = dialogObject.GetComponent<DialogSystem>();
        }

        playerRigidBody = GameObject.Find("RoyRooster").GetComponent<Rigidbody2D>();

        if (SceneNames.isScene(SceneNames.PROTECTING_SELF))
        {
            //dialogSystem.SetActiveIndex(31);
            moonTransform = GameObject.Find("SelfMoonCircle").GetComponent<Transform>();
            blackHoleTransform = GameObject.Find("BlackHole").GetComponent<Transform>();
        }

        if (SceneNames.isScene(SceneNames.UTTERLY_DEFEATED))
        {
            GameObject.Find("Audio Source").GetComponent<AudioSource>().Stop();
            chickoborosPlace = GameObject.Find("ChickoborosPlace").GetComponent<Transform>();
            FallingRoy();
        }

        if (SceneNames.isScene(SceneNames.DEMO_END))
        {
            //dialogSystem.SetActiveIndex(DialogSystem.THE_END);
        }
    }

    void Update()
    {
        if (SceneNames.isScene(SceneNames.ON_THE_WAY_TO_SELF))
        {
            //if (LevelController.IsFlag(LevelController.START_BATTLE) &&
            //    !isBattleStarted)
            //{
            //    isBattleStarted = true;
            //    NextScene();
            //}

            GettingToSelfScript();
        }

        // TODO: ScriptedEvents class? ScriptableObject? different script for each scene?
        if (SceneNames.isScene(SceneNames.PROTECTING_SELF))
        {
            //if (LevelController.IsFlag(LevelController.ROY_IS_DEFEATED))
            //{
            //    GameObject.Find("Audio Source").GetComponent<AudioSource>().Stop();
            //    dialogSystem.SetActiveIndex(DialogSystem.ROY_DEFEATED);
            //    Invoke("FallingRoy", 1);
            //    Invoke("TransitionBlackHoleAndMoon", 1);
            //}

            //if (!isNextSceneLoaded && flags[JAZZ_INSTALLED_TRANSLATOR])
            //{
            //    Invoke("NextScene", 6);
            //    return;
            //}
        }

        if (SceneNames.isScene(SceneNames.UTTERLY_DEFEATED))
        {
            //if (!isCameraAdded && LevelController.flags[LevelController.HEAL_ROY])
            //{
            //    isCameraAdded = true;
            //    GameObject.Find("Main Camera").AddComponent<SceneOneCameraController>();
            //    return;
            //}

            //if (LevelController.IsFlag(LevelController.OROBOROS_SHENANIGANS))
            //{
            //    if (flags[FUTURE_ONE] && !isSeenFutureOne)
            //    {
            //        AudioSource source = GameObject.Find("Audio Source").GetComponent<AudioSource>();
            //        source.time = 80;
            //        source.Play();

            //        Invoke("FutureOne", 5);
            //        isSeenFutureOne = true;
            //    }

            //    playerRigidBody.gravityScale = 0.05f;
            //    return;
            //}

            TransitionChickoborosPlace();

        }

        // TODO: state machine for dialog and scene switching?
        // Disable after testing
        if (SceneNames.isScene(SceneNames.FUTURE_ONE) && !isSeenFutureOne)
        {
            Invoke("FutureTwo", 3);
            isSeenFutureOne = true;
            return;
        }

        if (SceneNames.isScene(SceneNames.FUTURE_TWO) && !isSeenFutureTwo)
        {
            Invoke("FutureThree", 3);
            isSeenFutureTwo = true;
            return;
        }

        if (SceneNames.isScene(SceneNames.FUTURE_THREE) && !isSeenFutureThree)
        {
            Invoke("FutureFour", 3);
            isSeenFutureThree = true;
            return;
        }

        if (SceneNames.isScene(SceneNames.FUTURE_FOUR) && !isSeenFutureFour)
        {
            Invoke("FutureFour", 16);
            isSeenFutureFour = true;
            return;
        }

        //if (SceneNames.isScene(SceneNames.DEMO_END) &&
        //    LevelController.IsFlag(LevelController.THE_END) &&
        //    !isSeenDemoEndText)
        //{
        //    isSeenDemoEndText = true;
        //    Invoke("DemoEnd", 5);
        //}
    }

    void DemoEnd()
    {
        AudioSource source = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        source.time = 129;
        UI.SetActive(true);
    }

    void NextScene()
    {
        SceneController.NextScene();
        isNextSceneLoaded = true;
    }

    void FutureOne()
    {
        //LevelController.SetFlag(LevelController.FUTURE_ONE);
        SceneController.NextScene();
    }

    void FutureTwo()
    {
        //LevelController.SetFlag(LevelController.FUTURE_TWO);
        SceneController.NextScene();
    }

    void FutureThree()
    {
        //LevelController.SetFlag(LevelController.FUTURE_THREE);
        SceneController.NextScene();
    }

    void FutureFour()
    {
        AudioSource source = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        source.time = 114;
        //LevelController.SetFlag(LevelController.FUTURE_FOUR);
        SceneController.NextScene();
    }

    void TransitionChickoborosPlace()
    {
        if (chickoborosPlace.transform.position.y > 0)
        {
            playerRigidBody.velocity = Vector3.zero;
            playerRigidBody.angularDrag = 0;
            playerRigidBody.gravityScale = 1;
            BackgroundOffsetScrolling.scrollSpeed = 0;
            return;
        }

        chickoborosPlace.Translate(new Vector2(0, 10 * Time.deltaTime));
    }

    void FallingRoy()
    {
        if (!playerTorqueAdded)
        {
            playerRigidBody.AddTorque(-20f);
            playerTorqueAdded = true;
        }

        BackgroundOffsetScrolling.scrollSpeed = -1f;
    }

    void TransitionBlackHoleAndMoon()
    {
        if (blackHoleTransform.position.y > 6)
        {
            return;
        }

        moonTransform.Translate(new Vector2(0, -1f * Time.deltaTime));
        blackHoleTransform.Translate(new Vector2(0, 0.1f * Time.deltaTime));
    }

    void GettingToSelfScript()
    {
        //    if (flags[JAZZ_IS_HELPING] && !isHudEnabled)
        //    {
        //        Invoke("EnableEnemyDistanceHUD", 5);
        //        isHudEnabled = true;
        //    }

        //    if (!flags[EGGS_ENABLED] && TTLSlider.value > 21)
        //    {
        //        LevelController.SetFlag(LevelController.EGGS_ENABLED, true);
        //        eggsRemaining.SetActive(true);
        //    }

        //    if (!flags[COMMANDER_MODE_ENABLED] && TTLSlider.value > 26)
        //    {
        //        LevelController.SetFlag(LevelController.COMMANDER_MODE_ENABLED, true);
        //        commanderLines.SetActive(true);
        //        modeButton.SetActive(true);
        //    }
    }

    void GenerateStaticAsteroid()
    {
        // Roy will be able to land
    }

    void EnableEnemyDistanceHUD()
    {
        //TTLSlider.gameObject.SetActive(true);
        //LevelController.SetFlag(LevelController.ENEMY_HUD_ENABLED, true);
        //invaderEnemy.SetActive(true);
    }

    public static void SetFlag(string flagName)
    {
        //flags[flagName] = !flags[flagName];
    }

    public static void SetFlag(string flagName, bool flagValue)
    {
        //flags[flagName] = flagValue;
    }

    public static bool IsFlag(string flagName)
    {
        return true;
        //return flags[flagName];
    }
}
