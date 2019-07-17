using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageScript : MonoBehaviour {
    public void InitGame()
    {
        SceneManager.LoadScene("first phase");
    }
    public void HelpGame()
    {
        SceneManager.LoadScene("help");
    }
    public void Option()
    {
        SceneManager.LoadScene("Option_game");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
