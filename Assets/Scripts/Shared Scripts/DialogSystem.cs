using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public enum Characters
{
    Roy,
    Jazz,
    Ryan,
    Chickoboros,
    TweetySilverston,
    Rufus,
    Dottie
};

public class Trigger
{
    public string name = "";

    public Trigger(string triggerName)
    {
        this.name = triggerName;
    }
}

// TODO: LevelController/GameManager should control Dialog, and inject it with right script
// TODO: AND it should be objectable script. no constructor shit, editable right through unity
public class Dialog
{
    public Characters speaker;
    public string text;
    public int waitForSeconds  = 0;
    public int speed = 2;
    public bool isBreak = false;
    public string trigger;
    public SceneEvents sceneEvent;

    public Dialog(Characters speaker, string text, int waitFor = 0)
    {
        this.speaker = speaker;
        this.text = text;
    }

    public Dialog(Characters speaker, string text, SceneEvents sceneEvent)
    {
        this.speaker = speaker;
        this.text = text;
        this.sceneEvent = sceneEvent;
    }

    public Dialog(Characters speaker, string text, int waitFor, string trigger, bool isBreak)
    {
        this.speaker = speaker;
        this.text = text;
        this.trigger = trigger;
        this.waitForSeconds = waitFor;
        this.isBreak = isBreak;
    }
}

class OnTheWayToSelfDialog
{
    Dialog[] dialog = new Dialog[] {
            

            // Roy is on its way to Self
            new Dialog(Characters.Roy, "Jazz, Jazz, do you copy?!", SceneEvents.OnTheWayToSelf),
            new Dialog(Characters.Roy, "Jazz!!!"),
            new Dialog(Characters.Jazz, "Jesus Roy, what is it?"),
            new Dialog(Characters.Roy, "Self... Fucking Self. They Fucking NUKED SELF"),
            new Dialog(Characters.Jazz, "What?"),
            new Dialog(Characters.Roy, "I Can't believe it... I fucking can't...", 1),
            new Dialog(Characters.Jazz, "Oh my god... It's all over the news..."),
            new Dialog(Characters.Roy, "I'm already on my way there right now,"),
            new Dialog(Characters.Roy, "I'm gonna catch these bastards and and figure what the fuck is going on"),
            new Dialog(Characters.Jazz, "Is this a joke?"),
            new Dialog(Characters.Roy, "No Jazz"),
            new Dialog(Characters.Roy, "I need my egg and rooster teleporter,"),
            new Dialog(Characters.Roy, "I need all I can get. I have to get them"),
            new Dialog(Characters.Roy, "I'm gonna fucking get them."),
            new Dialog(Characters.Jazz, "Roy, wait - just wait,"),
            new Dialog(Characters.Roy, "No waiting. It's my fucking moon. I know roosters there. Fuck - they."),
            new Dialog(Characters.Roy, "They might have killed Wing in that blast."), // 20
            new Dialog(Characters.Jazz, "..."),
            new Dialog(Characters.Roy, "You know I won't stop."),
            new Dialog(Characters.Jazz, "I know."),
            new Dialog(Characters.Roy, "Then Jazz, please."),
            new Dialog(Characters.Roy, "I know we don't work together anymore, but I need everything you can get."),
            new Dialog(Characters.Jazz, "*SIGH*"), // 25
            new Dialog(Characters.Jazz, "Ok. I'm on it. Give me a few."),
            new Dialog(Characters.Jazz, "Don't do anything hasty until then. OK? Avoid contact.", SceneEvents.JazzIsHelping)
        };
}

class TrackerHudDialog
{
    Dialog[] dialog = new Dialog[] {
            new Dialog(Characters.Jazz, "OK. I've installed a tracking module in your HUD.", SceneEvents.EnemyDistanceHUDEnabled),
            new Dialog(Characters.Jazz, "You should see these fuckers now. Don't lose them Roy Rooster, do you get it?."),
            new Dialog(Characters.Roy, "Not a chance in hell I do.")
    };
}

class BattleStartDialog
{
    Dialog[] dialog = new Dialog[] {
            new Dialog(Characters.Ryan, "ଏବଂ ଆମର ଏଠାରେ କ’ଣ ଅଛି ...?", SceneEvents.InvaderPositioned), // 30
            new Dialog(Characters.Roy, "I'M GONNA FUCKING DESTROY YOU, YOU MONSTER"),
            new Dialog(Characters.Ryan, "ସେ କ’ଣ କହୁଛନ୍ତି")
    };
}

class BattleOutcomeDialog
{
    Dialog[] dialog = new Dialog[] {
             // Battle outcomes
            new Dialog(Characters.Ryan, "Out of my way, CHICKEN.", SceneEvents.RoyIsDefeated), // 33
            new Dialog(Characters.Ryan, "Shit, how is it so strong?", SceneEvents.RoyIsVictorious), // 34
    };
}

class TranslatorInstalledDialog
{
    Dialog[] dialog = new Dialog[] {

            new Dialog(Characters.Jazz, "Ok I've installed a translator tool in your HUD."),
            new Dialog(Characters.Jazz, "You should be able to understand what these fuckers say now."), // 35
            new Dialog(Characters.Jazz, "Roy?"),
    };
}

