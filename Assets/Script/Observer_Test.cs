using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observer_Test : Observer
{
    private Text send_Text, post_text01,post_text02;

    void Awake()
    {
        send_Text = this.transform.Find("SendNotification/Text").GetComponent<Text>();
        post_text01 = this.transform.Find("PostNotifcation01/Text").GetComponent<Text>();
        post_text02 = this.transform.Find("PostNotifcation02/Text").GetComponent<Text>();
        //注册观察者
        ObserverManaager.RegisterObserver(this);
        //注册观察者消息通知
        ObserverManaager.RegisterNotification(this);
    }
    void Start()
    {

    }

    public override string GetName()
    {
        return "observer_test";
    }

    public override string[] GetNote()
    {
        return new string[]
        {
            NoteConstant.POST_TEST,NoteConstant.SEND_TEST
        };
    }

    public override void OnNotification(string note_, EventParm data_)
    {
        switch (note_)
        {
            case NoteConstant.POST_TEST:
                {
                    if (data_.IsExist("postNotification"))
                    {
                        post_text01.text = (string)data_["postNotification"];
                    }
                    

                    break;
                }
            case NoteConstant.SEND_TEST:
                {
                    if (data_.IsExist("sendNotification"))
                    {
                        send_Text.text = (string)data_["sendNotification"];
                    }
                    if (data_.IsExist("postNotification"))
                    {
                        post_text02.text = (string)data_["postNotification"];
                    }

                    break;
                }
            default:
                break;
        }
    }

    void OnDestroy()
    {
        //撤消观察者
        ObserverManaager.UnregiserObserver(this);
        //撤消观察者消息通知
        ObserverManaager.UnregiserNotification(this);
    }

}
