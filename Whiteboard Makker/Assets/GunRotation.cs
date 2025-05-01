using UnityEngine;

public class GunRotation : MonoBehaviour
{
    void Update()
    {
        Vector2 screenPosition;

#if UNITY_ANDROID
        // Use first touch on Android
        if (Input.touchCount > 0)
        {
            screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }
#else
        // Use mouse position in Editor or PC
        screenPosition = Input.mousePosition;
#endif

        // Convert screen to world position
        Vector2 targetPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        // Get direction from gun to target
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        // Calculate angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply rotation (Z-axis for 2D)
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}