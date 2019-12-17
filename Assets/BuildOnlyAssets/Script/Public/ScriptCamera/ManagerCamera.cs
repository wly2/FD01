using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0606    14:12
* 功能描述：     ..............管理场景摄像机，所有的相机脚本都继承该脚本.................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ManagerCamera : MonoSingleton<ManagerCamera>
{
    public Camera CameraLookAt;//主摄像机
    public Camera CameraThird;//第三人称摄像机
    public Camera CameraOverView;//鸟瞰相机
    public Transform LookAtTarget;//摄像机看向的目标
    public float CameraDistance;//摄像机与看向目标的距离
    public float CameraHeight;//摄像机高度
    public float CameraOffset;//摄像机的偏移
    [HideInInspector] public float MainCameraMoveSpeed = 0.5F;//主摄像机移动的速度
    [HideInInspector] public float waitTime = 0F;//等待摄像机移动到设备附近的时间
    private Vector3 LookAtTargetPosition;//看向目标时的位置
    private Quaternion LookAtTargetRotation;//看向目标，且旋转
    public bool IsLookAtAppointTarget = false;//是否看向指定的物体
    public bool IsBack = false;
    private Vector3 _MainCameraOriginalPosition;//主摄像机的原始位置

    public bool IsLookAtAppointTargetTrain = false;
    public bool IsLookAtAppointTargetStr = false;

    public IEnumerator Start()
    {
        CameraDistance = 0.2f;
        CameraHeight = 0.01f;
        CameraOffset = 0;

        yield return new WaitForSeconds(0.1F);
        //记录主摄像机的原始位置
        if (CameraLookAt != null)
        {
            _MainCameraOriginalPosition = new Vector3(CameraLookAt.transform.localPosition.x, CameraLookAt.transform.localPosition.y, CameraLookAt.transform.localPosition.z);
            MyDebug.Log("==============主摄像机的原始位置的X=：===================" + _MainCameraOriginalPosition.x);
            MyDebug.Log("==============主摄像机的原始位置的Y=：===================" + _MainCameraOriginalPosition.y);
            MyDebug.Log("==============主摄像机的原始位置的Z=：===================" + _MainCameraOriginalPosition.z);
            MyDebug.Log("==============主摄像机的原始位置的Z=：===================" + _MainCameraOriginalPosition.z);
        }
    }


    private void FixedUpdate()
    {

        if (IsLookAtAppointTarget == true)
        {
            CameraLookAt.transform.position = Vector3.Lerp(CameraLookAt.transform.position, LookAtTargetPosition, Time.deltaTime * MainCameraMoveSpeed);
            CameraLookAt.transform.LookAt(LookAtTarget);
        }

        //高速列车镜头跳转速度
        if (IsLookAtAppointTargetTrain == true)
        {
            CameraLookAt.transform.position = Vector3.Lerp(CameraLookAt.transform.position, LookAtTargetPosition, Time.deltaTime * 1.5f);
            CameraLookAt.transform.LookAt(LookAtTarget);
        }

        //拉伸实验
        if (IsLookAtAppointTargetStr == true)
        {
            CameraLookAt.transform.position = Vector3.Lerp(CameraLookAt.transform.position, LookAtTargetPosition, Time.deltaTime * 0.8f);
            CameraLookAt.transform.LookAt(LookAtTarget);
        }

        if (IsLookAtAppointTarget == false)
        {

            CameraOverView.transform.position = Vector3.Lerp(CameraOverView.transform.position, LookAtTargetPosition, Time.deltaTime * 0.5f);
            CameraOverView.transform.LookAt(LookAtTarget);
        }

        if (IsBack == true) CameraLookAt.transform.position = Vector3.Lerp(CameraLookAt.transform.position,
         LookAtTargetPosition, 
         Time.deltaTime * MainCameraMoveSpeed);
        
    }

    /// <summary>
    /// 摄像机看向指定物体的方法
    /// </summary>
    public void LookAtAppointTarget()
    {
        if (LookAtTarget != null)
        {
            LookAtTargetPosition = new Vector3(LookAtTarget.transform.position.x + CameraOffset,
            LookAtTarget.transform.position.y + CameraHeight,
            LookAtTarget.transform.position.z + CameraDistance);
            IsLookAtAppointTarget = true;
        }
        else MyDebug.LogError(GetType() + "/LookAtAppointTarget()/================看向的物体不存在，请检查！！！==============");
    }

    /// <summary>
    /// 拉伸实验
    /// </summary>
    public void StrLookAtTarget()
    {
        if (LookAtTarget != null)
        {
            LookAtTargetPosition = new Vector3(LookAtTarget.transform.position.x, LookAtTarget.transform.position.y,LookAtTarget.transform.position.z - 0.5f);
            IsLookAtAppointTargetStr = true;
        }
        else MyDebug.LogError(GetType() + "/LookAtAppointTarget()/================看向的物体不存在，请检查！！！==============");
    }

    /// <summary>
    /// 全景鸟瞰
    /// </summary>
    public void LookAtOverView()
    {
        if (LookAtTarget != null)
        {
            LookAtTargetPosition = new Vector3(LookAtTarget.transform.position.x + CameraOffset,
            LookAtTarget.transform.position.y + 0.06f,
            LookAtTarget.transform.position.z + 0.2f);

            IsLookAtAppointTargetTrain = true;
        }
    }

    //摄像机返回原始位置
    public void ReturnOriginalPosition()
    {
        LookAtTargetPosition = new Vector3(_MainCameraOriginalPosition.x, _MainCameraOriginalPosition.y, _MainCameraOriginalPosition.z);
        IsBack = true;
    }

    IEnumerator Stop(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (IsLookAtAppointTarget == true)
        {
            IsLookAtAppointTarget = false;
            MyDebug.Log("IsLookAtAppointTarget=" + IsLookAtAppointTarget);
        }
        if (IsBack == true)
        {
            IsBack = false;
            MyDebug.Log("IsBack=" + IsBack);
        }
    }

    /// <summary>
    /// 视角切换
    /// </summary>
    public void MethIsCamera(string IsCamera)
    {
        switch (IsCamera)
        {
            case "IsCameraOverView":
                if (CameraOverView != null)
                {
                    CameraOverView.gameObject.SetActive(true);
                    CameraLookAt.gameObject.SetActive(false);
                    CameraThird.gameObject.SetActive(false);
                }
                break;

            case "IsCameraThird":
                CameraThird.gameObject.SetActive(true);
                CameraOverView.gameObject.SetActive(false);

                CameraLookAt.gameObject.SetActive(false);
                break;


            case "IsCameraMain":
                CameraLookAt.gameObject.SetActive(true);

                CameraThird.gameObject.SetActive(false);
                CameraOverView.gameObject.SetActive(false);
                break;
        }
    }
}
