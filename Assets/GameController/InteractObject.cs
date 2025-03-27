using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public enum InterType
    {
        Nothing,
        Info,
        PickUp,
        Dialogue
    }

    public DialogueManagement dialogueManager = null ; 

    [Header("Type of Interaction")]
    public InterType type;

    [Header("Info Message")]
    public string infoMessage;

    [Header("Dialogue")]
    [TextArea] public string[] sentences; 

    public TextMeshProUGUI infoText = null;

    public bool isTextDisplayed;
   

    // Start is called before the first frame update
    void Awake()
    {
        GameObject textObject = GameObject.Find("Info Display");
        if (textObject != null)
        {
            infoText = textObject.GetComponent<TextMeshProUGUI>();            
        }       
        isTextDisplayed = false;

        dialogueManager = GameObject.FindObjectOfType<DialogueManagement>();

    }
    

    public void Interact() 
    {
        Debug.Log("Interacting with " + this.gameObject.name);

        switch (this.type.ToString()) 
        {
            case "Nothing":
                Nothing();
                break;
            case "Info":
                Info();
                break;
            case "PickUp":
                PickUp();
                break;
            case "Dialogue":
                Dialogue();
                break;
            default:
                Nothing();
                break; 
        }

    }

    public void Nothing() 
    {
        Debug.Log("Interaction type not defined");
       
    }

    public void PickUp() 
    {
        Debug.Log("Picking up object" + gameObject.name);
        this.gameObject.SetActive(false); 
    }

    public void Info()
    {
        Debug.Log("Display info message on Object" + gameObject.name);
        infoText.text = "Info Message: " + infoMessage;       
        isTextDisplayed = true;
        StopAllCoroutines();
        StartCoroutine(ClearText(5f));
    }

    public void Dialogue() 
    {       
        dialogueManager.StartDialogue(sentences);
    }
    

    IEnumerator ClearText(float waitTime)
    {        
        yield return new WaitForSeconds(waitTime);
        infoText.text = "";
        isTextDisplayed = false;
    }

}
