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
* 功能描述：     ...............风洞实验控制动画脚本................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ControlAni : MonoSingleton<ControlAni>
{

    [HideInInspector] public Animator ani;
    public Transform Tra_TargetMeasure;
    public CameraLookAt cameraLookAt;
    AnimatorStateInfo animatorInfo;//判断动画是否播放


    void Start()
    {
        ani = GetComponent<Animator>();
        cameraLookAt.GetComponent<CameraLookAt>();
    }

    
    void FixedUpdate()
    {
        if (Input.anyKeyDown && ani.speed == 0)
        {
            ani.speed = 1;
            ManagerFDGame.instance.Go40.SetActive(false);
        }
    }


    /// <summary>
    /// 测量薄片长宽动画
    /// </summary>
    public void Step1()
    {
        ani.SetBool("IsMeasure", true);
        // ManagerModel.instance.IsOutLine = false;
    }

    /// <summary>
    /// 开始测量薄片，镜头看向薄片动画
    /// </summary>
    public void StartMeasure()
    {
        AssemblyCSharp.MyDebug.Log("===============开始测量薄片，镜头看向薄片动画============");
        cameraLookAt.NearMeasure();
        ManagerFDGame.instance.Go_PanelMask.SetActive(true);
    }

    public void StopMeasure()
    {
        AssemblyCSharp.MyDebug.Log("===============结束测量薄片============");
        ControlFDGame.clearTxtTip();
        ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP3, ManagerGame.txtPrintSpeed);
        ManagerFDGame.instance.goTipHand.SetActive(true);
        ManagerFDGame.instance.txtStepThemeContent.text = AssetsConfigPath.StepThemeContent.STEPTHEME_MEASURE_LENGTH_F;
        ManagerFDGame.instance.Go_PanelMask.SetActive(false);
        ManagerFDGame.instance.Go_MeasureDone.SetActive(true);
        ani.SetBool("IsMeasure", false);

        ManagerFDGame.measureValue = 1;
        ManagerFDGame.ToolStep = 1;
    }

    public void StartMeasureWidth()
    {
        ManagerFDGame.instance.Go_PanelMask.SetActive(true);
        AssemblyCSharp.MyDebug.Log("===============开始测量薄片厚度，镜头看向薄片动画============");
        cameraLookAt.NearMeasureYBKC();
    }
    
    public void StopMeasureWidth_H()
    {
        ManagerFDGame.instance.txtStepThemeContent.text = AssetsConfigPath.StepThemeContent.STEPTHEME_MEASURE_WIDTH_W_F;
        ani.speed = 0;
        cameraLookAt.NearMeasureWidthW();
        ControlFDGame.clearTxtTip();
        ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP, ManagerGame.txtPrintSpeed);

    }

    public void StopMeasureWidth()
    {
        ControlFDGame.clearTxtTip();
        ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP5_1, ManagerGame.txtPrintSpeed);
        ManagerFDGame.instance.goTipHand.SetActive(true);
        ManagerFDGame.instance.txtStepThemeContent.text = AssetsConfigPath.StepThemeContent.STEPTHEME_MEASURE_WIDTH_H_F;
        ani.SetBool("IsMeasureWidth", false);
        ManagerFDGame.instance.Go_PanelMask.SetActive(false);
        // ManagerFDGame.instance.Go_MeasureDone.SetActive(true);
        cameraLookAt.NearMeasureWidthDone();

        ManagerFDGame.measureValue = 2;
        ManagerFDGame.ToolStep = 2;
    }

    public void StartJianQu()
    {
        ManagerFDGame.instance.GoJD.SetActive(false);
        cameraLookAt.NearJianQu();
        ManagerFDGame.instance.Go_PanelMask.SetActive(true);
    }

    public void StopJianQu()
    {
        //ControlModelOutLine.stepOutLine = 5;
        ani.SetBool("IsJianQu", false);
        ManagerFDGame.instance.GoFanGuangPian.SetActive(false);
        ManagerFDGame.instance.GoJianQu.SetActive(true);
        ControlFDGame.clearTxtTip();
        ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP6, ManagerGame.txtPrintSpeed);
        ManagerFDGame.instance.Go_PanelMask.SetActive(false);

        //ManagerFDGame.instance.delayModelTip("FGP");
        ControlFDGame.loadTipModelShow("showTipFGP");
    }

    public void StartPaste()
    {
        cameraLookAt.NearMeasureDone();
        ManagerFDGame.instance.Go_PanelMask.SetActive(true);
    }
    public void StopPaste()
    {
        ManagerFDGame.instance.GoJianQuanOnBP.SetActive(true);
        StartCoroutine(latePasteTip(2));
        ManagerFDGame.instance.Go_PanelMask.SetActive(false);
        ControlFDGame.loadTipModelShow("showTipSYB");
    }


    public void StartInstall()
    {
        cameraLookAt.NearInstall();
        ManagerFDGame.instance.Go_PanelMask.SetActive(true);
    }

    public void StopInstall()
    {
        ManagerFDGame.instance.GobaopianDone.SetActive(true);
        ManagerFDGame.instance.GoBaopianAni.SetActive(false);
        ManagerFDGame.instance.GoFGPJianQu.SetActive(false);
        ani.SetBool("IsInstall", false);
        ControlFDGame.clearTxtTip();
        ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP8, ManagerGame.txtPrintSpeed);
        ManagerFDGame.instance.goTipHand.SetActive(true);
        ManagerFDGame.instance.Go_PanelMask.SetActive(false);

        ManagerFDGame.ToolStep = 3;
    }

    public void StartQizi()
    {
        cameraLookAt.NearQiZiAni();
        ManagerFDGame.instance.Go_PanelMask.SetActive(true);
    }

    public void StopQizi()
    {
        ManagerFDGame.instance.GoLuosi.SetActive(true);
        ani.SetBool("IsQizi", false);
        ManagerFDGame.instance.Go_PanelMask.SetActive(false);
        StartCoroutine((lateProgress(4)));

        ManagerFDGame.ToolStep = 4;

    }


    /// <summary>
    /// 延迟4秒显示拧玩螺丝的状态，螺丝刀消失
    /// </summary>
    /// <param name="lateSecond"></param>
    /// <returns></returns>
    public IEnumerator lateProgress(int lateSecond)
    {
        yield return new WaitForSeconds(lateSecond);
        ControlFDGame.clearTxtTip();
        ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP10, ManagerGame.txtPrintSpeed);
        ManagerFDGame.instance.goTipHand.SetActive(true);
        cameraLookAt.NearInstall();
    }

    public IEnumerator latePasteTip(int i)
    {
        yield return new WaitForSeconds(i);
        ControlFDGame.clearTxtTip();
        ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP7, ManagerGame.txtPrintSpeed);

        ManagerFDGame.GameProgress = 6;
    }

    public IEnumerator lateMeasureWidth()
    {
        yield return new WaitForSeconds(2);
        cameraLookAt.NearJianDao();
    }
}
