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

    public static Player Instance //다른 스크립트에서 접근할 수 있게 인스턴스 설정
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

    private void Awake() //player 오브젝트를 싱글톤으로 지정합니다
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

    public void SpeedUp(float power, float duration) // 스피드 업 아이템을 먹은 경우
    {
        coroutine = SpeedUpDelay(power,duration);
        StartCoroutine(coroutine);
    }

    private IEnumerator SpeedUpDelay(float power,float duration) // 스피드 업 코루틴
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
