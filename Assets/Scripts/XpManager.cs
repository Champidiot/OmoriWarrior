using UnityEngine;

public class XpManager : MonoBehaviour
{
    public float Niveau;

    public float XpNecessaire;

    public float XpObtenu;

    private int NombreChoix = 5;

    [SerializeField] private GameObject ChoixFeunetre;

    [SerializeField] private GameObject Attack;

    [SerializeField] private GameObject Curseur;

    [SerializeField] private CarreChoix Choix1;

    [SerializeField] private CarreChoix Choix2;



    void Start()
    {
        Niveau = 1;

        XpNecessaire = Niveau * 5;
    }


    void Update()
    {
        IsLvlAtteint();

        Debug.Log(XpObtenu + "/" + XpNecessaire);
    }

    private void IsLvlAtteint()
    {
        if(XpObtenu>= XpNecessaire)
        {
            Niveau += 1;

            XpObtenu -= XpNecessaire;

            XpNecessaire = Niveau * 5;

            Time.timeScale = 0f;

            ChoixFeunetre.SetActive(true);

            Curseur.SetActive(false);

            Attack.SetActive(false);

            Choix1.AmeliorationDonne = Random.Range(1, NombreChoix+1);

            while(Choix2.AmeliorationDonne == 0 || Choix2.AmeliorationDonne == Choix1.AmeliorationDonne)
            {
                Choix2.AmeliorationDonne = Random.Range(1, NombreChoix+1);
            }




        }
    }
}
