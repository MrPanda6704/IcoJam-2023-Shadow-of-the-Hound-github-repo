using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class lantern : MonoBehaviour
{
    public InventoryManager _inventoryManager;
    public GameObject _playerLight;
    [SerializeField] itemSO  _lantern;
    public bool check = false;

    public void Update()
    {
        lightUp();
    }
    void lightUp()
    {
        if (_inventoryManager.GetSelectedItemSO() == _lantern)
        {
            if (_playerLight.activeSelf == false)
            {
                _playerLight.SetActive(true);
            }
            
        }
        else
        {
            if (_playerLight.activeSelf)
            {
                _playerLight.SetActive(false);
            }
        }
    }
}
