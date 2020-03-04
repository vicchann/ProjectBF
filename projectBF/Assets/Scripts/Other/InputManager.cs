using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Dictionary<string, KeyCode> buttonKeys;

    void Start()
    {
        buttonKeys = new Dictionary<string, KeyCode>();

        buttonKeys["Jump"] = KeyCode.W;
        buttonKeys["Left"] = KeyCode.A;
        buttonKeys["Down"] = KeyCode.S;
        buttonKeys["Right"] = KeyCode.D;
        buttonKeys["Sprint"] = KeyCode.LeftShift;
        buttonKeys["Pause"] = KeyCode.Escape;
    }

    public bool GetButtonDown(string buttonName)
    {
        if(buttonKeys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("InputManager::GetButtonDown -- No button named: " + buttonName);
            return false;
        }

        return Input.GetKeyDown(buttonKeys[buttonName]);
    }

    public bool GetButton(string buttonName)
    {
        if(buttonKeys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("InputManager::GetButton -- No button named: " + buttonName);
            return false;
        }

        return Input.GetKey(buttonKeys[buttonName]);
    }

    public string[] GetButtonNames()
    {
        return buttonKeys.Keys.ToArray();
    }

    public string GetKeyNameForButton(string buttonName)
    {
        if(buttonKeys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("InputManager::GetKeyNameForButton -- No button named: " + buttonName);
            return "N/A";
        }

        return buttonKeys[buttonName].ToString();
    }

    public void SetButtonForKey(string buttonName, KeyCode keyCode)
    {
        buttonKeys[buttonName] = keyCode;
    }
}
