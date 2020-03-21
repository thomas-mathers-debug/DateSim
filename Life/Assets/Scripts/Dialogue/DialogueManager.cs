using UnityEngine;
using UnityEngine.UI;
using LitJson;


public class DialogueManager : MonoBehaviour
{
    public Text textDisplay;
    public Text speakerBox;
    public Image girl;
    public Image textBox;
    public Image speakerBoxImg;
    private JsonData dialogue;
    private int index;
    
    private string speaker;

    private bool inDialouge;

    public bool loadDialogue(string path, Sprite dialogueImage)
    {

        if (!inDialouge)
        {
            girl.sprite = dialogueImage;
            girl.color = new Color32(255, 255, 255, 255);
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
        speakerBox.enabled = false;
        speakerBoxImg.enabled = false;

        textDisplay.text = "";
        speakerBox.text = "";
        return false;
    }



    public bool printLine()
    {
        if (inDialouge)
        {
            textBox.enabled = true;
            speakerBox.enabled = true;
            girl.enabled = true;
            speakerBoxImg.enabled = true;
            JsonData line = dialogue[index];
           
            
            if (line[0].ToString() == "EOD")
            {
                finishConvo();
                return false;
            }
            foreach (JsonData key in line.Keys)
            {
                speaker = key.ToString();
            }
            speakerBox.text = speaker + ": ";
            textDisplay.text = line[0].ToString();
            index++;
        }
        return true;
    }

    // Start is called before the first frame update

    // Update is called once per frame

}