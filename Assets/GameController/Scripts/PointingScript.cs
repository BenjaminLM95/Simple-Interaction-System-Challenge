using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingScript : MonoBehaviour
{
    public GameObject cowboy;
    public Vector3 cowboyPosition;
    private Vector3 offset = new Vector3(0.00f, 0.67f, 0.00f); 

    // Start is called before the first frame update
    void Start()
    {
        cowboyPosition = cowboy.transform.position + offset;  // Get the position of the player 
        Actions.TargetingCowBoy += GoToCowBoy; 
    }

    // Update is called once per frame
    void Update()
    {
        cowboyPosition = cowboy.transform.position; // The position updates
    }

    void GoToCowBoy() 
    {
        this.gameObject.transform.position = cowboyPosition + offset; // Get the player's position
    }
}
