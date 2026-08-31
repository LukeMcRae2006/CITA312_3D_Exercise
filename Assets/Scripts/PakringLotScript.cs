using UnityEngine;

public class PakringLotScript : MonoBehaviour
{

    public int carAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("There are: " + carAmount + " cars in the parking lot spaces.");
    }


}
