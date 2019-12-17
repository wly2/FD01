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
* 功能描述：     ..............仿真结果图片.................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class UIPanelFDImgVResult : UIWindow {

    Sprite sprite = new Sprite();
    // public GameObject[] imgScale;
    public Image imgScale;

    /// <summary>
    /// 按钮事件
    /// </summary>
    /// <param name="btnName">按钮名称</param>
    public void btnType(string btnName)
    {
        switch (btnName)
        {
            case "ScaleYLFB"://压力分布
                loadScaleImg(AssetsConfigPath.TypeFDSimResult.YLFB);
                break;
            case "ScaleSUFB"://速度分布
                loadScaleImg(AssetsConfigPath.TypeFDSimResult.SDFB);
                break;
            case "ScaleSDSL"://速度矢量
                loadScaleImg(AssetsConfigPath.TypeFDSimResult.SDSL);
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
