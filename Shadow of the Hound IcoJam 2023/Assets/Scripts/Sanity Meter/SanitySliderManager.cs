using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanitySliderManager : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] SanityManagerSO _sanityManagerSO;
    // Start is called before the first frame update
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
    void Start()
    {
        MoveSlider(_sanityManagerSO.CurrentSanity);
    }

    private void OnEnable()
    {
        _sanityManagerSO.sanityChangeEvent.AddListener(MoveSlider);
    }
    private void OnDisable()
    {
        _sanityManagerSO.sanityChangeEvent.RemoveListener(MoveSlider);
    }

    private void MoveSlider(int amount)
    {
        _slider.value = (float)amount/_sanityManagerSO.MaxSanity;
    }
}
