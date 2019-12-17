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
* 功能描述：     ..............仿真结果输入数据，输入数据输出仿真结果.................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class UIPanelInputResult : UIWindow
{
    [SerializeField] InputField txtInputV;//风速值
    string maxInputV = 10 + "";
    string minInputV = 0 + "";

    private void Start()
    {
        txtInputV = GetComponent<InputField>();
    }

    private void Update()
    {
        //if (txtInputV.text > 10 + "")
        //{

        //}
    }

    /// <summary>
    /// 仿真结果输入数据
    /// </summary>
    /// <param name="str"></param>
    public void btnResult(string str)
    {
        switch (str)
        {
            //======================================风洞实验==================================//
            case "":
                break;
            case "btnBXG":
                break;
            case "sureFD":
                MyDebug.Log("========================确认键========================");
                base.OffUI();
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPanelVResult);
                ManagerUI.instance.UIOpenState();
                break;

            //======================================列车实验==================================//
            case "sureTrain":
                base.OffUI();
                ManagerUI.instance.ShowUIPanel(AssetsConfigPath.TestAbout.UIPANEL_TRAIN_VRESULT);
                ManagerUI.instance.UIOpenState();
                break;


        }
    }


}
