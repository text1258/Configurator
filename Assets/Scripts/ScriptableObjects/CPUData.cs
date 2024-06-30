using UnityEngine;

[CreateAssetMenu(fileName = "CPU Data", menuName = "ScriptableObjects/Create CPU Data")]
public class CPUData : DataComponentModelPC
{
    public CPU_Socet CPU_Socet;

    public override bool IsCompatible(CreatorOfPC pc)
    {
        MotherboardData motherboard = (MotherboardData)pc.Motherboard;
        return motherboard.CPU_Socet == CPU_Socet;
    }
}
