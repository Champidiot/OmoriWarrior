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

    [SerializeField] private WaterMelon water;



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
                Titre.text = "Couteau Lvl " + slash.NiveauAme + " -> Lvl " + (slash.NiveauAme+1);
                Desc.text = "Attaque de base. Frappe devant soit";
                Comm.text = "“Attention, ça coupe !”";
                break;

            case 2:
                Titre.text = "Main Rouge Lvl " + zone.NiveauAme + " -> Lvl " + (zone.NiveauAme + 1);
                Desc.text = "Cree une zone autour de sois qui attaque les ennemis en continu.";
                Comm.text = "“Mais elles viennent d'où ces mains ?”";
                break;

            case 3:
                Titre.text = "Pasteque Lvl " + water.NiveauAme + " -> Lvl " + (water.NiveauAme + 1);
                Desc.text = "Une pasteque qui frappe les ennemis sur qui elle passe";
                Comm.text = "“Miam”";
                break;






            case 100:
                Titre.text = "Vie Supplementaire";
                Desc.text = "Augmente la vie maximum";
                Comm.text = "“...”";
                break;
        }
    }

}
