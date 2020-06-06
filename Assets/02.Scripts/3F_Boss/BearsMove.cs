using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearsMove : MonoBehaviour
{
    #region Var
    [SerializeField]
    private Vector3 standardPos;
    private Vector3 markPos;
    
    [SerializeField]
    private Color color;

    [SerializeField]
    private float speed = 1.0f;
    private const float basicCircleRand = 1.5f;

    [SerializeField]
    private int waitingTime;

    private bool isCharge = false;
    #endregion

    private void Start()
    {
        Gizmos.color = color;
        SetMarkPosition();
        StartCoroutine(AttackDelay());
    }
    private void ChargeAttack(){
        Vector3 downPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -6.0f);
        gameObject.transform.forward = Vector3.back;
        gameObject.transform.position
                  = Vector3.MoveTowards(gameObject.transform.position,downPos, speed * 3.0f * Time.deltaTime);
    }

    private void SetMarkPosition(){
        float rRand = Random.Range(0.0f,basicCircleRand);
        float rAngle = Random.Range(0.0f,360.0f);

        float xPos = (rRand * Mathf.Cos(rAngle)) + standardPos.x;
        float zPos = (rRand * Mathf.Sin(rAngle)) + standardPos.z;

        markPos = new Vector3(xPos, gameObject.transform.position.y, zPos);
        print(markPos);
    }

    private void BasicMove(){
        Vector3 moveAngle = (markPos - gameObject.transform.position).normalized;
        gameObject.transform.forward = moveAngle;
        gameObject.transform.position 
                  = Vector3.MoveTowards(gameObject.transform.position, markPos, speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if(gameObject.transform.position == markPos){
            SetMarkPosition();
        }

        if (isCharge == true)
        {
            ChargeAttack();
            if(gameObject.transform.position.z <= -6.0f){
                gameObject.transform.position = markPos;
                print("도착");
                StartCoroutine(AttackDelay());
                isCharge = false;
            }
        }
        else
        {
            BasicMove();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(standardPos, basicCircleRand);
        Gizmos.DrawSphere(markPos,0.1f);
    }

    private IEnumerator AttackDelay(){
        yield return new WaitForSeconds(Random.Range(2,waitingTime));
        isCharge = true;
    }

}
