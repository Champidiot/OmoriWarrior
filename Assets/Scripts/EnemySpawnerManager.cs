using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{

    public static float TimerJeu;
    public float timerEnemy;
    public GameObject Enemy1Prefab;

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
        if (timerEnemy >= 1)
        {
            angle = Random.Range(0f, 2 * Mathf.PI);

            var enemy = Instantiate(Enemy1Prefab);
            enemy.transform.position = new Vector3((point.x + (radius * Mathf.Cos(angle))), (point.y + (radius * Mathf.Sin(angle))), 2f);
            enemy.SetActive(true);

            timerEnemy = 0f;
        }


    }

}
