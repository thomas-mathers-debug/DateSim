using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public GameObject player;
    public string dialoguePath;

    private bool inTrigger = false;
    private bool dialogueLoaded = false;

    public Sprite dialogueImage;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager.textBox.enabled = false;

        if (dialogueManager == null) //find a dialogue
            dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //collision effect
    {
        if (collision.gameObject == player)
            inTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)//out of trigger
    {
        if (collision.gameObject == player)
            inTrigger = false;
    }

    private void runDialogue(bool keyTrigger) // check dialogue with trigger
    {
        if (Input.anyKey && !inTrigger && dialogueLoaded)
        {
            if (dialogueLoaded)
            {
                dialogueLoaded = dialogueManager.finishConvo();
            }
        }

        if (keyTrigger)
        {
            if (inTrigger && !dialogueLoaded)
            {
                dialogueLoaded = dialogueManager.loadDialogue(dialoguePath, dialogueImage);
            }

            if (dialogueLoaded && inTrigger)
            {
                dialogueLoaded = dialogueManager.printLine();
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) || dialogueLoaded)
        {
            runDialogue(Input.GetKeyDown(KeyCode.C));
        }
        
        
    }
}
