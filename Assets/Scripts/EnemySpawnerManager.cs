using System;
using System.Drawing;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{

    public static float TimerJeu;
    public GameObject Enemy1Prefab;

    [SerializeField] private Transform positionJoueur;
    
    void Start()
    {
        TimerJeu = 0f;
    }

    
    void Update()
    {
        TimerJeu += Time.deltaTime;

        CreateEnemiesAroundPoint(5, positionJoueur.position, 5f);
    }


    public void CreateEnemiesAroundPoint(int num, Vector3 point, float radius)
    {

        for (int i = 0; i < num; i++)
        {

            /* Distance around the circle */
            var radians = 2 * MathF.PI / num * i;

            /* Get the vector direction */
            var vertical = MathF.Sin(radians);
            var horizontal = MathF.Cos(radians);

            var spawnDir = new Vector3(horizontal, 0, vertical);

            /* Get the spawn position */
            var spawnPos = point + spawnDir * radius; // Radius is just the distance away from the point

            /* Now spawn */
            var enemy = Instantiate(Enemy1Prefab, spawnPos, quaternion.identity) as GameObject;

            /* Rotate the enemy to face towards player */
            enemy.transform.LookAt(point);

            /* Adjust height */
            enemy.transform.Translate(new Vector3(0, enemy.transform.localScale.y / 2, 0));
        }
    }



}
