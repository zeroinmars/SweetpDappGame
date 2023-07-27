using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SimulationUIManager : MonoBehaviour
{

    public static SimulationUIManager _instance;
    public static SimulationUIManager instace
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SimulationUIManager>();
            }
            return _instance;
        }
    }


    [Header("Monster Spawner")]
    public TMP_InputField HP_Input;
    public TMP_InputField Damage_Input;
    public TMP_InputField Speed_Input;
    public TMP_Dropdown Monster_Options;

    private int currentOption_Monster;

    [Header("Weapon Manager")]
    public TMP_Dropdown Weapon_Options;

    private int currentOption_Weapon;

    List<string> optionList_Monster = new List<string>();
    List<string> optionList_Weapon = new List<string>();

    private string DROPDOWN_KEY_MONSTER = "DROPDOWN_KEY_MONSTER";
    private string DROPDOWN_KEY_WEAPON = "DROPDOWN_KEY_WEAPON";

    private void setDropDown(string key, int option)
    {
        PlayerPrefs.SetInt(key, option);
    }

    public void createEnemy()
    {
        float hp = 0f;
        float damage = 0f;
        float speed = 0f;


        if (float.TryParse(HP_Input.text, out hp))
        {
            Debug.Log("hp 변형 성공");
        }
        if (float.TryParse(Damage_Input.text, out damage))
        {
            Debug.Log("damage 변형 성공");
        }
        if (float.TryParse(Speed_Input.text, out speed))
        {
            Debug.Log("speed 변형 성공");
        }
        SimulationSpawner.instance.SpawnMonster(hp, damage, speed, Monster_Options.value);
    }

    public void equipWeapon()
    {
        WeaponData weaponData = new WeaponData();
        WeaponManager.instance.EquipWeapon(WeaponManager.instance.weaponDataList[Weapon_Options.value]);
        print("equip !");
        switch (WeaponManager.instance.curruentWeaponData.weapon_type)
        {
            case 0:
                GameObject weapon = Instantiate(WeaponManager.instance.Sword, PlayerAttack.instance.pivotWeaponR);

                PlayerAttack.instance.objWeapon = PlayerAttack.instance.pivotWeaponR.GetChild(0).gameObject;
                PlayerAttack.instance.colliderWeapon = PlayerAttack.instance.objWeapon.GetComponent<BoxCollider>();

                PlayerAttack.instance.colliderWeapon.enabled = false;
                PlayerAttack.instance.IsWeaponEquip = true;
                Player.instance.ChangeHealthWithWeapon();
                break;

                //bow
            case 1:
                break;

                //magic
            case 2:
                break;
        }

    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey(DROPDOWN_KEY_MONSTER) == false)
            currentOption_Monster = 0;
        else currentOption_Monster = PlayerPrefs.GetInt(DROPDOWN_KEY_MONSTER);

        if (PlayerPrefs.HasKey(DROPDOWN_KEY_WEAPON) == false)
            currentOption_Weapon = 0;
        else currentOption_Weapon = PlayerPrefs.GetInt(DROPDOWN_KEY_WEAPON);
    }

    // Start is called before the first frame update
    void Start()
    {
        Monster_Options.ClearOptions();
        for (int i = 0; i < SimulationSpawner.instance.enemyPrefabs.Length; i++)
        {
            optionList_Monster.Add(SimulationSpawner.instance.enemyPrefabs[i].name);
        }

        Monster_Options.AddOptions(optionList_Monster);
        Monster_Options.value = currentOption_Monster;
        Monster_Options.onValueChanged.AddListener(
            delegate {
                setDropDown(DROPDOWN_KEY_MONSTER,Monster_Options.value);
            });


        Weapon_Options.ClearOptions();
        for (int i = 0; i < WeaponManager.instance.weaponDataList.Count; i++)
        {
            optionList_Weapon.Add(WeaponManager.instance.weaponDataList[i].weapon_id.ToString());
        }

        Weapon_Options.AddOptions(optionList_Weapon);
        Weapon_Options.value = currentOption_Weapon;
        Weapon_Options.onValueChanged.AddListener(
            delegate {
                setDropDown(DROPDOWN_KEY_WEAPON, Weapon_Options.value);
            });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
