using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Scriptable Objects/Sanity Manager")]
public class SanityManagerSO : ScriptableObject
{
    public int MaxSanity;
    public int CurrentSanity;
    public UnityEvent<int> sanityChangeEvent;

    private void OnEnable()
    {
        CurrentSanity = MaxSanity;
        if ( sanityChangeEvent == null)
        {
            sanityChangeEvent = new UnityEvent<int>();
        }
    }
    public void ChangeSanity(int amount)
    {
        CurrentSanity += amount;
        CurrentSanity = Mathf.Clamp(CurrentSanity, 0, MaxSanity);
        sanityChangeEvent.Invoke(CurrentSanity);
       
    }
}
