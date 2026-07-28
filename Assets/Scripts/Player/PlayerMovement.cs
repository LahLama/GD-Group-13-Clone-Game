
    using Unity.VisualScripting;
    using UnityEngine;


    public class PlayerMovement : MonoBehaviour
    {
        InputSystem_Actions inputActions;
        CharacterController cc;
        float moveScale = 1;
        public float smallScale = 0.1f;
        float normalScale = 1f;
        public float walkMod = 8f;
        public float sprintMod = 16f;
        public float jumpForce = 8f;     
        public float gravity = -9.8f;
        public float crouchSpeed = 8f;
        float standingHeight;
        float standingCenterY;
        public float camOffset;
        public Camera mainCamera;
        

    float verticalVelocity;


        void Awake()
        {
            inputActions = new InputSystem_Actions();
            cc = GetComponent<CharacterController>();
            moveScale = walkMod;
            standingHeight = cc.height;
            standingCenterY = cc.center.y;
        }
    //Enables New Input System
        void OnEnable()
        {
            inputActions.Enable();
        }
        void OnDisable()
        {
            inputActions.Disable();
        }

        void Update()
        {
            Vector2 moveInput = inputActions.Player.Move.ReadValue<Vector2>();
            bool jumpInput = inputActions.Player.Jump.WasPressedThisFrame();
            bool sprintInput = inputActions.Player.Sprint.ReadValue<float>() > 0;
            bool crouchInput = inputActions.Player.Crouch.ReadValue<float>() > 0;

           
            //Detects if the player is sprinting or not
            moveScale = (sprintInput && !crouchInput) ? sprintMod : walkMod;
            float targetHeight = crouchInput ? smallScale : standingHeight;
            cc.height = Mathf.Lerp(cc.height, targetHeight, crouchSpeed * Time.deltaTime);

            
            float centerY = standingCenterY - (standingHeight - cc.height) / 2f;

            Vector3 camLocalPos = mainCamera.transform.localPosition;
            camLocalPos.y = cc.height - camOffset;
            mainCamera.transform.localPosition = camLocalPos;

            cc.center = new Vector3(cc.center.x, centerY, cc.center.z);
           

            // Movement relative to player facing direction

            Vector3 move = (transform.right * moveInput.x + transform.forward * moveInput.y) *moveScale  ;
        // Vertical movement
            if (cc.isGrounded)
            {
                // small downward value keeps the controller "grounded" each frame
                verticalVelocity = -1f;

                if (jumpInput && !crouchInput)
                {
                    verticalVelocity = jumpForce;
                }
            }
            else
            {
                verticalVelocity += gravity * Time.deltaTime;
            }

            move.y = verticalVelocity;

         

            cc.Move(move * Time.deltaTime);
        }
    }
