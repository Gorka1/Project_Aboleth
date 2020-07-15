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

        if (Physics.Raycast(playerCam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out hit, 10) && hit.transform.gameObject.tag == "Interact")
        {
            print("outlineguntest");
            currentHighlight = hit.transform.gameObject;
            currentHighlight.GetComponent<Outline>().enabled = true;
        }
        else
        {
            if(currentHighlight != null)
            {
                currentHighlight.GetComponent<Outline>().enabled = false;
                currentHighlight = null;
            }
        }
    }
}
