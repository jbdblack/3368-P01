using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 12f;
    [SerializeField] float _turnSpeed = 3f;

    [Header("Feedback")]
    [SerializeField] TrailRenderer _trail = null;

    [SerializeField] ParticleSystem shipParticle = null;

    Rigidbody _rb = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _trail.enabled = false;
    }

    private void FixedUpdate()
    {
        MoveShip();
        TurnShip();
    }

    private void Update()
    {
        // start/stop the particles for forward movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            shipParticle.Play();
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            shipParticle.Stop();
        }
        
    }

    // use forces to build momentum forward/backward
    void MoveShip()
    {
        // S/Down = -1, W/Up = 1, None = 0. Scale by moveSpeed
        float moveAmountThisFrame = Input.GetAxisRaw("Vertical") * _moveSpeed;
        // combine our direction with our calculated amount
        Vector3 moveDirection = transform.forward * moveAmountThisFrame;
        // apply the movement to the physics object
        _rb.AddForce(moveDirection);
    }

    // don't use forces for this. We want rotations to be precise
    void TurnShip()
    {
        // A/Left = -1, D/Right = 1, None = 0. Scale by turnSpeed
        float turnAmountThisFrame = Input.GetAxisRaw("Horizontal") * _turnSpeed;
        // specify an axis to apply our turn amount (x,y,z) as a rotation
        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
        // spin the rigidbody
        _rb.MoveRotation(_rb.rotation * turnOffset);
    }

    public void Kill()
    {
        Debug.Log("Player has been killed!");
        this.gameObject.SetActive(false);
    }

    public void SetSpeed(float speedChange)
    {
        _moveSpeed += speedChange;
        //TODO audio/visuals
    }

    public void SetBoosters(bool activeState)
    {
        _trail.enabled = activeState;
    }

    public void ShrinkScale()
    {
        this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void GrowScale()
    {
        this.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }


}
