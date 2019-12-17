using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019 0624
* 功能描述：     ...............本地路径................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

namespace AssetsConfigPath
{

    /// <summary>
    /// 本地路径
    /// </summary>
    public class UIConfigPath
    {
        //======================游戏界面======================//
        public const string HIERARCHY_SETTING = "/CanvasUI/Canvas/Panel_Left/But_Setting/";//游戏界面设置键
        public const string HIERARCHY_TOOL = "/CanvasUI/Canvas/Panel_Left/But_Tool/";//游戏界面工具键
        public const string HIERARCHY_CANVAS = "/CanvasUI";//
        public const string HIERARCHY_TIPCANVAS = "/CanvasUI/Panel_Tip";//
        //

        #region 预设体
        //=======================公共部分=====================//
        public const string UIPanelSetting = "Prefabs/UIWindow/Public/UIPanelSetting";//设置预设体
        public const string UIPANEL_HELP = "Prefabs/UIWindow/Public/UIPanelHelp";//帮助
        public const string UIPanelSetting_OFF = "/Canvas_UI/UIPanelSetting(Clone)/Img_Bg/But_Off";//设置框关闭按钮
        public const string UIPanelTool = "Prefabs/UIWindow/UIPanelTool";//工具框
        public const string UIPanelTool_OFF = "/Canvas_UI/UIPanelTool/Img_Bg/But_Off";//关闭按钮

        #endregion

    }


    /// <summary>
    ///实验相关
    /// </summary>
    public class TestAbout
    {
        //==========================风洞实验================================//
        public const string UIPANEL_YUANLI = "Prefabs/UIWindow/FD/UIPanelYuanLi";//实验原理
        public const string UIPANEL_MUDI = "Prefabs/UIWindow/FD/UIPanelMuDi";//实验目的
        public const string UIPanelReport = "Prefabs/UIWindow/FD/UIPanelReport";//实验报告
        public const string UIPANEL_DEVICE = "Prefabs/UIWindow/UIPanelModelShow";//实验设备
        public const string UIPANEL_RESULT = "Prefabs/UIWindow/FD/UIPanelInputResult";//输入仿真数据
        public const string UIPanelVResult = "Prefabs/UIWindow/FD/UIPanelVResult";//仿真结果

        //===================仿真结果========================//
        public const string UIPANEL_FD_IMGVRESULT = "Prefabs/UIWindow/FD/UIPanelFDImgVResult";//仿真结果图片
        public const string UIPANEL_FD_CURVRESULT = "Prefabs/UIWindow/FD/UIPanelFDCurVResult";//仿真结果曲线
        public const string UIPANEL_FD_ANIVRESULT = "Prefabs/UIWindow/FD/UIPanelFDAniVResult";//仿真结果视频


        //==========================列车实验================================//
        public const string UIPANEL_TRAIN_REPORT = "Prefabs/UIWindow/Train/UIPanelReportTrain";//实验报告
        public const string UIPANEL_TRAIN_INPUTRESULT = "Prefabs/UIWindow/Train/UIPanelTrainInputResult";//输入仿真数据
        public const string UIPANEL_TRAIN_VRESULT = "Prefabs/UIWindow/Train/UIPanelTrainVResult";//仿真结果
        //========================仿真结果=================================//
        public const string UIPANEL_TRAIN_IMGVRESULT = "Prefabs/UIWindow/Train/UIPanlelTrainImgVResult";//仿真结果“图片”
        public const string UIPANEL_TRAIN_CURVRESULT = "Prefabs/UIWindow/Train/UIPanlelTrainCurVResult";//仿真结果“曲线”

        public const string UIPANEL_TRAIN_TIPANGLE = "Prefabs/UIWindow/Train/UIPanelTipAngle";//选择角度
        public const string UIPANEL_TRAIN_YUANLI = "Prefabs/UIWindow/Train/UIPanelYuanliTrain";//选择角度
        public const string UIPANEL_TRAIN_MUDI = "Prefabs/UIWindow/Train/UIPanelMudiTrain";//选择角度

    }

    /// <summary>
    /// 模型提示预设
    /// </summary>
    public class tipShowPath
    {
        //==================================风洞实验===================================//
        public const string TIPBP = "Prefabs/UIWindow/FD/Tip/tipBP";//薄片
        public const string TIPZC = "Prefabs/UIWindow/FD/Tip/tipZC";//直尺
        public const string TIPYBKC = "Prefabs/UIWindow/FD/Tip/tipYBKC";//游标卡尺
        public const string TIPJD = "Prefabs/UIWindow/FD/Tip/tipJD";//剪刀
        public const string TIPFGP = "Prefabs/UIWindow/FD/Tip/tipFGP";//反光片
        public const string TIPSYB = "Prefabs/UIWindow/FD/Tip/tipSYB";//试样板
        public const string TIPLSD = "Prefabs/UIWindow/FD/Tip/tipLSD";//螺丝刀
        public const string TIPJGT = "Prefabs/UIWindow/FD/Tip/tipJGT";//激光头

