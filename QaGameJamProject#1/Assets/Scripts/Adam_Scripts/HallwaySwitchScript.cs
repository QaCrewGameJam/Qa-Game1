using UnityEngine;
using UnityEngine.VFX;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class HallwaySwitchScript : MonoBehaviour
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
        hallwayPivotPos = GameObject.FindGameObjectWithTag("HallwayPivot").transform.position;
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
            tempObject =Instantiate(hallwayPrefab, hallwayPivotPos, transform.rotation = Quaternion.Euler(0, 0, 0));
            Debug.Log(hallwayPrefab);
            this.gameObject.SetActive(false);

        }
    }


    void CheckIfNewObject()
    {
        if(hallwayPrefab == null)
        {
            hallwayPrefab = Resources.Load("BackwardsPrefab(Clone)") as GameObject;
        }

    }
    
}
