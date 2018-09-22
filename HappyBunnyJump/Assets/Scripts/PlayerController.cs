using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [System.Serializable]
    public class HealthObject
    {
        public enum HealthState
        {
            Well,
            GenericDead,
            GenericNotDead,
        }

        public HealthState healthState;
        public GameObject model;
        public AudioClip activationSFX;

        public void Setup()
        {
            this.model.SetActive(false);
        }

        public void Activate(PlayerController controller)
        {
            controller.defaultModel.SetActive(false);
            this.model.SetActive(true);
            controller.audioSource.PlayOneShot(this.activationSFX);
        }
    }

    public PlayerMovement movement;
    public PlayerAnimationController animationController;
    public GameObject defaultModel;
    public AudioSource audioSource;
    public HealthObject[] healthObjects;
    public HealthObject defaultHealthObject;
    public float respawnTimeSeconds;

    private float lastDead = 0f;

    private HealthObject _health = null;
    public HealthObject Health
    {
        get
        {
            return this._health;
        }
        set
        {
            if (this._health == null || this._health.healthState != value.healthState)
            {
                this._health = value;
                this._health.Activate(this);
            }
        }
    }

    void Awake()
    {
        this.movement.playerController = this;
        this.animationController.playerController = this;
        this.animationController.playerMovement = this.movement;

        foreach (HealthObject o in this.healthObjects)
        {
            o.Setup();
        }
    }

    void Start()
    {
        this.Respawn();
    }

    void Update()
    {
        if (this.Health != null && this.Health.healthState != HealthObject.HealthState.Well)
        {
            // evaluate respawn
            if (Time.time - this.lastDead > this.respawnTimeSeconds)
            {
                this.Respawn();
            }
        }
    }

    public void Kill(HealthObject.HealthState health)
    {
        foreach (HealthObject o in this.healthObjects)
        {
            if (o.healthState == health)
            {
                this.Health = o;
                this.lastDead = Time.time;
                return;
            }
        }
    }

    private void Respawn()
    {
        this.Health = this.defaultHealthObject;

        this.movement.Respawn();
    }
}
