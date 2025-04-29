using System.Collections.Generic;
using UnityEngine;

public class HallwaySwitchScriptForwards : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject hallwayPrefab;
    [SerializeField] Vector3 hallwayPivotPos;
    [SerializeField] public GameObject backwardsSwitch;
    GameObject tempObject;
    GameObject hallwayMaster;
    List<GameObject> hallwayList = new List<GameObject>();

    int spawncounter = 0;
    private Vector3 hallwayTriggerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hallwayTriggerPos = this.gameObject.transform.position;
        //hallwayPivotPos = GameObject.FindGameObjectWithTag("HallwayPivotForwards").transform.position;

        // Finds Object Position and adds to the transform for the forward spawn location
        hallwayPivotPos = this.gameObject.transform.position + new Vector3(-72, -3, 130);
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
            Debug.Log(hallwayTriggerPos);
            tempObject = Instantiate(hallwayPrefab, hallwayPivotPos, transform.rotation = Quaternion.Euler(0, 0, 0));
            Debug.Log(hallwayPrefab);
            //Destroy(this.gameObject);

            hallwayMaster.GetComponent<MasterHallwayControl>().AddHallwayToList(tempObject);

            backwardsSwitch.SetActive(false);
            this.gameObject.SetActive(false);

            
        }
    }

    void CheckIfNewObject()
    {
        if (hallwayPrefab == null)
        {
            hallwayPrefab = Resources.Load("ForwardsPrefab(Clone)") as GameObject;
        }

    }
}
