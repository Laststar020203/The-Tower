using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Linq;
public class RoofTopManager : MonoBehaviour {

    #region Var
    [SerializeField]
    private GameObject[] Lightning = new GameObject[2];
    [SerializeField]
    private Text TimeText;
    private float restTime = 600.0f;
    private float spendTime = 1.0f;
    [SerializeField]
    private GameObject[] Gears = new GameObject[4];
    #endregion

    // Use this for initialization
    void Start () {
        StartCoroutine(Time());
        StartCoroutine(CreateObstacle_One());
	}
	
	// Update is called once per frame
    string GetNowTime()
    {
        if (restTime > 0.0f)
            return ((int)(restTime / 60)).ToString() + " : " + ((int)(restTime % 60)).ToString();
        else
            return "GameOver";
    }

    int GetOnGear(){
        var hold_Gear_ = from piece in Gears
                         where piece.GetComponent<MeshRenderer>().material.color == Color.blue
                         select piece;
        return hold_Gear_.Count();
    }

    public float SpendTime{
        get { return spendTime; }
        set { spendTime = value; }
    }

    public void ClearConfig(){   
    }

    IEnumerator Time(){
        restTime -= spendTime;
        TimeText.text = GetNowTime();
        yield return new WaitForSeconds(1);
        StartCoroutine(Time());
    }

    IEnumerator CreateObstacle_One() {
        float circleRand = 23f;
        float rRand = Random.Range(0.0f, circleRand);
        float rAngle = Random.Range(0.0f,360.0f);

        float xPos = rRand * Mathf.Cos(rAngle);
        float zPos = rRand * Mathf.Sin(rAngle);

        int lightningNumber = 0;

        if (GetOnGear() > 2)
            lightningNumber = Random.Range(0, 2);

        Instantiate(Lightning[lightningNumber],new Vector3(xPos, 0, zPos),Quaternion.identity);
        int waitTime = Random.Range(0,4);

        yield return new WaitForSeconds(waitTime);
        StartCoroutine(CreateObstacle_One());

    }


}
