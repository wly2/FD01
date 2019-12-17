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
* Date : 2019.0606    14:12
* 功能描述：     ................高速列车实验报告...............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class UIPanelReportTrain : MonoSingleton<UIPanelReportTrain> {
    public GameObject uiPanelReport;

    public Text txtTypeCar;//车型
    public Text txtVFD;//风动速度
    public Text txtangleInstall;//安装角度
    public Text txtShengli;//升力系数
    public Text txrZhuli;//阻力系数
    public Text txtCeli;//侧力系数


    private void FixedUpdate()
    {
        txtTypeCar.text = ManagerTrainGame.txtTypeCar;
    }

    public void OffUI()
    {
        Destroy(uiPanelReport);
        ManagerUI.instance.UIOffState();
    }



}
