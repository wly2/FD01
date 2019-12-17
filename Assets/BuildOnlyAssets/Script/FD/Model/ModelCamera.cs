using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;
using DG.Tweening;
using UnityEngine;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0606    14:12
* 功能描述：     ...............................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ModelCamera : ManagerCamera {

    public Transform Tra_TargetBaoPian;

 public void NearZhiChi()
    {
        ManagerFDGame.UIThemeStepProgress = 1;//试样准备
        //ManagerModel.instance.IsOutLine = false;//禁止模型选中效果
        ControlFDGame.hidePanelTool();
        AssemblyCSharp.MyDebug.Log("===========================选中不锈钢薄片========================");
        base.LookAtTarget = Tra_TargetBaoPian;
        base.LookAtAppointTarget();
        MyDebug.Log("######################游戏进行到进程：#############################" + "第" + ControlFDGame.GameProgress + "步");
        ManagerCamera.instance.MethIsCamera("IsCameraMain");

        ManagerUI.instance.UIOffState();


    }
	
}
