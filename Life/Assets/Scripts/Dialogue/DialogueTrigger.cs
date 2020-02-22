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

        //Debug.Log(GameObject.Find("DialogueManger").GetComponent<DialogueManager>());
        if (dialogueManager == null) //find a dialogue
            dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
            inTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
            inTrigger = false;
    }

    private void runDialogue(bool keyTrigger)
    {
        if (keyTrigger)
        {
            if (inTrigger && !dialogueLoaded)
            {
                dialogueLoaded = dialogueManager.loadDialogue(dialoguePath, dialogueImage);
            }

            if (dialogueLoaded)
            {
                dialogueLoaded = dialogueManager.printLine();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        runDialogue(Input.GetKeyDown(KeyCode.C));
        
    }
}
