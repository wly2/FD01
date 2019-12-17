using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using AssetsConfigPath;
using UnityEngine.UI;
using cakeslice;
using UnityEngine.SceneManagement;
using DG.Tweening;

#region Author & Version
/* ========================================================================  
*Author：WLY  
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date :      2019.0611    10:42
* 功能描述：     ..............风洞实验实现游戏主场景功能块、逻辑.................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/ 
#endregion

public class ControlFDGame : ManagerFDGame
{
    [HideInInspector] public static bool iStartGame = false;//判断游戏是否按进程进行
    [HideInInspector] public static string IrotateValue = "";//风车启动开解按钮手动旋转的值
    public static int typeScene = 0;//判断实验类型

    private void Awake()
    {
        MyDebug.Log("===========进入游戏...=========");
        txtTip.DOText(StepTxtTip.TIP_STEP1, ManagerGame.txtPrintSpeed);
        base.txtStepThemeContent.text = "";
    }

    private void Start()
    {
        base.Panel_Graphic.GetComponent<Image>();
        GoJianQuanOnBP.SetActive(false);
        GobaopianDone.SetActive(false);
        ControlFDGame.hidePanelTool();
        ControlFDGame.hidePanelTool();
        base.LaserLine.SetActive(false);//激光
        GoDisPlay.SetActive(false);

        base.aniStep = GetComponent<Animator>();//获取动画组件
    }


    void Update()
    {
        GraphicType(IrotateValue);
        ManagerModel.instance.ModelEvent("baopian");//实验操作步骤第1步
        ManagerModel.instance.ModelEvent("keduchi");//实验操作步骤第二步
        ManagerModel.instance.ModelEvent("YBKC");
        ManagerModel.instance.ModelEvent("jiandao");
        ManagerModel.instance.ModelEvent("bpJianqu");
        ManagerModel.instance.ModelEvent("installmodel");
        ManagerModel.instance.ModelEvent("qizi");
        ManagerModel.instance.ModelEvent("laserComputer");
        ModelLaser.instance.ModelLaserEvent("laser");
        ManagerModel.instance.ModelEvent("ArovaneStart");
        showVcr();
        //判断是否按游戏进程进行实验
        if (iStartGame == false)
        {
        }
        //if (base.canvasFD.activeSelf) iStartGame = true;
    }

    /// <summary>
    /// 右边栏按钮响应
    /// </summary>
    /// <param name="btnName"></param>
    public void btnType(string btnName)
    {
        switch (btnName)
        {
            case "工具":
                MyDebug.Log("<<<<<<<<<<<<<<<按下工具键<<<<<<<<<<<<<<<<<");
                base.UIPanelTool.SetActive(true);
                base.goTipHand.SetActive(false);
                ManagerUI.instance.UIOpenState();
                break;

            case "设置":
                ManagerUI.instance.ShowUIPanel(UIConfigPath.UIPanelSetting);
                ManagerUI.instance.UIOpenState();
                break;

            case "帮助":
                ManagerUI.instance.ShowUIPanel(UIConfigPath.UIPANEL_HELP);
                ManagerUI.instance.UIOpenState();
                break;
        }
    }


    /// <summary>
    /// 选择薄片模块
    /// </summary>
    public static void chooseBP()
    {
        ManagerFDGame.instance.canvasModel.SetActive(true);
        ManagerFDGame.instance.canvasFD.SetActive(true);
        ManagerFDGame.instance.canvasTrain.SetActive(false);
        if (ManagerFDGame.instance.canvasModel.gameObject.activeSelf)
        {
            ManagerFDGame.instance.canvasUI.SetActive(false);
            ManagerFDGame.instance.canvasMian.SetActive(false);
        }
        else
        {
            ManagerFDGame.instance.canvasUI.SetActive(true);
            ManagerFDGame.instance.canvasMian.SetActive(true);
        }
    }


    /// <summary>
    /// 当风速小于8时，显示薄板位移时间历程曲线和频谱曲线图
    /// 当风速=8时，显示薄板位移时间历程曲线和频谱曲线图
    /// </summary>
    public void showVcr()
    {
        //===============================================待完成==============================//
        if (MouseEvent.rotateValue == 8 || MouseEvent.rotateValue < 8 && MouseEvent.rotateValue != 0)//当MouseEvent.y时，也就是风速为8时，得到Vcr的值是8
        {
            //待完成.....
            ManagerFDGame.UIThemeStepProgress = 4;//实验流程
        }

        if (MouseEvent.rotateValue == 8)//假设Vcr的值为8，进入结果分析
        {
            ManagerFDGame.UIThemeStepProgress = 5;//实验流程
        }

        //var Vcr = (MouseEvent.rotateValue == 8 || MouseEvent.rotateValue < 8 && MouseEvent.rotateValue != 0) ? ManagerFDGame.UIThemeStepProgress = 4：return;
    }

    //隐藏工具栏
    public static void hidePanelTool()
    {
        ManagerFDGame.instance.UIPanelTool.SetActive(false);
    }


    //===============================左上角UI栏===========================================//
    /// <summary>
    /// 面板引用左边栏按钮
    /// </summary>
    /// <param name="str">按钮类型</param>
    public void PanelLab(string str)
    {
        switch (str)
        {
            case "实验原理":
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPANEL_YUANLI);
                ManagerUI.instance.UIOpenState();
                break;

            case "实验目的":
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPANEL_MUDI);
                ManagerUI.instance.UIOpenState();
                break;

            case "实验设备":
                base.Go_ModelShow.SetActive(true);
                base.canvasMian.SetActive(false);
                base.canvasUI.SetActive(false);
                ManagerUI.instance.UIOpenState();
                break;

            case "实验报告":
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPanelReport);
                ManagerUI.instance.UIOpenState();
                break;

            case "仿真结果":
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPANEL_RESULT);
                ManagerUI.instance.UIOpenState();
                break;
        }
    }

    /// <summary>
    /// 频率响应曲线
    /// </summary>
    /// <param name="str"></param>
    public void GraphicType(string str)
    {
        Sprite sprite = new Sprite();
        switch (str)
        {
            case "Line1":
                base.Panel_Graphic.gameObject.SetActive(true);
                base.Panel_TipDown.gameObject.SetActive(false);
                sprite = Resources.Load(AssetsConfigPath.TypeGraghic.GRAPHIC_1, sprite.GetType()) as Sprite;
                base.Panel_Graphic.sprite = sprite;
                break;
            case "Line2":
                sprite = Resources.Load(AssetsConfigPath.TypeGraghic.GRAPHIC_2, sprite.GetType()) as Sprite;
                base.Panel_Graphic.sprite = sprite;
                break;
            case "Line3":
                sprite = Resources.Load(AssetsConfigPath.TypeGraghic.GRAPHIC_3, sprite.GetType()) as Sprite;
                base.Panel_Graphic.sprite = sprite;
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "caozuotai")
        {
            MyDebug.Log("==============与操作台发生碰撞!=================");
            //txtTip.text = ConfigPath.TIP_STEP_2;
        }
    }

    /// <summary>
    /// 切换到第三人称视角
    /// </summary>
    public void MethSwithThirdCamera()
    {
        MyDebug.Log("######################游戏进行到进程：#############################" + "第" + GameProgress + "步");
        ManagerCamera.instance.MethIsCamera("IsCameraMain");
    }


    // 清空步骤提示
    public static void clearTxtTip()
    {
        ManagerFDGame.instance.txtTip.text = null;
    }


    /// <summary>
    /// 延迟气泡提示
    /// </summary>
    /// <param name="modelName">模型名称</param>
    /// <returns></returns>
    public static IEnumerator delayModelTip(string modelName)
    {
        yield return new WaitForSeconds(2.5f);
        ControlFDGame.loadTipModelShow(modelName);
    }

    /// <summary>
    /// 加载气泡提示预设体
    /// </summary>
    /// <param name="str"></param>
    public static void loadTipModelShow(string str)
    {
        switch (str)
        {
            case "showTipBP":
                ManagerUI.instance.showTipUIPanel(AssetsConfigPath.tipShowPath.TIPBP);
                ManagerUI.instance.UIOpenState();
                ManagerFDGame.GameProgress = 1;
                break;
            case "showTipZC":
                ManagerUI.instance.showTipUIPanel(AssetsConfigPath.tipShowPath.TIPZC);
                ManagerUI.instance.UIOpenState();
                ManagerFDGame.GameProgress = 2;
                break;

            case "showTipYBKC":
                ManagerUI.instance.showTipUIPanel(AssetsConfigPath.tipShowPath.TIPYBKC);
                ManagerUI.instance.UIOpenState();
                ManagerFDGame.GameProgress = 3;
                break;

            case "showTipJD":
                ManagerUI.instance.showTipUIPanel(AssetsConfigPath.tipShowPath.TIPJD);
                ManagerUI.instance.UIOpenState();
                ManagerFDGame.GameProgress = 4;
                break;

            case "showTipFGP":
                ManagerUI.instance.showTipUIPanel(AssetsConfigPath.tipShowPath.TIPFGP);
                ManagerUI.instance.UIOpenState();
                ManagerFDGame.GameProgress = 5;
                break;

            case "showTipSYB":
                ManagerUI.instance.showTipUIPanel(AssetsConfigPath.tipShowPath.TIPSYB);
                ManagerUI.instance.UIOpenState();
                //ControlModelOutLine.stepOutLine = 6;
                break;

            case "showTipLSD":
                ManagerUI.instance.showTipUIPanel(AssetsConfigPath.tipShowPath.TIPLSD);
                ManagerUI.instance.UIOpenState();
                ManagerFDGame.GameProgress = 7;
                break;

            case "showTipJGT":
                ManagerUI.instance.showTipUIPanel(AssetsConfigPath.tipShowPath.TIPJGT);
                ManagerUI.instance.UIOpenState();
                ManagerFDGame.GameProgress = 9;
                break;
        }

    }
}
