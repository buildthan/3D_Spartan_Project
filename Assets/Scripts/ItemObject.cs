using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;
    private IEnumerator coroutine;

    private float cup;

    public string GetInteractPrompt()
    {
        string str = $"{data.itemName}\n{data.itemDescription}";
        return str;
    }

    public void OnInteract()
    {
        if(data.type == Type.SpeedUp) //���ǵ�� �������� ���� ���
        {
            Player.Instance.SpeedUp(data.itemPower,data.itemDuration);
        }

        Destroy(gameObject);
    }

}
