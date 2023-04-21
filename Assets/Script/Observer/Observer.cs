using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 观察者   
/// </summary>
public class Observer : MonoBehaviour
{
    /// <summary>
    /// 发送信息
    /// </summary>
    /// <param name="name_">预制体名字</param>
    /// <param name="note_">定义的消息ID</param>
    /// <param name="data_">发送的数据</param>
    public void SendNotification(string name_, string note_, EventParm data_)
    {
        ObserverManaager.SendNotification(name_, note_,data_);
    }

    /// <summary>
    /// 广播消息
    /// </summary>
    /// <param name="note_">定义的消息ID</param>
    /// <param name="data_">发送的数据</param>
    public void PostNotification(string note_, EventParm data_)
    {
        ObserverManaager.PostNotifcation(note_, data_);
    }

    /// <summary>
    /// 得到观察者名字，注册和撤销观察者要用到
    /// </summary>
    /// <returns></returns>
    public virtual string GetName()
    {
        return null;
    }

    /// <summary>
    /// 得到观察者通知ID，注册和撤销通知要用到
    /// </summary>
    /// <returns></returns>
    public virtual string[] GetNote()
    {
        return null;
    }


    /// <summary>
    /// 处理消息
    /// </summary>
    /// <param name="note_">消息ID</param>
    /// <param name="data_">消息数据</param>
    public virtual void OnNotification(string note_, EventParm data_)
    {

    }

}

