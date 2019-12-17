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
* 功能描述：     ...............控制动画................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ControlAniTrain : MonoSingleton<ControlAniTrain>
{

    [HideInInspector] public Animator ani;
    public CameraLookAtTrain cameraLookAt;
    AnimatorStateInfo animatorInfo;//判断动画是否播放

    public GameObject doneCRH2;


    void Start()
    {
        doneCRH2.SetActive(false);
        ani = GetComponent<Animator>();
        cameraLookAt.GetComponent<CameraLookAtTrain>();
    }

    
    void FixedUpdate()
    {

    }

    void startCRH2()
    {

    }

    void stopCRH2()
    {
        ManagerTrainGame.instance.trainDone.SetActive(true);
        ControlAniTrain.instance.ani.SetBool("isCRH2", false);
        ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPANEL_TRAIN_TIPANGLE);
        ManagerUI.instance.UIOpenState();

        ControlTrainGame.clearTxtTip();
        ManagerTrainGame.instance.txtTipTrain.DOText(AssetsConfigPath.StepTxtTip.TIP_TRAIN_STEP2,ManagerGame.txtPrintSpeed);
    }

    void startRotate()
    {
        ManagerTrainGame.instance.trainDone.SetActive(false);
    }

    void stopRotate()
    {
        ManagerTrainGame.instance.tipControl.SetActive(true);

        ControlTrainGame.clearTxtTip();
        ManagerTrainGame.instance.txtTipTrain.DOText(AssetsConfigPath.StepTxtTip.TIP_TRAIN_STEP3,ManagerGame.txtPrintSpeed);
    }
}
