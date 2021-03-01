using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HazardVolume : MonoBehaviour
{
    [SerializeField] AudioClip _loseSound = null;

    public float speed = 1.09f;
    Vector3 pointA;
    Vector3 pointB;

    void Start()
    {
        pointA = new Vector3(-17.6f, -1.34f, 51.6f);
        pointB = new Vector3(22.25f, -1.34f, 51.6f);
    }

    void FixedUpdate()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }

    private void OnTriggerEnter(Collider other)
    {
        // detect if it's the player
        PlayerShip playerShip
            = other.gameObject.GetComponent<PlayerShip>();
        if(playerShip != null)
        {
            //do something!
            playerShip.Kill();

            GameInput.instance.YouLose();
            // play audio
            AudioHelper.PlayClip2D(_loseSound, 1);
        }


    }

  

}
