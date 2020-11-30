using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private float accelerationForce = 10f;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    [Tooltip("How fast the player turns, it ranges from 0 to 1.")]
    [Range(0,1)]
    private float turnSpeed = 0.5f;

    [SerializeField]
    private PhysicMaterial stopPhysicMaterial, movePhysicMaterial;

    private new Rigidbody rigidbody;
    private Vector2 input;
    private Collider collider;
    private readonly int moveAnimPram = Animator.StringToHash("ToWalk");
    private Animator animator;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        var inputDirection = new Vector3(input.x, 0, input.y);

        Vector3 flatCameraForward = Camera.main.transform.forward;
        flatCameraForward.y = 0;
        var cameraRotate = Quaternion.LookRotation(flatCameraForward);

        Vector3 cameraReletiveInputDirection = cameraRotate * inputDirection;

        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(cameraReletiveInputDirection * accelerationForce, ForceMode.Acceleration);
        }
        if (cameraReletiveInputDirection.magnitude > 0)
        {
            var targetRotate = Quaternion.LookRotation(cameraReletiveInputDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotate, turnSpeed);

        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
        animator.SetFloat(moveAnimPram, input.magnitude);
    }
}
