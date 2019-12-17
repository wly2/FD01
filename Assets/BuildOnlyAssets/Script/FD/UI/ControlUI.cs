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
* Date : 2019.0619    15:44
* 功能描述：     ..............实现顶部UI逻辑.................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class ControlUI : ManagerUI
{

    void FixedUpdate()
    {
        StepTheme(ManagerFDGame.UIThemeStepProgress);
    }

    //===================================Top==================================//
    public void StepTheme(int value)
    {
        Sprite sprite = new Sprite();
        switch (value)
        {

            case 1://试样准备
                ManagerFDGame.instance.txtStepTheme.text = AssetsConfigPath.TxtStepTheme.STEP_THEME1;
                sprite = Resources.Load(AssetsConfigPath.typeTopStep.STEP1, sprite.GetType()) as Sprite;
                UIThemeStep[0].sprite = sprite;
               // UIThemeStep[0].SetNativeSize();
                break;

            case 2://试样安装
                ManagerFDGame.instance.txtStepTheme.text = AssetsConfigPath.TxtStepTheme.STEP_THEME2;
                sprite = Resources.Load(AssetsConfigPath.typeTopStep.STEP2, sprite.GetType()) as Sprite;
                UIThemeStep[1].sprite = sprite;
                break;

            case 3://试样流程
                ManagerFDGame.instance.txtStepTheme.text = AssetsConfigPath.TxtStepTheme.STEP_THEME3;
                sprite = Resources.Load(AssetsConfigPath.typeTopStep.STEP3, sprite.GetType()) as Sprite;
                UIThemeStep[2].sprite = sprite;
                break;

            case 4://输出结果
                ManagerFDGame.instance.txtStepTheme.text = AssetsConfigPath.TxtStepTheme.STEP_THEME4;
                sprite = Resources.Load(AssetsConfigPath.typeTopStep.STEP4, sprite.GetType()) as Sprite;
                UIThemeStep[3].sprite = sprite;
                break;

            case 5://结果分析
                ManagerFDGame.instance.txtStepTheme.text = AssetsConfigPath.TxtStepTheme.STEP_THEME5;
                sprite = Resources.Load(AssetsConfigPath.typeTopStep.STEP5, sprite.GetType()) as Sprite;
                UIThemeStep[4].sprite = sprite;
                break;
        }
    }
}
