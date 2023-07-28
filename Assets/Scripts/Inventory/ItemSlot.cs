using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemSlot : MonoBehaviour
{

    public WeaponData weaponData;
    public Image itemImage;

    [SerializeField]
    private TextMeshProUGUI item_Count;
    [SerializeField]
    private GameObject go_CountImage;

    private void SetColor(float alpha)
    {
        Color color = itemImage.color;
        color.a = alpha;
        itemImage.color = color;
    }

    public void AddWeapon(WeaponData _weaponData)
    {
        weaponData = _weaponData;
        switch (weaponData.weapon_type)
        {
                //sword
            case 0:
                itemImage.sprite = Item.instance.Sword;
                break;
                //bow
            case 1:
                itemImage.sprite = Item.instance.Bow;
                break;
                //magic
            case 2:
                itemImage.sprite = Item.instance.Magic;
                break;
        }

        SetColor(1);
    }

    private void ClearSlot()
    {

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
