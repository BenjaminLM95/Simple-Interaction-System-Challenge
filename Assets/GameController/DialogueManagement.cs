using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManagement : MonoBehaviour
{
    private Queue<string> dialogue;

    public GameObject dialogueUI;
    public TextMeshProUGUI dialogueText;
    public PlayerMovement thePlayer = null; 
    // Start is called before the first frame update
    void Start()
    {
        dialogue = new Queue<string>();
        thePlayer = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(string[] sentences) 
    {
        dialogueUI.gameObject.SetActive(true);
        thePlayer.isOnDialogue = true; 

        dialogue.Clear(); 
        //Turn on UI Dialogue panel
        
        foreach(string currentString in sentences) 
        {
            dialogue.Enqueue(currentString);           
        }

        // debug, it just to visually each sentence in the debug
        /*
        foreach (string sentence in dialogue) 
        {
            Debug.Log(sentence);
        }*/

        //TODO: Pass first item in dialogue<queue> into text box of dialogue panel
        //NOTE: Recommend making a new method ot load up the first item in the queue

        //Calling queue.Dequeue(); will grab the value of the first item in the queue
        // DialogueText(textOutput) == queue.Dequeue();

        // queue.Clear() Removes all objects from the queue<T>

        dialogueText.text = dialogue.Peek();

    }

    public void NextDialogue() 
    {
        if (dialogue.Count > 1)
        {
            dialogue.Dequeue();
            dialogueText.text = dialogue.Peek();
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue() 
    {
        dialogue.Clear(); 
        dialogueText.text = "";
        dialogueUI.gameObject.SetActive(false);
        thePlayer.isOnDialogue = false; 
    }

}
