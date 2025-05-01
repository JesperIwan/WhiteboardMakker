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
        var cam = GetComponent<Camera>();
        yield return ZoomIn(cam, 1.5f, 1f, 16f, new Vector3(4, 2, -10));
        yield return ZoomIn(cam, 4f, 1f, 3f, new Vector3(0, 0, -10));
        yield return ZoomIn(cam, 1.2f, 2f, 5f, new Vector3(-1, 1, -10));
        yield return ZoomIn(cam, 1.5f, 1f, 6.5f, new Vector3(4, 2, -10));
        yield return ZoomIn(cam, 1.5f, 3f, 8f, new Vector3(-1, 1, -10));
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

