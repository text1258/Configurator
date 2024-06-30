using UnityEngine;

[CreateAssetMenu(fileName = "PC component Model", menuName = "ScriptableObjects/Create PC cmponent Model")]
public class DataComponentModelPC : ScriptableObject
{
    public string ComponentModelName;
    public string CompinentModelDescription;
    public DataComponentPC ComponentPC;
    public GameObject Prefab;

    public virtual bool IsCompatible(CreatorOfPC pc) => true;
}
