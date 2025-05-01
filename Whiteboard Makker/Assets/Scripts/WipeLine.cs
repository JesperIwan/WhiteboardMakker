using UnityEngine;

public class WipeLine : MonoBehaviour
{
    public int numberOfZigs = 10;
    public float width = 10f;
    public float height = 5f;
    public float speed = 2f;
    public GameObject endSceneImage;

    private LineRenderer lineRenderer;
    private Vector3[] points;
    private float t = 0f;
    private int currentIndex = 1;
    private bool finished = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        points = new Vector3[numberOfZigs + 1];
        for (int i = 0; i <= numberOfZigs; i++)
        {
            float x = i * (width / numberOfZigs);
            float y = (i % 2 == 0) ? 0 : height;
            points[i] = new Vector3(x, y, 0);
        }

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, points[0]);
        lineRenderer.SetPosition(1, points[0]);

        if (endSceneImage != null)
            endSceneImage.SetActive(false);
    }

    void Update()
    {
        if (finished || currentIndex >= points.Length)
            return;

        t += Time.deltaTime * speed;
        Vector3 newPos = Vector3.Lerp(points[currentIndex - 1], points[currentIndex], t);
        lineRenderer.SetPosition(currentIndex, newPos);

        if (t >= 1f)
        {
            t = 0f;
            currentIndex++;
            if (currentIndex < points.Length)
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(currentIndex, points[currentIndex - 1]);
            }
            else
            {
                finished = true;

               
                if (endSceneImage != null)
                    endSceneImage.SetActive(true);

                
                lineRenderer.enabled = false;

            }
        }
    }
}
