using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class JsonManager : MonoBehaviour
{
    public GameObject exportBtn;
    public GameObject importBtn;
    public PinPointsManager pm;
    public GameObject level;
    private Transform[] Children;


    [SerializeField] 
    private JsonData data = JsonData.GetInstance();

    // Start is called before the first frame update
    void Start()
    {
        JsonData data = JsonData.GetInstance();

        exportBtn.GetComponent<Button>().onClick.AddListener(saveFile);
        importBtn.GetComponent<Button>().onClick.AddListener(loadFile);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveFile()
    {
        string path = EditorUtility.SaveFilePanel("Save config", "", "", "json");
        if (path.Length != 0)
        {
            string json = JsonUtility.ToJson(data);
            if (json != null)
                File.WriteAllText(path, json);
        }
    }

    public void loadFile()
    {
        string path = EditorUtility.OpenFilePanel("Load config", "", "json");
        Debug.Log(path);
        if (path.Length != 0)
        {
            StreamReader r = new StreamReader(path);
            string jsonString = r.ReadToEnd();
            JsonData tmpData = JsonUtility.FromJson<JsonData>(jsonString);

            Children = level.GetComponentsInChildren<Transform>();
            foreach (Transform child in Children)
            {
                if (child.GetComponent<PinPointBehaviour>() != null)
                {
                    Destroy(child.gameObject);
                }
            }

            int id = 0;
            foreach(int floor in tmpData.FloorUsedId)
            {
                if(floor == 0)
                {
                    foreach (Transform child in Children)
                    {
                        if (child.GetComponent<FloorInteractionBehaviour>() != null)
                        {
                            if (child.GetComponent<FloorInteractionBehaviour>().id == id)
                            {
                                Debug.Log("top");
                                pm.addPinPoint("ContaminationArea", child, id);
                            }
                        }
                    }
                }
                else if(floor == 1)
                {
                    Children = level.GetComponentsInChildren<Transform>();
                    foreach (Transform child in Children)
                    {
                        if (child.GetComponent<FloorInteractionBehaviour>() != null)
                        {
                            if (child.GetComponent<FloorInteractionBehaviour>().id == id)
                            {
                                Debug.Log("top");
                                pm.addPinPoint("ThrowableObject", child, id);
                            }
                        }
                    }
                }
                else if(floor == 2)
                {
                    Children = level.GetComponentsInChildren<Transform>();
                    foreach (Transform child in Children)
                    {
                        if (child.GetComponent<FloorInteractionBehaviour>() != null)
                        {
                            if (child.GetComponent<FloorInteractionBehaviour>().id == id)
                            {
                                Debug.Log("top");
                                pm.addPinPoint("SpawnPoint", child, id);
                            }
                        }
                    }
                }
                id++;
            }
        }
    }
}

[System.Serializable]
public class JsonData
{
    public List<int> FloorUsedId = new List<int>(); 

    private JsonData() { }

    private static JsonData _instance;

    public static JsonData GetInstance()
    {
        if (_instance == null)
        {
            _instance = new JsonData();
        }
        return _instance;
    }
}
