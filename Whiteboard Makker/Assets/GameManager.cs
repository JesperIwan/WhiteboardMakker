
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<GameObject> mapParts = new List<GameObject>();
    public int nr = 0;

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

        GameObject[] maps = GameObject.FindGameObjectsWithTag("MapPart");

        foreach (GameObject map in maps) {
            mapParts.Add(map);
            map.SetActive(false);
        } 
        mapParts.Reverse();

        foreach (GameObject map in mapParts) {
            
            nr++;
            Debug.Log(nr + "  " + map.name);
        }
    }

    public void HandleTrigger(string triggerName)
    {
        switch (triggerName)
        {
            case "Checkpoint1":
                Debug.Log("Reached Checkpoint 1!");
                // Do something 
                GameObject.Find("Checkpoint1").SetActive(false);
                mapParts[0].SetActive(true);

                break;


            default:
                Debug.Log("Unknown trigger: " + triggerName);
                break;
        }
    }
}