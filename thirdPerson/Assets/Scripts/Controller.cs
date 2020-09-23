using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private float accelerationForce = 10f;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    private PhysicMaterial stopPhysicMaterial, movePhysicMaterial;

    private new Rigidbody rigidbody;
    private Vector2 input;
    private Collider collider;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        var inputDirection = new Vector3(input.x, 0, input.y);

        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(inputDirection * accelerationForce, ForceMode.Acceleration);
        }
        if (inputDirection.magnitude> 0)
        {
            collider.material = movePhysicMaterial;
        }
        else
        {
            collider.material = stopPhysicMaterial;
        }
    }
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
}
