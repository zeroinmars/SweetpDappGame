using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{

    public static UIManager _instance;
    public static UIManager instace
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
            }
            return _instance;
        }
    }
    public TMP_InputField HP_Input;
    public TMP_InputField Damage_Input;
    public TMP_InputField Speed_Input;
    public TMP_Dropdown options;

    private int currentOption;

    List<string> optionList = new List<string>();
    string DROPDOWN_KEY = "DROPDOWN_KEY";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(DROPDOWN_KEY) == false)
            currentOption = 0;
        else currentOption = PlayerPrefs.GetInt(DROPDOWN_KEY);
    }
    // Start is called before the first frame update
    void Start()
    {
        options.ClearOptions();
        for(int i=0; i< SimulationSpawner.instance.enemyPrefabs.Length; i++)
        {
            optionList.Add(SimulationSpawner.instance.enemyPrefabs[i].name);
        }

        options.AddOptions(optionList);
        options.value = currentOption;
        options.onValueChanged.AddListener(
            delegate {
                setDropDown(options.value);
            });
        
    }

    void setDropDown(int option)
    {
        PlayerPrefs.SetInt(DROPDOWN_KEY, option);

    }

    public void createEnemy()
    {
        float hp = 0f;
        float damage = 0f;
        float speed = 0f;


        if(float.TryParse(HP_Input.text, out hp))
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
        SimulationSpawner.instance.SpawnMonster(hp, damage, speed, options.value);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
