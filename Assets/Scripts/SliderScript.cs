using UnityEngine;
using UnityEngine.UI;
using System;

public class SliderController : MonoBehaviour
{
    // Reference to the Unity Slider component
    public Slider slider;

    public GameObject hostPlayer;
    public GameObject clientPlayer;

    // Public values for min, max, and current value
    public float minValue = 0f;
    public float maxValue = 82.5f;

    void Start()
    {
        // If the Slider is not already assigned, try to get it from the GameObject
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }

        // Set the Slider's initial values
        SetCurrentValueAsDistance()
    }

    void Update()
    {
        // Continuously ensure the current value stays within the min and max bounds
        SetCurrentValueAsDistance();  // Update the slider’s handle position
    }

    // Method to change the current value
    public void SetCurrentValueAsDistance()
    {
        slider.value = Math.Sqrt((hostPlayer.transform.position.x - clientPlayer.transform.position.x) * (hostPlayer.transform.position.x - clientPlayer.transform.position.x) + 
                                 (hostPlayer.transform.position.y - clientPlayer.transform.position.y) * (hostPlayer.transform.position.y - clientPlayer.transform.position.y));
        
    }
}
