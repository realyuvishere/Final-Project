using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionButtonScript : MonoBehaviour
{
    public Material defaultMaterial;
    public Material hoverMaterial;

    private Renderer _renderer;
    private Vector3 _startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.parent.localPosition;
        _renderer = GetComponent<Renderer>();
        SetMaterial(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter()
    {
        SetMaterial(true);
    }

    public void OnPointerExit()
    {
        SetMaterial(false);
    }

    private void SetMaterial(bool isHovered)
    {
        if (hoverMaterial != null && defaultMaterial != null)
        {
            _renderer.material = isHovered ? hoverMaterial : defaultMaterial;
        }
    }
}
