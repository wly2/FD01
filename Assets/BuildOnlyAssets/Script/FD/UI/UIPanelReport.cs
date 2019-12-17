using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;
using UnityEngine;
using UnityEngine.UI;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0702         10:11
* 功能描述：     ................风洞实验实验报告...............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class UIPanelReport : MonoSingleton<UIPanelReport>
{
    public GameObject Go_UIReport;
    public Text txt_Length;//长度
    public Text txt_Width;//宽度
    public Text txt_Land;//厚度
    public Text txt_BPType;//薄片类型
    public Text txtVcr;//理论值
    public Text txtV;//临界速度
    public Text txtErrorRate;//误差率


    public void OffUI()
    {
        Destroy(Go_UIReport);
        ManagerUI.instance.UIOffState();
    }

    void Update()
    {
        Report();
    }

    public void Report()
    {
        if (Go_UIReport.activeSelf && ManagerFDGame.instance.isBXG == true) txt_BPType.text = ManagerFDGame.bpType.BP_BXG;
        if (Go_UIReport.activeSelf && ManagerFDGame.instance.isLHJ == true) txt_BPType.text = ManagerFDGame.bpType.BP_LHJ;
        if (ManagerFDGame.measureValue == 1) txt_Length.text = ManagerFDGame.EmeasureBPvalue.measureLength + "";

        if (ManagerFDGame.measureValue == 2)
        {
            txt_Length.text = ManagerFDGame.EmeasureBPvalue.measureLength + "";
            txt_Width.text = ManagerFDGame.EmeasureBPvalue.measrureWidth + "";
            txt_Land.text = ManagerFDGame.EmeasureBPvalue.measureLand + "";
        }

        if (ManagerFDGame.UIThemeStepProgress == 5)
        {

            txtV.text = "8.5";
            instance.txtErrorRate.text = "12%";
            txtVcr.text = "7.5";
        }

    }



}
