using UnityEngine;
using System.Collections;
using AssetsConfigPath;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019 0624   14：00
* 功能描述：     ................主场景设置模块...............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class UIPanelSetting : UIWindow
{
    private void Start()
    {
        GameObject obj = GameObject.Find(UIConfigPath.UIPanelSetting_OFF);

    }

    public void UIOff()
    {
        base.OffUI();
        ManagerUI.instance.UIOffState();
    }

    /// <summary>
    /// 跳转开始场景
    /// </summary>
    public void ExitScene()
    {
        SceneManager.LoadScene(SceneLocalPath.SCENE_START);
        clearFDData();
        clearTrainData();
    }

    /// <summary>
    ///清除风洞实验实验所有数据
    /// </summary>
    public void clearFDData()
    {
        ManagerFDGame.GameProgress = 0;
        ManagerFDGame.UIThemeStepProgress = 0;
        UIPanelReport.instance.txt_Length = null;
        UIPanelReport.instance.txt_Width = null;
        UIPanelReport.instance.txt_Land = null;
        UIPanelReport.instance.txtVcr = null;
        UIPanelReport.instance.txtVcr = null;
        UIPanelReport.instance.txtV = null;
        UIPanelReport.instance.txt_BPType = null;
        ManagerFDGame.measureValue = 0;

    }

    /// <summary>
    /// 清除列车实验所有数据
    /// </summary>
    public void clearTrainData()
    {
        UIPanelReportTrain.instance.txrZhuli = null;
        UIPanelReportTrain.instance.txtangleInstall = null;
        UIPanelReportTrain.instance.txtCeli = null;
        UIPanelReportTrain.instance.txtShengli = null;
        UIPanelReportTrain.instance.txtTypeCar = null;
        UIPanelReportTrain.instance.txtVFD = null;
    }
}
