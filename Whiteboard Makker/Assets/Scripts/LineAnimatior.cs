using UnityEditorInternal;
using UnityEngine;
using System.Collections;

public class LineAnimatior : MonoBehaviour
{
    [SerializeField] private float animationDuratiuon = 1f; // Speed of the animation
   
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        StartCoroutine(AnimateLine());
    }

    private IEnumerator AnimateLine()
    {
        float startTime = Time.time;

        Vector3 startposition = lineRenderer.GetPosition(0);
        Vector3 endposition = lineRenderer.GetPosition(1);

        Vector3 pos = startposition;
        while (pos != endposition)
        { 
            float t = (Time.time - startTime) / animationDuratiuon;
            pos = Vector3.Lerp(startposition, endposition, t);
            lineRenderer.SetPosition(1, pos);
            yield return null;
        }
    }
}
