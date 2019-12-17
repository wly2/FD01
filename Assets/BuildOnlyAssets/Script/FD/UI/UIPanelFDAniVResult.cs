using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0606    14:12
* 功能描述：     ................仿真结果视频模块...............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class UIPanelFDAniVResult : UIWindow
{

    Sprite sprite = new Sprite();
    public RawImage videoScale;
    public VideoPlayer videoUrl;

    private void Start()
    {
        // var videoUrl = imgScale.GetComponent<VideoPlayer>();
    }

    public void btnType(string btnName)
    {
        switch (btnName)
        {
            case "ScaleSDFB"://速度分布
                loadScaleImg(AssetsConfigPath.TypeFDSimResult.VSDFB);
                break;
            case "ScaleSDSL"://速度矢量
                loadScaleImg(AssetsConfigPath.TypeFDSimResult.VSDSL);
                break;
            case "ScaleWLFB"://渦量分布
                loadScaleImg(AssetsConfigPath.TypeFDSimResult.VWLFB);
                break;
            case "ScaleYLFB"://压力分布
                loadScaleImg(AssetsConfigPath.TypeFDSimResult.VYLFB);
                break;
            case "offScale":
                videoScale.gameObject.SetActive(false);
                break;
        }
    }

    /// <summary>
    /// 加载放大视频
    /// </summary>
    /// <param name="loadPath"> 加载路径</param>
    public void loadScaleImg(string loadPath)
    {
        videoScale.gameObject.SetActive(true);
        videoUrl.url = loadPath;
    }
}
