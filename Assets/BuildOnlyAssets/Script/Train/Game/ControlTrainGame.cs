using AssemblyCSharp;
using AssetsConfigPath;
using DG.Tweening;
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
* Date : 2019.0606    14:12
* 功能描述：     ................高速列车用于实现功能逻辑...............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ControlTrainGame : ManagerTrainGame
{

    private void Awake()
    {
        base.txtTipTrain.text = "";
        base.controlShow.SetActive(false);
        ManagerTrainGame.gamePrrogress = 11;
        base.cameraLookAt.GetComponent<CameraLookAtTrain>();
        clearTxtTip();
        base.txtTipTrain.DOText(StepTxtTip.TIP_TRAIN_STEP1, ManagerGame.txtPrintSpeed);
    }

    private void Update()
    {
        ManagerModel.instance.ModelEvent("CRH2");
        ManagerModel.instance.ModelEvent("CNH380A");
        ManagerModel.instance.ModelEvent("ArovaneStart");
    }

    /// <summary>
    /// 按钮点击事件
    /// </summary>
    /// <param name="btnName"></param>
    public void btnGame(string btnName)
    {
        switch (btnName)
        {
            case "Yuanli"://实验原理
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPANEL_TRAIN_YUANLI );
                ManagerUI.instance.UIOpenState();
                break;
            case "Mudi"://实验目的
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPANEL_MUDI);
                ManagerUI.instance.UIOpenState();
                break;
            case "Shebei"://实验设备
                base.canvasShowModel.SetActive(true);
                base.canvasMian.SetActive(false);
                base.canvasUI.SetActive(false);
                ManagerUI.instance.UIOpenState();
                break;
            case "Report"://实验报告
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPANEL_TRAIN_REPORT);
                ManagerUI.instance.UIOpenState();
                break;
            case "Result"://仿真结果
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPANEL_TRAIN_INPUTRESULT);
                ManagerUI.instance.UIOpenState();
                break;
            case "Controler"://镜头跳转到控制台
                base.cameraLookAt.lookAtModel("Controler");
                base.tipControl.SetActive(false);
                break;
            case "offShebei"://设备界面关闭按钮
                base.canvasShowModel.SetActive(false);
                ManagerTrainGame.instance.canvasMian.SetActive(true);
                ManagerTrainGame.instance.canvasUI.SetActive(true);
                break;
            case "shezhi"://设置
                ManagerUI.instance.ShowUIPanel(UIConfigPath.UIPanelSetting);
                ManagerUI.instance.UIOpenState();
                break;
            case "help"://帮助
                ManagerUI.instance.ShowUIPanel(UIConfigPath.UIPANEL_HELP);
                ManagerUI.instance.UIOpenState();
                break;

        }
    }


    /// <summary>
    /// 清空提示
    /// </summary>
    public static void clearTxtTip()
    {
        ManagerTrainGame.instance.txtTipTrain.text = null;
    }

    /// <summary>
    /// 加载提示预设体
    /// </summary>
    /// <param name="str"></param>
    public static void loadTipModelShow(string str)
    {
        switch (str)
        {
            case "showTipChooseTrain":
                ManagerUI.instance.showTipUIPanel(AssetsConfigPath.tipShowPath.TIPTRAIN);
                ManagerUI.instance.UIOpenState();
                break;
        }

    }
}