using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using AssemblyCSharp;
using AssetsConfigPath;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0605    14:12
* 功能描述：     .............选中模型时，相机跟随模型平滑移动..................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ManagerUI : MonoSingleton<ManagerUI>
{

    readonly Dictionary<UIType, string> UIResources = new Dictionary<UIType, string>();// 存放UI的加载路劲
    #region UI弹窗栈
    private readonly Stack<GameObject> windows = new Stack<GameObject>();
    private GameObject canvas;
    [HideInInspector] public bool isPOP = false;//判断当前是否有弹窗弹出 
    #endregion
    public Image[] UIThemeStep;

    public ManagerUI()
    {
        UIResources.Add(UIType.EnumUISetting, UIConfigPath.UIPanelSetting);
    }

    /// <summary>
    /// UI窗口加载路径
    /// </summary>
    /// <param name="UIname">弹出的UI窗体名称</param>
    public void ShowUIPanel(string UIpath)
    {
        canvas = GameObject.Find(UIConfigPath.HIERARCHY_CANVAS);//所有UIPanel父类
        GameObject obj = Instantiate(Resources.Load(UIpath) as GameObject);
        obj.transform.SetParent(canvas.transform, false);

    }

    /// <summary>
    /// 提示窗口加载路径
    /// </summary>
    /// <param name="UIname"></param>
    public void showTipUIPanel(string UIname)
    {
        canvas = GameObject.Find(UIConfigPath.HIERARCHY_TIPCANVAS);//所有UIPanel父类
        GameObject obj = Instantiate(Resources.Load(UIname) as GameObject);
        obj.transform.SetParent(canvas.transform, false);

    }

    /// <summary>
    /// 弹窗为打开状态,禁止镜头转动
    /// </summary>
    public void UIOpenState()
    {
        isPOP = true;
    }

    /// <summary>
    /// 弹窗关闭状态,镜头移动
    /// </summary>
    public void UIOffState()
    {
        isPOP = false;
    }

    public enum UIType
    {
        EnumUISetting,
        EnumUIGame,
    }


}
