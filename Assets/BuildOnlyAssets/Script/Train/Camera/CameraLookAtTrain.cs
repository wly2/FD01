using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;
using cakeslice;
using DG.Tweening;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：场景主相机
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 
* 功能描述：     ................第一视角，用于看向物体...............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class CameraLookAtTrain : ManagerCamera
{
    //===================高速列车=====================//
    public Transform traOver;
    public Transform traConsole;//控制台
    public Transform traCRH2;

    private void Awake()
    {
        StartCoroutine(base.Start());
        OverView();
        base.CameraThird.gameObject.SetActive(false);
    }

    /// <summary>
    /// 看向模型方法
    /// </summary>
    /// <param name="model"></param>
    public void lookAtModel(string model)
    {
        switch (model)
        {
            case "CRH2":
                base.LookAtTarget = traCRH2;
                base.LookAtAppointTarget();
                break;

            case "Controler":
                base.LookAtTarget = traConsole;
                base.LookAtAppointTarget();

                ControlTrainGame.clearTxtTip();
                ManagerTrainGame.instance.txtTipTrain.DOText(AssetsConfigPath.StepTxtTip.TIP_TRAIN_STEP4,ManagerGame.txtPrintSpeed);
                break;
        }
    }


    /// <summary>
    /// 鸟瞰场景
    /// </summary>
    public void OverView()
    {
        base.LookAtTarget = traOver;
        base.LookAtOverView();
        StartCoroutine(ILateProgress());
    }

    public IEnumerator ILateProgress()
    {
        yield return new WaitForSeconds(3f);
        ControlTrainGame.loadTipModelShow("showTipChooseTrain");
    }
}
