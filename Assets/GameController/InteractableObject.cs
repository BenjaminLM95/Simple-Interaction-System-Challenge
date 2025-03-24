using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject interactableObj = null;
  
 
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E) && interactableObj != null) 
        {
            interactableObj.GetComponent<InteractObject>().Interact(); 
        }
    }

    void OnTriggerStay2D(Collider2D col) 
    {
        if (col.gameObject.CompareTag("InteractObject")) 
        {
            interactableObj = col.gameObject; 
        }
    }

    void OnTriggerExit2D(Collider2D col) 
    {
        if (col.gameObject.CompareTag("InteractObject"))
        {
            interactableObj = null;
        }
    }

}
