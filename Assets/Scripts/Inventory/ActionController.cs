using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    private static ActionController _instance;
    public static ActionController instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<ActionController>();
            }
            return _instance;
        }
    }

    [SerializeField]
    private WeaponInventory weaponInventory;

    private void CanPickUp()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i< WeaponManager.instance.weaponDataList.Count; i++)
        {
            print("item input");
            weaponInventory.AcquireWeapon(WeaponManager.instance.weaponDataList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
