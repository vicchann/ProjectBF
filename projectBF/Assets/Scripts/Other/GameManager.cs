using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private InputManager inputManager;

    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
    }

    void Update()
    {
        if (inputManager.GetButtonDown("Pause"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
