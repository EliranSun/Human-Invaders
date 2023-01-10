using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using TMPro;

public class CharacterController : MonoBehaviour
{
    DialogueRunner dialogue;
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
    public Sprite chickoboros;
    public Sprite rufus;
    public Sprite dottie;

    void Start() { 
        dialogue = FindObjectOfType<DialogueRunner>();
    }

    void Update() { 
        ChangeAvatar();
    }

    public void ChangeAvatar() {
        GameObject characterDialogueAvatar = GameObject.Find("CharacterDialogueAvatar");
        
        if (!characterDialogueAvatar) {
            return;
        }

        Image characterDialogueAvatarImage = characterDialogueAvatar.GetComponent<Image>();

        if (dialogue.IsDialogueRunning == false) {
            characterDialogueAvatarImage.sprite = null;
            characterDialogueAvatar.SetActive(false);
            return;
        }

        Characters characterName;
        TextMeshProUGUI characterNameTextMeshPro = GameObject
            .Find("Character Name")
            .GetComponent<TextMeshProUGUI>();

        // convert string to enum
        if (System.Enum.TryParse<Characters>(characterNameTextMeshPro.text, out characterName)) {
            // array or something iteratable
            switch (characterName) {
                case Characters.Roy:
                    characterDialogueAvatarImage.sprite = royRooster;
                    break;

                case Characters.Jazz:
                    characterDialogueAvatarImage.sprite = jazz;
                    break;
                    
                case Characters.Ryan:
                    characterDialogueAvatarImage.sprite = ryan;
                    break;

                case Characters.Chickoboros:
                    characterDialogueAvatarImage.sprite = chickoboros;
                    break;

                case Characters.Dottie:
                    characterDialogueAvatarImage.sprite = dottie;
                    break;
                        
                case Characters.Rufus:
                    characterDialogueAvatarImage.sprite = rufus;
                    break;

                case Characters.None:
                default:
                    print($"No avatar found for {characterName}");
                    characterDialogueAvatarImage.sprite = null;
                    characterDialogueAvatar.SetActive(false);
                    break;
            }
        } else {
            print($"Can't parse character name: {characterNameTextMeshPro.text}");
        }
    }
}
