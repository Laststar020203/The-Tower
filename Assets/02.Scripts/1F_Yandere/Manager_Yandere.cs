using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Yandere : MonoBehaviour {

    public Transform map;
    public Transform yandere;
    public Transform changeObj;
    int yandereLife = 3;
    int playerLife = 1;
    int count = 0;
    public Transform player;

   

    public static Manager_Yandere instance;

    public YandareCtrl yandareCtrl;
    [HideInInspector]
    public bool isdamping = false;

    public Transform target;


    private void Update()
    {
        if (player.position.y < -200)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
    // Use this for initialization
    void Start () {

		PlayerPrefs.SetInt("SceneIndex" , SceneManager.GetActiveScene().buildIndex);

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


       

    }
	
	
    public void FallDamage()
    {
        if (this.CompareTag("MONSTER"))
            --yandereLife;
        else if(this.CompareTag("PLAYER"))
            --playerLife;
    }


    public void PlayerDie()
    {
        
    }

    public void YandereDamage()
    {

        if (yandereLife == 2)
            GameSystem.system.TurnScene();
        /*
        if (yandereLife <= 0)
        {
            Destroy(yandere.gameObject);
            SceneManager.LoadScene(5 , LoadSceneMode.Additive); 
        }
        */
        yandere.transform.position = new Vector3(-38.4f, 16, 0);
        yandereLife--;
        Debug.Log("YandererDamage");
    }

   

}
