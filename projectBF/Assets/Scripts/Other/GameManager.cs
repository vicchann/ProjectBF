using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject pauseMenu;

    [SerializeField]
    private GameObject theGame;

    private InputManager inputManager;

    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
    }

    void Update()
    {
        if(inputManager.GetButtonDown("Pause"))
        {
            OpenCloseMenu();
        }
    }

    public void OpenCloseMenu()
    {
        if(pauseMenu.activeInHierarchy == true)
        {
            pauseMenu.SetActive(false);
            theGame.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(true);
            theGame.SetActive(false);
        }
    }
}

