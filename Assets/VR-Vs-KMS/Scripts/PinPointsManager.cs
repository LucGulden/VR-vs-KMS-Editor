using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPointsManager : MonoBehaviour
{
    private List<Transform> Floors;
    public GameObject level;
    public GameObject jsonManager;
    private JsonManager jm;
    public List<GameObject> PinPoints;
    JsonData data;

    // Start is called before the first frame update
    void Start()
    {
        Floors = new List<Transform>();
        data = JsonData.GetInstance();
        jm = jsonManager.GetComponent<JsonManager>();

        int id = 0;
        foreach (Transform child in level.GetComponent<Transform>())
        {
            if (child.GetComponent<FloorInteractionBehaviour>() != null)
            {
                Floors.Add(child);
                data.FloorUsedId.Add(-1);
                child.GetComponent<FloorInteractionBehaviour>().id = id;
                id++;
            }
            foreach (Transform ch in child)
            {
                if (child.GetComponent<FloorInteractionBehaviour>() != null)
                {
                    Floors.Add(ch);
                    data.FloorUsedId.Add(-1);
                    ch.GetComponent<FloorInteractionBehaviour>().id = id;
                    id++;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addPinPoint(string radioOption, Transform clickedElement, int id)
    {
        Debug.Log(id);
        if (data.FloorUsedId[id] == -1)
        {
            GameObject newPin;
            int index = 0;
            if (radioOption == "ContaminationArea")
            {
                data.ContaminationAreas.Add(clickedElement.localPosition);
                index = 0;
            }
            else if (radioOption == "ThrowableObject")
            {
                data.ThrowableObjects.Add(clickedElement.localPosition);
                index = 1;
            }
            else if (radioOption == "SpawnPoint")
            {
                data.SpawnPoints.Add(clickedElement.localPosition);
                index = 2;
            }

            data.FloorUsedId[id] = index;

            newPin = Instantiate(PinPoints[index]);
            newPin.GetComponent<PinPointBehaviour>().UpdatePosition(clickedElement);
        }
    }

    public void rmPinPoint(string radioOption, Transform clickedElement, int id)
    {
        if (data.FloorUsedId[id] != -1)
        {
            string pinType = clickedElement.GetComponentInChildren<PinPointBehaviour>().PinType;
            if (pinType == "SpawnPoint")
            {
                data.SpawnPoints.Remove(clickedElement.localPosition);
            }
            else if (pinType == "ContaminationArea")
            {
                data.ContaminationAreas.Remove(clickedElement.localPosition);
            }
            else if (pinType == "ThrowableObject")
            {
                data.ThrowableObjects.Remove(clickedElement.localPosition);
            }
            data.FloorUsedId[id] = -1;
            Destroy(clickedElement.GetComponentInChildren<PinPointBehaviour>().gameObject);
        }
    }

    public void updatePinPoint(string radioOption, Transform clickedElement, int id)
    {
        if (radioOption == "Remove")
        {
            rmPinPoint(radioOption, clickedElement, id);
        }
        else
        {
            addPinPoint(radioOption, clickedElement, id);
        }
    }
}
