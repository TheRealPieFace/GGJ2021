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
    private Animator anim;
    private bool footstep = true;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerGrounded = characterController.isGrounded;


        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float yDirection = 0;
        if (!characterController.isGrounded)
        {
            yDirection -= gravity * Time.deltaTime;
        }
        Vector3 direction = new Vector3(horizontal, yDirection, vertical).normalized;
        

        if (direction.magnitude >= 0.1)
        {
            anim.SetBool("isWalking", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSpeed);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            characterController.Move(direction * movementSpeed * Time.deltaTime);
            if (!GetComponent<AudioSource>().isPlaying && footstep)
            {
                GetComponent<AudioSource>().Play();
                footstep = false;
                StartCoroutine(ToggleFootsteps());
            }
        }
        else
        {
            if (GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Stop();
            }
            anim.SetBool("isWalking", false);
        }
    }

    IEnumerator ToggleFootsteps()
    {
        yield return new WaitForSeconds(.45f);
        footstep = true;
    }
}
