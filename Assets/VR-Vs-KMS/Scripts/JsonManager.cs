using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    private List<Vector3> ContaminationAreas;
    private List<Vector3> ThrowableObjects;
    private List<Vector3> SpawnPoints;
    private List<Transform> FloorUsed;
    public List<GameObject> PinPoints;
    public GameObject Level;

    // Start is called before the first frame update
    void Start()
    {
        ContaminationAreas = new List<Vector3>();
        ThrowableObjects = new List<Vector3>();
        SpawnPoints = new List<Vector3>();
        FloorUsed = new List<Transform>();
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
                ContaminationAreas.Add(clickedElement.localPosition);
                index = 0;
            }
            else if (radioOption == "ThrowableObject")
            {
                ThrowableObjects.Add(clickedElement.localPosition);
                index = 1;
            }
            else if (radioOption == "SpawnPoint")
            {
                SpawnPoints.Add(clickedElement.localPosition);
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
            Debug.Log(pinType);
            Debug.Log(clickedElement.position);
            if (pinType == "SpawnPoint")
            {
                SpawnPoints.Remove(clickedElement.localPosition);
            }
            else if (pinType == "ContaminationArea")
            {
                ContaminationAreas.Remove(clickedElement.localPosition);
            }
            else if (pinType == "ThrowableObject")
            {
                ThrowableObjects.Remove(clickedElement.localPosition);
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
