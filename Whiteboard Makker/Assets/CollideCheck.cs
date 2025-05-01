using UnityEngine;

public class CollideCheck : MonoBehaviour
{
    public string lastTriggerName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger)
        {
            lastTriggerName = other.gameObject.name;
            Debug.Log("Entered trigger: " + lastTriggerName);
            GameManager.Instance.HandleTrigger(lastTriggerName);
        }
    }
}
