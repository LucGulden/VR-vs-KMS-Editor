using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class JsonManager : MonoBehaviour
{
    public List<Vector3> ContaminationAreas;
    public List<Vector3> ThrowableObjects;
    public List<Vector3> SpawnPoints;
    public GameObject Level;
    public GameObject exportBtn;
    public GameObject importBtn;

    // Start is called before the first frame update
    void Start()
    {
        ContaminationAreas = new List<Vector3>();
        ThrowableObjects = new List<Vector3>();
        SpawnPoints = new List<Vector3>();

        exportBtn.GetComponent<Button>().onClick.AddListener(saveFile);
        importBtn.GetComponent<Button>().onClick.AddListener(loadFile);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveFile()
    {
        string path = EditorUtility.SaveFilePanel("Save config", "", "", ".json");
        if (path.Length != 0)
        {
            string json = JsonUtility.ToJson(this);
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
