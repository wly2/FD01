using AssemblyCSharp;
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
* Date : 2019.0717    16：00
* 功能描述：     ..............仿真结果,查看数据、图像等.................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class UIPanelVResult : UIWindow
{

    public void btnTypeResult(string str)
    {
        switch (str)
        {
            //=====================================风洞实验======================================//
            case "数据":
                MyDebug.Log("===========================数据======================");
                break;

            case "曲线":
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPANEL_FD_CURVRESULT);
                ManagerUI.instance.UIOpenState();
                MyDebug.Log("===========================曲线======================");
                break;

            case "图片":
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPANEL_FD_IMGVRESULT);
                ManagerUI.instance.UIOpenState();
                MyDebug.Log("===========================图片======================");
                break;

            case "动画":
                base.OffUI();
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPANEL_FD_ANIVRESULT);
                ManagerUI.instance.UIOpenState();
                MyDebug.Log("===========================动画======================");
                break;


            //=====================================风洞实验======================================//
            case "列车数据":
               // base.OffUI();
                MyDebug.Log("===========================数据======================");
                break;

            case "列车曲线":
                //base.OffUI();
                MyDebug.Log("===========================曲线======================");
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPANEL_TRAIN_CURVRESULT);
                ManagerUI.instance.UIOpenState();
                break;

            case "列车图片":
                //base.OffUI();
                MyDebug.Log("===========================图片======================");
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPANEL_TRAIN_IMGVRESULT);
                ManagerUI.instance.UIOpenState();
                break;

            case "列车动画":
                //base.OffUI();
                MyDebug.Log("===========================动画======================");
                break;
        }
    }


}
