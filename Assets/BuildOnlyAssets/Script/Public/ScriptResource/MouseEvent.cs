using System;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;
using UnityEngine;

#region Author & Version
/* ========================================================================  
*Author：WLY 
* File name：
* Version：V1.0.1
* Company: 
* 创建：    
* Date : 2019.0620    10:28
* 功能描述：     ................判断鼠标左右拖动...............    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class MouseEvent : MonoBehaviour
{

    Vector2 first = Vector2.zero;    //记录鼠标点击的初始位置
    Vector2 second = Vector2.zero;   //记录鼠标移动时的位置
    bool directorToLeft = false;
    bool directorToRight = false;
    bool dragging = false;   //标记是否鼠标在滑动
    float speed = 0;
    public static int rotateValue = 0;
    float moveSpeed = 1f;
    public GameObject GoCube;

    void Update()
    {
        ManagerFDGame.instance.txtVFeng.text = Math.Round((double)MouseEvent.rotateValue, 2) + "";

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "DIY")
                {
                    print("qizi");
                    Vector3 newPosition = Vector3.zero;
                    if (directorToLeft == true)
                    {
                        newPosition = new Vector3(0, -1, 0);
                        speed = 15;
                        MyDebug.Log("left");
                        if (rotateValue > 0)
                        {
                            rotateValue--;
                        }
                        GoCube.transform.rotation = Quaternion.Euler(-31.5f, 0, rotateValue * moveSpeed);

                        MyDebug.Log("===============================y=======================" + rotateValue);
                        // ManagerFDGame.instance.txtVFeng.text = MouseEvent.rotateValue + "";


                    }
                    if (directorToRight == true)
                    {
                        speed = 10;
                        newPosition = new Vector3(0, 1, 0);
                        MyDebug.Log("right");
                        if (rotateValue < 10)
                        {
                            rotateValue++;
                        }
                        GoCube.transform.rotation = Quaternion.Euler(-31.5f, 0, rotateValue * moveSpeed);

                        MyDebug.Log("===============================y=======================" + rotateValue);
                        //ManagerFDGame.instance.txtVFeng.text = MouseEvent.rotateValue + "";
                    }
                }
            }
        }

        var a = rotateValue > 0 && rotateValue <= 3 ? ControlFDGame.IrotateValue = "Line1"
        : rotateValue >= 3 && rotateValue <= 6 ? ControlFDGame.IrotateValue = "Line2"
        : rotateValue != 0 && rotateValue > 6 || rotateValue <=10 ? ControlFDGame.IrotateValue = "Line3"
        : ControlFDGame.IrotateValue = "";

    }


    void OnGUI()
    {

        if (Event.current.type == EventType.MouseDown)
        {
            first = Event.current.mousePosition;//记录鼠标按下的位置 
        }

        dragging = false;

        if (Event.current.type == EventType.MouseDrag)//记录鼠标拖动的位置 
        {
            dragging = true;
            second = Event.current.mousePosition;
            Vector2 slideDirection = second - first;
            float x = slideDirection.x, y = slideDirection.y;

            if (y < x && y > -x)// right 
            {
                directorToRight = true;
                directorToLeft = false;
            }
            else if (y > x && y < -x)// left
            {
                directorToLeft = true;
                directorToRight = false;
            }
        }

    }
}