        //=====================================高速列车================================//
        public const string TIPTRAIN = "Prefabs/UIWindow/Train/Tip/tipTrain";//选择列车
    }


    /// <summary>
    /// 历程曲线图路径
    /// </summary>
    public class TypeGraghic
    {
        public const string GRAPHIC_1 = "UI/uiCurent/Line1";
        public const string GRAPHIC_2 = "UI/uiCurent/Line2";
        public const string GRAPHIC_3 = "UI/uiCurent/Line3";
    }

    /// <summary>
    /// FD仿真结果放大效果加载路径
    /// </summary>
    public class TypeFDSimResult
    {
        //======================图片====================//
        public const string YLFB = "UI/SimResult/FD/Image/YLFB";//压力分布
        public const string SDFB = "UI/SimResult/FD/Image/SDFB";//速度分布
        public const string SDSL = "UI/SimResult/FD/Image/SDSL";//速度矢量

        //======================曲线====================//
        public const string JDWY1 = "UI/SimResult/FD/Curent/JDWY1";//节点位移1
        public const string JDWY2 = "UI/SimResult/FD/Curent/JDWY2";//节点位移2
        public const string JDWY3 = "UI/SimResult/FD/Curent/JDWY3";//节点位移3


        //======================视频====================//
        //Url
        public const string TESTPATH = "https://vd4.bdstatic.com/mda-ijep4k65eve3g5k8/sc/mda-ijep4k65eve3g5k8.mp4?auth_key=1565254432-0-0-95e6c8672d1698408134551cf11dd281&bcevod_channel=searchbox_feed&pd=bjh&abtest=all";
        public const string URLPATH = "http://zxedu.natapp1.cc/pages/video.html";
        //本地路径
        public const string VSDFB = "E:/Unity Files/Programs/Dynamics/Assets/Resources/UI/SimResult/FD/Video/SDFB.mp4";//速度分布
        public const string VSDSL = "E:/Unity Files/Programs/Dynamics/Assets/Resources/UI/SimResult/FD/Video/SDSL.mp4";//速度矢量
        public const string VWLFB = "E:/Unity Files/Programs/Dynamics/Assets/Resources/UI/SimResult/FD/Video/WLFB.mp4";//渦量分布
        public const string VYLFB = "E:/Unity Files/Programs/Dynamics/Assets/Resources/UI/SimResult/FD/Video/YLFB.mp4";//压力分布
    }

    /// <summary>
    /// 高速列车仿真结果放大效果加载路径
    /// </summary>
    public class TypeTrainSimResult
    {
        //图车身压力分布
        public const string CSYLFB1 = "UI/SimResult/Train/Image/CSYLFB/CSYLFB1";
        public const string CSYLFB2 = "UI/SimResult/Train/Image/CSYLFB/CSYLFB2";

        //流场压力分布
        public const string LCYLFBALL = "UI/SimResult/Train/Image/LCYLFB/LCYLFB";

        //流场流线分布
        public const string LCLXFBALL = "UI/SimResult/Train/Image/LCLXFB/LCLXFB";

        //侧力系数
        public const string CLXSALL = "UI/SimResult/Train/Curent/CLXS/CLXS";

        //升力系数
        public const string SLXSALL = "UI/SimResult/Train/Curent/SLXS/SLXS";
    }


    /// <summary>
    /// 步骤主题
    /// </summary>
    public class typeTopStep
    {
        public const string STEP1 = "UI/uiTopStep/step1";
        public const string STEP2 = "UI/uiTopStep/step2";
        public const string STEP3 = "UI/uiTopStep/step3";
        public const string STEP4 = "UI/uiTopStep/step4";
        public const string STEP5 = "UI/uiTopStep/step5";
    }

    /// <summary>
    /// 操作提示
    /// </summary>
    public class StepTxtTip
    {
        //==============================风洞实验=================================//
        public const string TIP_STEP1 = "单击桌子上摆放的薄片,选择薄片类型！";
        public const string TIP_STEP2 = "单击选中直尺，对薄片进行测量！";
        public const string TIP_STEP3 = "打开工具选项栏，选择游标卡尺!";
        public const string TIP_STEP4 = "单击选中游标卡尺，测量薄片的厚度！";
        public const string TIP_STEP5 = "单击剪刀，裁剪反光片！";
        public const string TIP_STEP5_1 = "打开工具栏，选择剪刀!";
        public const string TIP_STEP6 = "选中反光片，将剪取的反光片安装到\n薄板上!";
        public const string TIP_STEP7 = "选取试样板，将试样安装到支架上!";
        public const string TIP_STEP8 = "打开工具栏，选择螺丝刀!";
        public const string TIP_STEP9 = "单击选中螺丝刀，拧紧试样板端部四颗\n固定螺丝!";

