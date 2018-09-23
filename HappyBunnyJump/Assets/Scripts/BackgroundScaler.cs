using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    //public Camera camera;
    void Awake()
    {
        //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        //float cameraHeight = camera.orthographicSize * 2;
        //Vector2 cameraSize = new Vector2(camera.aspect * cameraHeight, cameraHeight);
        //Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        //Vector2 scale = transform.localScale;
        //if (cameraSize.x >= cameraSize.y)
        //{ // Landscape (or equal)
        //    scale *= cameraSize.x / spriteSize.x;
        //}
        //else
        //{ // Portrait
        //    scale *= cameraSize.y / spriteSize.y;
        //}
        
        //transform.localScale = scale;


        //Vector3 k = transform.localScale;
        //k.x = 2 * Camera.main.orthographicSize * Camera.main.aspect / GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        //k.y = 2 * Camera.main.orthographicSize / GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        //transform.localScale = k;
    }
}
