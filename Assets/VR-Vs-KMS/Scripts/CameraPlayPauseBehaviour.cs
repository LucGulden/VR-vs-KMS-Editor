using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class CameraPlayPauseBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(delegate {
            FreezeCamera();
        });

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FreezeCamera()
    {
        if (GetComponent<Toggle>().isOn)
        {
            VuforiaRenderer.Instance.Pause(true);
        }
        else
        {
            VuforiaRenderer.Instance.Pause(false);
        }
    }
}
