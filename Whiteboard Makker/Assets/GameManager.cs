
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<GameObject> mapParts = new List<GameObject>();
    public int nr = 0; 
   public AudioManager audioManager; 

   public GameObject player; 

   GameObject cp8; 
    GameObject cp12;

    void Start()
    {
        AudioManager.Instance.PlayMusic("Theme");
       // AudioManager.Instance.PlayVoice("Cp1");

        //tmp løsning
        GameObject.Find("Cp8").SetActive(false);
        GameObject.Find("Cp12").SetActive(false);
    }
    private void Awake()
    { 
        audioManager = FindObjectOfType<AudioManager>();
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

       cp8 = GameObject.Find("Cp8");
       cp12 = GameObject.Find("Cp12");
        cp8.SetActive(false);
        cp12.SetActive(false);


    } 

    

    public void HandleTrigger(string triggerName)
    {
        switch (triggerName)
        {
            case "Cp1":
                Debug.Log("Reached Checkpoint 1!");
                // Do something  
                AudioManager.Instance.PlayVoice("Cp1");
                GameObject.Find("Cp1").SetActive(false);
                
                //mapParts[0].SetActive(true); 
               

                break;
            case "Cp2":
                Debug.Log("Reached Checkpoint 2!");
                // Do something 
                AudioManager.Instance.PlayVoice("Cp2");
                GameObject.Find("Cp2").SetActive(false); 
                mapParts[0].SetActive(true); 
               
                player.transform.position = GameObject.Find("Spawn1").transform.position;
                
                break;
            case "Cp3":
                Debug.Log("Reached Checkpoint 3!");
                // Do something 
                AudioManager.Instance.PlayVoice("Cp3");
                GameObject.Find("Cp3").SetActive(false);
                
                break;
            case "Cp4":
                Debug.Log("Reached Checkpoint 4!");
                // Do something 
                AudioManager.Instance.PlayVoice("Cp4");
                GameObject.Find("Cp4").SetActive(false);
               // mapParts[3].SetActive(true);
                break;
            case "Cp5":
                Debug.Log("Reached Checkpoint 5!");
                // Do something 
                AudioManager.Instance.PlayVoice("Cp5");
                GameObject.Find("Cp5").SetActive(false);
                //mapParts[4].SetActive(true);
                break;
            case "Cp6":
                Debug.Log("Reached Checkpoint 6!");
                // Do something 
                AudioManager.Instance.PlayVoice("Cp6");
                GameObject.Find("Cp6").SetActive(false);
                //mapParts[5].SetActive(true);
                break;
            case "Cp7":
                Debug.Log("Reached Checkpoint 7!");
                // Do something 
                cp8.SetActive(true);
                AudioManager.Instance.PlayVoice("Cp7");
                GameObject.Find("Cp7").SetActive(false);
                //mapParts[6].SetActive(true);
                break;
            case "Cp8": 
                Debug.Log("Reached Checkpoint 8!");
                // Do something
                AudioManager.Instance.PlayVoice("Cp8"); 
                GameObject.Find("Cp8").SetActive(false);
                mapParts[1].SetActive(true);
                player.transform.position = GameObject.Find("Spawn2").transform.position;
                break;
            case "Cp9":
                Debug.Log("Reached Checkpoint 9!");
                // Do something 
                AudioManager.Instance.PlayVoice("Cp9");
                GameObject.Find("Cp9").SetActive(false);
                //mapParts[8].SetActive(true);
                break;
            case "Cp10":
                Debug.Log("Reached Checkpoint 10!");
                // Do something 
                AudioManager.Instance.PlayVoice("Cp10");
                GameObject.Find("Cp10").SetActive(false);
                //mapParts[9].SetActive(true);
                break;
            case "Cp11":
                Debug.Log("Reached Checkpoint 11!");
                // Do something 
                AudioManager.Instance.PlayVoice("Cp11"); 
                cp12.SetActive(true);
                GameObject.Find("Cp11").SetActive(false);
                //mapParts[10].SetActive(true);
                break;
            case "Cp12":
                Debug.Log("Reached Checkpoint 12!");
                // Do something 
                AudioManager.Instance.PlayVoice("Cp12");
                GameObject.Find("Cp12").SetActive(false);
                //mapParts[11].SetActive(true);
                break;
            case "Cp13":
                Debug.Log("Reached Checkpoint 13!");
                // Do something 
                AudioManager.Instance.PlayVoice("Cp13");
                GameObject.Find("Cp13").SetActive(false);
                //mapParts[12].SetActive(true);
                break;


            default:
                Debug.Log("Unknown trigger: " + triggerName);
                break;
        }
    }
}