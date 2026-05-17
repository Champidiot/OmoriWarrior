using UnityEngine;

public class XpOrb : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    public float detectionRadius = 2f;

    private bool VaVersJoueur = false;

    [SerializeField] private Rigidbody2D rbOrb;

    [SerializeField] private XpManager XpManager;




    void Update()
    {
        if (VaVersJoueur == false) 
        {
            float distance = Vector2.Distance(transform.position, Player.transform.position);

            if (distance <= detectionRadius)
            {
                VaVersJoueur = true;
            }
        }

        else
        {
            VaVersPlayer();
        }



    }

    private void VaVersPlayer()
    {

        Vector2 direction = (Player.transform.position - transform.position);

        direction.Normalize();

        rbOrb.linearVelocity = direction * 10f;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("joueur"))
        {
            XpManager.XpObtenu += 1f;

            Destroy(gameObject);
        }
    }
}
