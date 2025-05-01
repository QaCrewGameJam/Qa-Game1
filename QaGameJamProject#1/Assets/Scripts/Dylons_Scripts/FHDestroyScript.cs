using UnityEngine;

public class FHDestroyScript : MonoBehaviour
{
    [SerializeField] GameObject FirstHallway;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(FirstHallway);
    }
}
