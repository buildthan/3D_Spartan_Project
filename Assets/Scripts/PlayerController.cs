using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpPower;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;

    public Transform Cameras;

    private Vector2 curMovementInput;
    private Vector2 mouseDelta;
    public LayerMask groundLayerMask;

    public Rigidbody rigidbody;

    void Start()
    {
        try //예외처리용
        {
            rigidbody = GetComponent<Rigidbody>(); //player rigidbody 지정용
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e.ToString());
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
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
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rigidbody.velocity.y;

        rigidbody.velocity = dir;
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        Cameras.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4] // 원점, 방향 지정용, 책상다리처럼
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 1f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 1f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 1f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) +(transform.up * 1f), Vector3.down)
        };

        for (int i = 0; i < rays.Length;  i++)
        {

            if (Physics.Raycast(rays[i], 1f, groundLayerMask)) //생각보다 짧으므로 1f 정도 길이로 싸줘야함
            {
                return true;
            }
        }

        return false;
    }

}
