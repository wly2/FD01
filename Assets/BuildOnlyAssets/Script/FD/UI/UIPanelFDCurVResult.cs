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
* 功能描述：     .................仿真结果曲线图..............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class UIPanelFDCurVResult : UIWindow {
    public Image imgScale;
    Sprite sprite = new Sprite();

    /// <summary>
    /// 按钮事件
    /// </summary>
    /// <param name="btnName">按钮名称</param>
    public void btnType(string btnName)
    {
       
        switch (btnName)
        {
            case "ScaleJDWY1"://节点位移1
                loadScaleImg(AssetsConfigPath.TypeFDSimResult.JDWY1);
                break;
            case "ScaleJDWY2"://节点位移2
                loadScaleImg(AssetsConfigPath.TypeFDSimResult.JDWY2);
                break;
            case "ScaleJDWY3"://节点位移3
                loadScaleImg(AssetsConfigPath.TypeFDSimResult.JDWY3);
                break;


            case "offScale":
                imgScale.gameObject.SetActive(false);
                break;
        }
    }


    /// <summary>
    /// 加载放大图片
    /// </summary>
    /// <param name="loadPath"></param>
    public void loadScaleImg(string loadPath)
    {
        imgScale.gameObject.SetActive(true);
        sprite = Resources.Load(loadPath, sprite.GetType()) as Sprite;
        imgScale.sprite = sprite;
    }

}
