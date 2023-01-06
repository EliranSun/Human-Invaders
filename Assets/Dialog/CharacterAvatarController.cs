using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class CharacterAvatarController : MonoBehaviour
{
    public enum Characters
    {
        Roy,
        Jazz,
        Ryan,
        Chickoboros,
        TweetySilverston,
        Rufus,
        Dottie,
        Count
    };

    public Sprite royRooster;
    public Sprite jazz;
    public Sprite ryan;
    public Sprite Chickoboros;

    void Start() { }

    void Update() { }

    [YarnCommand("changeAvatar")]
    public void ChangeAvatar() {
        // Change Image on GameObject "CharacterDialogueAvatar" to the sprite royRooster
        GameObject
            .Find("CharacterDialogueAvatar").GetComponent<Image>().sprite = royRooster;
    }
}
