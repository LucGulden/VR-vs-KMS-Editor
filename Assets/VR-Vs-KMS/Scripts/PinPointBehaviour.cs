using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinPointBehaviour : MonoBehaviour
{
    private Transform CameraTransform;
    public string PinType;


    // Use this for initialization
    void Start()
    {
        CameraTransform = GameObject.Find("ARCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO always turn the label to the Camera
        gameObject.transform.rotation = CameraTransform.rotation;

    }

    public void UpdatePosition(Transform labelPositionTransform)
    {
        //TODO update position of the label and label value

        gameObject.transform.parent = labelPositionTransform;
        gameObject.transform.localPosition = new Vector3(-1.5f, -1.5f, 0);
    }
}