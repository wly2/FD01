using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0618  11:20
* 功能描述：     ...............选中激光头镜头转向激光照射物体的方法................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ModelLaser : MonoSingleton<ModelLaser>
{

    [HideInInspector] public Ray ray;
    [HideInInspector] public RaycastHit hitInfo;
    public CameraLookAt cameraLookAt;

    void Start()

    {
        cameraLookAt.GetComponent<CameraLookAt>();
    }

    public void ModelLaserEvent(string str)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == str && Input.GetMouseButtonDown(0) && ManagerFDGame.GameProgress == 9)
        {
            AssemblyCSharp.MyDebug.Log("**************************激光头选中效果***********************");
            ManagerFDGame.instance.LaserEffect.SetActive(true);
            StartCoroutine(LateLaserHide(2));
            ManagerFDGame.instance.txtStepThemeContent.text = AssetsConfigPath.StepThemeContent.STEPTHEME_JIGHUAG;
            AssemblyCSharp.MyDebug.Log("######################游戏进行到进程：#############################" + "第" + ControlFDGame.GameProgress + "步");
            
            ManagerFDGame.instance.LaserLine.SetActive(true);
            ManagerFDGame.GameProgress = 10;
            ManagerFDGame.ToolStep = 6;
            ManagerGame.destoryGameobject("tipjgt");
        }
    }

/// <summary>
/// 激光延迟一秒消失，镜头拉近样板
/// </summary>
/// <param name="time"></param>
/// <returns></returns>
    public IEnumerator LateLaserHide(int time)
    {
        yield return new WaitForSeconds(time);
        cameraLookAt.NearLaserLine();
        Destroy(ManagerFDGame.instance.LaserEffect);
    }
}