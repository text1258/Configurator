using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PC components", menuName = "ScriptableObjects/Create All Component Models data")]
public class AllComponentModels : ScriptableObject
{
    public List<DataComponentModelPC> ComponentModelsPC;
}
