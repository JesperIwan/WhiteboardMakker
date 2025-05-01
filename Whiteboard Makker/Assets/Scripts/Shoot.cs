using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public ObjectPooler bulletPool;
    public int bulletSpeed = 10;

    // Reference to any UI elements you want to ignore shooting on
    public RectTransform[] uiElementsToIgnore;

    void Update()
    {
        Vector2 inputPosition;

#if UNITY_ANDROID
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            inputPosition = Input.GetTouch(0).position;
        }
        else return;
#else
        if (Input.GetButtonDown("Fire1"))
        {
            inputPosition = Input.mousePosition;
        }
        else return;
#endif

        if (IsPointerOverAnyUI(inputPosition)) return;

        ShootBullet(inputPosition);
    }

    private bool IsPointerOverAnyUI(Vector2 screenPosition)
    {
        foreach (RectTransform rect in uiElementsToIgnore)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(rect, screenPosition))
            {
                return true;
            }
        }
        return false;
    }

    private void ShootBullet(Vector2 screenPosition)
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        Vector2 direction = (worldPosition - (Vector2)transform.position).normalized;

        GameObject bullet = bulletPool.GetPooledObject();
        bullet.transform.position = transform.position;
        bullet.SetActive(true);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
    }
}
