using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Dictionary<string, KeyCode> buttonKeys;

    void Start()
    {
        buttonKeys = new Dictionary<string, KeyCode>();

        buttonKeys["Jump"] = KeyCode.W;
        buttonKeys["MoveLeft"] = KeyCode.A;
        buttonKeys["MoveRight"] = KeyCode.D;
        buttonKeys["Sprint"] = KeyCode.LeftShift;
        buttonKeys["Pause"] = KeyCode.Escape;
    }

    void Update()
    {
        
    }

    public bool GetButtonDown(string buttonName)
    {
        if (buttonKeys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("InputManager::GetButtonDown -- No button named: " + buttonName);
            return false;
        }

        return Input.GetKeyDown(buttonKeys[buttonName]);
    }

    public bool GetButton(string buttonName)
    {
        if (buttonKeys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("InputManager::GetButton -- No button named: " + buttonName);
            return false;
        }

        return Input.GetKey(buttonKeys[buttonName]);
    }
}
