using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;

    public GameObject mainGame;

    private InputManager inputManager;

    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
    }

    void Update()
    {
        if(inputManager.GetButtonDown("PauseGame"))
        {
            OpenCloseMenu();
        }
    }

    public void OpenCloseMenu()
    {
        if(pauseMenu.activeInHierarchy == true)
        {
            pauseMenu.SetActive(false);
            mainGame.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(true);
            mainGame.SetActive(false);
        }
    }
}

