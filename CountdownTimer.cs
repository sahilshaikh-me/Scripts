using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour
{
    [Range(0.1f, 10f)] // Adjust the range as needed
    public float fastForwardFactor = 1f; // Fast forward factor controlled by a range in the Inspector
    public int initialMinutes = 60; // Replace with your desired initial minutes

    private int remainingSeconds;
    public TextMeshProUGUI _tmpProText;

    public int seconds;
    public int hours;
    public int minutes;

  
    void Start()
    {
      
        // Convert initial minutes to seconds
        remainingSeconds = initialMinutes * 60;

        // Start the countdown
        InvokeRepeating(nameof(UpdateTimer), 0f, 1f);
    }

    void UpdateTimer()
    {
        // Decrement remaining seconds with the fast forward factor
        remainingSeconds -= Mathf.RoundToInt(fastForwardFactor);

        // Calculate hours, minutes, and seconds
         hours = remainingSeconds / 3600;
         minutes = (remainingSeconds % 3600) / 60;
         seconds = remainingSeconds % 60;

        // Print the countdown in the console
        //  Debug.Log("Time Remaining: " + hours.ToString("00") + "h " + minutes.ToString("00") + "m " + seconds.ToString("00") + "s");
        _tmpProText.text = hours.ToString("00") + ": " + minutes.ToString("00") + ": " + seconds.ToString("00") + "s";
        // Check if the countdown is complete
        if (remainingSeconds <= 0)
        {
            Debug.Log("Countdown complete!");
            
            // Optionally, you can stop the countdown or perform other actions when the countdown is complete
            CancelInvoke(nameof(UpdateTimer));
        }
    }
}
