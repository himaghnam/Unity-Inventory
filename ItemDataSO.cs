using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Inventory Item Data")]
public class ItemDataSO : ScriptableObject
{
    public string id;
    public string displayName;
    public bool stackable;
    [ShowIf("stackable", true)]public int maxStack;
    [ShowIf("stackable", true)]public int amount = 1;
    public bool consumeable;
    public Sprite icon;
    public GameObject prefab;


}
