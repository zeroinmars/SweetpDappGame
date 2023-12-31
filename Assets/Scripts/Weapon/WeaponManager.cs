using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private static WeaponManager _instance;
    public static WeaponManager instance
    {

        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                _instance = FindObjectOfType<WeaponManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            // 싱글톤 오브젝트를 반환
            return _instance;
        }
    }

    public List<WeaponData> weaponDataList = new List<WeaponData>();
    private class WeaponTBArray
    {
        public WeaponTB[] weapons;
    }

    public WeaponData curruentWeaponData;
    private bool currentWeaponCheck = false;

    public GameObject Sword;
    public GameObject Bow;
    public GameObject Magic;

    // Start is called before the first frame update

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        GetWeaponList();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void HandleWeaponTB(string jsonData)
    {
        WeaponTBArray weaponTBArray = JsonUtility.FromJson<WeaponTBArray>("{\"weapons\":"+jsonData+"}");
        int count = 0;
        if(weaponTBArray != null && weaponTBArray.weapons != null)
        {
            foreach (var weaponTB in weaponTBArray.weapons)
            {
                int weapon_id = weaponTB.weapon_id;
                int weapon_owenr = weaponTB.weapon_owner;

                GetWeaponData(weapon_id);
                count++;
            }
            
            
        }
        else
        {
            Debug.LogError("JSON NULL");
        }
    }

    private void HandleWeaponData(string jsonData)
    {
        WeaponData weaponData = JsonUtility.FromJson<WeaponData>(jsonData);
        weaponDataList.Add(weaponData);
        print(weaponDataList[0].weapon_id);

    }

    public void GetWeaponList()
    {
        HTTPClient.instance.GET("https://breadmore.azurewebsites.net/api/Weapon_TB/owner/" + LoginManager.instance.PlayerID, delegate (string www)
        {
            HandleWeaponTB(www);
        });
    }

    public void GetWeaponData(int weapon_id)
    {
        HTTPClient.instance.GET("https://breadmore.azurewebsites.net/api/Weapon_Data/weapon/" + weapon_id, delegate (string www)
        {
            HandleWeaponData(www);
        });
    }

    public void EquipWeapon(WeaponData weaponData)
    {
        curruentWeaponData = weaponData;
    }

    public void createWeapon()
    {
        switch (curruentWeaponData.weapon_type)
        {
            //sword
            case 0:
                Instantiate(Sword);
                break;

            // bow
            case 1:
                break;

            // magic
            case 2:
                break;
        }
    }

}
