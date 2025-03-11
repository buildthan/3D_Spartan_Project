using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IInteractable //상호작용 인터페이스
{
    public string GetInteractPrompt();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;
    private IEnumerator coroutine;

    private float cup;

    public string GetInteractPrompt() //아이템 정보 출력용
    {
        string str = $"{data.itemName}\n{data.itemDescription}";
        return str;
    }

    public void OnInteract()
    {
        if(data.type == Type.SpeedUp) //스피드업 아이템을 먹은 경우
        {
            Player.Instance.SpeedUp(data.itemPower,data.itemDuration);
        }

        if (data.type == Type.JumpUp) //점프업 아이템을 먹은 경우
        {
            Player.Instance.JumpUp(data.itemPower, data.itemDuration);
        }

        Destroy(gameObject);
    }

}
