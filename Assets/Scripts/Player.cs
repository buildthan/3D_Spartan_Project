using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;

    private static Player instance;

    public ItemData itemData;

    private IEnumerator coroutine;
    private float speedCup;
    private float jumpCup;

    public static Player Instance //�ٸ� ��ũ��Ʈ���� ������ �� �ְ� �ν��Ͻ� ����
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake() //player ������Ʈ�� �̱������� �����մϴ�
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }



        try //����ó����
        {
            controller = GetComponent<PlayerController>();
        }catch(NullReferenceException e)
        {
            Debug.LogError(e.ToString());
        }
    }

    public void SpeedUp(float power, float duration) // ���ǵ� �� �������� ���� ���
    {
        coroutine = SpeedUpDelay(power,duration);
        StartCoroutine(coroutine);
    }

    private IEnumerator SpeedUpDelay(float power,float duration) // ���ǵ� �� �ڷ�ƾ
    {
        while (true)
        {
            Debug.Log($"���ǵ�� ȿ�� ���� : {duration}��");
            speedCup = controller.moveSpeed;
            controller.moveSpeed = speedCup + power;
            yield return new WaitForSeconds(duration); //waitTime ��ŭ �������� ���� �ڵ尡 ����ȴ�.
            Debug.Log("���ǵ�� ȿ�� ����");
            controller.moveSpeed = speedCup;
            break;
        }
    }

    public void JumpUp(float power, float duration)
    {
        coroutine = JumpUpDelay(power, duration);
        StartCoroutine(coroutine);
    }

    private IEnumerator JumpUpDelay(float power, float duration) // ���ǵ� �� �ڷ�ƾ
    {
        while (true)
        {
            Debug.Log($"������ ȿ�� ���� : {duration}��");
            jumpCup = controller.jumpPower;
            controller.jumpPower = jumpCup + power;
            yield return new WaitForSeconds(duration); //waitTime ��ŭ �������� ���� �ڵ尡 ����ȴ�.
            Debug.Log("������ ȿ�� ����");
            controller.jumpPower = jumpCup;
            break;
        }
    }

}
