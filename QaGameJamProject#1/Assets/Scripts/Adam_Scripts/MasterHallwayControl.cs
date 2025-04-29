using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MasterHallwayControl : MonoBehaviour
{
    public List<GameObject> hallwayList = new List<GameObject>();
    private GameObject hallways;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int x = 0; x < hallwayList.Count; x++) {
            
            if (x > 2)
            {
                DestroyImmediate(hallwayList[0].transform.root.gameObject, true);
                hallwayList.RemoveAt(0);
            }
        }

      
    }

    public void AddHallwayToList(GameObject hallway)
    {
        hallwayList.Add(hallway);
    }
}
