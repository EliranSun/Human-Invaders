using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOffsetScrolling : MonoBehaviour
{
    static public float scrollSpeed = 0.5f;
    float speedReductionFactor = 90;
    private Renderer backgroundRenderer;
    private Vector2 savedOffset;
    Transform playerTransform;

    void Start()
    {
        GameObject player = GameObject.Find("RoyRooster");
        if (player)
        {
            playerTransform = player.GetComponent<Transform>();
        }

        backgroundRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (!playerTransform)
        {
            return;
        }

        // TODO: move with player
        float y = Mathf.Repeat(Time.time * scrollSpeed + (playerTransform.position.y / speedReductionFactor), 1);
        Vector2 offset = new Vector2(playerTransform.position.x / speedReductionFactor, y);
        backgroundRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
