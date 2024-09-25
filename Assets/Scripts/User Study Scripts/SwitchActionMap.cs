using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchActionMap : MonoBehaviour
{
    public PlayerInput playerInput;
    public void Start()
    {
        //playerInput = GetComponent<PlayerInput>();
    }

    public void ActivateNormalPitchMap() {
        playerInput.actions.FindActionMap("Player").Enable();
        playerInput.actions.FindActionMap("Inverted Pitch").Disable();
        Debug.Log("Player action map enabled");
    }

    public void ActivateInvertedPitchMap()
    {
        playerInput.actions.FindActionMap("Player").Disable();
        playerInput.actions.FindActionMap("Inverted Pitch").Enable();
        Debug.Log("Inverted action map enabled");
    }

}
