using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public float scrollSpeed = 0.1f;
    public bool xAxis = true, yAxis = true;
    
    private Vector2 startPosition;

    void Awake()
    {
        this.startPosition = this.transform.localPosition;
    }

    void Update()
    {
        float x = this.transform.localPosition.x;
        float y = this.transform.localPosition.y;
        if (this.xAxis)
        {
            x = (Camera.main.transform.position.x - this.startPosition.x) * (this.scrollSpeed);
        }
        if (this.yAxis)
        {
            y = (Camera.main.transform.position.y - this.startPosition.y) * (this.scrollSpeed);
        }
        this.transform.localPosition = new Vector2(x, y);
    }
}
