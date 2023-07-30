using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SanityTrigger : MonoBehaviour
{
    [SerializeField] SanityManagerSO _sanityManagerSO;
    [SerializeField] int _sanityChangeAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _sanityManagerSO.ChangeSanity(_sanityChangeAmount);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _sanityManagerSO.ChangeSanity(_sanityChangeAmount);
        }
        
    }

}