class ChickoborosDialogPart1
{
    Dialog[] dialog = new Dialog[] {

            // chickoboros
            new Dialog(Characters.Chickoboros, "My oh my. How the - not so mighty - have fallen ;)", SceneEvents.HitTheGround),
            new Dialog(Characters.Roy, "..."),
            new Dialog(Characters.Roy, "Who are you?"),
            new Dialog(Characters.Chickoboros, "No, bro. The right question is - who are YOU?"),
            new Dialog(Characters.Chickoboros, "Look at you. You can't even walk. You can't even move"),
            new Dialog(Characters.Roy, "..."),
            new Dialog(Characters.Chickoboros, "Let me fix that. Can't talk to you in this state. I feel so... UNHINGED. So... UNNATURAL."),
            new Dialog(Characters.Chickoboros, "BOOM"),
            new Dialog(Characters.Roy, "What the..."),
            new Dialog(Characters.Chickoboros, "Right?", 1),
            new Dialog(Characters.Roy, "Hey, Thanks for healing me... however you did that."),
            new Dialog(Characters.Roy, "But I gotta go now."),
            new Dialog(Characters.Chickoboros, "Hey man, you do you. no one's going to stop you..."),
    };
}

class ChickoborosDialogPart2
{
    Dialog[] dialog = new Dialog[] {

            new Dialog(Characters.Chickoboros, "...because YOU are the only one stopping yourself"),
            new Dialog(Characters.Roy, "WTH"),
            new Dialog(Characters.Chickoboros, "It might be hell, but it also might be heaven ;)")
    };
}

class ChickoborosDialogPart3
{
    Dialog[] dialog = new Dialog[] {

            new Dialog(Characters.Chickoboros, "Look at you. Flying around like that."),
            new Dialog(Characters.Roy, "..."),
            new Dialog(Characters.Roy, "Let me leave right now"),
            new Dialog(Characters.Chickoboros, "Oh? Or else?"),
            new Dialog(Characters.Chickoboros, "You will kill me, like you killed that invader?"),
            new Dialog(Characters.Roy, "..."),
            new Dialog(Characters.Chickoboros, "I've seen it all. You are weak. Too weak."),
            new Dialog(Characters.Chickoboros, "Think you can destroy their fleet? Avenge your friend?"),
            new Dialog(Characters.Chickoboros, "Think again."),
            new Dialog(Characters.Roy, "Who are you exactly?"),
            new Dialog(Characters.Chickoboros, "I can help you, if you let me."),
            new Dialog(Characters.Roy, "I don't need your help."),
            new Dialog(Characters.Chickoboros, "Oh? is that so?"),
            new Dialog(Characters.Roy, "That is."),
            new Dialog(Characters.Chickoboros, "Well then. leave, if you think you can."),
    };
}

class ChickoborosDialogPart4
{
    Dialog[] dialog = new Dialog[] {
            new Dialog(Characters.Chickoboros, "But before you do, let me show you TWO reasons why you CAN'T"),
            new Dialog(Characters.Chickoboros, "First, let me show you your future..."),
            new Dialog(Characters.Roy, "What?"),
    };
}

class DemoEndDialog
{
    Dialog[] dialog = new Dialog[] {
            new Dialog(Characters.Roy, "0.0"),
            new Dialog(Characters.Chickoboros, "Second reason for why you can't go there, is, well..."),
            new Dialog(Characters.Chickoboros, "a BIT more technical.")
    };
}

public class DialogSystem : MonoBehaviour
{

    int activeDialogIndex = 0;

    bool isSpeaking = false;
    bool isWaitingFlag = false;
    bool isNextButtonPressed = false;

    public List<Sprite> sprites = new List<Sprite>();

    public TextMeshProUGUI dialogText;
    public SpriteRenderer avatar;
    public SpriteRenderer avatarBG;

    Dialog[] dialog;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        
        ClearSpeakSection();
    }

    void Update()
    {
        bool dialogEnd = activeDialogIndex >= dialog.Length;
        if (dialogEnd)
        {
            ClearSpeakSection();
            return;
        }


        bool isTriggerEvent = dialog[activeDialogIndex].trigger != null;
        int waitForSeconds = dialog[activeDialogIndex].waitForSeconds;


        if (isTriggerEvent && !LevelController.IsFlag(dialog[activeDialogIndex].trigger))
        {
            LevelController.SetFlag(dialog[activeDialogIndex].trigger);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            ClearSpeakSection();
            bool isBreak = dialog[activeDialogIndex].isBreak;
            if (isBreak)
            {
                return;
            }

            Invoke("Speak", waitForSeconds);
        }
    }

    void Speak()
    {
        avatarBG.enabled = true;
        dialogText.text = dialog[activeDialogIndex].text;
        avatar.sprite = sprites[0];
    }

    void ClearSpeakSection()
    {
        dialogText.text = "";
        avatar.sprite = null;
        avatarBG.enabled = false;
    }
}
