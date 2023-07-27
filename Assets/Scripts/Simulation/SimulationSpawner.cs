using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationSpawner : MonoBehaviour
{
    private static SimulationSpawner _instance;
    public static SimulationSpawner instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<SimulationSpawner>();
            }
            return _instance;
        }
    }

    public Enemy[] enemyPrefabs;

    public Transform spawnPoint;

    public float baseDamage = 20f;
    public float baseHP = 100f;
    public float baseSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMonster(float inputHP, float inputDamage, float inputSpeed, int enemyNumber)
    {
        float setHP = baseHP;
        float setDamage = baseDamage;
        float setSpeed = baseSpeed;

        if(inputHP !=0f)
        {
            Debug.Log("HP set");
            setHP = inputHP;
        }
        if (inputDamage !=0f)
        {
            Debug.Log("Damage set");
            setDamage = inputDamage;
        }
        if (inputSpeed != 0f)
        {
            Debug.Log("Speed set");
            setSpeed = inputSpeed;
        }
        CreateEnemy(setHP, setDamage, setSpeed,enemyNumber);
        Debug.Log("create");
    }

    private void CreateEnemy(float setHP, float setDamage, float setSpeed, int enemyNumber)
    {
        Color skinColor = Color.white;


        Enemy enemy = Instantiate(
            enemyPrefabs[enemyNumber],
            spawnPoint.position,
            spawnPoint.rotation);
        enemy.Setup(setHP, setDamage, setSpeed, skinColor);
        Debug.Log("spawn!");
    }

}
