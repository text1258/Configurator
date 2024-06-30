using UnityEngine;
using UnityEngine.Events;

public class Button3D : MonoBehaviour
{
    public UnityEvent onMouseEnter;
    public UnityEvent onMouseExit;
    public UnityEvent onMouseUpAsButton;

    private void OnMouseEnter()
    {
        onMouseEnter?.Invoke();
    }

    private void OnMouseExit()
    {
        onMouseExit?.Invoke();
    }

    private void OnMouseUpAsButton()
    {
        onMouseUpAsButton?.Invoke();
    }
}
