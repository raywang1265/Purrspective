using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    // Reference to the Unity Slider component
    public Slider slider;

    // Public values for min, max, and current value
    public float minValue = 0f;
    public float maxValue = 1f;
    public float currentValue = 0.5f;

    void Start()
    {
        // If the Slider is not already assigned, try to get it from the GameObject
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }

        // Set the Slider's initial values
        SetSliderValues(minValue, maxValue, currentValue);
    }

    void Update()
    {
        // Continuously ensure the current value stays within the min and max bounds
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        slider.value = currentValue;  // Update the slider’s handle position
    }

    // Method to set all values (min, max, and current)
    public void SetSliderValues(float min, float max, float current)
    {
        minValue = min;
        maxValue = max;
        currentValue = Mathf.Clamp(current, minValue, maxValue);  // Ensure the current value is valid

        // Update the slider component with the new values
        slider.minValue = minValue;
        slider.maxValue = maxValue;
        slider.value = currentValue;
    }

    // Method to change the min value
    public void SetMinValue(float min)
    {
        minValue = min;
        slider.minValue = minValue;
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        slider.value = currentValue;
    }

    // Method to change the max value
    public void SetMaxValue(float max)
    {
        maxValue = max;
        slider.maxValue = maxValue;
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        slider.value = currentValue;
    }

    // Method to change the current value
    public void SetCurrentValue(float value)
    {
        currentValue = Mathf.Clamp(value, minValue, maxValue);
        slider.value = currentValue;
    }
}
