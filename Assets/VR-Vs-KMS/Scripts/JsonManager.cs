using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    private List<Vector3> ContaminationAreas;
    private List<Vector3> ThrowableObjects;
    private List<Vector3> SpawnPoints;
    public List<GameObject> PinPoints;
    public GameObject Level;

    // Start is called before the first frame update
    void Start()
    {
        ContaminationAreas = new List<Vector3>();
        ThrowableObjects = new List<Vector3>();
        SpawnPoints = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPinPoint(string radioOption, Transform clickedElement)
    {
        GameObject newPin;
        int index = 0;
        if (radioOption == "ContaminationArea")
        {
            ContaminationAreas.Add(clickedElement.position);
            index = 0;
        }
        else if (radioOption == "ThrowableObject")
        {
            ThrowableObjects.Add(clickedElement.position);
            index = 1;
        }
        else if (radioOption == "SpawnPoint")
        {
            Debug.Log("Spawnpoint: " + radioOption + clickedElement.position);
            SpawnPoints.Add(clickedElement.position);
            index = 2;
        }

        newPin = Instantiate(PinPoints[index]);
        newPin.GetComponent<PinPointBehaviour>().UpdatePosition(clickedElement);
    }
}
