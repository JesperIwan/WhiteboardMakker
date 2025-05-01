using UnityEngine;

public class Hammer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDestroyable destroyable = collision.gameObject.GetComponent<IDestroyable>();
        if (destroyable != null)
        {
            destroyable.TakeHit(); // Destroy the object
        }
    }
}
