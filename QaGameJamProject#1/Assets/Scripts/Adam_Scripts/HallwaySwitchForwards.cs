using System.Collections.Generic;
using UnityEngine;

public class HallwaySwitchScriptForwards : MonoBehaviour
{

    [SerializeField] GameObject player;
    //[SerializeField] GameObject hallwayPrefab;
    [SerializeField] Vector3 hallwayPivotPos;
    GameObject tempObject;
    GameObject hallwayMaster;
    List<GameObject> hallwayList = new List<GameObject>();
    [SerializeField] private GameObject[] randomHallway;
    [SerializeField] private int prefabIndex;

    int spawncounter = 0;
    private Vector3 hallwayTriggerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hallwayTriggerPos = this.gameObject.transform.position;
        //hallwayPivotPos = GameObject.FindGameObjectWithTag("HallwayPivotForwards").transform.position;

        // Finds Object Position and adds to the transform for the forward spawn location
        hallwayPivotPos = this.gameObject.transform.position + new Vector3(-72, -2.85f, 132);
        player = GameObject.FindGameObjectWithTag("Player");
        CheckIfNewObject();

        hallwayMaster = GameObject.FindGameObjectWithTag("HallwayList");
        hallwayList = hallwayMaster.GetComponent<MasterHallwayControl>().hallwayList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Player")
        {
            prefabIndex = UnityEngine.Random.Range(0, randomHallway.Length);
            Debug.Log(prefabIndex);

            //Debug.Log(hallwayTriggerPos);
            tempObject = Instantiate(randomHallway[prefabIndex], hallwayPivotPos, transform.rotation = Quaternion.Euler(0, 0, 0));
            //Debug.Log(hallwayPrefab);
            hallwayMaster.GetComponent<MasterHallwayControl>().AddHallwayToList(tempObject);

            this.gameObject.SetActive(false);

            
        }
    }

    void CheckIfNewObject()
    {
        if (randomHallway[prefabIndex] == null)
        {
            //randomHallway[prefabIndex] = Resources.Load("ForwardsPrefab(Clone)") as GameObject;
        }

    }
}
