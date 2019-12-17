using UnityEngine;
using System.Collections;
using AssemblyCSharp;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name： 第三视角相机
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 
* 功能描述：     ...............................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion


public class CameraThird : MonoBehaviour
{
    float x, y;
    Camera camer;
    private Transform cameraTrans;
    private Transform tragetTrans;
    private float NStartSee;
    public Transform mastTrans;
    public float minSee = -30;
    public float maxSee = 30;
    public float speedMouse = 10;
    public float speedCamera = 5;
    public float distance_height = 28;
    public float distance_bcak = 55;
    public static int nUseModel;

    private void Awake()
    {
        camer = Camera.main;
        MyDebug.Log("=================当前的视角是：" + camer);
    }

    void Start()
    {
        nUseModel = 0;
        NStartSee = 60;
        cameraTrans = camer.transform;
        tragetTrans = mastTrans;

        ComputeCameraRotate();
        ComputeCameraPosition();
    }

    //相机跟随主角旋转
    void ComputeCameraRotate()
    {
        cameraTrans.eulerAngles = new Vector3(cameraTrans.eulerAngles.x, tragetTrans.eulerAngles.y, cameraTrans.eulerAngles.z);
    }
    
    //计算相机位置
    void ComputeCameraPosition()
    {
        float angle = cameraTrans.eulerAngles.y;
        float detlaX = distance_bcak * Mathf.Sin(angle * Mathf.PI / 180);
        float detlaZ = distance_bcak * Mathf.Cos(angle * Mathf.PI / 180);
        cameraTrans.position = new Vector3(tragetTrans.position.x - detlaX,
        tragetTrans.position.y + distance_height, tragetTrans.position.z - detlaZ);

    }

    //计算相机视距
    void ComputeViewDistance()
    {
        NStartSee += Input.GetAxis("Mouse ScrollWheel") * 10;
        NStartSee = NStartSee > 80 ? 80 : NStartSee < 30 ? 30 : NStartSee;
        camer.fieldOfView = NStartSee;
    }

    void RoteOnlyRightKey()
    {
        if (Input.GetMouseButton(1) && ManagerUI.instance.isPOP == false)
        {
            x += Input.GetAxis("Mouse X") * speedMouse;
            y -= Input.GetAxis("Mouse Y") * speedMouse;
            y = Mathf.Clamp(y, minSee, maxSee);
            Quaternion ration = Quaternion.Euler(y, x, 0);
            cameraTrans.rotation = Quaternion.Slerp(cameraTrans.rotation,
            ration, Time.deltaTime * speedCamera);
        }
        ComputeCameraPosition();
        ComputeViewDistance();
    }

    void RoteCamera()
    {
        if (Input.GetMouseButton(1) && ManagerUI.instance.isPOP == false)
        {
            x += Input.GetAxis("Mouse X") * speedMouse;
            y -= Input.GetAxis("Mouse Y") * speedMouse;
            y = Mathf.Clamp(y, minSee, maxSee);
            Quaternion ration = Quaternion.Euler(y, x, 0);

            //保持一直绕圈
            //Quaternion camRot = cameraTrans.rotation;
            //camRot = Quaternion.Euler(camRot.eulerAngles.x + y , camRot.eulerAngles.y + x , 0);

            cameraTrans.rotation = Quaternion.Slerp(cameraTrans.rotation, ration,
            Time.deltaTime * speedCamera);
        }
        else if (Input.GetMouseButton(0) && ManagerUI.instance.isPOP == false)
        {
            x += Input.GetAxis("Mouse X") * speedMouse;
            Quaternion ration = Quaternion.Euler(0, x, 0);
            cameraTrans.rotation = Quaternion.Slerp(cameraTrans.rotation, ration,
            Time.deltaTime * speedCamera);
            tragetTrans.rotation = ration;
            //Quaternion.Slerp(tragetTrans.rotation, ration, Time.deltaTime * speedCamera);
        }
        //放开右键直接还原，指定位置
        //         else
        //        {
        //            ComputeCameraRotate();
        //            x = cameraTrans.rotation.eulerAngles.y;
        //            y = cameraTrans.rotation.eulerAngles.x;
        //        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            ComputeCameraRotate();
            x = cameraTrans.rotation.eulerAngles.y;
            y = cameraTrans.rotation.eulerAngles.x;
        }
        ComputeCameraPosition();
        ComputeViewDistance();
    }

    void LateUpdate()
    {
        switch (nUseModel)
        {
            case 0:
                RoteCamera();
                break;
            case 1:
                RoteOnlyRightKey();//无法控制人物转向
                break;
        }
    }
}
