<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NACAreaAtuacao.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MimAcher.Apresentacao.App.NACAreaAtuacao" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="main">
   
<%-- Window --%>
	<ext:Window ID="NACAreaAtuacaoWindowId" Width="600" Height="355" Modal="true" runat="server" Hidden="true">
		<Items>

		<%-- Form --%>
		<ext:FormPanel ID="NACAreaAtuacaoFormPanelId" runat="server" Title="NACAreaAtuacao" BodyPadding="5" ButtonAlign="Right" Layout="Column">    
							   
			<FieldDefaults LabelAlign="Left" MsgTarget="Side" Size="100"  AllowBlank="false" />
														
			<Items> 
			
				<ext:FieldSet ID="NACAreaAtuacaoFieldSetId" runat="server" Title="NACAreaAtuacao" MarginSpec="0 0 0 10">                                                      
					<Defaults>
						<ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
						<ext:Parameter Name="MsgTarget" Value="side" />                                
					</Defaults>
					<Items>

						<%-- Código do AreaAtuacao Aprender --%>
						<ext:TextField ID="cod_nac_area_atuacaoId" Name="cod_nac_area_atuacao"  runat="server" FieldLabel="Código" />

						<%-- Combobox do NAC --%>
						<ext:ComboBox ID="cod_nacId" Width="300" Name="cod_nac" AllowBlank="false" runat="server" FieldLabel="NAC" ValueField="cod_nac_combo" DisplayField="nome_representante_combo">
							<Store>
								<ext:Store ID="StoreNACId" runat="server">
									<Model>
										<ext:Model ID="ModeNACId" runat="server">
											<Fields>
												<ext:ModelField Name="cod_nac_combo" Mapping="cod_nac" />
												<ext:ModelField Name="nome_representante_combo" Mapping="nome_representante" />
											</Fields>
										</ext:Model>
									</Model>
								</ext:Store>
							</Store>
						</ext:ComboBox>   

						<%-- Combobox do Área de Atuação --%>
						<ext:ComboBox ID="cod_area_atuacaoId" Width="300" Name="cod_area_atuacao" AllowBlank="false" runat="server" FieldLabel="Nome do AreaAtuacao" ValueField="cod_area_atuacao_combo" DisplayField="nome_combo">
							<Store>
								<ext:Store ID="StoreAreaAtuacaoId" runat="server">
									<Model>
										<ext:Model ID="ModelAreaAtuacaoId" runat="server">
											<Fields>
												<ext:ModelField Name="cod_area_atuacao_combo" Mapping="cod_area_atuacao" />
												<ext:ModelField Name="nome_combo" Mapping="nome" />
											</Fields>
										</ext:Model>
									</Model>
								</ext:Store>
							</Store>
						</ext:ComboBox>   
												
					</Items>
				</ext:FieldSet>
			</Items>

			<BottomBar>
				<ext:StatusBar ID="NACAreaAtuacaoBarId" runat="server" />
			</BottomBar>

			<%-- Botões do Form --%>
			<Buttons>
				<ext:Button ID="SaveButtonId" runat="server" Text="Save" Disabled="false" FormBind="true" OnDirectClick="Save" />
				<ext:Button ID="CancelButtonId" runat="server" Text="Cancel" OnClientClick="#{NACAreaAtuacaoWindowId}.hide()"/>
			</Buttons>

			</ext:FormPanel>
		</Items>   
	</ext:Window>

	<%-- Store da Grid --%>
	<Store>
		<ext:Store 
			ID="StoreNACAreaAtuacaoId" 
			runat="server" 
			PageSize="31" 
			OnReadData="List" 
			RemoteSort="true" 
			AutoLoad="true">
			<Model>
				<ext:Model ID="ModelNACAreaAtuacaoId" runat="server" IDProperty="cod_nac_area_atuacao">
					<Fields>
						<ext:ModelField Name="cod_nac_area_atuacao" Type="Int" />																		
						<ext:ModelField Name="cod_nac" Type="Int" />
						<ext:ModelField Name="nome" ServerMapping="MA_NAC.nome" />                         
						<ext:ModelField Name="cod_area_atuacao"  Type="Int" />
						<ext:ModelField Name="nome" ServerMapping="MA_AREA_ATUACAO.nome" />                                                                                                                                       
					</Fields>
				</ext:Model>
			</Model>
		</ext:Store>
	</Store>

 <%-- Grid --%> 
 <ext:GridPanel 
		ID="NACAreaAtuacaoGridPanelId"
		runat="server" 
		Title="Gerenciamento de NACAreaAtuacao"
		StoreID="StoreNACAreaAtuacaoId">         
		<%--Height="1500"--%>    

		<%-- Colunas da Grid --%>
		<ColumnModel>
			<Columns>
				<ext:Column ID="codNACAreaAtuacaoColumnId" runat="server" Text="Código" DataIndex="cod_nac_area_atuacao" Visible="false" />
				<ext:Column ID="nomeRepresentanteColumnId" runat="server" Text="Representante do NAC" Flex="2" DataIndex="nome_representante" />                                  								
				<ext:Column ID="nomeColumnId" runat="server" Text="Área de Atuação" Flex="2" DataIndex="nome" />                                  				
			</Columns>            
		</ColumnModel>    
		   
		<SelectionModel>
			<ext:RowSelectionModel ID="NACAreaAtuacaoRowSelectionModelId" Mode="Single" runat="server" >
					<Listeners>                        
						<Select Handler="#{NACAreaAtuacaoFormPanelId}.getForm().loadRecord(record); 
										 #{EditButtonId}.setDisabled(false);
										 #{DeleteButtonId}.setDisabled(false);" />                      
					</Listeners>                    
			</ext:RowSelectionModel>                        
		</SelectionModel>  

		<%-- Botões da Grid --%>
		<TopBar>
			<ext:Toolbar ID="ToolbarId" runat="server">
				<Items>
					<%-- Incluir --%>
					<ext:Button ID="IncluirButtonId" runat="server" Text="Novo Registro" Icon="PageAdd" OnClientClick="#{NACAreaAtuacaoWindowId}.show();#{NACAreaAtuacaoFormPanelId}.getForm().reset();" />

					<%-- Edit --%>
					<ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" Disabled="true" >
						<DirectEvents>
							<Click OnEvent="Edit">
								<ExtraParams>
									<ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{NACAreaAtuacaoGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_nac_area_atuacao" />                                
								</ExtraParams>
							</Click>
						</DirectEvents>
					</ext:Button>

					<%-- Delete --%>
					<ext:Button ID="DeleteButtonId" runat="server" Text="Excluir Registro" Icon="Delete" Disabled="true" >
						<DirectEvents>
							<Click OnEvent="Delete">
								<Confirmation ConfirmRequest="true" Message="Deseja excluir este registro?" />                                
							</Click>
						</DirectEvents>
					</ext:Button>

					<%-- Atualizar --%>
					<ext:Button ID="AtualizarButtonId" runat="server" Text="Atualizar" Icon="Reload" OnDirectClick="List" /> 
				</Items>
			</ext:Toolbar>
		</TopBar>

		<%-- Double Click --%>
		<DirectEvents>
			<ItemDblClick OnEvent="Edit">
				<ExtraParams>                    
					<ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{NACAreaAtuacaoGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_nac_area_atuacao" />                                
				</ExtraParams>
			</ItemDblClick>
		</DirectEvents>

		<BottomBar>
			<ext:PagingToolbar ID="PagingToolbarId" runat="server" />
		</BottomBar>

	</ext:GridPanel>

</asp:Content>

