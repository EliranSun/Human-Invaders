using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using TMPro;

public class CharacterController : MonoBehaviour
{
    public enum Characters
    {
        None,
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

    void Start() { 
    }

    void Update() { 
        ChangeAvatar();
    }

    public void ChangeAvatar() {
        TextMeshProUGUI characterNameTextMeshPro = GameObject
            .Find("Character Name")
            .GetComponent<TextMeshProUGUI>();

        // convert string to enum
        Characters characterName;
        if (System.Enum.TryParse<Characters>(characterNameTextMeshPro.text, out characterName)) {
            // do something with characterName
        } else {
            print($"Can't parse character name: {characterNameTextMeshPro.text}");
        }

        switch (characterName) {
            case Characters.Roy:
                GameObject
                    .Find("CharacterDialogueAvatar")
                    .GetComponent<Image>().sprite = royRooster;
                break;

            case Characters.Dottie:
            case Characters.Jazz:
                GameObject
                    .Find("CharacterDialogueAvatar")
                    .GetComponent<Image>().sprite = jazz;
                break;
                
            case Characters.Rufus:
            case Characters.Ryan:
                GameObject
                    .Find("CharacterDialogueAvatar")
                    .GetComponent<Image>().sprite = ryan;
                break;

            case Characters.Chickoboros:
                GameObject
                    .Find("CharacterDialogueAvatar")
                    .GetComponent<Image>().sprite = Chickoboros;
                break;

            case Characters.None:
            default:
                print($"No avatar found for {characterName}");
                GameObject
                    .Find("CharacterDialogueAvatar")
                    .GetComponent<Image>().sprite = null;
                break;
        }
    }
}
