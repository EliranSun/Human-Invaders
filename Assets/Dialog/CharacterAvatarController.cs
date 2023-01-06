using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [ContextMenu("Change Avatar")]
    [YarnCommand("avatar")]
    public void ChangeAvatar() { }
}
