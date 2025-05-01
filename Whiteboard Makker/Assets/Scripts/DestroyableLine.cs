using UnityEngine;

public class DestroyableLine : MonoBehaviour, IDestroyable
{
    public int hitsToDestroy = 5;
    private int hitCount = 0;

    public void TakeHit() //this is from the interface. and we can implement the needed features for this object 
    {
        hitCount++;
        if (hitCount >= hitsToDestroy)
        {
            Destroy(gameObject); // Line disappears after 5 hits w bullet
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
           TakeHit(); // Call the TakeHit method when the bullet hits the line 
        }
    }
}




