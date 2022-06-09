using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{
    List<Renderer> _modelComponentRenderers = new List<Renderer>();

    private void Start()
    {
        foreach (Renderer ren in gameObject.GetComponentsInChildren<Renderer>())
        {
            if (ren.gameObject.tag == "ShowerDoorComponent")
            {
                _modelComponentRenderers.Add(ren);
            }
        }
    }

    public void ChangeColor(Material selectedColor)
    {
        foreach (Renderer ren in _modelComponentRenderers)
        {
            ren.material = selectedColor;
        }
    }
}
