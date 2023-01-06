using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public Slider ttlSlider;
    public Slider enemyHealth;

    float timeTillEndInSeconds;
    float updateSpeed;

    void Start()
    {
        //ttlSlider = GameObject.Find("TimeTillHitSlider").GetComponent<Slider>();
        //enemyHealth = GameObject.Find("EnemyHealth").GetComponent<Slider>();

        timeTillEndInSeconds = 100f;
        updateSpeed = 1f;

        //StartCoroutine(UpdateSliderValue());
    }

    void Update()
    {
        enemyHealth.value = HumanInvaderMovement.health / 100;
    }

    IEnumerator UpdateSliderValue()
    {
        while (true)
        {
            yield return new WaitForSeconds(updateSpeed);
            float newValue = ttlSlider.value + (1 / timeTillEndInSeconds) * updateSpeed;
            ttlSlider.SetValueWithoutNotify(newValue);
        }
    }
}
