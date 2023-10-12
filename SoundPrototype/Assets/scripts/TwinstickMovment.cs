using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using CodeMonkey.HealthSystemCM;

namespace EasyPhysicsSurfaces
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(AudioSource))]


    public class TwinstickMovment : MonoBehaviour
    {
        [SerializeField] private float playerSpeed = 5f;
        [SerializeField] private GameObject booblet;
        [SerializeField] private Transform boobletDirection;
        [SerializeField] private float gravityValue = -9.81f;
        [SerializeField] private float controllerDeadzone = 0.1f;
        [SerializeField] private float gamepadRotateSmoothing = 1000f;
        [SerializeField] private GameObject Player;
        
        

        [SerializeField] private bool isGamepad;

        private CharacterController controller;
        public ParticleSystem shellParticle;

        private AudioSource m_audioSource;
        private bool m_sprint;
        private float m_footstepDelay;
        private Vector2 movement;
        private Vector2 aim;
        private HealthSystem healthSystem;
        public MeshRenderer P;
     //   private bool canShoot;
     //   public float delayInSeconds;

        private Vector3 playerVelocity;

        private CarControlls carContolls;
        private PlayerInput playerInput;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            carContolls = new CarControlls();
            playerInput = GetComponent<PlayerInput>();
            m_audioSource = GetComponent<AudioSource>();
            healthSystem = new HealthSystem(1);

            healthSystem.OnDead += HealthSystem_OnDead;
        }
        private void OnEnable()
        {
            carContolls.Enable();
        }

        private void OnDisable()
        {
            carContolls.Disable();
        }

        public void Damage()
        {
            healthSystem.Damage(1);
        }

        private void HealthSystem_OnDead(object sender, System.EventArgs e)
        {
            Destroy(gameObject);
        }

        void Update()
        {
            HandleInput();
            HandleMovment();
            HandleRotation();
            UpdateSteps();
            HideMish();
            MeshShow();
        }

        void HandleInput()
        {
            movement = carContolls.Control.move.ReadValue<Vector2>();
            aim = carContolls.Control.aim.ReadValue<Vector2>();
            carContolls.Control.Shoot.performed += _ => PlayerShoot();
            carContolls.Control.disable.performed += _ => HideMish();
            carContolls.Control.enable.performed += _ => MeshShow();
        }

        private void PlayerShoot()
        {
      //      if (!canShoot) return;
            GameObject g = Instantiate(booblet, boobletDirection.position, boobletDirection.rotation);
            g.SetActive(true);
            shellParticle.Emit(count:1);
     //     StartCoroutine(CanShoot());
        }

        //  IEnumerator CanShoot()
        // {
        //    yield return new WaitForSeconds(delayInSeconds);
        //     canShoot = true;
        //   }


        private void HideMish()
        {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        }

        private void MeshShow()
        {
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;

        }


        void HandleMovment()
        {
            Vector3 move = new Vector3(movement.x, 0, movement.y);
            controller.Move(move * Time.deltaTime * playerSpeed);

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }

      

        void HandleRotation()
        {
            if (Mathf.Abs(aim.x) > controllerDeadzone || Mathf.Abs(aim.y) > controllerDeadzone)
            {
                Vector3 playerDirection = Vector3.right * aim.x + Vector3.forward * aim.y;

                if (playerDirection.sqrMagnitude > 0.0f)
                {
                    Quaternion newrotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, newrotation, gamepadRotateSmoothing * Time.deltaTime);
                }
            }
        }

       public void OnMove(InputAction.CallbackContext context)
        {
            movement = context.ReadValue<Vector2>();
        }

       public void OnAim(InputAction.CallbackContext context)
        {
            aim = context.ReadValue<Vector2>();
        }



        private void UpdateSteps()
        {
            Vector3 move = new Vector3(movement.x, 0, movement.y);

            if (movement.magnitude > 0.1f)
            {
                if (m_footstepDelay > 0)
                    m_footstepDelay -= Time.deltaTime;
                else
                {
                    float maxSpeed = playerSpeed * 2.5f; // speed in sprint
                    Footstep(movement.magnitude / maxSpeed);
                }
            }
        }
       

        private void Footstep(float force)
        {
            if (m_sprint)
                m_footstepDelay = 0.3f;
            else
                m_footstepDelay = 0.6f;

            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 2f))
            {
                if (hit.collider.TryGetComponent(out PhysicsSurfaceData physicsSurfaceData))
                    m_audioSource.PlayOneShot(physicsSurfaceData.GetFootstepSound(force));
            }
        }
    }
}

