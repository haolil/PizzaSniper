using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorRotate : MonoBehaviour
{
    public Texture2D[] cursorTextureArray;
    public int frameCount;
    public float frameRate;

    private int currentFrame;
    private float frameTimer;

    void Start()
    {
        Cursor.visible = true;
        Cursor.SetCursor(cursorTextureArray[0], new Vector2(50, 50), CursorMode.Auto);
    }

    void Update()
    {
        frameTimer -= Time.deltaTime;
        if(frameTimer <= 0f)
        {
            frameTimer += frameRate;
            currentFrame = (currentFrame + 1) % frameCount;
            Cursor.SetCursor(cursorTextureArray[currentFrame], new Vector2(50, 50), CursorMode.Auto);
        }
    }
}
