using UnityEngine;

public class slash : MonoBehaviour
{
    public Transform player;
    public float radius = 2.0f;
    private float timer;
    public float dureeActif;
    public float dureeInactif;
    private etat etatAttack = etat.inactif;

    public float slashDamage = 5f;

    public int NiveauAme = 1;


    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private BoxCollider2D boxCol;

    private void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 direction = (mousePos - player.position).normalized;
        transform.position = player.position + direction * radius;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);


        switch (etatAttack)
        {
            case etat.actif:
                timer += Time.deltaTime;
                if (timer > dureeActif)
                {
                    sprite.enabled = false;
                    boxCol.enabled = false;
                    etatAttack = etat.inactif;
                    timer = 0f;
                }
                break;

            case etat.inactif:
                timer += Time.deltaTime;
                if (timer > dureeInactif)
                {
                    sprite.enabled = true;
                    boxCol.enabled = true;
                    etatAttack = etat.actif;
                    timer = 0f;
                }
                break;
        }


    }


    enum etat
    {

        actif,
        inactif

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("enemy"))
        {
            EnemyScript enemy = collision.GetComponent<EnemyScript>();


            if (enemy.nextDamageTime >= 0.13f)
            {
                enemy.EnemyHp1 -= slashDamage;

                enemy.nextDamageTime = 0f;
            }

        }
    }

    public void Upgrade()
    {
        switch (NiveauAme)
        {
            case 1:
                transform.localScale *= 1.5f;
                slashDamage += 5;

                break;

            case 2:
                transform.localScale *= 1.3f;
                slashDamage += 10;
                break;
        }
    }

}
