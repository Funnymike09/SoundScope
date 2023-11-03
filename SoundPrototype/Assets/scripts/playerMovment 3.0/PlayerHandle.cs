using EasyPhysicsSurfaces;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerHandle : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private NewPlayerController playerController;
    [SerializeField] private MeshRenderer playerMesh;
    [SerializeField] private Renderer bloodSys;

    private CarControlls controls; 

    private void Awake()
    {

        playerController = GetComponent<NewPlayerController>();   
        controls = new CarControlls();
    }
     
    public void InitialisePlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        playerMesh.material = pc.playerMaterial;
        bloodSys.material = pc.playerMaterial;
        playerConfig.Input.onActionTriggered += Input_onActionTriggered;
        
    }

    private void Input_onActionTriggered(CallbackContext obj)
    {
        if (obj.action.name == controls.Control.move.name) 
        {
            OnMove(obj);
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
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
