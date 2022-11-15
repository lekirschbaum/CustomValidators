using LeKirschbaum.CustomValidators.Runtime.RootObjectValidators;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class OptimisedGameObject : MonoBehaviour
{
    private Transform _transform => GetComponent<Transform>();
    private ChildCountValidator _childCountValidator = new ChildCountValidator();
    private ChildCountValidator.FixArgs _fixArgs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (_transform.childCount > _childCountValidator.ChildCountLimit)
        {
            for (int i = 0; i < _transform.childCount; i++)
            {
                _transform.GetChild(i).GetComponent<Image>().color = Color.red;
            }
        }
        else
        {
            for (int i = 0; i < _transform.childCount; i++)
            {
                _transform.GetChild(i).GetComponent<Image>().color = Color.green;
            }
        }
    }
}
