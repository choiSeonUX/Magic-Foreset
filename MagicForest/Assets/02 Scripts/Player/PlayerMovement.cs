using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float runSpeed = 2f;
    private Rigidbody rigidbody;
    private Animator animator;
    private bool isRunning = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float currentSpeed = isRunning ? runSpeed : walkSpeed;
        float mobileCurrentSpeed = ButtonController.isPressed ? runSpeed : walkSpeed;
        isRunning = Input.GetKey(KeyCode.LeftShift);

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL // 키보드
        float moveHorizontal = Input.GetAxis("Horizontal") * -1;
        float moveVertical = Input.GetAxis("Vertical") * -1;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * currentSpeed;
        rigidbody.velocity = new Vector3(movement.x, rigidbody.velocity.y, movement.z);

#elif UNITY_IOS || UNITY_ANDROID // 모바일

        float moveHorizontal = Input.acceleration.x * -1;
        float moveVertical = Input.acceleration.y * -1;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * mobileCurrentSpeed;
        rigidbody.velocity = new Vector3(movement.x, rigidbody.velocity.y, movement.z);
#endif

        if (isRunning || ButtonController.isPressed)
        {
            animator.SetTrigger("Run");
            Debug.Log("Run");
        }
        else
        {
            animator.SetTrigger("Walk");
        }
    }
}