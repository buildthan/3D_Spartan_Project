using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPaddle : MonoBehaviour
{
    public float jumpPower;

    private void OnTriggerEnter(Collider on)
    {
        if (on.gameObject.CompareTag("Player"))
        {
            Player.Instance.controller.rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }

}
