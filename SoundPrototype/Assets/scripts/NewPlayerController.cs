using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using CodeMonkey.HealthSystemCM;

namespace EasyPhysicsSurfaces
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(AudioSource))]

    public class NewPlayerController : MonoBehaviour
    {
        [SerializeField] private float playerSpeed = 5f;
        [SerializeField] private GameObject booblet;
        [SerializeField] private Transform boobletDirection;
        [SerializeField] private float gravityValue = -9.81f;
        [SerializeField] private float controllerDeadzone = 0.1f;
        [SerializeField] private float gamepadRotateSmoothing = 1000f;
        [SerializeField] private GameObject Player;
        [SerializeField] private bool isGamepad;
        CharacterController controller;


        // stuff

        public ParticleSystem shellParticle;
        private AudioSource m_audioSource;
        private bool m_sprint;
        private float m_footstepDelay;
        private Vector2 movement;
        private Vector2 aim;
        private HealthSystem healthSystem;
        public MeshRenderer P;
        private Vector3 playerVelocity;

        private void Start()
        {
            controller = GetComponent<CharacterController>();   
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            movement = context.ReadValue<Vector2>();
        }

        public void OnAim(InputAction.CallbackContext context)
        {
            aim = context.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            //movment
            Vector3 move = new Vector3(movement.x, 0, movement.y);
            controller.Move(move * Time.deltaTime * playerSpeed);

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

            //aim
            if (Mathf.Abs(aim.x) > controllerDeadzone || Mathf.Abs(aim.y) > controllerDeadzone)
            {
                Vector3 playerDirection = Vector3.right * aim.x + Vector3.forward * aim.y;

                if (playerDirection.sqrMagnitude > 0.0f)
                {
                    Quaternion newrotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, newrotation, gamepadRotateSmoothing * Time.deltaTime);
                }
            }

            //MeshHider
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;

            //PlayerShoot
            GameObject g = Instantiate(booblet, boobletDirection.position, boobletDirection.rotation);
            g.SetActive(true);
            shellParticle.Emit(count: 1);
        }
    }

}
