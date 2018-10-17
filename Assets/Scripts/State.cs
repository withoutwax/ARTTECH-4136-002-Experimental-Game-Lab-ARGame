using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creating a menu option to add State Object in Game
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject {

    [TextArea(10, 14)][SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    [SerializeField] string[] ButtonTexts;
 
    public string GetStateStory() {
        return storyText;
    }

    public State[] GetNextStates() {
        return nextStates;
    }

    public string[] GetButtonTexts() {
        return ButtonTexts;
    }
}
