using System.Collections.Generic;
using UnityEngine;

public class MasterHallwayControl : MonoBehaviour
{
    [SerializeField] List<GameObject> hallwayList = new List<GameObject>();
    private GameObject hallways;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void AddHallwayToList(GameObject hallway)
    {
        hallwayList.Add(hallway);
    }
}
