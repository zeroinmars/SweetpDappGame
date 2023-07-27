using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class WeaponTest : MonoBehaviour
{
    string jsonData;
    public void Save(WeaponData myWeaponData)
    {
        WeaponData weaponData = new WeaponData();

        weaponData.weapon_id = myWeaponData.weapon_id;
        weaponData.weapon_type = myWeaponData.weapon_type;
        weaponData.weapon_unique = myWeaponData.weapon_unique;
        weaponData.weapon_atk = myWeaponData.weapon_atk;
        weaponData.weapon_hp = myWeaponData.weapon_hp;
        weaponData.weapon_element = myWeaponData.weapon_element;
        weaponData.weapon_durability = myWeaponData.weapon_durability;
        weaponData.weapon_upgrade = myWeaponData.weapon_upgrade;


    string json = JsonUtility.ToJson(weaponData);
        jsonData += json;
    }


    public void SaveJsonFile()
    {
        string fileName = "/WeaponData" +".Json";
        string path = Application.dataPath + "/Resources/WeaponData";

        DirectoryInfo di = new DirectoryInfo(path);
        foreach(FileInfo file in di.GetFiles())
        {
            if (file.Name == "WeaponData.Json")
            {
                Debug.Log("Update");
            }
        }
        
        File.WriteAllText(path+fileName, jsonData);
    }

    public void LoginTest()
    {
        SaveJsonFile();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
