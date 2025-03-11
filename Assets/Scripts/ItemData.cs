using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    SpeedUp,
    JumpUp
}


[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    public Type type;
    public string itemName;
    public string itemDescription;
    public float itemPower;
    public float itemDuration;
}

