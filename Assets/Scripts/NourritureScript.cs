using UnityEngine;

public class NourritureScript : MonoBehaviour
{
    private float timer;

    private bool Recup = false;

    [SerializeField] private AudioSource Miam;

    [SerializeField] private PlayerScript Player;

    [SerializeField] private SpriteRenderer sprRe;

    [SerializeField] private HPbar Hpbar;

    [SerializeField] private HPtext hptext;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("joueur"))
        {
            if (!Recup)
            {
                Miam.Play();
                Recup = true;
                Player.HeroHp += Player.HeroMaxHp / 3;
                sprRe.enabled = false;
                Hpbar.HPbarMiseAjour();
                hptext.HPmiseAjour();
            }            
        }
    }

    private void Update()
    {
        if (Recup)
        {
            timer += Time.deltaTime;

            if (timer >= 0.3)
            {
                Destroy(gameObject);
            }
        }
    }
}
