using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="Scriptable Objects/item")]
public class itemSO : ScriptableObject
{
    [Header("GamePlay")]
    public TileBase tile;
    public ItemName type;
    public ActionType actionType;
    public float range;
    public GameObject prefab;

    [Header("UI")]
    public bool stackable;

    [Header("Both")]
    public Sprite image;

    public enum ItemName
    {
        
        lantern
    }

    public enum ActionType
    {
        consumable,
        permanent
    }
}
