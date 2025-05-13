using System.Collections;
using UnityEngine;

public class TransformCameraIntro : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       TransformCamera();
    }

   void TransformCamera()
    {
        // Get the camera component
        var cam = GetComponent<Camera>();

        StartCoroutine(ZoomSequensce());
    }

    private IEnumerator ZoomSequensce() {
        var player = GameObject.FindGameObjectsWithTag("Player"); // NEW CODE AFTER GAMEJAM
        var playerAnim = GameObject.FindGameObjectsWithTag("PlayerAnim"); // NEW CODE AFTER GAMEJAM
        var princessAnim = GameObject.FindGameObjectsWithTag("PrincessAnim"); // NEW CODE AFTER GAMEJAM
        var dragonAnim = GameObject.FindGameObjectsWithTag("DragonAnim"); // NEW CODE AFTER GAMEJAM
        
        player[0].GetComponent<Movement>().enabled = false; // NEW CODE AFTER GAMEJAM
        
        playerAnim[0].SetActive(false); // NEW CODE AFTER GAMEJAM
        princessAnim[0].SetActive(false); // NEW CODE AFTER GAMEJAM
        dragonAnim[0].SetActive(false); // NEW CODE AFTER GAMEJAM
        

        var cam = GetComponent<Camera>();
        cam.transform.position = new Vector3(36.7f, -10+46.9f, -10);
        cam.orthographicSize = 46 ;
        
        yield return ZoomIn(cam, 36f, 14f, 2f, new Vector3(36.7f, -10+46.9f, -10)); // NEW CODE AFTER GAMEJAM
        
        yield return ZoomIn(cam, 20f, 1f, 0f, new Vector3(55+36.7f, 46.9f, -10)); //CHANGED CODE AFTER GAMEJAM
        
        princessAnim[0].SetActive(true); // NEW CODE AFTER GAMEJAM
        
        yield return ZoomIn(cam, 10f, 1f, 5f, new Vector3(25+36.7f, -12+46.9f, -10));
        
        yield return ZoomIn(cam, 12f, 2f, 3f, new Vector3(-2+36.7f, -5+46.9f, -10));
        
        playerAnim[0].SetActive(true); // NEW CODE AFTER GAMEJAM
        
        yield return ZoomIn(cam, 15, 1f, 6.5f, new Vector3(35+36.7f, 5+46.9f, -10));

        dragonAnim[0].SetActive(true); // NEW CODE AFTER GAMEJAM
        
        yield return ZoomIn(cam, 12f, 3f, 8f, new Vector3(-2+36.7f, -5+46.9f, -10));
        
        player[0].GetComponent<Movement>().enabled = true; // NEW CODE AFTER GAMEJAM
    }
    private IEnumerator ZoomIn(Camera cam, float targetSize, float duration, float delay, Vector3 targetPosition)
    {
        // Wait for the specified delay before starting the zoom
        yield return new WaitForSeconds(delay);

        float startSize = cam.orthographicSize;
        Vector3 startPosition = cam.transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            cam.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsed / duration);
            cam.orthographicSize = Mathf.Lerp(startSize, targetSize, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        cam.orthographicSize = targetSize;
    }
}

