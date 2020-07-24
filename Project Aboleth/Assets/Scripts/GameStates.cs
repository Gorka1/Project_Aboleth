using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    [SerializeField] bool useItems = false;
    [SerializeField] GameObject weaponsEmpty;
    [SerializeField] InteractMode interactMode;
    [SerializeField] public int numberOfWeapons;

    // Start is called before the first frame update
    void Start()
    {
        //Get stuff to Enable/Disable
        //weaponsEmpty = GameObject.FindGameObjectWithTag("WeaponsEmpty");
        interactMode = FindObjectOfType<InteractMode>();
        numberOfWeapons = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Switch Modes by Pressing Space
        if(Input.GetButtonDown("SwapMode") && numberOfWeapons > 0)
        {
            if(!useItems)
            {
                //Remove all outlines when switching to weapons
                Outline[] outlineObjs = FindObjectsOfType<Outline>();
                foreach(Outline outline in outlineObjs)
                {
                    outline.enabled = false;
                }

                //Turn on weapons
                useItems = true;
            }
            else
            {
                useItems = false;
            }
        }

        //Activate/Deactivate Weapons
        if(useItems)
        {
            weaponsEmpty.SetActive(true);
            interactMode.enabled = false;
        }
        else
        {
            weaponsEmpty.SetActive(false);
            interactMode.enabled = true;
        }
    }
}
