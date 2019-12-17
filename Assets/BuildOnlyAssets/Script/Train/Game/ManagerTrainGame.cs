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
* Date : 2019.0724    14:12
* 功能描述：     ..............高速列车用于场景赋值，功能管理.................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ManagerTrainGame : MonoSingleton<ManagerTrainGame> {

    public Text txtTipTrain;//面板步骤提示
    public GameObject canvasUI;//UI层
    public GameObject canvasModel;//模型层
    public GameObject canvasMian;
    public GameObject canvasShowModel;
    public GameObject canvasFD;
    public GameObject canvasTrain;
    public GameObject tipControl;
    public CameraLookAtTrain cameraLookAt;
    public static int gamePrrogress = 0;
    public GameObject controlShow;//显示屏
    public GameObject controlStart;
    public Text txtVFeng;
    public GameObject trainDone;

    //===================数据====================//
    public static string txtTypeCar;//列车类型


}
