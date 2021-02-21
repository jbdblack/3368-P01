using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInput : MonoBehaviour
{

    public GameObject youWinText;
    public GameObject youLoseText;

    [SerializeField] AudioClip _powerupSound = null;

    public static GameInput instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ReloadLevel();
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // play audio
            AudioHelper.PlayClip2D(_powerupSound, 1);
            
        }
    }

    void ReloadLevel()
    {
        int activeSceneIndex =
            SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }

    public void YouWin()
    {
        youWinText.SetActive(true);
    }

    public void YouLose()
    {
        youLoseText.SetActive(true);
    }
}
