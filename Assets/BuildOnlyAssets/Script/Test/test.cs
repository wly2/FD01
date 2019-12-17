using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using cakeslice;
using DG.Tweening;
using UnityEngine.UI;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0606    14:12
* 功能描述：     ...............测试脚本................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class test : MonoBehaviour {

    public GameObject goOutLine;
    public List<Image> img = new List<Image>();
    [Range(1.0f, 10.0f)]
    public float lineThickness = 0;

    private void Start ()
    {
       
        // goOutLine.GetComponent<cakeslice.Outline>().enabled = false;

    }

    private void Update()
    {
    }

    void outLineTip()
    {
        InvokeRepeating("tipOutLine", 0.1f,0.3f);
        InvokeRepeating("hideOutLine", 0.2f,0.3f);
    }

    private void tipOutLine()
    {
        goOutLine.GetComponent<cakeslice.Outline>().enabled = true;
    }

    private void hideOutLine()
    {
        goOutLine.GetComponent<cakeslice.Outline>().enabled = false;
    }

    public void imgMove()
    {
        img[0].transform.DOMoveY(5, 1).From();

    }
}
