using System.Drawing;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemySpawnerManager : MonoBehaviour
{

    public static float TimerJeu;

    public float timerEnemy;


    public GameObject Enemy1Prefab;

    public GameObject Enemy2Prefab;

    public GameObject Enemy3Prefab;

    public GameObject Enemy4Prefab;

    public GameObject Enemy5Prefab;



    [SerializeField] private Transform positionJoueur;

    private float angle;

    private int roulement;

    void Start()
    {
        TimerJeu = 0f;
        timerEnemy = 0f;

    }

    
    void Update()
    {
        TimerJeu += Time.deltaTime;
        CreateEnemies1AroundPoint(positionJoueur.position, 10f);

        timerEnemy += Time.deltaTime;

    }


    public void CreateEnemies1AroundPoint(Vector3 point, float radius)
    {

        if (TimerJeu < 60)
        {
            if (timerEnemy >= 1)
            {
                angle = Random.Range(0f, 2 * Mathf.PI);
                var enemy = Instantiate(Enemy1Prefab);
                enemy.transform.position = new Vector3((point.x + (radius * Mathf.Cos(angle))), (point.y + (radius * Mathf.Sin(angle))), 2f);
                enemy.SetActive(true);
                timerEnemy = 0f;
            }
                
        }


        else if (TimerJeu >= 60 && TimerJeu < 120)
        {
            if (timerEnemy >= 0.75)
            {
                angle = Random.Range(0f, 2 * Mathf.PI);
                var enemy = Instantiate(Enemy2Prefab);
                enemy.transform.position = new Vector3((point.x + (radius * Mathf.Cos(angle))), (point.y + (radius * Mathf.Sin(angle))), 2f);
                enemy.SetActive(true);
                timerEnemy = 0f;
            }
            
        }

        else if (TimerJeu >= 120 && TimerJeu < 180)
        {
            if (timerEnemy >= 0.5)
            {
                angle = Random.Range(0f, 2 * Mathf.PI);
                var enemy = Instantiate(Enemy3Prefab);
                enemy.transform.position = new Vector3((point.x + (radius * Mathf.Cos(angle))), (point.y + (radius * Mathf.Sin(angle))), 2f);
                enemy.SetActive(true);
                timerEnemy = 0f;
            }
            
        }

        else if (TimerJeu >= 180 && TimerJeu < 240)
        {
            if (timerEnemy >= 0.4)
            {
                angle = Random.Range(0f, 2 * Mathf.PI);
                var enemy = Instantiate(Enemy4Prefab);
                enemy.transform.position = new Vector3((point.x + (radius * Mathf.Cos(angle))), (point.y + (radius * Mathf.Sin(angle))), 2f);
                enemy.SetActive(true);
                timerEnemy = 0f;
            }
            
        }

        else if (TimerJeu >= 240)
        {
            if (timerEnemy >= 0.25)
            {
                angle = Random.Range(0f, 2 * Mathf.PI);
                var enemy = Instantiate(Enemy5Prefab);
                enemy.transform.position = new Vector3((point.x + (radius * Mathf.Cos(angle))), (point.y + (radius * Mathf.Sin(angle))), 2f);
                enemy.SetActive(true);
                timerEnemy = 0f;
            }
            
        }


    }


    

}
