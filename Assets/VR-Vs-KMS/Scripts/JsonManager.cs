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
        Debug.Log("Dylaaaaaaaaaaaan");
    }

    public void loadFile()
    {
        Debug.Log("Clemeeeeeeeeeeeent");
    }
}

[System.Serializable]
public class JsonData
{
    public List<Vector3> ContaminationAreas = new List<Vector3>();
    public List<Vector3> ThrowableObjects = new List<Vector3>();
    public List<Vector3> SpawnPoints = new List<Vector3>();
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
