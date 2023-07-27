using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public static GameManager instance
    {
        
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                _instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return _instance;
        }
    }

    public bool IsUI= false;
    // Start is called before the first frame update
    void Start()
    {
        //weapon check

        if (WeaponManager.instance.weaponDataList[0] != null)
        {
            WeaponManager.instance.EquipWeapon(WeaponManager.instance.weaponDataList[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
