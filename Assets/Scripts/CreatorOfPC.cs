using UnityEngine;

public class CreatorOfPC : MonoBehaviour
{
    [SerializeField] private CPUData _CPU;
    [SerializeField] private MotherboardData _Motherboard;
    [SerializeField] private DataComponentModelPC _VideoCard;
    [SerializeField] private DataComponentModelPC _RAM;
    [SerializeField] private DataComponentModelPC _HardDrive;
    [SerializeField] private DataComponentModelPC _PowerUnit;
    public Transform HardDrivePoint;
    public Transform PowerUnitPoint;
    public Transform MotherboardPoint;
    public GameObject CPU_Model;
    public GameObject Motherboard_Model;
    public GameObject VideoCard_Model;
    public GameObject RAM_Model1;
    public GameObject RAM_Model2;
    public GameObject HardDrive_Model;
    public GameObject PowerUnit_Model;

    public DataComponentModelPC VideoCard
    {
        get => _VideoCard;
        set
        {
            _VideoCard = value;
            Destroy(VideoCard_Model);
            VideoCard_Model = Instantiate(value.Prefab, position: _Motherboard.MotherboardStand.VideoCard_Point.position, Quaternion.identity, parent: transform);
        }
    }
    public DataComponentModelPC RAM
    {
        get => _RAM; set
        {
            _RAM = value;
            Destroy(RAM_Model1);
            Destroy(RAM_Model2);
            RAM_Model1 = Instantiate(value.Prefab, position: _Motherboard.MotherboardStand.RAM_Point1.position, Quaternion.identity, parent: transform);
            RAM_Model2 = Instantiate(value.Prefab, position: _Motherboard.MotherboardStand.RAM_Point2.position, Quaternion.identity, parent: transform);
        }
    }
    public DataComponentModelPC HardDrive
    {
        get => _HardDrive; set
        {
            _HardDrive = value;
            Destroy(HardDrive_Model);
            HardDrive_Model = Instantiate(value.Prefab, position: HardDrivePoint.position, Quaternion.identity, parent: transform);
        }
    }
    public DataComponentModelPC PowerUnit
    {
        get => _PowerUnit; set
        {
            _PowerUnit = value;
            Destroy(PowerUnit_Model);
            PowerUnit_Model = Instantiate(value.Prefab, position: PowerUnitPoint.position, Quaternion.identity, parent: transform);
        }
    }
    public DataComponentModelPC CPU
    {
        get => _CPU;
        set
        {
            _CPU = (CPUData)value;
            Destroy(CPU_Model);
            CPU_Model = Instantiate(value.Prefab, position: _Motherboard.MotherboardStand.CPU_Point.position, Quaternion.identity, parent: transform);
        }
    }
    public DataComponentModelPC Motherboard
    {
        get => _Motherboard;
        set
        {
            _Motherboard = (MotherboardData)value;
            Destroy(Motherboard_Model);
            Motherboard_Model = Instantiate(value.Prefab, position: MotherboardPoint.position, Quaternion.identity, parent: transform);
            CPU = CPU;
            RAM = RAM;
            VideoCard = VideoCard;
        }
    }
}
