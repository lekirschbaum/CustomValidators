using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class OptimisedImage : MonoBehaviour
{
    private Image _image => GetComponent<Image>();
    private Outline _outline => GetComponent<Outline>();
    private Shadow _shadow => GetComponent<Shadow>();
    private Animation _animation => GetComponent<Animation>();
    private Animator _animator => GetComponent<Animator>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_image.raycastTarget || !_image.useSpriteMesh || _shadow.enabled || _outline.enabled || _animation.enabled || _animator.enabled || _image.sprite.packingMode == SpritePackingMode.Rectangle)
        {
            _image.color = Color.red;
        }
        else
        {
            _image.color = Color.green;
        }
    }
}
