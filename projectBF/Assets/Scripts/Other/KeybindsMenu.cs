using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeybindsMenu : MonoBehaviour
{
    private InputManager inputManager;
    public GameObject keyList;
    public GameObject keyItemPrefab;

    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
        string[] buttonNames = inputManager.GetButtonNames();

        foreach (string bn in buttonNames)
        {
            GameObject go = (GameObject)Instantiate(keyItemPrefab);
            go.transform.SetParent(keyList.transform);
            go.transform.localScale = Vector3.one;

            Text buttonNameText = go.transform.Find("ButtonName").GetComponent<Text>();
            buttonNameText.text = bn;

            Text keyNameText = go.transform.Find("Button/KeyName").GetComponent<Text>();
            keyNameText.text = inputManager.GetKeyNameForButton(bn);

        }
    }

    void Update()
    {
        
    }
}
