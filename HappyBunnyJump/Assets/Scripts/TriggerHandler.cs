using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    private bool triggered = false;

    public bool IsTriggered()
    {
        return this.triggered;
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        this.triggered = true;
        Debug.Log("Trigger enter : ");
    }

    public void OnTriggerExit2D(Collider2D c)
    {
        this.triggered = false;
        Debug.Log("Trigger exit : ");
    }
}
