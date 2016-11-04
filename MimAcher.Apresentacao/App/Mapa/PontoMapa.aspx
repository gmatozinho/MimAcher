<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PontoMapa.aspx.cs" Inherits="MimAcher.Apresentacao.App.Mapa.PontoMapa" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <cc1:GMap 
		ID="GMap1" 
		runat="server" 
		Width="1152px" 
		Height="600px" 
		enableServerEvents="True"
		serverEventsType="AspNetPostBack"
		key="AIzaSyDg2gdbqcXWG0AP4WAGWlZYjoCfzQyZBdI"
					
	/>
    </div>
    </form>
</body>
</html>