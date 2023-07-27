using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public static SimulationManager _instance;
    public static SimulationManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                _instance = FindObjectOfType<SimulationManager>();
            }

            // 싱글톤 오브젝트를 반환
            return _instance;
        }
    }

    public GameObject spawnUIPanel;
    public GameObject weaponUIPanel;
    public bool isUI = false;
    // Start is called before the first frame update
    void Start()
    {
        if (WeaponManager.instance.weaponDataList[0] != null)
        {
            WeaponManager.instance.EquipWeapon(WeaponManager.instance.weaponDataList[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isUI == false)
            {
                isUI = true;
                spawnUIPanel.SetActive(true);
            }
            else
            {
                isUI = false;
                spawnUIPanel.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isUI == false)
            {
                isUI = true;
                weaponUIPanel.SetActive(true);
            }
            else
            {
                isUI = false;
                weaponUIPanel.SetActive(false);
            }
        }
    }
}
