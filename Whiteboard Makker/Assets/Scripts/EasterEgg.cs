using UnityEngine;
using System.Collections;



public class EasterEgg : MonoBehaviour
{
    [Header("Shake Detection Settings")]

    // How strong the shake must be to count as a "shake"
    public float shakeDetectionThreshold = 1f;

    // How long the shake must be sustained to trigger the easter egg
    public float requiredShakeDuration = 1.5f;

    // Tracks how long the user has been shaking the device
    private float shakeTimer = 0f;

    // Reference to the GameObject to be activated/deactivated
    public GameObject Stickman;

    // Reference to the GameObject to be activated/deactivated
    public GameObject TwerkBootyStickman;

    public float twerkingTime = 7f;

    void Start()
    {
        // Enable the gyroscope (optional, not required for accelerometer)
        Input.gyro.enabled = true;
    }

    void Update()
    {
        DetectShake(); // Check for shaking each frame
        
        if (Input.GetKeyDown(KeyCode.T)) // Press T for Twerk
        {
            TriggerEasterEgg();
        }
    }

    void DetectShake()
    {
        // Get the current acceleration of the device
        Vector3 acceleration = Input.acceleration;

        // If the magnitude of acceleration is over the shake threshold
        if (acceleration.sqrMagnitude >= shakeDetectionThreshold * shakeDetectionThreshold)
        {
            // Increment the shake timer
            shakeTimer += Time.deltaTime;
            if (shakeTimer >= requiredShakeDuration)
            {
                TriggerEasterEgg();
                shakeTimer = 0f; // Reset the timer after triggering the easter egg
            }
               
        }
        else
        {
            // If the shake stops, reset the timer
            shakeTimer = 0f;
        }
    }

    // This method runs when the easter egg condition is met
    void TriggerEasterEgg()
    {
        AudioManager.Instance.PlaySFX("EasterEgg");
        Debug.Log("Easter Egg Activated by Shake!");

        TwerkBootyStickman.transform.position = Stickman.transform.position;

        Stickman.SetActive(false);
        TwerkBootyStickman.SetActive(true);

        StartCoroutine(RevertAfterSeconds(twerkingTime));


        
        // TODO: Replace this with your custom easter egg action
        // For example: show a hidden UI, load a scene, spawn an object, etc.
    }

    private IEnumerator RevertAfterSeconds(float duration)
    {
        yield return new WaitForSeconds(duration);
        
        Stickman.transform.position = TwerkBootyStickman.transform.position;

        Stickman.SetActive(true);
        TwerkBootyStickman.SetActive(false);
    }
}

