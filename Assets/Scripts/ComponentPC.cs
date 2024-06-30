using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ComponentPC : MonoBehaviour
{
    [SerializeField] private DataComponentModelPC model;
    public GameObject ApplyingModel;
    public Vector3 MultypluingStrokeSize = Vector3.one;
    public GameObject StrokeObject;
    public List<VisualComponentModel> VisualModels;
    public UnityEvent<DataComponentModelPC> onModelChange;

    public DataComponentModelPC Model
    {
        get => model; 
        set
        {
            model = value;
            onModelChange?.Invoke(value);
        }
    }

    public void ChangeVisaual(DataComponentModelPC model)
    {
        foreach (VisualComponentModel visualModel in VisualModels)
        {
            visualModel.gameObject.SetActive(false);
        }
        VisualModels.Find(x => x.Model == model).gameObject.SetActive(true);
    }
}
