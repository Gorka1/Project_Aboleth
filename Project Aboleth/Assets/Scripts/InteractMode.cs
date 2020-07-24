using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMode : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera playerCam;
    [SerializeField] GameObject currentHighlight;

    void Start()
    {
        playerCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;      

        //Check if Raycast Hits
        if (Physics.Raycast(playerCam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out hit, 10) && hit.transform.gameObject.tag == "Interact")
        {
            //Make outline appear
            currentHighlight = hit.transform.gameObject;
            currentHighlight.GetComponent<Outline>().enabled = true;

            //Call script to make the interaction function if left clicked
            if (Input.GetButtonUp("Fire1"))
            {
                currentHighlight.GetComponent<ObjectTasks>().DoSomething();
                //print("left clicked on interactable");
            }
        }
        else
        {
            //Remove outline
            if(currentHighlight != null)
            {
                currentHighlight.GetComponent<Outline>().enabled = false;
                currentHighlight = null;
            }
        }
    }
}
