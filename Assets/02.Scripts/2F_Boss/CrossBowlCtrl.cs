using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBowlCtrl : MonoBehaviour {

    bool isStop = false;

    public float auroraAttackCoolTime = 4.0f;
    public GameObject aurora;

    Transform tr;

    private void Start()
    {
        tr = GetComponent<Transform>();
        StartCoroutine(AuroraAttack());
    }

    IEnumerator AuroraAttack()
    {
        while (!isStop)
        {
            yield return new WaitForSeconds(auroraAttackCoolTime);
           // Vector3 distance = playerTr.position - tr.position;
           // distance.y = 0;

            GameObject _aurora = Instantiate(aurora, tr.position, Quaternion.LookRotation(tr.forward));
            Destroy(_aurora, 10f);
        }
    }
}
