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

    public void Stroke(Material material)
    {
        DeleteStroke();
        MeshFilter[] meshFilters = ApplyingModel.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        for (int i = 0; i < meshFilters.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
        }
        Mesh mesh = new Mesh();
        mesh.Clear();
        mesh.CombineMeshes(combine);
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] -= ApplyingModel.transform.position;
        }
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        GameObject strokeObject = new GameObject("Stroke");
        strokeObject.AddComponent<MeshFilter>().sharedMesh = mesh;
        strokeObject.AddComponent<MeshRenderer>().material = material;
        strokeObject.transform.position = ApplyingModel.transform.position;
        strokeObject.transform.localScale = MultypluingStrokeSize;
        StrokeObject = strokeObject;
    }

    public void DeleteStroke()
    {
        if (StrokeObject == null)
        {
            return;
        }
        Destroy(StrokeObject);
        StrokeObject = null;
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
