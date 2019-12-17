using UnityEngine;
using System.Collections;
using AssemblyCSharp;

#region Author & Version
    /* ========================================================================  
    *Author：WLY 
    * File name：
    * Version：V1.0.1
    * Company: 
    * 创建：    
    * Date : 
    * 功能描述：     ............用于UI弹窗的关闭，所有UI窗口都继承该类...................    
    * 版本：     主.次.月日.时分  修改者姓名  修改内容    
    *            ............       ....      .......        
    * ========================================================================
    */
    #endregion

public class UIWindow : MonoSingleton<UIWindow>
{
    /// <summary>
    /// 关闭弹窗
    /// </summary>
    /// 
    public virtual void OffUI()
    {
        Destroy(gameObject);
        ManagerUI.instance.UIOffState();

        MyDebug.Log("==============当前关闭的弹窗是=============：" + gameObject);

    }

    }
    public interface IUIWindow
    {
        void OffUUI();
        

}
