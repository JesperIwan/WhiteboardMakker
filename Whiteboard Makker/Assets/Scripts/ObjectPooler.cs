using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject prefab; //prefab to pool 
    public int poolSize = 10;   

    private List<GameObject> pool; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initialize the object pool 
        InitializePool();
    }

    private void InitializePool()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        { //we will go around this for loop as many times as the pool size is set too

            CreateNewObj();
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            //check if the object is in the pool
            if (!obj.activeInHierarchy) //if the object is not active
            {
                return obj; //return the object
            }
        }
        //if no inactive object is found, return null

        return CreateNewObj(); //if no inactive object is found, create a new one
    }


    //to avoid duplicate code
    private GameObject CreateNewObj()
    {
        GameObject obj = Instantiate(prefab, Vector2.zero, Quaternion.identity); //create a new object from the prefab (x, position, rotation) - default position and rotation
        obj.SetActive(false); //deactivate the object
        pool.Add(obj); //add the object to the pool
        return obj; //return the object
    }
}
