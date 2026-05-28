using UnityEngine;


public class EnemyScript : MonoBehaviour
{
    public Transform player;
    public float speed;

    public float EnemyHp1;


    private float nextHeroDamageTime = 0f;
    public float damageHeroCooldown = 0.12f;
    public float damageToHero;

    public float nextDamageTime = 0f;


    [SerializeField] private Rigidbody2D rbEnemy;

    private HPtext HPtext;

    private HPbar HPbar;

    [SerializeField] private SpriteRenderer spriteRend;

    public GameObject XpPrefab;

    public GameObject Food;

    private void Start()
    {
        GameObject joueurObject = GameObject.FindWithTag("joueur");
        player = joueurObject.transform;

        HPtext = FindFirstObjectByType<HPtext>();
        HPbar = FindFirstObjectByType<HPbar>();
    }

    void Update()
    {

        IsDead();

        nextDamageTime += Time.deltaTime;

    }

    private void FixedUpdate()
    {
        VaVersPlayer();
        Flip();
    }


    private void VaVersPlayer()
    {

        Vector2 direction = (player.position - transform.position);

        direction.Normalize();

        rbEnemy.linearVelocity = direction * speed;

    }

    private void Flip()
    {
        if(rbEnemy.linearVelocityX > 0)
        {
            spriteRend.flipX = true;
        }

        else
        {
            spriteRend.flipX = false;
        }
    }

    private void IsDead()
    {
        if (EnemyHp1 <= 0)
        {

            var enemy = Instantiate(XpPrefab);
            enemy.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            enemy.SetActive(true);

            int IsFood = Random.Range(1, 30);
            if (IsFood == 5)
            {
                var food = Instantiate(Food);
                food.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-1);
                food.SetActive(true);
            }

            Destroy(gameObject);
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("joueur") && !collision.gameObject.CompareTag("attack") && Time.time >= nextHeroDamageTime)
        {
            PlayerScript playerScri = collision.gameObject.GetComponent<PlayerScript>();

            playerScri.HeroHp -= damageToHero;

            HPtext.HPmiseAjour();

            HPbar.HPbarMiseAjour();

            nextHeroDamageTime = Time.time + damageHeroCooldown;
        }


    }

}