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
    private JsonData data;
    private Transform[] Children;

    // Start is called before the first frame update
    void Start()
    {
        Floors = new List<Transform>();
        data = JsonData.GetInstance();
        jm = jsonManager.GetComponent<JsonManager>();

        Children = level.GetComponentsInChildren<Transform>();
        int id = 0;
        foreach (Transform child in Children)
        {
            if (child.GetComponent<FloorInteractionBehaviour>() != null)
            {
                Floors.Add(child);
                data.FloorUsedId.Add(-1);
                child.GetComponent<FloorInteractionBehaviour>().id = id;
                id++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPinPoint(string radioOption, Transform clickedElement, int id)
    {
        Debug.Log(radioOption);
        Debug.Log(clickedElement.name);
        Debug.Log(id);
        Debug.Log("--------------------------------------");
        if (data.FloorUsedId[id] == -1)
        {
            GameObject newPin;

            int index = radioOption == "ContaminationArea" ? 0 : radioOption == "ThrowableObject" ? 1 : radioOption == "SpawnPoint" ? 2 : -1;
            data.FloorUsedId[id] = index;

            newPin = Instantiate(PinPoints[index]);
            newPin.GetComponent<PinPointBehaviour>().UpdatePosition(clickedElement);
        }
    }

    public void rmPinPoint(string radioOption, Transform clickedElement, int id)
    {
        if (data.FloorUsedId[id] != -1)
        {
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
