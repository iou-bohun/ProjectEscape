using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
using FMOD.Studio;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public float jumpForce;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;
    [SerializeField] private Transform originCameraPosition;
    [SerializeField] private Transform sitCameraPosition;

    private Vector2 mouseDelta;

    [HideInInspector]
    public bool canLook = true;

    private Rigidbody _rigidbody;

    public static PlayerController instance;


    // Audio
    private EventInstance footstepsWalkRock;
    private EventInstance footstepsRunRock;
    private bool isRunning = false;




    private void Awake()
    {
        instance = this;
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Audio
        footstepsWalkRock = AudioManager.instance.CreateInstace(FMODEvents.instance.footstepsWalkRock);
        footstepsRunRock = AudioManager.instance.CreateInstace(FMODEvents.instance.footstepsRunRock);
    }
    private void FixedUpdate()
    {
        Move();
        UpdateSound();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }
    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);

    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (IsGrounded())
            {
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
    private bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position+ (transform.forward*0.2f)+(Vector3.up*0.01f),Vector3.down),
            new Ray(transform.position+ (-transform.forward*0.2f)+(Vector3.up*0.01f),Vector3.down),
            new Ray(transform.position +(transform.right * 0.2f) +(Vector3.up * 0.01f),Vector3.down),
            new Ray(transform.position +(-transform.right * 0.2f) +(Vector3.up * 0.01f),Vector3.down),
        };
        for(int i = 0; i< rays.Length; i++)
        {
            if (Physics.Raycast(rays[i],0.1f, groundLayerMask))
            {
                return true; 
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + (transform.forward * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (-transform.forward * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (transform.right * 0.2f), Vector3.down);
        Gizmos.DrawRay(transform.position + (-transform.right * 0.2f), Vector3.down);
    }

    public void OnRunInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            moveSpeed = 8;
            isRunning = true;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            moveSpeed = 4;
            isRunning = false;
        }
    }

    public void OnSitInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            cameraContainer.position = sitCameraPosition.position;
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            cameraContainer.position = originCameraPosition.position;
        }
    }

    private void UpdateSound()
    {
        float x = _rigidbody.velocity.x;
        float z = _rigidbody.velocity.z;
        bool isStopped = (x == 0 || z == 0) ? true : false;

        if (!isStopped && IsGrounded())
        {
            if (!isRunning)
            {
                footstepsRunRock.stop(STOP_MODE.ALLOWFADEOUT);
                PLAYBACK_STATE playbackState;
                footstepsWalkRock.getPlaybackState(out playbackState);
                if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
                {
                    footstepsWalkRock.start();
                }
            }
            else
            {
                footstepsWalkRock.stop(STOP_MODE.ALLOWFADEOUT);
                PLAYBACK_STATE playbackState;
                footstepsRunRock.getPlaybackState(out playbackState);
                if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
                {
                    footstepsRunRock.start();
                }
            }
        }
        else
        {
            footstepsWalkRock.stop(STOP_MODE.ALLOWFADEOUT);
            footstepsRunRock.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }
}


