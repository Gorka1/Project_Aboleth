using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<KeyCode, char> typingDict;
    [SerializeField] Text text;
    [SerializeField] string[] lineArray;
    [SerializeField] string currentLine;

    void Start()
    {
        text = FindObjectOfType<Text>();

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
            text.text = text.text.Remove(text.text.Length - 1, 1);
        }

        //Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Split text into an array of lines and set current line
            lineArray = text.text.Split(new[] { '\r', '\n' });
            currentLine = lineArray[lineArray.Length - 1];

            //Go to the next line
            text.text = text.text + '\n';

            //Call Commands Method
            Commands(currentLine);
        }
    }

    //This method is used to type characters on the screen
    void Type(char letter)
    {
        text.text = text.text + letter;
    }

    //This method will check the list of commands and see if the string passed in matches any of them
    void Commands(string command)
    {
        //End all text returns with a next skip and a string split
        if(command.Trim() == "hello")
        {
            text.text = text.text + "hello user" + '\n';
            lineArray = text.text.Split(new[] { '\r', '\n' });
        }
    }
}
