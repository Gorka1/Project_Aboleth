using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<KeyCode, char> typingDict;
    [SerializeField] Text typeText;
    [SerializeField] Text screenText;
    [SerializeField] List<string> lineList;
    [SerializeField] string currentLine;

    void Start()
    {
        typeText = GameObject.FindGameObjectWithTag("TypeText").GetComponent<Text>();
        screenText = GameObject.FindGameObjectWithTag("ScreenText").GetComponent<Text>();

        #region CharacterList
        //Dictionary converts inputs into characters
        typingDict = new Dictionary<KeyCode, char>
        {
            [KeyCode.Space] = ' ',

            [KeyCode.A] = 'a',
            [KeyCode.B] = 'b',
            [KeyCode.C] = 'c',
            [KeyCode.D] = 'd',
            [KeyCode.E] = 'e',
            [KeyCode.F] = 'f',
            [KeyCode.G] = 'g',
            [KeyCode.H] = 'h',
            [KeyCode.I] = 'i',
            [KeyCode.J] = 'j',
            [KeyCode.K] = 'k',
            [KeyCode.L] = 'l',
            [KeyCode.M] = 'm',
            [KeyCode.N] = 'n',
            [KeyCode.O] = 'o',
            [KeyCode.P] = 'p',
            [KeyCode.Q] = 'q',
            [KeyCode.R] = 'r',
            [KeyCode.S] = 's',
            [KeyCode.T] = 't',
            [KeyCode.U] = 'u',
            [KeyCode.V] = 'v',
            [KeyCode.W] = 'w',
            [KeyCode.X] = 'x',
            [KeyCode.Y] = 'y',
            [KeyCode.Z] = 'z',  
        };
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        //Checks keyboard inputs
        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in typingDict.Keys)
            {
                if (Input.GetKeyDown(key))
                {
                    print("letter printed");
                    print(typingDict[key]);

                    Type(typingDict[key]);
                }
            }
        }

        //Backspace
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            print("backspace");
            typeText.text = typeText.text.Remove(typeText.text.Length - 1, 1);
        }

        //Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Add text that is typed in the lower box to the screen
            screenText.text = screenText.text + typeText.text + '\n';

            //Split text into an array of lines and set current line
            Split();

            //text.text = text.text + '\n';

            //Call Commands Method
            Commands(currentLine);

            //Clear typing box
            typeText.text = "";

            //Move text up if there is no room (I wrote this so the first line gets deleted effectively making it scroll down)
            while (lineList.Count > 8)
            {
                //Remove first line in the array
                lineList.RemoveAt(0);

                //Clear text and rewrite it without the first value
                screenText.text = "";
                for (int i = 0; i < lineList.Count - 1; i++)
                {
                    screenText.text += lineList[i] + '\n';
                }
                //The last line can't go into the loop because it can't have a "\n" at the end
                screenText.text += lineList[lineList.Count - 1];
            }
        }
    }

    //This method is used to type characters on the screen
    void Type(char letter)
    {
        typeText.text = typeText.text + letter;
    }

    //This method will check the list of commands and see if the string passed in matches any of them
    void Commands(string command)
    {
        //End all text returns with a next skip and a string split
        if(command.Trim() == "hello")
        {
            screenText.text = screenText.text + "hello user" + '\n';
            Split();
        }
    }

    //Splits the large block of text into a list of lines
    void Split()
    {
        //Split strings into an array
        string[] lineArray = screenText.text.Split(new[] { '\r', '\n' });

        //Convert an array into a list (probably an easier way to do this but I have no internet rn lmao
        lineList.Clear();
        foreach(string value in lineArray)
        {
            lineList.Add(value);
        }

        //Set current line
        currentLine = lineList[lineList.Count - 2];
    }
}
