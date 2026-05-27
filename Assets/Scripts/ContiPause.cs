using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ContiPause : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private int ElBouton;

    [SerializeField] private AudioSource Over;

    [SerializeField] private GameObject MenuPause;

    [SerializeField] private AudioSource JaiRienDisMb;

    [SerializeField] private AudioSource ByebyeLaTeam;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Over.Play();

        redhandpause.QuelBouton = ElBouton;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        switch (ElBouton)
        {
            case 1:
                JaiRienDisMb.Play();
                MenuPause.SetActive(false);
                Time.timeScale = 1f;
                redhandpause.QuelBouton = 0;
                break;

            case 2:
                ByebyeLaTeam.Play();
                Time.timeScale = 1f;
                SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
                break;
        }
    }

}
