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
* 功能描述：     ...............................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class UIPaneCurVResult : UIWindow
{
    public Image imgScale;
    public GameObject[] goImgType;
    int CurrentActiveTxt = 0;
    Sprite[] sprites = new Sprite[6];

    private void Start()
    {
        goImgType[0].SetActive(true);//默认第一个按钮显示图片
    }


    /// <summary>
    /// 图片类型按钮
    /// </summary>
    /// <param name="str"></param>
    public void btnType(string btnname)
    {
        switch (btnname)
        {
            case "btnCLXS":
                goImgType[0].SetActive(true);
                goImgType[1].SetActive(false);
                break;

            case "btnSLXS":
                goImgType[0].SetActive(false);
                goImgType[1].SetActive(true);
                break;

            //================侧力系数================//
            case "CLXS1":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.CLXSALL);
                imgScale.sprite = sprites[0];
                break;

            case "CLXS2":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.CLXSALL);
                imgScale.sprite = sprites[1];
                break;
            case "CLXS3":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.CLXSALL);
                imgScale.sprite = sprites[2];
                break;

            //========================升力系数=================//
            case "SLXS1":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.SLXSALL);
                imgScale.sprite = sprites[0];
                break;
            case "SLXS2":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.SLXSALL);
                imgScale.sprite = sprites[1];
                break;
            case "SLXS3":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.SLXSALL);
                imgScale.sprite = sprites[2];
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
        sprites = Resources.LoadAll<Sprite>(loadPath);
    }

    public void btnName()
    {
        int NextCurrentTxt = CurrentActiveTxt + 1 >= goImgType.Length ? 0 : CurrentActiveTxt + 1;
        for (int i = 0; i < goImgType.Length; i++)
        {
            goImgType[i].SetActive(i == NextCurrentTxt);
        }
    }
}
