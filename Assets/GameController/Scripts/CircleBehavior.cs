using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBehavior : MonoBehaviour
{
    private Vector3 objSize = Vector3.zero;
    private bool grow;
    private float GrowSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        objSize = this.gameObject.transform.localScale;
        grow = true;
        GrowSpeed = 1; 
        Actions.GrowCircle += growing;
        Actions.StopGrowing += stopGrowing;
    }

    private void Update()
    {
        if(grow)
        {
            objSize *= GrowSpeed;
            this.transform.localScale = objSize;
        }

        if (objSize.x > 1.5f)
        {
            // This stops to be very big
            grow = false;
            objSize = new Vector3(1f, 1f, 1f);
        }
    }

    public void growing() 
    {
        GrowSpeed = 1 + (0.25f * Time.deltaTime); 
    }

    public void stopGrowing() 
    {
        GrowSpeed = 1; 
    }

    private void OnDisable()
    {
        Actions.GrowCircle -= growing;
        Actions.StopGrowing -= stopGrowing;
    }

}
