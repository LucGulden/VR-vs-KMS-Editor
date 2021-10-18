using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorInteractionBehaviour : MonoBehaviour
{
    public RadioButtonSystem radioButtons;
    public PinPointsManager pm;
    public int id;

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
        pm.updatePinPoint(radioButtons.OnClick(), gameObject.transform, id);
    }
}
