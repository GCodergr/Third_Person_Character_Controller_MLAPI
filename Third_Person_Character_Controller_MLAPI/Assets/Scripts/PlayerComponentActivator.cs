using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using Cinemachine;
using MLAPI;

public class PlayerComponentActivator : NetworkBehaviour
{
    public override void NetworkStart()
    {
        base.NetworkStart();

        if (IsLocalPlayer)
        {
            CharacterController characterController = GetComponent<CharacterController>();
            characterController.enabled = true;
            ThirdPersonController thirdPersonController = GetComponent<ThirdPersonController>();
            thirdPersonController.enabled = true;
            PlayerInput playerInput = GetComponent<PlayerInput>();
            playerInput.enabled = true;
            // Make Cinemachine Virtual Camera to follow player 
            GameObject playerFollowCamera = GameObject.Find("PlayerFollowCamera");
            var cinemachineVirtualCamera = playerFollowCamera.GetComponent<CinemachineVirtualCamera>();
            cinemachineVirtualCamera.Follow = thirdPersonController.CinemachineCameraTarget.transform;
        }
    }
}