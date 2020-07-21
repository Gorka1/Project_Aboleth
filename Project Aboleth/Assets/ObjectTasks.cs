using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTasks : MonoBehaviour
{
    [SerializeField] int objectValue;
    RadioControl radioControl;
    AudioSource radioAudio;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoSomething()
    {
        switch(objectValue)
        {
            //Radio On/Off
            case 1:
                //Turn Radio on and off
                radioControl = this.gameObject.GetComponentInChildren<RadioControl>();
                radioAudio = this.gameObject.GetComponentInChildren<AudioSource>();
                if (!radioControl.enabled)
                {
                    print("re enable");
                    radioControl.enabled = true;
                    radioAudio.enabled = true;
                }
                else
                {
                    print("still on");
                    radioControl.enabled = false;
                    radioAudio.enabled = false;
                }
                break;
            //Gun Pickup
            case 2:
                break;
            //Flashlight Pickup
            case 3:
                break;
        }
    }
}
