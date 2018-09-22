using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour {

    public PlayerController.HealthObject.HealthState setHealthState = PlayerController.HealthObject.HealthState.GenericDead;
    public AudioSource[] soundEffects;

    private void OnTriggerEnter2D(Collider2D c)
    {
        PlayerController playerController = c.GetComponentInParent<PlayerController>();
        if (playerController != null)
        {
            playerController.SetHealthState(this.setHealthState);
            foreach (AudioSource soundEffect in this.soundEffects)
                soundEffect.Play();
        }
    }
}
