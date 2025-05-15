using UnityEngine;
using System.Collections;

public class EasterEgg : MonoBehaviour
{
    [Header("Shake Detection Settings")]
    public float shakeDetectionThreshold = 6f;
    public float twerkingTime = 7f;

    public GameObject Stickman;
    public GameObject TwerkBootyStickman;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) // Press T for Twerk to debug
        {
            TriggerEasterEgg();
        }

        Vector3 acceleration = Input.acceleration;
        if (acceleration.sqrMagnitude >= shakeDetectionThreshold * shakeDetectionThreshold)
        {
            TriggerEasterEgg();
        }
    }
    
    void TriggerEasterEgg()
    {
        AudioManager.Instance.PlaySFX("EasterEgg");
        Debug.Log("Easter Egg Activated by Shake!");

        TwerkBootyStickman.transform.position = Stickman.transform.position;
        Stickman.SetActive(false);
        TwerkBootyStickman.SetActive(true);

        StartCoroutine(RevertAfterSeconds(twerkingTime));
    }

    private IEnumerator RevertAfterSeconds(float duration)
    {
        yield return new WaitForSeconds(duration);

        Stickman.transform.position = TwerkBootyStickman.transform.position;
        Stickman.SetActive(true);
        TwerkBootyStickman.SetActive(false);
    }
}
