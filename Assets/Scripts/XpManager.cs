using System.Collections.Generic;
using UnityEngine;

public class XpManager : MonoBehaviour
{
    public float Niveau;

    public float XpNecessaire;

    public float XpObtenu;

    private int NombreChoix = 3;

    [SerializeField] private GameObject ChoixFeunetre;

    [SerializeField] private GameObject Attack;

    [SerializeField] private GameObject Curseur;

    [SerializeField] private CarreChoix Choix1;

    [SerializeField] private CarreChoix Choix2;





    [SerializeField] private slash Slash;

    [SerializeField] private ZoneDegat Zone;



    void Start()
    {
        Niveau = 1;

        XpNecessaire = Niveau * 5;
    }


    void Update()
    {

        if (!ChoixFeunetre.activeSelf)
        {
            IsLvlAtteint();
        }
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



            FaitUnChoix();


        }
    }

    private void FaitUnChoix()
    {
        List<int> AmeDispo = new List<int>();

        for (int i = 1; i <= NombreChoix; i++)
        {
            if (AmeLvl(i))
            {
                AmeDispo.Add(i);
            }
        }

        if (AmeDispo.Count == 0)
        {
            ChoixFeunetre.SetActive(false);
            Curseur.SetActive(true);
            Attack.SetActive(true);
            Choix2.gameObject.SetActive(true);
            Time.timeScale = 1f;
            return;
        }


        int indexAleatoire1 = Random.Range(0, AmeDispo.Count);
        Choix1.AmeliorationDonne = AmeDispo[indexAleatoire1];
        AmeDispo.RemoveAt(indexAleatoire1);

        if (AmeDispo.Count > 0)
        {
            int indexAleatoire2 = Random.Range(0, AmeDispo.Count);
            Choix2.AmeliorationDonne = AmeDispo[indexAleatoire2];
        }
        else
        {
            Choix2.gameObject.SetActive(false);
        }

        Debug.Log("Choix 1: " + Choix1.AmeliorationDonne + " | Choix 2: " + Choix2.AmeliorationDonne);


        Choix1.Affichage(Choix1.AmeliorationDonne);
        Choix2.Affichage(Choix2.AmeliorationDonne);
    }

    private bool AmeLvl(int Ame)
    {
        switch (Ame)
        {
            case 1:
                return Slash.NiveauAme < 3;

            case 2:
                return Zone.NiveauAme < 3;

            default:
                return true;
        }
    }





    public void GiveAme(int AmeDonne)
    {
        switch (AmeDonne)
        {
            case 1:
                Slash.Upgrade();
                break;


            case 2:
                if(Zone.NiveauAme == 0)
                {
                    GameObject ZoneGo = Zone.gameObject;
                    ZoneGo.SetActive(true);
                }

                Zone.Upgrade();
                break;
        }

        
    }
}
