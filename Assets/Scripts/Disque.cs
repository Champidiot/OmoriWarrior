using UnityEngine;

public class Disque : MonoBehaviour
{
    public int NiveauAme = 0;

    [SerializeField] private AudioSource Music1;

    [SerializeField] private AudioSource Music2;

    [SerializeField] private AudioSource Music3;

    [SerializeField] private AudioSource Music4;

    [SerializeField] private AudioSource Music5;

    [SerializeField] private AudioSource Music6;

    [SerializeField] private AudioSource Music7;

    [SerializeField] private AudioSource Music8;

    [SerializeField] private AudioSource Music9;

    [SerializeField] private AudioSource Music10;


    [SerializeField] private AudioSource MusicJoue;

    private float PasDeuxFoisLaMeme = 0;

    public void ChangeMusic()
    {
        
        int musicChoisie = Random.Range(1, 11);

        while (musicChoisie == PasDeuxFoisLaMeme)
        {
            musicChoisie = Random.Range(0, 11);
        }

        switch (musicChoisie)
        {
            case 1:
                MusicJoue.Stop();
                Music1.Play();
                MusicJoue = Music1;
                PasDeuxFoisLaMeme = 1;
                break;

            case 2:
                MusicJoue.Stop();
                Music2.Play();
                MusicJoue = Music2;
                PasDeuxFoisLaMeme = 2;
                break;

            case 3:
                MusicJoue.Stop();
                Music3.Play();
                MusicJoue = Music3;
                PasDeuxFoisLaMeme = 3;
                break;

            case 4:
                MusicJoue.Stop();
                Music4.Play();
                MusicJoue = Music4;
                PasDeuxFoisLaMeme = 4;
                break;

            case 5:
                MusicJoue.Stop();
                Music5.Play();
                MusicJoue = Music5;
                PasDeuxFoisLaMeme = 5;
                break;

            case 6:
                MusicJoue.Stop();
                Music6.Play();
                MusicJoue = Music6;
                PasDeuxFoisLaMeme = 6;
                break;

            case 7:
                MusicJoue.Stop();
                Music7.Play();
                MusicJoue = Music7;
                PasDeuxFoisLaMeme = 7;
                break;

            case 8:
                MusicJoue.Stop();
                Music8.Play();
                MusicJoue = Music8;
                PasDeuxFoisLaMeme = 8;
                break;

            case 9:
                MusicJoue.Stop();
                Music9.Play();
                MusicJoue = Music9;
                PasDeuxFoisLaMeme = 9;
                break;

            case 10:
                MusicJoue.Stop();
                Music10.Play();
                MusicJoue = Music10;
                PasDeuxFoisLaMeme = 10;
                break;
        }
    }

}
