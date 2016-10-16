<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MimAcher.Apresentacao.Login" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>IFES - MimAcher</title>
    <ext:ResourceManager ID="ResourceManager1" runat="server" Theme="Gray">
    </ext:ResourceManager>
    <link rel="stylesheet" type="text/css" href="~/Styles/estilo.css"/>
</head>
<body style="background-color:white;">
    <div id="ext-comp-1003" class=" x-panel x-panel-noborder x-border-panel" style="left: 0px; top: 0px; ">
        <div class="x-panel-bwrap" id="ext-gen15">
            <div class="x-panel-body x-panel-body-noheader x-panel-body-noborder" id="ext-gen16" style="height: 70px;">
                <div id="header" style="height:70px;">            
                    <div class="api-title"> 
                        <em>IFES</em>                
                    </div>            
                    <div class="api-title">                 
                        MimAcher
                    </div>            
                </div>
            </div>
            
        </div>
    </div>    
    <form id="LoginFormId" runat="server">     
        <ext:Window ID="LoginWindowId" runat="server" Closable="false" Resizable="false" Height="150" Icon="Lock" Title="Login" Draggable="false" Width="350" Modal="false" BodyPadding="5" Layout="Form" StyleSpec="background-color:acacbd;">                
            <Items>
                <ext:TextField AutoFocus="true" AutoFocusDelay="50" ID="emailId" runat="server" FieldLabel="Email" AllowBlank="true" BlankText="Email obrigatório." EnableKeyEvents="true">                                               
                    <Listeners>                    
                        <KeyPress Handler="if ((e.getKey() == e.ENTER)) { #{btnLogin}.fireEvent('click'); }" />
                    </Listeners>
                 </ext:TextField>
                 <ext:TextField ID="senhaId" runat="server" InputType="Password" FieldLabel="Senha" AllowBlank="true" BlankText="Senha obrigatória." EnableKeyEvents="true">         
                    <Listeners>
                            <%-- <KeyPress Handler="if ((e.getKey() == e.ENTER)) {
                                            #{DirectMethods}.Login_Click();
                                        }" />--%>
                            <KeyPress Handler="if ((e.getKey() == e.ENTER)){ #{btnLogin}.fireEvent('click'); }"/>
                    </Listeners>                
                 </ext:TextField>                
            </Items>
            <Buttons>
                <ext:Button ID="LoginButtonId" runat="server" Text="Login" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="Logar_Click">
                            <%-- <Confirmation ConfirmRequest="true" Title="Title" Message="Message" />--%>
                            <EventMask ShowMask="true" Msg="Verificando..." MinDelay="1000" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Buttons>                           
        </ext:Window>        
    </form>
</body>
</html>
