using UnityEngine;

public class DestroyableObject : MonoBehaviour, IDestroyable
{
    public void TakeHit()
    {
        Destroy(gameObject); // Destroy the object immediately
    }
}
