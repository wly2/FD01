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

public class UIPanelImgVResult : UIWindow
{
    public Image imgScale;
    public GameObject[] goImgType;
    int CurrentActiveTxt = 0;

    Sprite sprite = new Sprite();
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
            case "CSYLFB"://车身压力分布
                goImgType[0].SetActive(true);
                goImgType[1].SetActive(false);
                goImgType[2].SetActive(false);
                break;

            case "LCYLFB"://流场压力分布
                goImgType[0].SetActive(false);
                goImgType[1].SetActive(true);
                goImgType[2].SetActive(false);
                break;

            case "LCLXFB"://流场流线分布
                goImgType[0].SetActive(false);
                goImgType[1].SetActive(false);
                goImgType[2].SetActive(true);
                 break;
            //==================车身压力分布===============//
            case "CSYLFB1":
                imgScale.gameObject.SetActive(true);
                sprite = Resources.Load(AssetsConfigPath.TypeTrainSimResult.CSYLFB1, sprite.GetType()) as Sprite;
                imgScale.sprite = sprite;
                break;
            case "CSYLFB2":
                imgScale.gameObject.SetActive(true);
                sprite = Resources.Load(AssetsConfigPath.TypeTrainSimResult.CSYLFB2, sprite.GetType()) as Sprite;
                imgScale.sprite = sprite;
                break;


            //==================流场压力分布===============//
            case "LCYLFB1":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.LCYLFBALL);
                imgScale.sprite = sprites[6];
                break;
            case "LCYLFB2":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.LCYLFBALL);
                imgScale.sprite = sprites[7];
                break;
            case "LCYLFB3":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.LCYLFBALL);
                imgScale.sprite = sprites[8];
                break;
            case "LCYLFB4":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.LCYLFBALL);
                imgScale.sprite = sprites[9];
                break;
            case "LCYLFB5":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.LCYLFBALL);
                imgScale.sprite = sprites[10];
                break;
            case "LCYLFB6":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.LCYLFBALL);
                imgScale.sprite = sprites[11];
                break;

            //==================流场流线分布===============//
            case "LCLXFB1":
                imgScale.gameObject.SetActive(true);
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.LCLXFBALL);
                imgScale.sprite = sprites[0];
                break;
            case "LCLXFB2":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.LCLXFBALL);
                imgScale.sprite = sprites[1];
                break;
            case "LCLXFB3":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.LCLXFBALL);
                imgScale.sprite = sprites[2];
                break;
            case "LCLXFB4":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.LCLXFBALL);
                imgScale.sprite = sprites[3];
                break;
            case "LCLXFB5":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.LCLXFBALL);
                imgScale.sprite = sprites[4];
                break;
            case "LCLXFB6":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.LCLXFBALL);
                imgScale.sprite = sprites[5];
                break;
            case "LCLXFB7":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.LCLXFBALL);
                imgScale.sprite = sprites[6];
                break;
            case "LCLXFB8":
                loadScaleImg(AssetsConfigPath.TypeTrainSimResult.LCLXFBALL);
                imgScale.sprite = sprites[7];
                break;

            case "offScale":
                imgScale.gameObject.SetActive(false);
                break;
        }
    }

    /// <summary>
    /// 加载放大图片
    /// </summary>
    /// <param name="loadPath">加载类型</param>
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
