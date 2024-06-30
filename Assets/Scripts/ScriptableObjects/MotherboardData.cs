using UnityEngine;

[CreateAssetMenu(fileName = "Motherboard Data", menuName = "ScriptableObjects/Create Motherboard Data")]
public class MotherboardData : DataComponentModelPC
{
    public MotherboardStand MotherboardStand;
    public CPU_Socet CPU_Socet;

    public override bool IsCompatible(CreatorOfPC pc)
    {
        CPUData cpu = (CPUData)pc.CPU;
        return cpu.CPU_Socet == CPU_Socet;
    }
}
