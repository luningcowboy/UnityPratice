using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TestDetailedInfoBox : MonoBehaviour
{
    [DetailedInfoBox("详情请点击", "xxxxxxxxxxx")]
    public string message = "无";

    [DetailedInfoBox("详情请点击", "", InfoMessageType.Info)]
    public string InfoMessage = "null";

    [DetailedInfoBox("详情请点击", "", InfoMessageType.Warning)]
    public string WarningMessage = "";

    [DetailedInfoBox("详情请点击", "", InfoMessageType.Error)]
    public string ErrorMessage = "";
    [DetailedInfoBox("详情请点击", "", InfoMessageType.Error, VisibleIf="VisibleFunction")]
    public string VisibleMessage = "";
    [DetailedInfoBox("详情请点击", "", InfoMessageType.Error, VisibleIf="NoVisibleFunction")]
    public string NoVisibleMessage = "";

    public bool VisibleFunction()
    {
        return true;
    }

    public bool NoVisibleFunction()
    {
        return false;
    }
}
