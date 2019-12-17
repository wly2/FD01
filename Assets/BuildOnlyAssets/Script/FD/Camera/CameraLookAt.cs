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
* Date : 2019.0611    10:42
* 功能描述：     ................第一视角，用于看向物体...............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class CameraLookAt : ManagerCamera
{
    public Transform Tra_TargetBaoPian;//镜头看向薄片的位置
    public Transform Tra_TargetMeasure;
    public Transform Tra_OverView1;
    public Transform Tra_YBKC;//游标卡尺
    public Transform Tra_MeasureDone;
    public Transform Tra_JianDao;
    public Transform Tra_JianQu;
    public Transform Tra_Install;
    public Transform Tra_LuoSiKnife;
    public Transform Tra_QiZiAni;
    public Transform Tra_Laser;//激光头
    public Transform Tra_LaserComputer;//激光仪器
    public Transform Tra_LaserLine;//激光照射点
    public Transform Tra_Console;//控制台
    public Transform Tra_MeasureYBKC;
    public Transform traMeasureWidthDone;
    public Transform traMeasureWidthW;

    private void Awake()
    {
        StartCoroutine(base.Start());
        OverView();
    }

    public void lookAtModel(string model)
    {
        switch (model)
        {
            case "CRH2":
                // base.LookAtTarget = traCRH2;
                base.LookAtAppointTarget();
                break;
        }
    }
    //靠近不锈钢薄片方法
    public void NearZhiChi()
    {
        StartCoroutine(ControlFDGame.delayModelTip("showTipZC"));
        ManagerFDGame.UIThemeStepProgress = 1;//试样准备
        ControlFDGame.hidePanelTool();
        ControlFDGame.clearTxtTip();
        ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP2, ManagerGame.txtPrintSpeed);
        MyDebug.Log("===========================选中不锈钢薄片========================");
        base.LookAtTarget = Tra_TargetBaoPian;
        base.LookAtAppointTarget();
        MyDebug.Log("######################游戏进行到进程：#############################" + "第" + ControlFDGame.GameProgress + "步");
        ManagerCamera.instance.MethIsCamera("IsCameraMain");
        ManagerUI.instance.UIOffState();
    }

    public void NearMeasure()
    {

        MyDebug.Log("==========================镜头看向测量动画==================" + base.LookAtTarget);
        base.LookAtTarget = Tra_TargetMeasure;
        base.LookAtAppointTarget();
    }

    public void NearMeasureDone()
    {
        MyDebug.Log("==========================镜头看向测量完成薄片==================" + base.LookAtTarget);
        base.LookAtTarget = Tra_MeasureDone;
        base.LookAtAppointTarget();
    }

    public void NearMeasureWidthDone()
    {
        MyDebug.Log("==========================镜头看向测量厚度完成数值==================" + base.LookAtTarget);
        base.LookAtTarget = traMeasureWidthDone;
        base.LookAtAppointTarget();
    }


    /// <summary>
    /// 看向测量宽度完成
    /// </summary>
    public void NearMeasureWidthW()
    {
        MyDebug.Log("==========================镜头看向测量宽度完成数值==================" + base.LookAtTarget);
        base.LookAtTarget = traMeasureWidthW;
        base.LookAtAppointTarget();
    }

    public void NearYBKC()
    {
        if (ManagerFDGame.ToolStep == 1)
        {
            MyDebug.Log("==========================镜头看向游标卡尺==================" + base.LookAtTarget);
            ControlFDGame.clearTxtTip();
            ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP4, ManagerGame.txtPrintSpeed);
            base.LookAtTarget = Tra_YBKC;
            base.LookAtAppointTarget();
            ControlFDGame.hidePanelTool();

            StartCoroutine(ControlFDGame.delayModelTip("showTipYBKC"));
        }
    }

    public void NearMeasureYBKC()
    {
        MyDebug.Log("==========================镜头看向游标卡尺==================" + base.LookAtTarget);
        ManagerFDGame.instance.Go_MeasureDone.SetActive(false);
        base.LookAtTarget = Tra_MeasureYBKC;
        base.LookAtAppointTarget();
    }

    /// <summary>
    /// 螺丝刀,剪刀都看向同一个方法
    /// </summary>
    public void NearJianDao()
    {
        if (ManagerFDGame.ToolStep == 2)
        {
            MyDebug.Log("==========================镜头看向剪刀==================" + base.LookAtTarget);
            ControlFDGame.clearTxtTip();
            ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP5, ManagerGame.txtPrintSpeed);

            base.LookAtTarget = Tra_JianDao;
            base.LookAtAppointTarget();
            ControlFDGame.hidePanelTool();
            ManagerFDGame.instance.Go_MeasureDone.SetActive(false);

            StartCoroutine(ControlFDGame.delayModelTip("showTipJD"));
        }
    }

    public void NearInstall()
    {
        MyDebug.Log("==========================镜头看向安装支架==================" + base.LookAtTarget);
        base.LookAtTarget = Tra_Install;
        base.LookAtAppointTarget();
    }

    public void NearJianQu()
    {
        MyDebug.Log("==========================镜头看向剪取动画==================" + base.LookAtTarget);
        base.LookAtTarget = Tra_JianQu;
        base.LookAtAppointTarget();
    }

    public void NearKnife()
    {
        if (ManagerFDGame.ToolStep == 3)
        {
            MyDebug.Log("==========================镜头看向螺丝刀==================" + base.LookAtTarget);
            base.LookAtTarget = Tra_LuoSiKnife;
            base.LookAtAppointTarget();
            ControlFDGame.hidePanelTool();
            ControlFDGame.clearTxtTip();
            ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP9, ManagerGame.txtPrintSpeed);

            StartCoroutine(ControlFDGame.delayModelTip("showTipLSD"));
        }
    }

    public void NearQiZiAni()
    {
        MyDebug.Log("==========================镜头看向螺丝刀动画==================" + base.LookAtTarget);
        base.LookAtTarget = Tra_QiZiAni;
        base.LookAtAppointTarget();
    }

    public void NearLaserComputer()
    {
        if (ManagerFDGame.ToolStep == 4)
        {
            MyDebug.Log("==========================镜头看向激光测振仪==================" + base.LookAtTarget);
            base.LookAtTarget = Tra_LaserComputer;
            base.LookAtAppointTarget();
            ControlFDGame.hidePanelTool();
            ControlFDGame.clearTxtTip();
            ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP10_1, ManagerGame.txtPrintSpeed);
        }
    }

    public void NearLaser()
    {
        if (ManagerFDGame.ToolStep == 5)
        {
            MyDebug.Log("==========================镜头看向激光头==================" + base.LookAtTarget);
            base.LookAtTarget = Tra_Laser;
            base.LookAtAppointTarget();
            ControlFDGame.hidePanelTool();
            ControlFDGame.clearTxtTip();
            ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP11, ManagerGame.txtPrintSpeed);

            StartCoroutine(ControlFDGame.delayModelTip("showTipJGT"));
        }
    }

    public void NearLaserLine()
    {
        MyDebug.Log("==========================镜头看向激光照射处==================" + base.LookAtTarget);
        base.LookAtTarget = Tra_LaserLine;
        base.LookAtAppointTarget();
        ControlFDGame.clearTxtTip();
        ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP12, ManagerGame.txtPrintSpeed);
        ManagerFDGame.instance.goTipHand.SetActive(true);
    }

    public void NearConsole()
    {
        if (ManagerFDGame.ToolStep == 6)
        {
            MyDebug.Log("==========================镜头看向控制台==================" + base.LookAtTarget);
            base.LookAtTarget = Tra_Console;
            base.LookAtAppointTarget();
            ControlFDGame.hidePanelTool();
            ControlFDGame.clearTxtTip();
            ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP13, ManagerGame.txtPrintSpeed);
        }
    }




    /// <summary>
    /// 鸟瞰场景
    /// </summary>
    public void OverView()
    {
        base.LookAtTarget = Tra_OverView1;
        base.LookAtOverView();
        StartCoroutine(ILateProgress());
        //StartCoroutine(ControlFDGame.delayModelTip("BP"));
    }

    public IEnumerator ILateProgress()
    {
        yield return new WaitForSeconds(5f);
        ControlFDGame.loadTipModelShow("showTipBP");
        //ControlModelOutLine.stepOutLine = 1;
        MyDebug.Log("######################游戏进行到进程：#############################" + "第" + ControlFDGame.GameProgress + "步");
    }
}
