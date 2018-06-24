using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public bool gameOver = false;
    public Text hunterUI;
    public Text duckUI;

    string win = "You Win";
    string lose = "You Lose";

    [SerializeField] AudioClip bg;

    private void Start()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        //audio.Play();
        
    }

    public void HunterWin()
    {
        gameOver = true;
        duckUI.gameObject.SetActive(true);
        hunterUI.gameObject.SetActive(true);
        hunterUI.text = win;
        duckUI.text = lose;
    }

    public void DuckWin()
    {
        gameOver = true;
        duckUI.gameObject.SetActive(true);
        hunterUI.gameObject.SetActive(true);
        hunterUI.text = lose;
        duckUI.text = win;
    }
	
}
