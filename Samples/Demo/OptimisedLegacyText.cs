using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class OptimisedLegacyText : MonoBehaviour
{
    private Text _component => GetComponent<Text>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_component.raycastTarget || _component.resizeTextForBestFit)
        {
            _component.text = "I am an unoptimised (Legacy) Text.";
            _component.color = Color.red;
        }
        else
        {
            _component.text = "I am an optimised (Legacy) Text.";
            _component.color = Color.green;
        }
    }
}