        public const string TIP_STEP10 = "打开工具栏，选择激光仪器!";
        public const string TIP_STEP10_1 = "点击计算机，打开电脑！";
        public const string TIP_STEP10_2 = "打开工具栏，选择激光头!";
        public const string TIP_STEP11 = "单击选中激光器头，微调整激光头位置，\n使激光点打在反光片!";
        public const string TIP_STEP12 = "选中工具栏控制台!";
        public const string TIP_STEP13 = "单击“风车启动”按钮，启动控制台风\n洞风机装置!";
        public const string TIP_STEP14 = "选择“手动调速”按钮，可以手动调节风速\n的大小!";
        public const string TIP_STEP15 = "工具栏选中直尺!";
        public const string TIP_STEP = "按任意键继续!";
        public const string TIP_CAMERA = "当前视角处于第三视角，按方向键进行\n移动!";


        //==============================高速列车=================================//
        public const string TIP_TRAIN_STEP1 = "单击桌子上放置的列车,选择列车车型！";
        public const string TIP_TRAIN_STEP2 = "输入列车吹风角度！";
        public const string TIP_TRAIN_STEP3 = "点击操作台，跳转到操作台视角！";
        public const string TIP_TRAIN_STEP4 = "点击“风车启动”按钮，左右拖动“手动调速”\n按钮调节风速大小！";

    }

    /// <summary>
    /// 场景路径
    /// </summary>
    public class SceneLocalPath
    {
        public const int TYPESCENE = 0;
        public const string SCENE_FD = "SCENE_FD";//风动场景
        public const string SCENE_MODEL = "SCENE_MODEL";//模型选择场景
        public const string SCENE_LOADINGFD = "SCENE_LOADING";//风洞实验进度条
        public const string SCENE_LOADINGTRAIN = "SCENE_LOADINGTRAIN";//高速列车进度条
        public const string SCENE_TRAIN = "SCENE_TRAIN";//高速列车场景
        public const string SCENE_START = "SCENE_START";
    }


    /// <summary>
    /// 实验操作步骤主题
    /// </summary>
    public class TxtStepTheme
    {
        public const string STEP_THEME1 = "试样准备";
        public const string STEP_THEME2 = "试样安装";
        public const string STEP_THEME3 = "实验流程";
        public const string STEP_THEME4 = "输出结果";
        public const string STEP_THEME5 = "结果分析";

    }

    /// <summary>
    /// 实验操作步骤主题内容
    /// </summary>
    public class StepThemeContent
    {
        public const string STEPTHEME_CHOBAOPIAN = "选取薄片，如铝薄片、\n不锈钢薄片。";
        public const string STEPTHEME_MEASURE_LENGTH = "正在测量薄板的长度。";
        public const string STEPTHEME_MEASURE_LENGTH_F = "薄板的长度为400mm。";
        public const string STEPTHEME_MEASURE_WIDTH_W = "正在测量薄板的宽度。";
        public const string STEPTHEME_MEASURE_WIDTH_H = "正在测量薄板的厚度。";
        public const string STEPTHEME_MEASURE_WIDTH_W_F = "薄板的宽度为40mm";
        public const string STEPTHEME_MEASURE_WIDTH_H_F = "薄板的宽度为40mm\n薄板的厚度为0.5mm";

        public const string STEPTHEME_JIANQU = "剪取一小块反光片。";
        public const string STEPTHEME_ZHANGTIE = "反光片贴在薄板的受风\n测距固定端3/4处。";
        public const string STEPTHEME_INSTALL = "将试样安装支架上。";
        public const string STEPTHEME_LASER = "接通激光测振仪电源，\n预热两分钟!";
        public const string STEPTHEME_GUDING = "拧紧端部四颗固定螺丝。";
        public const string STEPTHEME_JIGHUAG = "微调整激光头位置\n使激光点打在反光片上。";
        public const string STEPTHEME_INPUT = "输入薄板的弹性模量，泊松比。";
        public const string STEPTHEME_QIDONG = "启动风动风机装置。";
        public const string STEPTHEME_ADDFENGSU = "逐步增加风速未达到Vcr,采集薄板振动响应信号。";
        public const string STEPTHEME_MINVCR = "风速小于Vcr时，薄板位移时间历程曲线及频谱曲线。";
        public const string STEPTHEME_VCR = "风速为Vcr时，薄板位移时间历程曲线及频谱曲线。";
        public const string STEPTHEME_JILU = "记录并获得实验薄板的失稳临界风速Vcr,并验证理论临界风速公式。";

    }

    public enum typeScene
    {
        FD,
        Train,
    }
}
