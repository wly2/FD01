using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0611      10:43
* 功能描述：     ...............管理场景所有模型的效果、功能实现................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ManagerModel : MonoSingleton<ManagerModel>
{
    [HideInInspector] Camera CameraBuXiuGang;
    [HideInInspector] public Ray ray;
    [HideInInspector] public RaycastHit hitInfo;

    /// <summary>
    /// 模型选中事件
    /// </summary>
    /// <param name="modelName"></param>
    public void ModelEvent(string modelName)
    {
        #region 风洞实验
        switch (modelName)
        {
            case "baopian":
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0) && ManagerFDGame.GameProgress == 1)
                {
                    AssemblyCSharp.MyDebug.Log("**************************触发桌子薄片点击事件***********************");
                    //ControlModelOutLine.stepOutLine = 2;
                    ManagerGame.destoryGameobject("tipbp");
                    //ControlModelOutLine.isPlay = false; ;
                    ManagerUI.instance.UIOpenState();

                    ManagerFDGame.instance.txtStepThemeContent.text = AssetsConfigPath.StepThemeContent.STEPTHEME_CHOBAOPIAN;
                    MyDebug.Log("######################游戏进行到进程：#############################" + "第" + ControlFDGame.GameProgress + "步");

                    ControlFDGame.chooseBP();
                }
                return;

            case "keduchi":
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0))
                {
                    if (ManagerFDGame.GameProgress == 2)
                    {
                        AssemblyCSharp.MyDebug.Log("**************************触发防震台薄片点击事件***********************");
                        ControlAni.instance.Step1();
                        ManagerGame.destoryGameobject("tipzc");
                        //ControlModelOutLine.stepOutLine = 3;
                        ManagerFDGame.instance.txtStepThemeContent.text = AssetsConfigPath.StepThemeContent.STEPTHEME_MEASURE_LENGTH;
                        MyDebug.Log("######################游戏进行到进程：#############################" + "第" + ControlFDGame.GameProgress + "步");
                    }
                }
                return;

            case "YBKC":
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0) && ManagerFDGame.GameProgress == 3)
                {
                    AssemblyCSharp.MyDebug.Log("**************************游标卡尺模型点击事件***********************");
                    ControlAni.instance.ani.SetBool("IsMeasureWidth", true);
                    //ControlModelOutLine.stepOutLine = 4;
                    ManagerFDGame.instance.txtStepThemeContent.text = AssetsConfigPath.StepThemeContent.STEPTHEME_MEASURE_WIDTH_W;


                    MyDebug.Log("######################游戏进行到进程：#############################" + "第" + ControlFDGame.GameProgress + "步");

                    ManagerGame.destoryGameobject("tipybkc");

                }
                return;

            case "jiandao":
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0) && ManagerFDGame.GameProgress == 4)
                {
                    AssemblyCSharp.MyDebug.Log("**************************剪刀模型点击事件***********************");
                    ControlAni.instance.ani.SetBool("IsJianQu", true);
                    ManagerFDGame.instance.txtStepThemeContent.text = AssetsConfigPath.StepThemeContent.STEPTHEME_JIANQU;


                    MyDebug.Log("######################游戏进行到进程：#############################" + "第" + ControlFDGame.GameProgress + "步");

                    ManagerGame.destoryGameobject("tipjd");

                }
                return;

            case "bpJianqu":
                //待完成...播放动画
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0) && ManagerFDGame.GameProgress == 5)
                {
                    AssemblyCSharp.MyDebug.Log("************************张贴反光片*************************");

                    ControlAni.instance.ani.SetBool("IsPaste", true);
                    ManagerFDGame.instance.txtBPShow.SetActive(false);
                    ManagerFDGame.instance.txtStepThemeContent.text = AssetsConfigPath.StepThemeContent.STEPTHEME_ZHANGTIE;
                    MyDebug.Log("######################游戏进行到进程：#############################" + "第" + ControlFDGame.GameProgress + "步");

                    ManagerGame.destoryGameobject("tipfgp");
                }
                return;

            case "installmodel":
                //待完成...播放动画
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0) && ManagerFDGame.GameProgress == 6)
                {
                    ManagerFDGame.UIThemeStepProgress = 2;//试样安装
                    AssemblyCSharp.MyDebug.Log("**************************将试样安装在支架上***********************");
                    ManagerFDGame.instance.txtStepThemeContent.text = AssetsConfigPath.StepThemeContent.STEPTHEME_INSTALL;
                    ControlAni.instance.ani.SetBool("IsInstall", true);

                    ManagerGame.destoryGameobject("tipsyb");
                }
                return;

            case "qizi":
                //待完成...播放动画
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0) && ManagerFDGame.GameProgress == 7)
                {
                    AssemblyCSharp.MyDebug.Log("**************************选择起子点击事件***********************");
                    ControlAni.instance.ani.SetBool("IsQizi", true);
                    // ManagerModel.instance.IsOutLine = false;
                    ManagerFDGame.instance.txtStepThemeContent.text = AssetsConfigPath.StepThemeContent.STEPTHEME_GUDING;
                    MyDebug.Log("######################游戏进行到进程：#############################" + "第" + ControlFDGame.GameProgress + "步");

                    ManagerFDGame.GameProgress = 8;
                    ManagerGame.destoryGameobject("tiplsd");
                }
                return;

            case "laserComputer":
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0) && ManagerFDGame.GameProgress == 8)
                {
                    AssemblyCSharp.MyDebug.Log("**************************选择激光仪器点击事件***********************");

                    ManagerFDGame.instance.Go_laserCompeterShow.GetComponent<Renderer>().material.mainTexture = (Texture2D)Resources.Load("Materail/layerComputer");
                    ControlFDGame.clearTxtTip();
                    ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP10_2, ManagerGame.txtPrintSpeed);
                    ManagerFDGame.instance.goTipHand.SetActive(true);
                    ManagerFDGame.instance.txtStepThemeContent.text = AssetsConfigPath.StepThemeContent.STEPTHEME_LASER;

                    ManagerFDGame.ToolStep = 5;
                }
                return;

            case "ArovaneStart":
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0) && ManagerFDGame.GameProgress == 10)
                {
                    AssemblyCSharp.MyDebug.Log("**************************风车启动***********************");
                    ManagerFDGame.UIThemeStepProgress = 3;//实验流程
                    ManagerFDGame.instance.MaStartState.GetComponent<Renderer>().material.color = Color.green;//开启按钮，按钮变绿
                    ControlFDGame.clearTxtTip();
                    ManagerFDGame.instance.txtTip.DOText(AssetsConfigPath.StepTxtTip.TIP_STEP14, ManagerGame.txtPrintSpeed);

                    ManagerFDGame.instance.GoDisPlay.SetActive(true);

                    ManagerFDGame.instance.txtStepThemeContent.text = AssetsConfigPath.StepThemeContent.STEPTHEME_QIDONG;
                    MyDebug.Log("######################游戏进行到进程：#############################" + "第" + ControlFDGame.GameProgress + "步");

                    ManagerFDGame.GameProgress = 11;
                }

                //=============================高速列车===========================//
                if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0) && ManagerTrainGame.gamePrrogress == 11)
                {
                    AssemblyCSharp.MyDebug.Log("**************************风车启动***********************");
                    //ManagerFDGame.UIThemeStepProgress = 3;//实验流程
                    ManagerTrainGame.instance.controlStart.GetComponent<Renderer>().material.color = Color.green;//开启按钮，按钮变绿
                    ManagerTrainGame.instance.controlShow.SetActive(true);
                }
                return;
            #endregion


            #region 高速列车
            case "CRH2":
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0))
                {
                    ManagerGame.destoryGameobject("tiptrain");
                    AssemblyCSharp.MyDebug.Log("**************************触发CRH2点击事件***********************");
                    typeTrainModel();
                }
                return;

            case "CNH380A":
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.gameObject.tag == modelName && Input.GetMouseButtonDown(0))
                {
                    ManagerGame.destoryGameobject("tiptrain");
                    AssemblyCSharp.MyDebug.Log("**************************触发CNH380A点击事件***********************");
                    typeTrainModel();
                }
                return;
                #endregion
        }
    }

    public void typeTrainModel()
    {
        ManagerTrainGame.instance.canvasModel.SetActive(true);
        ManagerTrainGame.instance.canvasFD.SetActive(false);
        ManagerTrainGame.instance.canvasTrain.SetActive(true);
        if (ManagerTrainGame.instance.canvasModel.gameObject.activeSelf)
        {
            ManagerTrainGame.instance.canvasUI.SetActive(false);
            ManagerTrainGame.instance.canvasMian.SetActive(false);
        }
        else
        {
            ManagerTrainGame.instance.canvasUI.SetActive(true);
            ManagerTrainGame.instance.canvasMian.SetActive(true);
        }
    }
}
