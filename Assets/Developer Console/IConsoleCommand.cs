using UnityEngine; 
public interface IConsoleCommand
{
    string CommandWord { get; }
    bool Process(string[] args);
    //string InfoText { get; }
}
