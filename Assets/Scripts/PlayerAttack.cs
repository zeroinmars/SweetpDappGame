using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform pivotWeaponR;
    BoxCollider colliderWeapon;
    private GameObject objWeapon;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        objWeapon = pivotWeaponR.GetChild(0).gameObject;
        colliderWeapon = objWeapon.GetComponent<BoxCollider>();

        colliderWeapon.enabled = false;
    }

    private void AttackColliderOn()
    {
        colliderWeapon.enabled = true;
    }

    private void AttackColliderOff()
    {
        colliderWeapon.enabled = false;
    }


}
