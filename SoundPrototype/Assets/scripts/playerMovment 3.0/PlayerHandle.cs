using EasyPhysicsSurfaces;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerHandle : MonoBehaviour
{
    private PlayerInput playerInput;
    private NewPlayerController playerController;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var Index = playerInput.playerIndex;
        var playerControllers = FindObjectsOfType<NewPlayerController>();
        playerController = playerControllers.FirstOrDefault(m=> m.GetPlayerIndex()  == Index);
        
    }
     
    
    
    
    
    
    
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (playerController != null)
            playerController.Move(context.ReadValue<Vector2>());
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        if (playerController != null)
            playerController.Aim(context.ReadValue<Vector2>());
    }

    public void OnShooter(InputAction.CallbackContext context)
    {
        if (playerController != null && context.performed)
        {
            playerController.Shooter(context.phase == InputActionPhase.Performed && context.ReadValueAsButton());
        }
    }




}
