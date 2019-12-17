using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public class UIPanelYuanliTrain : UIWindow {

    public GameObject[] goYuanli;

    public void btnType(string btnName)
    {
        switch (btnName)
        {
            case "txt":
                goYuanli[0].SetActive(true);
                goYuanli[1].SetActive(false);
                break;

            case "img":
                goYuanli[1].SetActive(true);
                goYuanli[0].SetActive(false);
                break;
        }
    }


}
