using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPaddle : MonoBehaviour
{
    public float jumpPower;

    private void OnTriggerEnter(Collider on) // 점프 패드를 밟을 경우 위로 솟구쳐오름
    {
        if (on.gameObject.CompareTag("Player"))
        {
            Player.Instance.controller.rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }

}
