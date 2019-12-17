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
* 功能描述：     ...............................    
* 版本：     主.次.月日.时分  修改者姓名  修改内容    
*            ............       ....      .......        
* ========================================================================
*/
#endregion

public class AniPlay : MonoBehaviour {

      //定义参数获取VideoPlayer组件和RawImage组件

    private VideoPlayer videoPlayer;

    private RawImage rawImage;

    // Use this for initialization

    void Start () {

        //获取场景中对应的组件

        videoPlayer = this.GetComponent <VideoPlayer> ();

        rawImage = this.GetComponent <RawImage> ();

    }

    

    // Update is called once per frame

    void Update () {

        //如果videoPlayer没有对应的视频texture，则返回

        if(videoPlayer.texture == null){

            return;

        }

        //把VideoPlayerd的视频渲染到UGUI的RawImage

        rawImage.texture = videoPlayer.texture;

    }

	
}
