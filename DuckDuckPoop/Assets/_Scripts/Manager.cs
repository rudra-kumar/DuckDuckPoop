using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public bool gameOver = false;
    public Text msg;
    public GameObject canvas;

    string win = "You Win";
    string lose = "You Lose";
    string Win = "Duck for dinner tonight!";
    string Lose = "You Dead!";


    [SerializeField] AudioClip bg;

    private void Start()
    {

        //AudioSource audio = gameObject.GetComponent<AudioSource>();
        //audio.Play();
        GameObject textCanvas = Instantiate(canvas, canvas.transform.position, canvas.transform.rotation);
        msg = GameObject.Find("MSG").GetComponent<Text>();
        msg.gameObject.SetActive(false);


        
    }

    public void HunterWin()
    {
        gameOver = true;
        msg.gameObject.SetActive(true);
        //duckUI.gameObject.SetActive(true);
        //hunterUI.gameObject.SetActive(true);
        msg.text = Win;
    }

    public void DuckWin()
    {
        gameOver = true;
        msg.gameObject.SetActive(true);
        //duckUI.gameObject.SetActive(true);
        //hunterUI.gameObject.SetActive(true);
        msg.text = Lose;
    }
	
}
