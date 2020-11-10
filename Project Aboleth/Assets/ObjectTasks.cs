using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTasks : MonoBehaviour
{
    [SerializeField] int objectValue;
    RadioControl radioControl;
    AudioSource radioAudio;
    [SerializeField] GameObject gunWeapon; //= GameObject.FindGameObjectWithTag("Gun");
    [SerializeField] bool doorStat = true;
    [SerializeField] GameObject screen;
    FirstPersonCharacter fpsScript;

    // Start is called before the first frame update
    void Start()
    {
        fpsScript = FindObjectOfType<FirstPersonCharacter>();
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
                    radioAudio.UnPause();
                }
                else
                {
                    print("still on");
                    radioControl.enabled = false;
                    radioAudio.Pause();
                }
                break;
            //Gun Pickup
            case 2:
                gunWeapon.SetActive(true);
                GameStates player = FindObjectOfType<GameStates>();
                player.numberOfWeapons++;
                Destroy(this.gameObject);
                break;
            //Flashlight Pickup
            case 3:
                gunWeapon.SetActive(true);
                player = FindObjectOfType<GameStates>();
                player.numberOfWeapons++;
                Destroy(this.gameObject);
                break;
            //Door Open
            case 4:
                //Transform doorTrans = this.transform.GetChild(0);
                if (doorStat)
                {
                    this.transform.Rotate(0f, 90f, 0.0f, Space.Self);
                    doorStat = false;
                }else
                {
                    this.transform.Rotate(0f, -90f, 0.0f, Space.Self);
                    doorStat = true;
                }
                break;
            case 5:
                if(screen.activeSelf)
                {
                    screen.SetActive(false);
                    fpsScript.enabled = true;
                }
                else
                {
                    screen.SetActive(true);
                    fpsScript.enabled = false;
                }
                break;
        }
    }
}
