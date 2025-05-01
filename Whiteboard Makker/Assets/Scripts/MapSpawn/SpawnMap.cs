using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public GameObject _mapPart; 

    public void SpawnMapPart()  
    {
        _mapPart.SetActive(true);
            
    }
}
