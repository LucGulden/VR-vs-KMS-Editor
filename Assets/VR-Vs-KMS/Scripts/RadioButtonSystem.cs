using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RadioButtonSystem : MonoBehaviour
{
    ToggleGroup toggleGroup;

    // Start is called before the first frame update
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string OnClick()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        return toggle.name;
    }
}
