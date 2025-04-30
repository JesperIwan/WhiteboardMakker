using UnityEngine;

public class DestroyableLine : MonoBehaviour
{
    public int hitsToDestroy = 5;
    private int hitCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            hitCount++;

            if (hitCount >= hitsToDestroy)
            {
                Destroy(gameObject); // Line disappears
            }

            // Don't destroy the bullet — let object pool handle it
        }
    }
}




