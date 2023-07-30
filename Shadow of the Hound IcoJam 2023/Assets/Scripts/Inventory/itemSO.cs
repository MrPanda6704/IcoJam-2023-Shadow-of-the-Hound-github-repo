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
    public ItemType type;
    public ActionType actionType;
    public Vector2 range = new Vector2(3, 4);

    [Header("UI")]
    public bool stackable;

    [Header("Both")]
    public Sprite image;

    public enum ItemType
    {
        Block,
        Tool
    }

    public enum ActionType
    {
        Dig,
        Mine,
        Fight
    }
}
