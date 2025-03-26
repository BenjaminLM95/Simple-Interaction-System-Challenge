using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GameInput.IPlayerActions
{
    private GameInput gameInput;
    private bool right; 

    void Awake() 
    {
        gameInput = new GameInput();
        gameInput.Player.Enable();
        gameInput.Player.SetCallbacks(this);
        right = true; 
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log("Receiving move Input : " + context.ReadValue<Vector2>());
        Actions.MoveEvent?.Invoke(context.ReadValue<Vector2>()); 
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {

        if(context.started) 
        {
            Actions.TargetingCowBoy?.Invoke();
            Actions.SpaceBarAction?.Invoke();
        }

        if (context.performed) 
        {
            Actions.ChangeSprite?.Invoke();
            //Debug.Log("ChangeSprite");

            Actions.GrowCircle?.Invoke();
            //Debug.Log("GrowCircle");

            
        }


        if (context.canceled) 
        {            
            Actions.StopGrowing?.Invoke();
            Actions.ResumeSpeed?.Invoke();

            if (right)
            {
                Actions.ChangeSprite?.Invoke();
                //Debug.Log("ChangeSprite");
                right = false;
            }
            else
            {
                Actions.ReturnSprite?.Invoke();
                //Debug.Log("ReturnSprite");
                right = true;
            }
        }
    }
}


public static class Actions
{
    public static Action<Vector2> MoveEvent;
    public static Action GrowCircle; //This action will be triggered with space
    public static Action StopGrowing;  //This action will be triggered with space
    public static Action ChangeSprite; //This action will be triggered with space
    public static Action ReturnSprite; //This action will be triggered with space
    public static Action TargetingCowBoy;  //This action will be triggered with space
    public static Action SpaceBarAction; //This action will be triggered with space
    public static Action ResumeSpeed; //This action will be triggered with space


}


