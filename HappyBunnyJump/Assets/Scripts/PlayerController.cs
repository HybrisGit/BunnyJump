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
            this.Deactivate();
        }

        public void Activate(PlayerController controller)
        {
            this.model.SetActive(true);
            controller.audioSource.PlayOneShot(this.activationSFX);
        }

        public void Deactivate()
        {
            this.model.SetActive(false);
        }
    }

    public PlayerMovement movement;
    public PlayerAnimationController animationController;
    public AudioSource audioSource;
    public HealthObject[] healthObjects;
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
                if (this._health != null)
                {
                    this._health.Deactivate();
                }
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

    public void SetHealthState(HealthObject.HealthState health)
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
        this.SetHealthState(HealthObject.HealthState.Well);

        this.movement.Respawn();
    }
}
