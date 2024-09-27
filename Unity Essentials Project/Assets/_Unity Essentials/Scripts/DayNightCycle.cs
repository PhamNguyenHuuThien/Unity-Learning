using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Length of the day in seconds
    [Tooltip("Duration of a full day in seconds")]
    public float dayDuration = 86400f; // Default: 86400 seconds = 24 hours

    // Update is called once per frame
    void Update()
    {
        // Calculate the rotation angle based on the elapsed time and day duration
        float rotationAngle = (Time.deltaTime / dayDuration) * 360f;

        // Apply the rotation to the Directional Light
        transform.Rotate(Vector3.right, rotationAngle);
    }
}
