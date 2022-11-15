using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class OptimisedTMPText : MonoBehaviour
{
    private TextMeshProUGUI _component => GetComponent<TextMeshProUGUI>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_component.raycastTarget || _component.enableAutoSizing || _component.materialForRendering.shader == Shader.Find("TextMeshPro/Distance Field"))
        {
            _component.text = "I am an unoptimised (TMP) Text.";
            _component.color = Color.red;
        }
        else
        {
            _component.text = "I am an optimised (TMP) Text.";
            _component.color = Color.green;
        }
    }
}
