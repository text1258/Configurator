using UnityEngine;
using UnityEngine.Events;

public class ComponentChoser : MonoBehaviour
{
    public ComponentPC ChoosenComponent;
    public Material ChoosenMaterial;
    public UnityEvent<ComponentPC> OnChoose;

    public void Choose(ComponentPC component)
    {
        if (ChoosenComponent != null)
        {
            ChoosenComponent.Stroke();
        }
        ChoosenComponent = component;
        ChoosenComponent.Stroke(ChoosenMaterial);
        OnChoose?.Invoke(ChoosenComponent);
    }
}
