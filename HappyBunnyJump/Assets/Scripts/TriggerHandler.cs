using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    private int triggers = 0;

    public bool IsTriggered()
    {
        return this.triggers > 0;
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        this.triggers++;
        Debug.Log("Trigger enter : ");
    }

    public void OnTriggerExit2D(Collider2D c)
    {
        this.triggers--;
        Debug.Log("Trigger exit : ");
    }
}
