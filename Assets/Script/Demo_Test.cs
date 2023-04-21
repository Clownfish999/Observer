using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Demo_Test : Observer {


    public void OnClickSendNotificationBtn()
    {
        ObserverManaager.SendNotification("observer_test", NoteConstant.SEND_TEST, new EventParm("sendNotification", "发送消息"));

    }

    public void OnClickPostNotificationBtn_01()
    {
        ObserverManaager.PostNotifcation(NoteConstant.POST_TEST, new EventParm("postNotification", "广播消息01"));
    }

    public void OnClickPostNotificationBtn_02()
    {
        ObserverManaager.PostNotifcation(NoteConstant.SEND_TEST, new EventParm("postNotification", "广播消息02"));
    }


}
