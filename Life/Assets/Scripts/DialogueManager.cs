using UnityEngine;
using UnityEngine.UI;
using LitJson;


public class DialogueManager : MonoBehaviour
{
    public Text textDisplay;
    private JsonData dialogue;
    private int index;
    public Image girl;
    private string speaker;

    private void loadDialogue(string path)
    {
        index = 0;
        var jsonTextFile = Resources.Load<TextAsset>("Dialogues/" + path);
        dialogue = JsonMapper.ToObject(jsonTextFile.text);
    }

    private void printLine()
    {
        JsonData line = dialogue[index];
        foreach (JsonData key in line.Keys)
        {
            speaker = key.ToString();
        }
        
        textDisplay.text = speaker + ": " + line[0].ToString();
        UnityEngine.Debug.Log(line[0].ToString());
        index++;
    }

    // Start is called before the first frame update
    void Start()
    {

        girl.enabled = false;
        loadDialogue("Scene0/Json/test");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            girl.enabled = true;
            printLine();
        }
    }
}
