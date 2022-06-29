using UnityEngine;
using UnityEngine.UI;

public class HealthBarControl : MonoBehaviour
{
    private Slider _slider;

    private void OnEnable()
    {
        _slider = GetComponent<Slider>();
    }

    public void SetHealth(float value)
    {
        _slider.value = value;
    }

    public void SetMaxHealth(float maxHealth)
    {
        _slider.maxValue = maxHealth;
        _slider.value = maxHealth;
    }
}
