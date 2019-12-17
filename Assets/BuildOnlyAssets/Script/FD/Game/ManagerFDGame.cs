using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0611    10:42
* 功能描述：     ...............风洞实验用于赋值、功能管理................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion
public class ManagerFDGame : MonoSingleton<ManagerFDGame>
{
    public Text txtTip;//面板步骤提示
    public Text txtStepTheme;//步骤主题
    [HideInInspector] public static int UIThemeStepProgress = 0;//主题步骤进程
    [HideInInspector] public static int measureValue = 0;//主题步骤进程
    public Text txtStepThemeContent;//步骤主题内容
    public GameObject UIPanelTool;
    [HideInInspector] public static int GameProgress = 0;//游戏进程 
    public GameObject GobaopianDone;//安装完成的薄板
    public GameObject GoBaopianAni;//安装薄板时的薄板
    public GameObject GoLuosi;
    public GameObject GoJianQu;//反光片剪取部分
    public GameObject GoJianQuanOnBP;//剪取完成贴在薄片上的反光片
    public GameObject GoFanGuangPian;//反光片
    public GameObject GoFGPJianQu;
    [HideInInspector] public Animator aniStep;
    public GameObject GoDisPlay;//显示屏 
    public GameObject MaStartState;//风车启动按钮
    public Text txtVFeng;//风速
    [SerializeField] public GameObject LaserLine;//激光效果
    public GameObject canvasUI;//UI层
    public GameObject canvasModel;//模型层
    public GameObject canvasMian;
    public GameObject Go_ModelShow;//
    public GameObject Go_PanelMask;//全局遮罩
    public bool isBXG = false;//判断选中的薄片
    public bool isLHJ = false;//判断选中的薄片
    public GameObject Tool;//工具栏工具
    public Image Panel_Graphic;//历程图
    public Image Panel_TipDown;//提醒框
    public GameObject LaserEffect;//激光线
    [HideInInspector] public static int ToolStep = 0;//不在工具使用步骤，限制工具的使用
    public GameObject Go_MeasureDone;
    public GameObject Go_laserCompeterShow;//激光仪器显示屏
    public GameObject Go40;
    public GameObject GoJD;//剪刀
    public GameObject canvasFD;
    public GameObject canvasTrain;
    public GameObject txtBPShow;

    public GameObject goTipHand;
   


    /// <summary>
    /// 薄片类型
    /// </summary>
    public class bpType
    {
        public const string BP_BXG = "不锈钢";
        public const string BP_LHJ = "铝合金";

    }


    /// <summary>
    /// 测量结果
    /// </summary>
    public class EmeasureBPvalue
    {
        public const int measureLength = 400;
        public const int measrureWidth = 40;
        public const float measureLand = 1 / 2f;
    }
}
