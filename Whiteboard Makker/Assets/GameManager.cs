using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        // Singleton pattern so there's only one GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void HandleTrigger(string triggerName)
    {
        switch (triggerName)
        {
            case "Checkpoint1":
                Debug.Log("Reached Checkpoint 1!");
                // Do something
                break;


            default:
                Debug.Log("Unknown trigger: " + triggerName);
                break;
        }
    }
}