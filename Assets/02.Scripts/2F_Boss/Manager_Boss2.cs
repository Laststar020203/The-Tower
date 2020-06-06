using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Boss2 : MonoBehaviour {

    public GameObject trap;
    public static Manager_Boss2 instance;
    public Transform playerTr;

    bool isStop = false;

    //z 40 -40 x 30 -30

    public int trapCount = 3;
    
    public int NowTrapCount = 0;

    int playerHealth = 3;
    int bossHealth = 3;

	// Use this for initialization
	void Start () {

        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        StartCoroutine(CreateTrap());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HitPlayer()
    {
        playerHealth--;
        Debug.Log("playerhit!");
        if (playerHealth < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("playerDead");
        }
    }
    public void HitBoss()
    {
        bossHealth--;
        Debug.Log("enemyhit");
        if (bossHealth < 0)
        {
            GameSystem.system.TurnScene();
            Debug.Log("BossDead");
        }

    }

    IEnumerator CreateTrap()
    {
        while (!isStop)
        {
            if ((NowTrapCount < trapCount))
            {
                for (int i = 1; i <= trapCount - NowTrapCount; i++)
                {

                    Vector3 pos = new Vector3(Random.Range(-30, 30), 0, Random.Range(-40, 40));
                    Instantiate(trap, pos, Quaternion.identity);
                    NowTrapCount++;
                }
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
