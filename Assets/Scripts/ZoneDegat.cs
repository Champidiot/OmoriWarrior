using UnityEngine;

public class ZoneDegat : MonoBehaviour
{
    public float zoneDamage = 1f;

    private float timerDamage;

    private float intervalDamage = 0.2f;

    public int NiveauAme = 0;


    private void Update()
    {
        timerDamage += Time.deltaTime;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if(timerDamage >= intervalDamage)
        {

            if (collision.CompareTag("enemy"))
            {
                EnemyScript enemy = collision.GetComponent<EnemyScript>();

                    enemy.nextDamageTime += Time.deltaTime;

                    if (enemy.nextDamageTime >= intervalDamage)
                    {
                        enemy.EnemyHp1 -= zoneDamage;
                    enemy.TextDamage((int)zoneDamage);
                        enemy.nextDamageTime = 0f;
                    }
            }

        }

        
    }

    public void Upgrade()
    {
        switch (NiveauAme)
        {
            case 1:
                transform.localScale *= 1.8f;
                zoneDamage += 1;

                break;

            case 2:
                transform.localScale *= 1.5f;
                zoneDamage += 1;
                break;
        }

    }
}
