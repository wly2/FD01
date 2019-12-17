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
* Date : 2019.9.25  13:50
* 功能描述：     .................实现UI逻辑..............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion


public class UIStrerch : MonoBehaviour {
    [SerializeField] Image imgMenu;
    [SerializeField]Image imgHelp;

    private void Start()
    {
        //imgMenu.gameObject.SetActive(false);
        //imgHelp.gameObject.SetActive(false);
    }

    public void btnMenu(string btnName)
    {
        switch (btnName)
        {
            case "菜单":
                break;
            case "设置":
                break;
            case "帮助":

                break;
            case "退出":
                break;
            case "测试":
                break;
        }
    }

    public void btnHelp()
    {
        if (!imgHelp.gameObject.activeSelf)
        {
            MyDebug.Log("=============按下EsCape键=============");
            imgHelp.gameObject.SetActive(true);
        }
        else imgHelp.gameObject.SetActive(false);
    }
	
}
