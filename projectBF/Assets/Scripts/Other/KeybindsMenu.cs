using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class KeybindsMenu : MonoBehaviour
{
    Dictionary <string, Text> buttonToLabel;

    private InputManager inputManager;
    public GameObject keyList;
    public GameObject keyItemPrefab;

    string buttonToRebind = null;

    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
        string[] buttonNames = inputManager.GetButtonNames();
        buttonToLabel = new Dictionary<string, Text>();

        for(int i = 0; i < buttonNames.Length; i++)
        {
            string bn;
            bn = buttonNames[i];

            GameObject go = (GameObject)Instantiate(keyItemPrefab);
            go.transform.SetParent(keyList.transform);
            go.transform.localScale = Vector3.one;

            Text buttonNameText = go.transform.Find("ButtonName").GetComponent<Text>();
            buttonNameText.text = bn;

            Text keyNameText = go.transform.Find("Button/KeyName").GetComponent<Text>();
            keyNameText.text = inputManager.GetKeyNameForButton(bn);
            buttonToLabel[bn] = keyNameText;

            Button keyBindButton = go.transform.Find("Button").GetComponent<Button>();
            keyBindButton.onClick.AddListener(() => { StartRebindFor(bn); });

        }
    }

    void Update ()
    {
        if(buttonToRebind != null)
        {
            if(Input.anyKeyDown)
            {
                foreach(KeyCode kc in Enum.GetValues (typeof(KeyCode)))
                {
                    if(Input.GetKeyDown(kc))
                    {
                        inputManager.SetButtonForKey(buttonToRebind, kc);
                        buttonToLabel[buttonToRebind].text = kc.ToString();
                        buttonToRebind = null;
                        break;
                    }
                }
            }
        }
    }
    
    void StartRebindFor(string buttonName)
    {
        Debug.Log("Start rebind for: " + buttonName);
        buttonToRebind = buttonName;
    }
}
