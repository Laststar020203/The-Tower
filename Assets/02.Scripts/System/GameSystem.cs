using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSystem : MonoBehaviour {
    [HideInInspector]
    public SceneTurnManager sceneTurnManager;
    [HideInInspector]
    public InfoManager InfoManager;

    public static GameSystem system;


    

    


  

    // Use this for initialization
    void Start () {
        if (system == null)
            system = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this.gameObject);

        sceneTurnManager = GetComponentInChildren<SceneTurnManager>();
        // InfoManager = GetComponentInChildren<InfoManager>();

        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
            TurnScene();
	}

    public void TurnScene()
    {
        int idx = SceneManager.GetActiveScene().buildIndex + 1;
        sceneTurnManager.AddScene(idx);

        
    }

    public void LoadGame()
    {
		/*
		InfoManager.info = InfoManager.Load();
        SceneManager.LoadScene(InfoManager.info.sceneIndex);
		*/

		SceneManager.LoadScene(PlayerPrefs.GetInt("SceneIndex"));


	}

    public void SaveGame()
    {

		
        //InfoManager.Create();
        TurnScene();
		
    
		PlayerPrefs.SetInt("SceneIndex" , SceneManager.GetActiveScene().buildIndex);
	
	}
    
}
