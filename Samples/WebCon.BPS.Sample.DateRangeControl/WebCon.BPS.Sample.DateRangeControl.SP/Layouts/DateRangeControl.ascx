<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateRangeControl.ascx.cs" Inherits="WebCon.BPS.Sample.DateRangeControl.SP.Layouts.DateRangeControl, $SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="WebCon.WorkFlow.SDK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=c30f1f18c194ceba" %>
<%@ Assembly Name="WebCon.WorkFlow.SDK.SP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=c30f1f18c194ceba" %>
<%@ Register assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" namespace="Microsoft.SharePoint.WebControls" tagprefix="cc1" %>
<tr>
    <td>
        <table border ="1">
            <tr>
                <td>
                    FROM
                </td>

                <td>
                    <cc1:DateTimeControl ID="DateTimeControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    TO
                </td>
                <td>
                    <cc1:DateTimeControl ID="DateTimeControl2" runat="server" />
                </td>
            </tr>
        </table>
    </td>
</tr>
