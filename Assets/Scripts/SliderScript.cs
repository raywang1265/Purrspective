using UnityEngine;
using UnityEngine.UI;
using System;

public class SliderController : MonoBehaviour
{
    // Reference to the Unity Slider component
    public Slider slider;

    // Public values for min, max, and current value
    private float minValue = 0f;
    private float maxValue = 82.5f;
    private float currentValue = 0.5f;

    public Vector3 hostPosition;
    
    public Vector3 clientPosition;


    void Start()
    {
        // If the Slider is not already assigned, try to get it from the GameObject
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
    }

    void Update()
    {
        // Continuously ensure the current value stays within the min and max bounds
        slider.value = (float) Math.Sqrt(((hostPosition.x - clientPosition.x) * (hostPosition.x - clientPosition.x) +
                                          (hostPosition.y - clientPosition.y) * (hostPosition.y - clientPosition.y)));  // Update the slider’s handle position
    }
}
