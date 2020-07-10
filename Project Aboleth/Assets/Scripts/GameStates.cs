using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    [SerializeField] bool useItems = false;
    [SerializeField] GameObject weaponsEmpty;
    [SerializeField] InteractMode interactMode;

    // Start is called before the first frame update
    void Start()
    {
        //Get stuff to Enable/Disable
        weaponsEmpty = FindObjectOfType<WeaponSystem>().gameObject;
        interactMode = FindObjectOfType<InteractMode>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("SwapMode"))
        {
            if(!useItems)
            {
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
