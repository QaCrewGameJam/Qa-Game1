using UnityEngine;

public class HallwayEnteredScript : MonoBehaviour
{
    [SerializeField] public GameObject forwardCheckTrigger;
    [SerializeField] public GameObject backwardCheckTrigger;

    void Start()
    {
        
    }

    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            forwardCheckTrigger.SetActive(true);
            backwardCheckTrigger.SetActive(true);

            this.gameObject.SetActive(false);
        }
    }

}
