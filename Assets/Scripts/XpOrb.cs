using UnityEngine;

public class XpOrb : MonoBehaviour
{
    private GameObject Player;

    public float detectionRadius = 2f;

    private bool VaVersJoueur = false;

    [SerializeField] private Rigidbody2D rbOrb;

    private XpManager XpManager;


    private void Start()
    {
        GameObject joueurObject = GameObject.FindWithTag("joueur");

        Player = joueurObject;

        XpManager = FindFirstObjectByType<XpManager>();
    }

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
