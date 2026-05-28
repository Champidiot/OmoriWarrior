using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Update()
    {
        text.text = TempsMoinsMoche(); 
    }

    private string TempsMoinsMoche()
    {
        int tempsTotalSecondes = Mathf.FloorToInt(EnemySpawnerManager.TimerJeu);

        int minutes = tempsTotalSecondes / 60;
        int secondes = tempsTotalSecondes % 60;

        return minutes.ToString() + ":" + secondes.ToString("00");
    }
}
