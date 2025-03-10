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
    private float cup;

    public static Player Instance
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

    private void Awake()
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

        controller = GetComponent<PlayerController>();
    }

    public void SpeedUp(float power, float duration)
    {
        coroutine = SpeedUpDelay(power,duration);
        StartCoroutine(coroutine);
    }

    private IEnumerator SpeedUpDelay(float power,float duration)
    {
        while (true)
        {
            Debug.Log($"스피드업 효과 시작 : {duration}초");
            cup = controller.moveSpeed;
            controller.moveSpeed = cup + power;
            yield return new WaitForSeconds(duration); //waitTime 만큼 딜레이후 다음 코드가 실행된다.
            Debug.Log("스피드업 효과 종료");
            controller.moveSpeed = cup;
            break;
        }
    }

}
