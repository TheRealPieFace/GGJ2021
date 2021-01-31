using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterController characterController;
    [SerializeField] private float turnSpeed = 0.1f;
    private float turnSmoothVelocity;
    public float movementSpeed = 1;
    public float gravity = 9.6f;
    [SerializeField] bool playerGrounded; 

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerGrounded = characterController.isGrounded;

        KeepGrounded();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        if (!characterController.isGrounded)
        {
            direction.y -= gravity * Time.deltaTime;
        }

        if (direction.magnitude >= 0.1)
        {
            //anim.SetBool("Walking", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSpeed);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            characterController.Move(direction * movementSpeed * Time.deltaTime);
        }
        else
        {
            //anim.SetBool("Walking", false);
        }
    }

    void KeepGrounded()
    {
        if (!characterController.isGrounded)
        {
            Vector3 moveDirection = new Vector3();
            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}
