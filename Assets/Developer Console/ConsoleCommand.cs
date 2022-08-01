using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConsoleCommand : ScriptableObject, IConsoleCommand
{
    [SerializeField] private string commandWord = string.Empty;
    //[SerializeField] private string infoTextField = string.Empty;

    public string CommandWord => commandWord;

    public abstract bool Process(string[] args);

    //public string InfoText => infoTextField;
}
