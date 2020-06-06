using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FollowCameraCtrl : MonoBehaviour {


    public Transform target;
    public float moveDamping = 15.0f;
    public float rotateDamping = 10.0f;
    public float distance = 5.0f;
    public float height = 4.0f;
    public float targetOffset = 2.0f;

    private Transform tr;

    public bool useRotate = false;
    public bool constract = false;
    public bool justFollow = false;

    public float constractXMin = 0;
    public float constractZMin = 0;
    public float constractXMax = 0;
    public float constractZMax = 0;



    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();
	}
    private void LateUpdate()
    {

        var Campos = target.position - (target.forward * distance) + (target.up * height);

        if (justFollow)
          Campos = target.position - (Vector3.right * distance) + (Vector3.up * height);
        


        if (constract)
        {

            tr.position = Vector3.Slerp(tr.position, new Vector3(Mathf.Clamp(Campos.x, constractXMin, constractXMax), Campos.y,
                Mathf.Clamp(Campos.z, constractZMin, constractZMax)), Time.deltaTime * moveDamping);
        }
       
            tr.position = Vector3.Slerp(tr.position, Campos, Time.deltaTime * moveDamping);
        


        if (useRotate)
        {
            tr.rotation = Quaternion.Slerp(tr.rotation, target.rotation, Time.deltaTime * rotateDamping);
            tr.LookAt(target.position + (target.up * targetOffset));
            


        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
[CustomEditor(typeof(FollowCameraCtrl))]
public class FollowCameraCtrlEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.HelpBox("constract는 카메라 이동에 제한을 걸어놓습니다 \n\n" +
                                "UseRotae는 taget에 회전/위치 따라 카메라의 위치가 스무스하게 변합니다 \n\n" +
                                "justFollow는 taget에 위치에 따라 카메라의 위치가 스무스하게 변합니다.", MessageType.Info);
    }

}

