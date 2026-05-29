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

    [SerializeField] private CarreChoix Choix3;





    [SerializeField] private slash Slash;

    [SerializeField] private ZoneDegat Zone;

    [SerializeField] private WaterMelon watermelon;

    [SerializeField] private PlayerScript Ps;

    [SerializeField] private HPbar hpba;

    [SerializeField] private HPtext hpte;



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

        Debug.Log(Zone.NiveauAme);
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


        int AmeDonne1 = Random.Range(0, AmeDispo.Count);
        Choix1.AmeliorationDonne = AmeDispo[AmeDonne1];
        AmeDispo.RemoveAt(AmeDonne1);

        if (AmeDispo.Count > 0)
        {
            int AmeDonne2 = Random.Range(0, AmeDispo.Count);
            Choix2.AmeliorationDonne = AmeDispo[AmeDonne2];
            AmeDispo.RemoveAt(AmeDonne2);
        }
        else
        {
            Choix2.AmeliorationDonne = 100;
        }


        if (AmeDispo.Count > 0)
        {
            int AmeDonne3 = Random.Range(0, AmeDispo.Count);
            Choix3.AmeliorationDonne = AmeDispo[AmeDonne3];
        }
        else
        {
            Choix3.AmeliorationDonne = 100;
        }

        Debug.Log("Choix 1: " + Choix1.AmeliorationDonne + " | Choix 2: " + Choix2.AmeliorationDonne + " | Choix 3: " + Choix3.AmeliorationDonne);


        Choix1.Affichage(Choix1.AmeliorationDonne);
        Choix2.Affichage(Choix2.AmeliorationDonne);
        Choix3.Affichage(Choix3.AmeliorationDonne);
    }

    private bool AmeLvl(int Ame)
    {
        switch (Ame)
        {
            case 1:
                return Slash.NiveauAme < 3;

            case 2:
                return Zone.NiveauAme < 3;

            case 3:
                return watermelon.NiveauAme < 3;


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
                Slash.NiveauAme += 1;
                break;


            case 2:
                if (Zone.NiveauAme == 0)
                {
                    GameObject ZoneGo = Zone.gameObject;
                    ZoneGo.SetActive(true);
                }

                else 
                { 
                    Zone.Upgrade(); 
                }
                Zone.NiveauAme += 1;
                break;



            case 3:

                if (watermelon.NiveauAme == 0)
                {
                    watermelon.NiveauAme = 1;
                    watermelon.gameObject.SetActive(true);
                }

                else
                {
                    watermelon.NiveauAme += 1; 


                    GameObject WaterGo = watermelon.gameObject;
                    GameObject newWaterMelon = Instantiate(WaterGo);
                    newWaterMelon.SetActive(true);


                    GameObject[] toutesLesPastèques = GameObject.FindGameObjectsWithTag("WaterMelon");
                    foreach (GameObject go in toutesLesPastèques)
                    {
                        WaterMelon scriptMelon = go.GetComponent<WaterMelon>();

                        scriptMelon.NiveauAme = watermelon.NiveauAme;
                        scriptMelon.Upgrade();

                    }
                }
                break;











            case 100:

                Ps.HeroMaxHp += 5;
                Ps.HeroHp += 5;

                hpba.HPbarMiseAjour();
                hpte.HPmiseAjour();

                break;

        }

        
    }
}
