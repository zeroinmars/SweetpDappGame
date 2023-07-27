using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;
    public static UIManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                _instance = FindObjectOfType<UIManager>();
            }

            // 싱글톤 오브젝트를 반환
            return _instance;
        }
    }

    public GameObject Inventory;
    private bool IsInventory = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (IsInventory)
            {
                Inventory.SetActive(false);
                IsInventory = false;


                GameManager.instance.IsUI = false;
            }
            else
            {
                Inventory.SetActive(true);
                IsInventory = true;

                GameManager.instance.IsUI = true;
            }
        }
    }
}
