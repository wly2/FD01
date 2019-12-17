using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using AssetsConfigPath;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2.19.6.5
* 功能描述：     ...............实现点击选中模型边缘高光的效果................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

namespace cakeslice
{
    public class ModelOutLine : ManagerModel
    {
      // public GameObject goOutLine;

       void Start ()
       {
           
       }

       void Update ()
       {
           //goOutLine.GetComponent<Outline>().enabled = true;
       }

        void OnMouseEnter()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                hitInfo.collider.gameObject.GetComponent<Outline>().enabled = true;
                MyDebug.Log("==================鼠标经过薄片==========================");
            }
        }

        void OnMouseExit()
        {
            if (hitInfo.collider.gameObject.GetComponent<Outline>() != null)
            {
                MyDebug.Log("==================鼠标离开薄片==========================");
                hitInfo.collider.gameObject.GetComponent<Outline>().enabled = false;
            }
        }
    }
}


