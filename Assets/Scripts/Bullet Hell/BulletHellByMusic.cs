using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletHellByMusic : MonoBehaviour
{
    public GameObject bullet;
    public AudioClip audioClip;
    public AudioSource audioSource;
    public Slider timeToEndSlider;
    public Transform targetGameObjectTransform;
    public RectTransform mappedTargetTransform;

    public bool isVertical;

    bool isHudEnabled = false;
    int activeTempoIndex = 0;
    float initialTargetX = 0;
    float initialTargetY = 0;

    public float tempo = 1.24f;
    public float secondTempo = 1.22f;
    public float thirdTempo = 0.8f;

    public float horizontalForce = 500f;

    float[] tempoStartTimes = new float[5] { 40f, 77f, 102f, 145f, 200f }; // TODO: indicate if that's a stop or play, to be used in the coroutine

    float x = 0;
    float directionX = 1;
    float y = 0;
    float directionY = 1;
    
    void Start()
    {
        // TODO: actually sample the music? but it seem complex. There's a package for that that cost money https://assetstore.unity.com/packages/tools/audio/rhythmtool-15679
        initialTargetX = targetGameObjectTransform.position.x;
        initialTargetY = targetGameObjectTransform.position.y;
    }

    void Update()
    {
        //if (
        //    Mathf.Round(audioSource.time) == 41 &&
        //    !LevelController.IsFlag(LevelController.ENEMY_HUD_ENABLED)
        //    )
        //{
        //    audioSource.time = 38;
        //}

        //if (
        //    LevelController.IsFlag(LevelController.ENEMY_HUD_ENABLED) &&
        //    !isHudEnabled
        //    )
        //{
        //    isHudEnabled = true;
        //    audioSource.time = 38;
        //    audioSource.Play();
        //}

        if (Math.Round(audioSource.time) == tempoStartTimes[activeTempoIndex] + 4 && activeTempoIndex == 0) // TODO: remove +4 for prod
        {
            StartCoroutine(ShootWithTempo("vertical", tempo, y));
            activeTempoIndex++; // 1
        }

        if (Math.Round(audioSource.time) == tempoStartTimes[activeTempoIndex] && activeTempoIndex == 1)
        {
            StartCoroutine(ShootWithTempo("horizontal", secondTempo, x));
            activeTempoIndex++; // 2
        }

        if (Math.Round(audioSource.time) == tempoStartTimes[activeTempoIndex] && activeTempoIndex == 3)
        {
            StartCoroutine(ShootWithTempo("horizontal", tempo, y));
            StartCoroutine(ShootWithTempo("horizontal", tempo + 0.5f, y * 2));
            StartCoroutine(ShootWithTempo("vertical", secondTempo, x));
            StartCoroutine(ShootWithTempo("vertical", secondTempo + 0.5f, x * 2));
            activeTempoIndex++;
        }

        UpdateTimeToEndSlider();
    }

    void UpdateTimeToEndSlider()
    {
        float sliderLength = 500; // TODO: actual slider width
        float knobPosition = timeToEndSlider.fillRect.rect.width;

            // Advance both knob and enemy. That's why we divide by 2
        timeToEndSlider.value = audioSource.time * 100 / audioClip.length / 2;

        if (!targetGameObjectTransform)
        {
            // enemy destroyed
            return;
        }

        float targetPosition = isVertical ? targetGameObjectTransform.position.y : targetGameObjectTransform.position.x;

        float sliderMin = timeToEndSlider.minValue;
        float sliderMax = timeToEndSlider.maxValue;

        float positionXPercentage = isVertical
            ? targetPosition * 100 / initialTargetY
            : targetPosition * 100 / initialTargetX;

        float mappedPositionX = ((sliderLength - knobPosition) * positionXPercentage / 100) - 250;

        //print("x " + mappedPositionX + " y " + mappedTargetTransform.anchoredPosition.y);
        mappedTargetTransform.anchoredPosition = new Vector2(mappedPositionX, mappedTargetTransform.anchoredPosition.y);
    }

    IEnumerator ShootWithTempo(string type, float tempo, float axis)
    {
        while (true)
        {
            if (Math.Round(audioSource.time) == 102f && activeTempoIndex == 2)
            {
                activeTempoIndex++; // 3
                break;
            }

            if (type == "vertical")
            {
                GameObject newBullet = Instantiate(bullet, new Vector3(axis, 7, -6), Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1));
                
                if (axis < 8 && directionY == 1)
                {
                    axis++;
                }
                else if (axis > -8 && directionY == -1)
                {
                    axis--;
                } else
                {
                    // changing direction?
                    directionY = directionY * -1;
                }
            } 
            else if (type == "horizontal")
            {
                GameObject newBullet = Instantiate(bullet, new Vector3(12, axis, -6), Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-horizontalForce, 0));

                if (axis < 6 && directionX == 1) {
                    axis++;
                } 
                else if (axis > -6 && directionX == -1)
                {
                    axis--; 
                } else
                {
                    directionX = directionX * -1;
                }
            }



            yield return new WaitForSeconds(tempo);
        }
    }
}
