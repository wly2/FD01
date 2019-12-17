using UnityEngine;
using System.Collections;
using AssetsConfigPath;
using UnityEngine.UI;
using AssemblyCSharp;

 #region Author & Version
    /* ========================================================================  
    *Author：WLY 
    * File name：
    * Version：V1.0.1
    * Company: 
    * 创建：    
    * Date : 
    * 功能描述：     ...............................    
    * 版本：     主.次.月日.时分  修改者姓名  修改内容    
    *            ............       ....      .......        
    * ========================================================================
    */
    #endregion

public class UIPanelTool : UIWindow
{
    public CameraLookAt cameraLookAt;

    private void Start()
    {
        cameraLookAt.GetComponent<CameraLookAt>();
        GameObject obj = GameObject.Find(UIConfigPath.UIPanelTool_OFF);
    }

    public void UIOff()
    {
       ControlFDGame.hidePanelTool();
       ManagerUI.instance.UIOffState();
    }
}
