using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class HallwaySwitchScript : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject hallwayPrefab;
    [SerializeField] Vector3 hallwayPivotPos;
    GameObject tempObject;
    GameObject hallwayMaster;
    List<GameObject> hallwayList = new List<GameObject>();

    int spawncounter = 0;
    private Vector3 hallwayTriggerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hallwayTriggerPos = this.gameObject.transform.position;
        //hallwayPivotPos = GameObject.FindGameObjectWithTag("HallwayPivot").transform.position;
        hallwayPivotPos = this.gameObject.transform.position + new Vector3(77, 0, -127);
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
            //Debug.Log(hallwayTriggerPos);
            tempObject =Instantiate(hallwayPrefab, hallwayPivotPos, transform.rotation = Quaternion.Euler(0, 180, 0));
            //Debug.Log(hallwayPrefab);
            hallwayMaster.GetComponent<MasterHallwayControl>().AddHallwayToList(tempObject);

            this.gameObject.SetActive(false);

        }
    }


    void CheckIfNewObject()
    {
        if(hallwayPrefab == null)
        {
            hallwayPrefab = Resources.Load("BackwardsTestPrefab(Clone)") as GameObject;
        }

    }
    
}
