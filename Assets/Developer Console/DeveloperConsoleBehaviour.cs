﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class DeveloperConsoleBehaviour : MonoBehaviour
{
    [SerializeField] private string prefix = string.Empty;
    [SerializeField] private ConsoleCommand[] commands = new ConsoleCommand[0];

    [Header("UI")]
    [SerializeField] private GameObject uiCanvas = null;
    [SerializeField] private InputField inputField = null;
    public bool consoleOpen;

    private float pausedTimeScale;

    public static DeveloperConsoleBehaviour instance;

    private DeveloperConsole developerConsole;

    private DeveloperConsole DeveloperConsole
    {
        get
        {
            if(developerConsole != null) { return developerConsole; }
            return developerConsole = new DeveloperConsole(prefix, commands);
        }
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void Toggle(CallbackContext context)
    {
        if(!context.action.triggered) { return; }

        if(uiCanvas.activeSelf)
        {
            consoleOpen = false;
            Time.timeScale = pausedTimeScale;
            uiCanvas.SetActive(false);
        }
        else
        {
            consoleOpen = true;
            pausedTimeScale = Time.timeScale;
            Time.timeScale = 0;
            uiCanvas.SetActive(true);
            inputField.ActivateInputField();
        }
    }

    public void ProcessCommand(string inputValue)
    {
        DeveloperConsole.ProcessCommand(inputValue);

        inputField.text = string.Empty;
    }
}
