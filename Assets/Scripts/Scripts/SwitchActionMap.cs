using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchActionMap : MonoBehaviour
{
    public PlayerInput playerInput;
    public void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    public void ActivateNormalPitchMap(InputAction.CallbackContext context) {
        playerInput.actions.FindActionMap("Player").Enable();
        playerInput.actions.FindActionMap("Inverted Pitch").Disable();
    }

    public void ActivateInvertedPitchMap(InputAction.CallbackContext context)
    {
        playerInput.actions.FindActionMap("Player").Disable();
        playerInput.actions.FindActionMap("Inverted Pitch").Enable();
    }

}
