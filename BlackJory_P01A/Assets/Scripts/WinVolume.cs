using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // detect if it's the player
        PlayerShip playerShip
            = other.gameObject.GetComponent<PlayerShip>();
        if (playerShip != null)
        {
            //do something!
            playerShip.Kill();
            GameInput.instance.YouWin();
        }

    }
}
