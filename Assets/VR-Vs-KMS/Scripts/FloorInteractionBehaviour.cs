using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorInteractionBehaviour : MonoBehaviour
{
    public RadioButtonSystem radioButtons;
    public JsonManager jsonManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        jsonManager.addPinPoint(radioButtons.OnClick(), gameObject.transform);
        Debug.Log(gameObject.transform.position);
    }
}
