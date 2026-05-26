using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class ContiPause : MonoBehaviour
{
    [SerializeField] private int ElBouton;

    [SerializeField] private AudioSource Over;

    [SerializeField] private GameObject MenuPause;

    [SerializeField] private AudioSource JaiRienDisMb;

    [SerializeField] private AudioSource ByebyeLaTeam;

    private bool AClick = false;

    private float timer = 0f;

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
                break;

            case 2:
                ByebyeLaTeam.Play();
                Time.timeScale = 1f;
                SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
                break;
        }
    }

}
