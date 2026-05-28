using TMPro;
using UnityEngine;

public class CarreChoix : MonoBehaviour
{

    public int AmeliorationDonne = 0;

    [SerializeField] private GameObject ChoixFeunetre;

    [SerializeField] private GameObject Curseur;

    [SerializeField] private GameObject Attack;

    [SerializeField] XpManager XpManager;




    [SerializeField] private SpriteRenderer Image;

    [SerializeField] private TextMeshProUGUI Titre;

    [SerializeField] private TextMeshProUGUI Desc;

    [SerializeField] private TextMeshProUGUI Comm;





    [SerializeField] private slash slash;

    [SerializeField] private ZoneDegat zone;



    private void OnMouseDown()
    {

        ChoixFeunetre.SetActive(false);

        Curseur.SetActive(true);

        Attack.SetActive(true);

        Time.timeScale = 1f;

        Debug.Log(AmeliorationDonne);

        XpManager.GiveAme(AmeliorationDonne);

    }

    public void Affichage(int Choix)
    {
        switch (Choix)
        {
            case 1:
                Titre.text = "Couteau Lvl" + slash.NiveauAme + " -> Lvl" + (slash.NiveauAme+1);
                Desc.text = "Attaque de base. Frappe devant soit";
                Comm.text = "“Attention, ça coupe !”";
                break;

            case 2:
                Titre.text = "Main Rouge Lvl" + zone.NiveauAme + " -> Lvl" + (zone.NiveauAme + 1);
                Desc.text = "Crée une zone autour de sois qui attaque les ennemis en continu.";
                Comm.text = "“Mais elles viennent d'où ces mains ?”";
                break;
        }
    }

}
