using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class vbAnim : MonoBehaviour, IVirtualButtonEventHandler {
//public class vbAnim : MonoBehaviour {
	
    // Initialize Button
    public GameObject vbBtnObj;
    private TextMesh vbBtnObjText;
    public GameObject vbBtnObj02;
    private TextMesh vbBtnObjText02;

    public Animator cubeAni;

    // Display of instructions and story goes here.
    public TextMesh instructions;

    [SerializeField] TextMesh textComponent;
    [SerializeField] State startingState;

    State state;


    // Use this for initialization
    void Start () {
        Debug.Log("Game Initiated");

        // This initializes the cube (for dancing)
        cubeAni.GetComponent<Animator>();

        // ===== INSTRUCTION SETUP =======
        // Set Instruction for this game.
        instructions = GameObject.Find("Instructions").GetComponent<TextMesh>();
        instructions.gameObject.SetActive(true);

        state = startingState;
        textComponent.text = state.GetStateStory();

        // Display the instructions!
        instructions.text = textComponent.text;

        var buttonTexts = state.GetButtonTexts();

        // ===== BUTTON SETUP =======
        vbBtnObj = GameObject.Find("Button");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vbBtnObjText = GameObject.Find("Button01Text").GetComponent<TextMesh>();
        vbBtnObjText.text = buttonTexts[0]; // Display Text in the Button

        vbBtnObj02 = GameObject.Find("Button02");
        vbBtnObj02.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vbBtnObjText02 = GameObject.Find("Button02Text").GetComponent<TextMesh>();
        vbBtnObjText02.text = buttonTexts[1]; // Display Text in the Button

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) {

        var nextStates = state.GetNextStates();

        //  This calls the next state allocated in State Class.
        switch (vb.VirtualButtonName)
        {
            case "Button01":
                Debug.Log("Button 01");
                state = nextStates[0]; // Choose next state

                break;

            case "Button02":
                Debug.Log("Button 02");
                state = nextStates[1]; // Choose next state

                break;
        }
        // Update the buttons according to next states
        var buttonTexts = state.GetButtonTexts();
        vbBtnObjText.text = buttonTexts[0];
        vbBtnObjText02.text = buttonTexts[1];

        // Play the Cube! (Make the cube dance)
        cubeAni.Play("cube_animation");

        // Update the display with new story
        textComponent.text = state.GetStateStory();
        instructions.text = textComponent.text; 

    }
	

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        cubeAni.Play("none");
        //Debug.Log("BTN Released");

    }
}
