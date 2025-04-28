using UnityEngine;

public class HallwaySwitchScriptForwards : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject hallwayPrefab;
    [SerializeField] Vector3 hallwayPivotPos;
    GameObject tempObject;

    int spawncounter = 0;
    private Vector3 hallwayTriggerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hallwayTriggerPos = this.gameObject.transform.position;
        //hallwayPivotPos = GameObject.FindGameObjectWithTag("HallwayPivotForwards").transform.position;

        // Finds Object Position and adds to the transform for the forward spawn location
        hallwayPivotPos = this.gameObject.transform.position + new Vector3(-72, -3, 104);
        player = GameObject.FindGameObjectWithTag("Player");
        CheckIfNewObject();
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
            Destroy(this.gameObject);
            //this.gameObject.SetActive(false);
        }
    }

    void CheckIfNewObject()
    {
        if (hallwayPrefab == null)
        {
            hallwayPrefab = Resources.Load("BackwardsPrefab(Clone)") as GameObject;
        }

    }
}
