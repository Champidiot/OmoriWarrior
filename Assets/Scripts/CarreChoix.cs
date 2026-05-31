using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarreChoix : MonoBehaviour
{

    public int AmeliorationDonne = 0;

    [SerializeField] private GameObject ChoixFeunetre;

    [SerializeField] private GameObject Curseur;

    [SerializeField] private GameObject Attack;

    [SerializeField] XpManager XpManager;




    [SerializeField] private Image Image;

    [SerializeField] private TextMeshProUGUI Titre;

    [SerializeField] private TextMeshProUGUI Desc;

    [SerializeField] private TextMeshProUGUI Comm;





    [SerializeField] private slash slash;

    [SerializeField] private ZoneDegat zone;

    [SerializeField] private WaterMelon water;

    [SerializeField] private balleRebond balle;

    [SerializeField] private Disque disque;


    [SerializeField] private Sprite couteau;

    [SerializeField] private Sprite melon;

    [SerializeField] private Sprite volley;

    [SerializeField] private Sprite hand;

    [SerializeField] private Sprite ecouteur;

    [SerializeField] private Sprite life;



    private void OnMouseDown()
    {

        ChoixFeunetre.SetActive(false);

        Curseur.SetActive(true);

        Attack.SetActive(true);

        Time.timeScale = 1f;

        XpManager.GiveAme(AmeliorationDonne);

        if(disque.NiveauAme == 3)
        {
            disque.ChangeMusic();
        }

    }

    public void Affichage(int Choix)
    {
        switch (Choix)
        {
            case 1:
                Titre.text = "Couteau Lvl " + slash.NiveauAme + " -> Lvl " + (slash.NiveauAme+1);
                Desc.text = "Attaque de base. Frappe devant soit";
                Comm.text = "“Attention, ça coupe !”";
                Image.sprite = couteau;
                break;

            case 2:
                Titre.text = "Main Rouge Lvl " + zone.NiveauAme + " -> Lvl " + (zone.NiveauAme + 1);
                Desc.text = "Cree une zone autour de sois qui attaque les ennemis en continu.";
                Comm.text = "“Mais elles viennent d'où ces mains ?”";
                Image.sprite = hand;
                break;

            case 3:
                Titre.text = "Pasteque Lvl " + water.NiveauAme + " -> Lvl " + (water.NiveauAme + 1);
                Desc.text = "Une pasteque qui frappe les ennemis sur qui elle passe";
                Comm.text = "“Miam”";
                Image.sprite = melon;
                break;

            case 4:
                Titre.text = "Balle Lvl " + balle.NiveauAme + " -> Lvl " + (balle.NiveauAme + 1);
                Desc.text = "Une balle envoyé à toute vitesse";
                Comm.text = "“Attention à la tête”";
                Image.sprite = volley;
                break;

            case 5:
                Titre.text = "Casque Inutile";
                Desc.text = "Change la musique en gagnant un niveau";
                Comm.text = "“Ne sert à rien. La musique est bonne.”";
                Image.sprite = ecouteur;
                break;






            case 100:
                Titre.text = "Vie Supplementaire";
                Desc.text = "Augmente la vie maximum";
                Comm.text = "“...”";
                Image.sprite = life;

                break;
        }
    }

}
