using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPointsManager : MonoBehaviour
{
    private List<Transform> FloorUsed;
    public GameObject jsonManager;
    private JsonManager jm;
    public List<GameObject> PinPoints;

    // Start is called before the first frame update
    void Start()
    {
        FloorUsed = new List<Transform>();
        jm = jsonManager.GetComponent<JsonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addPinPoint(string radioOption, Transform clickedElement)
    {
        if (!FloorUsed.Contains(clickedElement))
        {
            FloorUsed.Add(clickedElement);
            GameObject newPin;
            int index = 0;
            if (radioOption == "ContaminationArea")
            {
                jm.ContaminationAreas.Add(clickedElement.localPosition);
                index = 0;
            }
            else if (radioOption == "ThrowableObject")
            {
                jm.ThrowableObjects.Add(clickedElement.localPosition);
                index = 1;
            }
            else if (radioOption == "SpawnPoint")
            {
                jm.SpawnPoints.Add(clickedElement.localPosition);
                index = 2;
            }


            newPin = Instantiate(PinPoints[index]);
            newPin.GetComponent<PinPointBehaviour>().UpdatePosition(clickedElement);
        }
    }

    public void rmPinPoint(string radioOption, Transform clickedElement)
    {
        if (FloorUsed.Contains(clickedElement))
        {
            string pinType = clickedElement.GetComponentInChildren<PinPointBehaviour>().PinType;
            if (pinType == "SpawnPoint")
            {
                jm.SpawnPoints.Remove(clickedElement.localPosition);
            }
            else if (pinType == "ContaminationArea")
            {
                jm.ContaminationAreas.Remove(clickedElement.localPosition);
            }
            else if (pinType == "ThrowableObject")
            {
                jm.ThrowableObjects.Remove(clickedElement.localPosition);
            }
            FloorUsed.Remove(clickedElement);
            Destroy(clickedElement.GetComponentInChildren<PinPointBehaviour>().gameObject);
        }
    }

    public void updatePinPoint(string radioOption, Transform clickedElement)
    {
        if (radioOption == "Remove")
        {
            rmPinPoint(radioOption, clickedElement);
        }
        else
        {
            addPinPoint(radioOption, clickedElement);
        }
    }
}
