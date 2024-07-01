using UnityEngine;
using UnityEngine.Events;

public class ComponentChoser : MonoBehaviour
{
    public ComponentPC ChoosenComponent;
    public UnityEvent<ComponentPC> OnChoose;

    public void Choose(ComponentPC component)
    {
        ChoosenComponent = component;
        OnChoose?.Invoke(ChoosenComponent);
    }
}
