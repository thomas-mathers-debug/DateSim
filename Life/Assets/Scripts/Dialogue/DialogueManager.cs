using UnityEngine;
using UnityEngine.UI;
using LitJson;


public class DialogueManager : MonoBehaviour
{
    public Text textDisplay;
    private JsonData dialogue;
    private int index;
    public Image girl;
    public Image textBox;
    private string speaker;

    private bool inDialouge;

    public bool loadDialogue(string path, Sprite dialogueImage)
    {

        if (!inDialouge)
        {
            girl.sprite = dialogueImage;
            girl.color = new Color32(255, 255, 255, 255);
            girl.enabled = false;
            textBox.enabled = false;
            index = 0;
            var jsonTextFile = Resources.Load<TextAsset>("Dialogues/" + path);
            dialogue = JsonMapper.ToObject(jsonTextFile.text);
            inDialouge = true;
            return true;
        }
        return false;
    }

    public bool finishConvo()
    {
        inDialouge = false;
        girl.enabled = false;
        textBox.enabled = false;

        textDisplay.text = "";
        return false;
    }



    public bool printLine()
    {
        if (inDialouge)
        {
            textBox.enabled = true;
            girl.enabled = true;
            JsonData line = dialogue[index];
            Debug.Log(line[0]);
           
            
            if (line[0].ToString() == "EOD")
            {
                finishConvo();
                return false;
            }
            foreach (JsonData key in line.Keys)
            {
                speaker = key.ToString();
            }

            textDisplay.text = speaker + ": " + line[0].ToString();
            index++;
        }
        return true;
    }

    // Start is called before the first frame update

    // Update is called once per frame

}