using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScale : MonoBehaviour
{
    [Header("Powerup Settings")]
    [SerializeField] float _sizeIncreaseAmount = 2;
    [SerializeField] float _powerupDuration = 5;

    [Header("Setup")]
    [SerializeField] GameObject _visualsToDeactivate = null;
    [SerializeField] AudioClip _powerupSound = null;
    [SerializeField] AudioClip _powerdownSound = null;

    Collider _colliderToDeactivate = null;
    bool _poweredUp = false;

    private void Awake()
    {
        _colliderToDeactivate = GetComponent<Collider>();

        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerShip playerShip
            = other.gameObject.GetComponent<PlayerShip>();
        // if we have a valid player and not already powered up
        if (playerShip != null && _poweredUp == false)
        {
            // start powerup timer. Restart if it's already started
            StartCoroutine(PowerupSequence(playerShip));
        }
        // play audio
        AudioHelper.PlayClip2D(_powerupSound, 1);
    }

    IEnumerator PowerupSequence(PlayerShip playerShip)
    {
        // set boolean for detecting lockout
        _poweredUp = true;

        ActivatePowerup(playerShip);
        // simulate this object being disabled. We don't
        // REALLY want to disable it, because we still need
        // script behaviour to continue functioning
        DisableObject();

        // wait for the required duration
        yield return new WaitForSeconds(_powerupDuration);
        // reset
        DeactivatePowerup(playerShip);
        EnableObject();

        // set boolean to release lockout
        _poweredUp = false;
    }

    void ActivatePowerup(PlayerShip playerShip)
    {
        if (playerShip != null)
        {
            // powerup player
            playerShip.ShrinkScale();
            // visuals
           
        }
    }

    void DeactivatePowerup(PlayerShip playerShip)
    {
        // revert player powerup. - will subtract
        playerShip.GrowScale();
        // audio
        AudioHelper.PlayClip2D(_powerdownSound, 1);

    }

    public void DisableObject()
    {
        // disable collider, so it can't be retriggered
        _colliderToDeactivate.enabled = false;
        // disable visuals, to stimulate deactivated
        _visualsToDeactivate.SetActive(false);
        //TODO reactivate particle flash/audio
    }

    public void EnableObject()
    {
        // enable collider, so it can be tretriggered
        _colliderToDeactivate.enabled = true;
        // enable visuals again, to draw player attention
        _visualsToDeactivate.SetActive(true);
        //TODO reactivate particule flash/audio
    }

}
