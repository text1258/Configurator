using SQLite4Unity3d;
using System;
using System.IO;
using System.Linq;
using UnityEngine;

// Заготовка для базы и десериализации данных
public class PCComponents
{
    public string CPU { get; set; }
    public string Motherboard { get; set; }
    public string RAM { get; set; }
    public string Videocard { get; set; }
    public string HDD { get; set; }
    public string PowerUnit { get; set; }
    public string Efficiency { get; set; }
}

public class GetDatabaseEfficiency : MonoBehaviour
{
    
    private SQLiteConnection db;
    public CreatorOfPC PC;

    public void Awake() 
    {   
        var databasePath = "Assets/DataBase/EfficiencyDB.db"; // Получения пути к базе
        db = new SQLiteConnection(databasePath); // Подключение к базе
        db.CreateTable<PCComponents>(); // Создание таблицы комплектующих, если отсутствует

        // Пример кода
        //int ef = getEfficiency("AMD_Ryzen_5_7500F_OEM", "GIGABYTE_B650M_GAMING_X_AX", "Kingston_FURY_Beast_Black_DDR5", "KFA2_GeForce_RTX_4060_Ti_CORE", "Seagate_BarraCuda_2TB", "Chieftec_PowerUP_750W"); // Вызов функции проверки эффективности
        //Debug.Log(ef);
    }

    public int getEfficiency(string CPU, string Motherboard, string RAM, string Videocard, string HDD, string PowerUnit) // Функция получения эффективности
    {
        var test = db.Query<PCComponents>($"SELECT * FROM PCComponents WHERE CPU = '{CPU}' AND Motherboard = '{Motherboard}' AND RAM = '{RAM}' AND Videocard = '{Videocard}' AND HDD = '{HDD}' AND PowerUnit = '{PowerUnit}'"); // SQL запрос через поиск по комплектующим
        if (test.Any()) // Проверка, существует ли сборка в базе
            if (!string.IsNullOrEmpty(test[0].Efficiency))
                return int.Parse(test[0].Efficiency); // Перевод эффективности в Int
        return 0;
    }

    [ContextMenu("Get Efficiency")]
    public int getEfficiency()
    {
        return getEfficiency(PC.CPU.ComponentModelName, PC.Motherboard.ComponentModelName, PC.RAM.ComponentModelName, PC.VideoCard.ComponentModelName, PC.HardDrive.ComponentModelName, PC.PowerUnit.ComponentModelName);
    }
}

