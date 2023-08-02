using System;
using System.Windows.Forms;

namespace DesktopApp2
{
    partial class FormICMSMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormICMSMain));
            this.TreeViewCustomer = new System.Windows.Forms.TreeView();
            this.checkBoxInactiveCustomers = new System.Windows.Forms.CheckBox();
            this.tabControlPlantLocations = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.balanceToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPageDefaultMachines = new System.Windows.Forms.TabPage();
            this.btAddMachine = new System.Windows.Forms.Button();
            this.buttonUpdateHoldDown = new System.Windows.Forms.Button();
            this.textBoxHoldDown = new System.Windows.Forms.TextBox();
            this.labelMachineHoldDown = new System.Windows.Forms.Label();
            this.labelDefaultSSSmFinish = new System.Windows.Forms.Label();
            this.comboBoxDefaultSSSmFinish = new System.Windows.Forms.ComboBox();
            this.groupBoxDefaultScrapUnit = new System.Windows.Forms.GroupBox();
            this.radioButtonScrapUnitLBS = new System.Windows.Forms.RadioButton();
            this.radioButtonScrapUnitInches = new System.Windows.Forms.RadioButton();
            this.buttonDefaultCTLThickDiscUpdate = new System.Windows.Forms.Button();
            this.textBoxDefaultsCTLThickDiscrepency = new System.Windows.Forms.TextBox();
            this.labelCTLThicknessDiscrepency = new System.Windows.Forms.Label();
            this.buttonClClDiffTrimRemove = new System.Windows.Forms.Button();
            this.comboBoxClClDiffTrim = new System.Windows.Forms.ComboBox();
            this.labelClClDiffTrimVal = new System.Windows.Forms.Label();
            this.labelClClDiffTrimTo = new System.Windows.Forms.Label();
            this.labelClClDiffTrimFrom = new System.Windows.Forms.Label();
            this.buttonClClDiffAddTrim = new System.Windows.Forms.Button();
            this.listViewClClDiffTrim = new System.Windows.Forms.ListView();
            this.columnHeaderClClDiffTrimFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderClClDiffTrimTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderClClDiffTrimVal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxClClDiffTrimValue = new System.Windows.Forms.TextBox();
            this.textBoxClClDiffTrimTo = new System.Windows.Forms.TextBox();
            this.textBoxClClDiffTrimFrom = new System.Windows.Forms.TextBox();
            this.labelDefaultClClSameFinish = new System.Windows.Forms.Label();
            this.comboBoxDefaultClClSameFinish = new System.Windows.Forms.ComboBox();
            this.tabPageReportDrive = new System.Windows.Forms.TabPage();
            this.cbReportDrive = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageWorkers = new System.Windows.Forms.TabPage();
            this.buttonAddWorker = new System.Windows.Forms.Button();
            this.dataGridViewWorker = new System.Windows.Forms.DataGridView();
            this.WorkerFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.WorkerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageLeadTime = new System.Windows.Forms.TabPage();
            this.dataGridViewLeadTimes = new System.Windows.Forms.DataGridView();
            this.colMachine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeadTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPagePrinters = new System.Windows.Forms.TabPage();
            this.labelShippingLabels = new System.Windows.Forms.Label();
            this.comboBoxShippingLabelPrinter = new System.Windows.Forms.ComboBox();
            this.labelTagPrinter = new System.Windows.Forms.Label();
            this.comboBoxTagLabelPrinter = new System.Windows.Forms.ComboBox();
            this.tabPageOrderFlow = new System.Windows.Forms.TabPage();
            this.buttonOrdFlowDelConnections = new System.Windows.Forms.Button();
            this.buttonOrdFlowAddConnection = new System.Windows.Forms.Button();
            this.comboBoxOrdFlowToMachine = new System.Windows.Forms.ComboBox();
            this.comboBoxOrdFlowFromMachine = new System.Windows.Forms.ComboBox();
            this.listViewOrderFlowMachines = new System.Windows.Forms.ListView();
            this.colOrdFlowFromMachine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrdFlowToMachine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageSkidPricing = new System.Windows.Forms.TabPage();
            this.buttonDeleteSkidPrice = new System.Windows.Forms.Button();
            this.labelTestPriceValue = new System.Windows.Forms.Label();
            this.labelTestPrice = new System.Windows.Forms.Label();
            this.buttonSkidPriceTest = new System.Windows.Forms.Button();
            this.buttonAddPrice = new System.Windows.Forms.Button();
            this.dataGridViewSkidPricing = new System.Windows.Forms.DataGridView();
            this.dgvSPFromWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSPToWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSPFromLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSPToLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSPPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxSkidTypeID = new System.Windows.Forms.ComboBox();
            this.comboBoxSkidDescription = new System.Windows.Forms.ComboBox();
            this.labelSkidType = new System.Windows.Forms.Label();
            this.labelTierLevel = new System.Windows.Forms.Label();
            this.comboBoxTierLevel = new System.Windows.Forms.ComboBox();
            this.tabPageProcPricing = new System.Windows.Forms.TabPage();
            this.labelProcPriceResults = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxProcMachineID = new System.Windows.Forms.ComboBox();
            this.comboBoxProcMachineDesc = new System.Windows.Forms.ComboBox();
            this.labelProcMachine = new System.Windows.Forms.Label();
            this.buttonProcPriceDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelProcPrice = new System.Windows.Forms.Label();
            this.buttonProcTest = new System.Windows.Forms.Button();
            this.buttonProcPricAdd = new System.Windows.Forms.Button();
            this.dataGridViewProcPricing = new System.Windows.Forms.DataGridView();
            this.dgvProcFromThickness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProcToThickness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProcFromWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProcToWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProcFromLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProcToLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProcPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxProcSteelTypeID = new System.Windows.Forms.ComboBox();
            this.comboBoxProcSteelTypeDesc = new System.Windows.Forms.ComboBox();
            this.labelProcSteelType = new System.Windows.Forms.Label();
            this.labelProcTierLevel = new System.Windows.Forms.Label();
            this.comboBoxProcTierLevel = new System.Windows.Forms.ComboBox();
            this.tabPageSteelTypes = new System.Windows.Forms.TabPage();
            this.buttonSTAddFinish = new System.Windows.Forms.Button();
            this.listBoxSTFinish = new System.Windows.Forms.ListBox();
            this.buttonSteelTypeAddAlloy = new System.Windows.Forms.Button();
            this.dataGridViewSteelTypeAlloys = new System.Windows.Forms.DataGridView();
            this.dgvSTAlloy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSTAlloyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSTDensity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSTDisplayOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSTPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSteelTypeAdd = new System.Windows.Forms.Button();
            this.listBoxSteelTypes = new System.Windows.Forms.ListBox();
            this.tabPageSTPricing = new System.Windows.Forms.TabPage();
            this.listViewSPHistory = new System.Windows.Forms.ListView();
            this.columnHeaderSPHistoryPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSPHistoryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelSPPrice = new System.Windows.Forms.Label();
            this.chartSPHistory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listViewSPPrice = new System.Windows.Forms.ListView();
            this.columnHeaderSPAlloy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSPPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.labelAboutConnString = new System.Windows.Forms.Label();
            this.tabControlProcess = new System.Windows.Forms.TabControl();
            this.tabControlMachines = new System.Windows.Forms.TabControl();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.panelCoilSheetSame = new System.Windows.Forms.Panel();
            this.labelPaperPrice = new System.Windows.Forms.Label();
            this.textBoxPaperPrice = new System.Windows.Forms.TextBox();
            this.labelSpecialLeadTime = new System.Windows.Forms.Label();
            this.dataGridViewAdders = new System.Windows.Forms.DataGridView();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvAdderDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAdderPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCTLDeleteRow = new System.Windows.Forms.Button();
            this.buttonAdderDone = new System.Windows.Forms.Button();
            this.textBoxCTLRunSheetComments = new System.Windows.Forms.TextBox();
            this.labelCTLRunSheetComments = new System.Windows.Forms.Label();
            this.buttonCTLDelete = new System.Windows.Forms.Button();
            this.comboBoxCTLModify = new System.Windows.Forms.ComboBox();
            this.checkBoxCTLModify = new System.Windows.Forms.CheckBox();
            this.labelCTLSendTo = new System.Windows.Forms.Label();
            this.comboBoxCTLSendTo = new System.Windows.Forms.ComboBox();
            this.checkBoxCTLMultiStep = new System.Windows.Forms.CheckBox();
            this.buttonCTLReset = new System.Windows.Forms.Button();
            this.labelCTLPrice = new System.Windows.Forms.Label();
            this.labelCTLPO = new System.Windows.Forms.Label();
            this.labelCTLPromiseDate = new System.Windows.Forms.Label();
            this.checkBoxCTLScrapCredit = new System.Windows.Forms.CheckBox();
            this.textBoxCTLPO = new System.Windows.Forms.TextBox();
            this.textBoxCTLPrice = new System.Windows.Forms.TextBox();
            this.dateTimePickerCTLPromiseDate = new System.Windows.Forms.DateTimePicker();
            this.richTextBoxCTLComments = new System.Windows.Forms.RichTextBox();
            this.buttonCTLAddOrder = new System.Windows.Forms.Button();
            this.buttonCTLArrowDown = new System.Windows.Forms.Button();
            this.buttonCTLArrowUp = new System.Windows.Forms.Button();
            this.dataGridViewCTLOrderEntry = new System.Windows.Forms.DataGridView();
            this.dgvCTLTagID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLThickness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLAlloy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLWeightLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLPaper = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvCTLPVC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvCTLAdder = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvCTLAddCut = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvCTLSkidType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvCTLCurrSkidPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLSkidCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLPieceCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLSheetWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLTheoLBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLBranch = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvCTLBranchID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvCTLAdderID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvCTLAdderPrice = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvCTLDensityFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLPVCGroupID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSkidTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvCTLPVCPriceList = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvCTLCurrPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listViewCTLCoilList = new System.Windows.Forms.ListView();
            this.colCTLTagID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLAlloy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLThickness = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLWidth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLWeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLMill = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLHeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLCarbon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLVendor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLPO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLContainer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLRecDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLRecID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLCoilCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLCountryOfOrigin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCTLOrders = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonCTLStartOrder = new System.Windows.Forms.Button();
            this.panelSheetSheetDiff = new System.Windows.Forms.Panel();
            this.buttonSSDCancelOrder = new System.Windows.Forms.Button();
            this.checkBoxSSDScrapCredit = new System.Windows.Forms.CheckBox();
            this.checkBoxCutFullSkids = new System.Windows.Forms.CheckBox();
            this.labelSSDSpecialLeadTime = new System.Windows.Forms.Label();
            this.textBoxSSDRunSheetComments = new System.Windows.Forms.TextBox();
            this.labelSSDRunSheetComments = new System.Windows.Forms.Label();
            this.comboBoxSSDModify = new System.Windows.Forms.ComboBox();
            this.checkBoxSSDModify = new System.Windows.Forms.CheckBox();
            this.comboBoxSSDMultiStep = new System.Windows.Forms.ComboBox();
            this.checkBoxSSDMultiStep = new System.Windows.Forms.CheckBox();
            this.labelSSDPrice = new System.Windows.Forms.Label();
            this.labelSSDPO = new System.Windows.Forms.Label();
            this.labelSSDPromiseDate = new System.Windows.Forms.Label();
            this.textBoxSSDPurchaseOrder = new System.Windows.Forms.TextBox();
            this.textBoxSSDPrice = new System.Windows.Forms.TextBox();
            this.dateTimePickerSSDPromiseDate = new System.Windows.Forms.DateTimePicker();
            this.richTextBoxSSDComments = new System.Windows.Forms.RichTextBox();
            this.buttonSSDAddOrder = new System.Windows.Forms.Button();
            this.buttonSSDStartOrder = new System.Windows.Forms.Button();
            this.listViewSSD = new System.Windows.Forms.ListView();
            this.columnHeader87 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader88 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader89 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader90 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader91 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader92 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader93 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader94 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader100 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvheat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader95 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader96 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader97 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader98 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader99 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwSSDOrders = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelSSDOrderEntry = new System.Windows.Forms.Panel();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.buttonAddCuts = new System.Windows.Forms.Button();
            this.treeViewSSD = new System.Windows.Forms.TreeView();
            this.dgvSSDItems = new System.Windows.Forms.DataGridView();
            this.dgvSSDHeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSDAlloy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSDPieceCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSDWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSDLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSDSkidIDs = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSDCoilTagSuffix = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSDOrigPcs = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSDCutPcs = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panelCoilCoilSame = new System.Windows.Forms.Panel();
            this.buttonClClSameDelete = new System.Windows.Forms.Button();
            this.comboBoxClClSameModify = new System.Windows.Forms.ComboBox();
            this.checkBoxClClSameModify = new System.Windows.Forms.CheckBox();
            this.labelClClSameMultiToMachine = new System.Windows.Forms.Label();
            this.comboBoxClClSameToMachine = new System.Windows.Forms.ComboBox();
            this.checkBoxClClSameMultiStep = new System.Windows.Forms.CheckBox();
            this.buttonClClSameReset = new System.Windows.Forms.Button();
            this.labelClClSamePrice = new System.Windows.Forms.Label();
            this.labelClClSamePO = new System.Windows.Forms.Label();
            this.labelClClSamePromiseDate = new System.Windows.Forms.Label();
            this.checkBoxClClSameScrap = new System.Windows.Forms.CheckBox();
            this.textBoxClClSamePO = new System.Windows.Forms.TextBox();
            this.textBoxClClSamePrice = new System.Windows.Forms.TextBox();
            this.dateTimePickerClClSamePromise = new System.Windows.Forms.DateTimePicker();
            this.richTextBoxClClSameComments = new System.Windows.Forms.RichTextBox();
            this.dataGridViewCLCLSame = new System.Windows.Forms.DataGridView();
            this.colClClSameCoilTagID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClCLSameThickness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClSameWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClSameAlloy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClSameOrigFinish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClSameNewFinish = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colClClSameOrigLBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClSamePolishLBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClSameCoilCnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClSamePolWeights = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colClClSamePaper = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colClClSameNewFinishID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colClClSameCoilFinish = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.listViewClClSame = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvCCSOrders = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonCLCLSameStartOrder = new System.Windows.Forms.Button();
            this.buttonClClSameAddOrder = new System.Windows.Forms.Button();
            this.panelClClDiff = new System.Windows.Forms.Panel();
            this.labelClClDiffMasterSequence = new System.Windows.Forms.Label();
            this.labelClClDiffMasterFrom = new System.Windows.Forms.Label();
            this.buttonClClDiffResetCuts = new System.Windows.Forms.Button();
            this.buttonClClDiffModifyDelte = new System.Windows.Forms.Button();
            this.comboBoxClClDiffModify = new System.Windows.Forms.ComboBox();
            this.checkBoxClClDiffModify = new System.Windows.Forms.CheckBox();
            this.labelClClDiffMultSendTo = new System.Windows.Forms.Label();
            this.comboBoxClClDiffSendTo = new System.Windows.Forms.ComboBox();
            this.checkBoxClClDiffMultStep = new System.Windows.Forms.CheckBox();
            this.labelClClDiffPrice = new System.Windows.Forms.Label();
            this.labelClClDiffPO = new System.Windows.Forms.Label();
            this.labelClClDiffPromiseDate = new System.Windows.Forms.Label();
            this.checkBoxClClDiffScrapCredit = new System.Windows.Forms.CheckBox();
            this.textBoxClClDiffPO = new System.Windows.Forms.TextBox();
            this.textBoxClClDiffPrice = new System.Windows.Forms.TextBox();
            this.dateTimePickerClClDiffPromiseDate = new System.Windows.Forms.DateTimePicker();
            this.richTextBoxClClDiffComments = new System.Windows.Forms.RichTextBox();
            this.buttonClClDiffReset = new System.Windows.Forms.Button();
            this.buttonClClDiffStartOrder = new System.Windows.Forms.Button();
            this.buttonClClDiffAddOrder = new System.Windows.Forms.Button();
            this.dataGridViewClClDiff = new System.Windows.Forms.DataGridView();
            this.colClClDiffTagID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClDiffThickness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClDiffWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClDiffAlloy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClDiffBreak = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colClClDiffOrigWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClDiffNewWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClDiffWidthLeft = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClDiffTrimAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClDiffCutCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClClDiffPaper = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colClClDiffAddCutButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.listViewClClDiff = new System.Windows.Forms.ListView();
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader26 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader32 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader33 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader34 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvCCDOrders = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelSheetSheetSame = new System.Windows.Forms.Panel();
            this.btnSSMCancel = new System.Windows.Forms.Button();
            this.labelSSSmSpecialLeadTime = new System.Windows.Forms.Label();
            this.textBoxSSSmRunSheet = new System.Windows.Forms.TextBox();
            this.labelSSSmRunSheet = new System.Windows.Forms.Label();
            this.comboBoxSSSmModify = new System.Windows.Forms.ComboBox();
            this.checkBoxSSSmModify = new System.Windows.Forms.CheckBox();
            this.comboBoxSSSmMulti = new System.Windows.Forms.ComboBox();
            this.checkBoxSSSmMultiStep = new System.Windows.Forms.CheckBox();
            this.labelSSSmPrice = new System.Windows.Forms.Label();
            this.labelSSSmPO = new System.Windows.Forms.Label();
            this.labelSSSmPromiseDate = new System.Windows.Forms.Label();
            this.textBoxSSSmPO = new System.Windows.Forms.TextBox();
            this.textBoxSSSmPrice = new System.Windows.Forms.TextBox();
            this.dateTimePickerSSSmPromiseDate = new System.Windows.Forms.DateTimePicker();
            this.richTextBoxSSSmComments = new System.Windows.Forms.RichTextBox();
            this.buttonSSSmAddOrder = new System.Windows.Forms.Button();
            this.buttonSSSmStartOrder = new System.Windows.Forms.Button();
            this.listViewSSSmSkidData = new System.Windows.Forms.ListView();
            this.columnHeader43 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader44 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader45 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader46 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader47 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader48 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader49 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader101 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader102 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader51 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader52 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader53 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader54 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader55 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvsssOrders = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataGridViewSSSmSkid = new System.Windows.Forms.DataGridView();
            this.dgvSSSmBreakSkid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvSSSmSkidID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmLetter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmPieces = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmAlloy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmNewFinish = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSSmThickness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmPVC = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSSmPaper = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvSSSmLineMark = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvSSSmComments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmBranch = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSSmBranchID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSSmAlloyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmFinishID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSSmDensityFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmOrigFinish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmPVCGroupID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSSmPVCPriceList = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSSmCurrPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.lblReportTagID = new System.Windows.Forms.Label();
            this.tbReportTransferTagID = new System.Windows.Forms.TextBox();
            this.lblReportTransferID = new System.Windows.Forms.Label();
            this.tbReportTransferID = new System.Windows.Forms.TextBox();
            this.btnReportTransfer = new System.Windows.Forms.Button();
            this.tbReportHistory = new System.Windows.Forms.TextBox();
            this.btnReportHistory = new System.Windows.Forms.Button();
            this.lblInventoryUpdate = new System.Windows.Forms.Label();
            this.chkBxInventorySkids = new System.Windows.Forms.CheckBox();
            this.chkBxInventoryCoils = new System.Windows.Forms.CheckBox();
            this.chkBxReportInventoryAllCustomers = new System.Windows.Forms.CheckBox();
            this.btnReportInventory = new System.Windows.Forms.Button();
            this.tbReportWorkOrder = new System.Windows.Forms.TextBox();
            this.btnReportWorkOrder = new System.Windows.Forms.Button();
            this.tbReportShipping = new System.Windows.Forms.TextBox();
            this.btnRepotShipping = new System.Windows.Forms.Button();
            this.txtReportRecieving = new System.Windows.Forms.TextBox();
            this.btnReportReceiving = new System.Windows.Forms.Button();
            this.tabPageReceiving = new System.Windows.Forms.TabPage();
            this.cbRecPrintLabel = new System.Windows.Forms.CheckBox();
            this.labelContainer = new System.Windows.Forms.Label();
            this.textBoxContainer = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBoxPreReceiving = new System.Windows.Forms.CheckBox();
            this.buttonRecSubmit = new System.Windows.Forms.Button();
            this.buttonDamageDone = new System.Windows.Forms.Button();
            this.buttonReceiveDeleteRow = new System.Windows.Forms.Button();
            this.buttonRecieveAddRow = new System.Windows.Forms.Button();
            this.checkedListBoxDamage = new System.Windows.Forms.CheckedListBox();
            this.dataGridViewReceiving = new System.Windows.Forms.DataGridView();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colUnloader = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPurchaseOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMillNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPieceCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThickness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlloy = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colFinish = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCarbon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriginCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDamage = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colWorkerID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAlloyID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colFinishID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDensityFactor = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDamageID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSteelType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colRecSteelDesc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabPageSkid = new System.Windows.Forms.TabPage();
            this.listViewSkidData = new System.Windows.Forms.ListView();
            this.lvSkidID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSkidLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPieceCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSkidAlloy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSkidThickness = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSkidWidth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSkidLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSkidWeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSkidMillNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSkidHeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSkidPVC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSkidPI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSkidComments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSkidNotPrime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSkidBranch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvOrders = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageCoil = new System.Windows.Forms.TabPage();
            this.ListViewCoilData = new System.Windows.Forms.ListView();
            this.hdrTagID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrAlloy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrThickness = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrWidth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrWeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrMillNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrHeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrCarbon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrVendor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrPONum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrContainer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrRecDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrRecID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrCoilCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrCountryOfOrigin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdrOrderInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControlICMS = new System.Windows.Forms.TabControl();
            this.tabPageShipping = new System.Windows.Forms.TabPage();
            this.buttonReleaseBOL = new System.Windows.Forms.Button();
            this.checkBoxShipModifyRel = new System.Windows.Forms.CheckBox();
            this.buttonBuildTruck = new System.Windows.Forms.Button();
            this.splitContainerShipping = new System.Windows.Forms.SplitContainer();
            this.listViewShipCoil = new System.Windows.Forms.ListView();
            this.columnHeader56 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader57 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader58 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader59 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader60 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader61 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader62 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader63 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader64 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader65 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader66 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader67 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader68 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader69 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader70 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader71 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader72 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader73 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewShipSkid = new System.Windows.Forms.ListView();
            this.columnHeader74 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader75 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader76 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader77 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader78 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader79 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader80 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader81 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colshipMillNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShipHeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader82 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader83 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader84 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader85 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader86 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelModifyRelease = new System.Windows.Forms.Panel();
            this.comboBoxBranchChooser = new System.Windows.Forms.ComboBox();
            this.buttonShipStart = new System.Windows.Forms.Button();
            this.tabPageCustomerInfo = new System.Windows.Forms.TabPage();
            this.buttonCustInfoAddBranch = new System.Windows.Forms.Button();
            this.dataGridViewBranchInfo = new System.Windows.Forms.DataGridView();
            this.dgvCBShortBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCBLongBranch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCBBranchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCustInfo = new System.Windows.Forms.DataGridView();
            this.InfoShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoLongName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoAddress1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoAddress2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoZip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoPackaging = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoMaxWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoPriceTier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoWeightFormula = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.InfoQBName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoLeadTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPagePVC = new System.Windows.Forms.TabPage();
            this.tabControlPVC = new System.Windows.Forms.TabControl();
            this.tabPagePVCInventory = new System.Windows.Forms.TabPage();
            this.tabControlPVCInventory = new System.Windows.Forms.TabControl();
            this.tabPagePVCInvDetailed = new System.Windows.Forms.TabPage();
            this.listViewPVCInvDetail = new System.Windows.Forms.ListView();
            this.Customer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TagID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Group = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tack = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Location = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnWidth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPagePVCInvTotals = new System.Windows.Forms.TabPage();
            this.tabPagePVCReceiving = new System.Windows.Forms.TabPage();
            this.panelPVCReceiving = new System.Windows.Forms.Panel();
            this.checkBoxPVCRecCustomer = new System.Windows.Forms.CheckBox();
            this.buttonPVCRecDeleteRow = new System.Windows.Forms.Button();
            this.buttonPVCRecAddRow = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.labelPVCRecPONum = new System.Windows.Forms.Label();
            this.textBoxPVCRecPONum = new System.Windows.Forms.TextBox();
            this.labelPVCRecRefNum = new System.Windows.Forms.Label();
            this.textBoxPVCRecRefNumber = new System.Windows.Forms.TextBox();
            this.buttonPVCRecAdd = new System.Windows.Forms.Button();
            this.dataGridViewPVCRec = new System.Windows.Forms.DataGridView();
            this.PVCRecItemNumber = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PVCRecItemNumberTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PVCRecGroupType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PVCRecRollCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PVCRecLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PVCRecPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PVCRecItemWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PVCRecItemLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PVCRecTypeID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PVCRecGroupID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PVCRecDefWidth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PVCRecDefLength = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.comboBoxPVCRecVendors = new System.Windows.Forms.ComboBox();
            this.tabPagePVCItems = new System.Windows.Forms.TabPage();
            this.panelPVCItemDesc = new System.Windows.Forms.Panel();
            this.labelPVCItemAddDesc = new System.Windows.Forms.Label();
            this.lblPVCItemAddItemNumber = new System.Windows.Forms.Label();
            this.lblPVCItemTack = new System.Windows.Forms.Label();
            this.lblPVCItemGroup = new System.Windows.Forms.Label();
            this.buttonPVCItemDelete = new System.Windows.Forms.Button();
            this.comboBoxPVCItemTack = new System.Windows.Forms.ComboBox();
            this.textBoxPVCItemDescAdd = new System.Windows.Forms.TextBox();
            this.textBoxPVCItemNumberAdd = new System.Windows.Forms.TextBox();
            this.comboBoxPVCItemGroupAdd = new System.Windows.Forms.ComboBox();
            this.buttonPVCItemsAddItem = new System.Windows.Forms.Button();
            this.comboBoxPVCVendor = new System.Windows.Forms.ComboBox();
            this.listViewPVCItems = new System.Windows.Forms.ListView();
            this.lvwPVCItemsGroupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwPVCItemsTack = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwPVCItemsItemNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwPVCItemsItemDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwPVCItemsWidth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwPVCItemsLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPagePVCVendor = new System.Windows.Forms.TabPage();
            this.panelPVCVendor = new System.Windows.Forms.Panel();
            this.buttonPVCVendorDeleteRow = new System.Windows.Forms.Button();
            this.buttonPVCVendorUpdate = new System.Windows.Forms.Button();
            this.dataGridViewPVCVendor = new System.Windows.Forms.DataGridView();
            this.dgvPVCVendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPVCVendorPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPagePVCGroup = new System.Windows.Forms.TabPage();
            this.buttonPVCGroupDeleteGroup = new System.Windows.Forms.Button();
            this.buttonPVCGroupAddGroup = new System.Windows.Forms.Button();
            this.listBoxPVCGroupList = new System.Windows.Forms.ListBox();
            this.tabPagePVCAdjust = new System.Windows.Forms.TabPage();
            this.TxtEdit = new System.Windows.Forms.TextBox();
            this.groupBoxPVCAdjustReason = new System.Windows.Forms.GroupBox();
            this.radioButtonPVCAdjUsed = new System.Windows.Forms.RadioButton();
            this.radioButtonPVCAdjSold = new System.Windows.Forms.RadioButton();
            this.radioButtonPVCAdjNotFound = new System.Windows.Forms.RadioButton();
            this.buttonPVCAdjInv = new System.Windows.Forms.Button();
            this.listViewPVCAdjInv = new System.Windows.Forms.ListView();
            this.columnHeader35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader42 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader41 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageRunSheet = new System.Windows.Forms.TabPage();
            this.lvwRunSheet = new System.Windows.Forms.ListView();
            this.tabControlOrderMachines = new System.Windows.Forms.TabControl();
            this.checkBoxCloseOrders = new System.Windows.Forms.CheckBox();
            this.contextMenuStripAddVertical = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ClearItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolMenuPrintLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.transferCoilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printSkidLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.transferSkidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btAddCustomer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.tabPageDefaultMachines.SuspendLayout();
            this.groupBoxDefaultScrapUnit.SuspendLayout();
            this.tabPageReportDrive.SuspendLayout();
            this.tabPageWorkers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorker)).BeginInit();
            this.tabPageLeadTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeadTimes)).BeginInit();
            this.tabPagePrinters.SuspendLayout();
            this.tabPageOrderFlow.SuspendLayout();
            this.tabPageSkidPricing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSkidPricing)).BeginInit();
            this.tabPageProcPricing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcPricing)).BeginInit();
            this.tabPageSteelTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSteelTypeAlloys)).BeginInit();
            this.tabPageSTPricing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSPHistory)).BeginInit();
            this.tabPageAbout.SuspendLayout();
            this.tabPageOrders.SuspendLayout();
            this.panelCoilSheetSame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCTLOrderEntry)).BeginInit();
            this.panelSheetSheetDiff.SuspendLayout();
            this.panelSSDOrderEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSSDItems)).BeginInit();
            this.panelCoilCoilSame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCLCLSame)).BeginInit();
            this.panelClClDiff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClClDiff)).BeginInit();
            this.panelSheetSheetSame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSSSmSkid)).BeginInit();
            this.tabPageReports.SuspendLayout();
            this.tabPageReceiving.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceiving)).BeginInit();
            this.tabPageSkid.SuspendLayout();
            this.tabPageCoil.SuspendLayout();
            this.tabControlICMS.SuspendLayout();
            this.tabPageShipping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerShipping)).BeginInit();
            this.splitContainerShipping.Panel1.SuspendLayout();
            this.splitContainerShipping.Panel2.SuspendLayout();
            this.splitContainerShipping.SuspendLayout();
            this.tabPageCustomerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBranchInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustInfo)).BeginInit();
            this.tabPagePVC.SuspendLayout();
            this.tabControlPVC.SuspendLayout();
            this.tabPagePVCInventory.SuspendLayout();
            this.tabControlPVCInventory.SuspendLayout();
            this.tabPagePVCInvDetailed.SuspendLayout();
            this.tabPagePVCReceiving.SuspendLayout();
            this.panelPVCReceiving.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPVCRec)).BeginInit();
            this.tabPagePVCItems.SuspendLayout();
            this.panelPVCItemDesc.SuspendLayout();
            this.tabPagePVCVendor.SuspendLayout();
            this.panelPVCVendor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPVCVendor)).BeginInit();
            this.tabPagePVCGroup.SuspendLayout();
            this.tabPagePVCAdjust.SuspendLayout();
            this.groupBoxPVCAdjustReason.SuspendLayout();
            this.tabPageRunSheet.SuspendLayout();
            this.contextMenuStripAddVertical.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeViewCustomer
            // 
            this.TreeViewCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TreeViewCustomer.Location = new System.Drawing.Point(6, 64);
            this.TreeViewCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TreeViewCustomer.Name = "TreeViewCustomer";
            this.TreeViewCustomer.ShowRootLines = false;
            this.TreeViewCustomer.Size = new System.Drawing.Size(255, 590);
            this.TreeViewCustomer.TabIndex = 0;
            this.TreeViewCustomer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewCustomer_AfterSelect);
            this.TreeViewCustomer.Enter += new System.EventHandler(this.TreeViewCustomer_Enter);
            this.TreeViewCustomer.Leave += new System.EventHandler(this.TreeViewCustomer_Leave);
            this.TreeViewCustomer.Validating += new System.ComponentModel.CancelEventHandler(this.TreeViewCustomer_Validating);
            // 
            // checkBoxInactiveCustomers
            // 
            this.checkBoxInactiveCustomers.AutoSize = true;
            this.checkBoxInactiveCustomers.Location = new System.Drawing.Point(267, 4);
            this.checkBoxInactiveCustomers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxInactiveCustomers.Name = "checkBoxInactiveCustomers";
            this.checkBoxInactiveCustomers.Size = new System.Drawing.Size(174, 20);
            this.checkBoxInactiveCustomers.TabIndex = 1;
            this.checkBoxInactiveCustomers.Text = "View Inactive Customers";
            this.checkBoxInactiveCustomers.UseVisualStyleBackColor = true;
            // 
            // tabControlPlantLocations
            // 
            this.tabControlPlantLocations.Location = new System.Drawing.Point(267, 35);
            this.tabControlPlantLocations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlPlantLocations.Name = "tabControlPlantLocations";
            this.tabControlPlantLocations.SelectedIndex = 0;
            this.tabControlPlantLocations.Size = new System.Drawing.Size(459, 25);
            this.tabControlPlantLocations.TabIndex = 2;
            this.tabControlPlantLocations.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControlPlantLocations_DrawItem);
            this.tabControlPlantLocations.SelectedIndexChanged += new System.EventHandler(this.TabControlPlantLocations_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.balanceToToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 28);
            // 
            // balanceToToolStripMenuItem
            // 
            this.balanceToToolStripMenuItem.Name = "balanceToToolStripMenuItem";
            this.balanceToToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this.balanceToToolStripMenuItem.Text = "Balance To";
            this.balanceToToolStripMenuItem.Click += new System.EventHandler(this.BalanceToToolStripMenuItem_Click);
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSettings.Controls.Add(this.tabPageDefaultMachines);
            this.tabControlSettings.Controls.Add(this.tabPageReportDrive);
            this.tabControlSettings.Controls.Add(this.tabPageWorkers);
            this.tabControlSettings.Controls.Add(this.tabPageLeadTime);
            this.tabControlSettings.Controls.Add(this.tabPagePrinters);
            this.tabControlSettings.Controls.Add(this.tabPageOrderFlow);
            this.tabControlSettings.Controls.Add(this.tabPageSkidPricing);
            this.tabControlSettings.Controls.Add(this.tabPageProcPricing);
            this.tabControlSettings.Controls.Add(this.tabPageSteelTypes);
            this.tabControlSettings.Controls.Add(this.tabPageSTPricing);
            this.tabControlSettings.Controls.Add(this.tabPageAbout);
            this.tabControlSettings.Location = new System.Drawing.Point(267, 64);
            this.tabControlSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(1099, 649);
            this.tabControlSettings.TabIndex = 4;
            this.tabControlSettings.SelectedIndexChanged += new System.EventHandler(this.TabControlSettings_SelectedIndexChanged);
            this.tabControlSettings.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlSettings_Selected);
            // 
            // tabPageDefaultMachines
            // 
            this.tabPageDefaultMachines.Controls.Add(this.btAddMachine);
            this.tabPageDefaultMachines.Controls.Add(this.buttonUpdateHoldDown);
            this.tabPageDefaultMachines.Controls.Add(this.textBoxHoldDown);
            this.tabPageDefaultMachines.Controls.Add(this.labelMachineHoldDown);
            this.tabPageDefaultMachines.Controls.Add(this.labelDefaultSSSmFinish);
            this.tabPageDefaultMachines.Controls.Add(this.comboBoxDefaultSSSmFinish);
            this.tabPageDefaultMachines.Controls.Add(this.groupBoxDefaultScrapUnit);
            this.tabPageDefaultMachines.Controls.Add(this.buttonDefaultCTLThickDiscUpdate);
            this.tabPageDefaultMachines.Controls.Add(this.textBoxDefaultsCTLThickDiscrepency);
            this.tabPageDefaultMachines.Controls.Add(this.labelCTLThicknessDiscrepency);
            this.tabPageDefaultMachines.Controls.Add(this.buttonClClDiffTrimRemove);
            this.tabPageDefaultMachines.Controls.Add(this.comboBoxClClDiffTrim);
            this.tabPageDefaultMachines.Controls.Add(this.labelClClDiffTrimVal);
            this.tabPageDefaultMachines.Controls.Add(this.labelClClDiffTrimTo);
            this.tabPageDefaultMachines.Controls.Add(this.labelClClDiffTrimFrom);
            this.tabPageDefaultMachines.Controls.Add(this.buttonClClDiffAddTrim);
            this.tabPageDefaultMachines.Controls.Add(this.listViewClClDiffTrim);
            this.tabPageDefaultMachines.Controls.Add(this.textBoxClClDiffTrimValue);
            this.tabPageDefaultMachines.Controls.Add(this.textBoxClClDiffTrimTo);
            this.tabPageDefaultMachines.Controls.Add(this.textBoxClClDiffTrimFrom);
            this.tabPageDefaultMachines.Controls.Add(this.labelDefaultClClSameFinish);
            this.tabPageDefaultMachines.Controls.Add(this.comboBoxDefaultClClSameFinish);
            this.tabPageDefaultMachines.Location = new System.Drawing.Point(4, 25);
            this.tabPageDefaultMachines.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageDefaultMachines.Name = "tabPageDefaultMachines";
            this.tabPageDefaultMachines.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageDefaultMachines.Size = new System.Drawing.Size(1091, 620);
            this.tabPageDefaultMachines.TabIndex = 2;
            this.tabPageDefaultMachines.Text = "Machine Defaults";
            this.tabPageDefaultMachines.UseVisualStyleBackColor = true;
            this.tabPageDefaultMachines.Click += new System.EventHandler(this.TabPageDefaultMachines_Click);
            // 
            // btAddMachine
            // 
            this.btAddMachine.Location = new System.Drawing.Point(27, 20);
            this.btAddMachine.Name = "btAddMachine";
            this.btAddMachine.Size = new System.Drawing.Size(112, 26);
            this.btAddMachine.TabIndex = 21;
            this.btAddMachine.Text = "Add Machine";
            this.btAddMachine.UseVisualStyleBackColor = true;
            this.btAddMachine.Click += new System.EventHandler(this.btAddMachine_Click);
            // 
            // buttonUpdateHoldDown
            // 
            this.buttonUpdateHoldDown.Location = new System.Drawing.Point(364, 426);
            this.buttonUpdateHoldDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdateHoldDown.Name = "buttonUpdateHoldDown";
            this.buttonUpdateHoldDown.Size = new System.Drawing.Size(197, 25);
            this.buttonUpdateHoldDown.TabIndex = 20;
            this.buttonUpdateHoldDown.Text = "Update HoldDown";
            this.buttonUpdateHoldDown.UseVisualStyleBackColor = true;
            this.buttonUpdateHoldDown.Click += new System.EventHandler(this.ButtonUpdateHoldDown_Click);
            // 
            // textBoxHoldDown
            // 
            this.textBoxHoldDown.Location = new System.Drawing.Point(150, 426);
            this.textBoxHoldDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxHoldDown.Name = "textBoxHoldDown";
            this.textBoxHoldDown.Size = new System.Drawing.Size(171, 22);
            this.textBoxHoldDown.TabIndex = 19;
            // 
            // labelMachineHoldDown
            // 
            this.labelMachineHoldDown.AutoSize = true;
            this.labelMachineHoldDown.Location = new System.Drawing.Point(22, 425);
            this.labelMachineHoldDown.Name = "labelMachineHoldDown";
            this.labelMachineHoldDown.Size = new System.Drawing.Size(73, 16);
            this.labelMachineHoldDown.TabIndex = 18;
            this.labelMachineHoldDown.Text = "Hold Down";
            // 
            // labelDefaultSSSmFinish
            // 
            this.labelDefaultSSSmFinish.AutoSize = true;
            this.labelDefaultSSSmFinish.Location = new System.Drawing.Point(15, 121);
            this.labelDefaultSSSmFinish.Name = "labelDefaultSSSmFinish";
            this.labelDefaultSSSmFinish.Size = new System.Drawing.Size(125, 16);
            this.labelDefaultSSSmFinish.TabIndex = 17;
            this.labelDefaultSSSmFinish.Text = "Sheet Default Finish";
            // 
            // comboBoxDefaultSSSmFinish
            // 
            this.comboBoxDefaultSSSmFinish.FormattingEnabled = true;
            this.comboBoxDefaultSSSmFinish.Location = new System.Drawing.Point(211, 121);
            this.comboBoxDefaultSSSmFinish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxDefaultSSSmFinish.Name = "comboBoxDefaultSSSmFinish";
            this.comboBoxDefaultSSSmFinish.Size = new System.Drawing.Size(181, 24);
            this.comboBoxDefaultSSSmFinish.TabIndex = 16;
            this.comboBoxDefaultSSSmFinish.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDefaultSSSmFinish_SelectedIndexChanged);
            // 
            // groupBoxDefaultScrapUnit
            // 
            this.groupBoxDefaultScrapUnit.Controls.Add(this.radioButtonScrapUnitLBS);
            this.groupBoxDefaultScrapUnit.Controls.Add(this.radioButtonScrapUnitInches);
            this.groupBoxDefaultScrapUnit.Location = new System.Drawing.Point(23, 515);
            this.groupBoxDefaultScrapUnit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxDefaultScrapUnit.Name = "groupBoxDefaultScrapUnit";
            this.groupBoxDefaultScrapUnit.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxDefaultScrapUnit.Size = new System.Drawing.Size(280, 59);
            this.groupBoxDefaultScrapUnit.TabIndex = 15;
            this.groupBoxDefaultScrapUnit.TabStop = false;
            this.groupBoxDefaultScrapUnit.Text = "Default Scrap Unit";
            // 
            // radioButtonScrapUnitLBS
            // 
            this.radioButtonScrapUnitLBS.AutoSize = true;
            this.radioButtonScrapUnitLBS.Location = new System.Drawing.Point(187, 30);
            this.radioButtonScrapUnitLBS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonScrapUnitLBS.Name = "radioButtonScrapUnitLBS";
            this.radioButtonScrapUnitLBS.Size = new System.Drawing.Size(53, 20);
            this.radioButtonScrapUnitLBS.TabIndex = 1;
            this.radioButtonScrapUnitLBS.TabStop = true;
            this.radioButtonScrapUnitLBS.Text = "LBS";
            this.radioButtonScrapUnitLBS.UseVisualStyleBackColor = true;
            this.radioButtonScrapUnitLBS.CheckedChanged += new System.EventHandler(this.RadioButtonScrapUnitLBS_CheckedChanged);
            // 
            // radioButtonScrapUnitInches
            // 
            this.radioButtonScrapUnitInches.AutoSize = true;
            this.radioButtonScrapUnitInches.Location = new System.Drawing.Point(32, 30);
            this.radioButtonScrapUnitInches.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonScrapUnitInches.Name = "radioButtonScrapUnitInches";
            this.radioButtonScrapUnitInches.Size = new System.Drawing.Size(67, 20);
            this.radioButtonScrapUnitInches.TabIndex = 0;
            this.radioButtonScrapUnitInches.TabStop = true;
            this.radioButtonScrapUnitInches.Text = "Inches";
            this.radioButtonScrapUnitInches.UseVisualStyleBackColor = true;
            this.radioButtonScrapUnitInches.CheckedChanged += new System.EventHandler(this.RadioButtonScrapUnitInches_CheckedChanged);
            // 
            // buttonDefaultCTLThickDiscUpdate
            // 
            this.buttonDefaultCTLThickDiscUpdate.Location = new System.Drawing.Point(342, 471);
            this.buttonDefaultCTLThickDiscUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDefaultCTLThickDiscUpdate.Name = "buttonDefaultCTLThickDiscUpdate";
            this.buttonDefaultCTLThickDiscUpdate.Size = new System.Drawing.Size(109, 25);
            this.buttonDefaultCTLThickDiscUpdate.TabIndex = 14;
            this.buttonDefaultCTLThickDiscUpdate.Text = "Update";
            this.buttonDefaultCTLThickDiscUpdate.UseVisualStyleBackColor = true;
            this.buttonDefaultCTLThickDiscUpdate.Click += new System.EventHandler(this.ButtonDefaultCTLThickDiscUpdate_Click);
            // 
            // textBoxDefaultsCTLThickDiscrepency
            // 
            this.textBoxDefaultsCTLThickDiscrepency.Location = new System.Drawing.Point(210, 472);
            this.textBoxDefaultsCTLThickDiscrepency.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDefaultsCTLThickDiscrepency.Name = "textBoxDefaultsCTLThickDiscrepency";
            this.textBoxDefaultsCTLThickDiscrepency.Size = new System.Drawing.Size(111, 22);
            this.textBoxDefaultsCTLThickDiscrepency.TabIndex = 13;
            this.textBoxDefaultsCTLThickDiscrepency.TextChanged += new System.EventHandler(this.TextBoxDefaultsCTLThickDiscrepency_TextChanged);
            this.textBoxDefaultsCTLThickDiscrepency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDefaultsCTLThickDiscrepency_KeyPress);
            // 
            // labelCTLThicknessDiscrepency
            // 
            this.labelCTLThicknessDiscrepency.AutoSize = true;
            this.labelCTLThicknessDiscrepency.Location = new System.Drawing.Point(14, 477);
            this.labelCTLThicknessDiscrepency.Name = "labelCTLThicknessDiscrepency";
            this.labelCTLThicknessDiscrepency.Size = new System.Drawing.Size(176, 16);
            this.labelCTLThicknessDiscrepency.TabIndex = 12;
            this.labelCTLThicknessDiscrepency.Text = "CTL Thickness Discrepency";
            // 
            // buttonClClDiffTrimRemove
            // 
            this.buttonClClDiffTrimRemove.Location = new System.Drawing.Point(470, 213);
            this.buttonClClDiffTrimRemove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClClDiffTrimRemove.Name = "buttonClClDiffTrimRemove";
            this.buttonClClDiffTrimRemove.Size = new System.Drawing.Size(117, 28);
            this.buttonClClDiffTrimRemove.TabIndex = 11;
            this.buttonClClDiffTrimRemove.Text = "Remove";
            this.buttonClClDiffTrimRemove.UseVisualStyleBackColor = true;
            this.buttonClClDiffTrimRemove.Click += new System.EventHandler(this.ButtonClClDiffTrimRemove_Click);
            // 
            // comboBoxClClDiffTrim
            // 
            this.comboBoxClClDiffTrim.FormattingEnabled = true;
            this.comboBoxClClDiffTrim.Location = new System.Drawing.Point(16, 180);
            this.comboBoxClClDiffTrim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxClClDiffTrim.Name = "comboBoxClClDiffTrim";
            this.comboBoxClClDiffTrim.Size = new System.Drawing.Size(432, 24);
            this.comboBoxClClDiffTrim.TabIndex = 10;
            this.comboBoxClClDiffTrim.SelectedIndexChanged += new System.EventHandler(this.ComboBoxClClDiffTrim_SelectedIndexChanged);
            // 
            // labelClClDiffTrimVal
            // 
            this.labelClClDiffTrimVal.AutoSize = true;
            this.labelClClDiffTrimVal.Location = new System.Drawing.Point(310, 367);
            this.labelClClDiffTrimVal.Name = "labelClClDiffTrimVal";
            this.labelClClDiffTrimVal.Size = new System.Drawing.Size(52, 16);
            this.labelClClDiffTrimVal.TabIndex = 9;
            this.labelClClDiffTrimVal.Text = "Amount";
            // 
            // labelClClDiffTrimTo
            // 
            this.labelClClDiffTrimTo.AutoSize = true;
            this.labelClClDiffTrimTo.Location = new System.Drawing.Point(163, 367);
            this.labelClClDiffTrimTo.Name = "labelClClDiffTrimTo";
            this.labelClClDiffTrimTo.Size = new System.Drawing.Size(24, 16);
            this.labelClClDiffTrimTo.TabIndex = 8;
            this.labelClClDiffTrimTo.Text = "To";
            // 
            // labelClClDiffTrimFrom
            // 
            this.labelClClDiffTrimFrom.AutoSize = true;
            this.labelClClDiffTrimFrom.Location = new System.Drawing.Point(22, 367);
            this.labelClClDiffTrimFrom.Name = "labelClClDiffTrimFrom";
            this.labelClClDiffTrimFrom.Size = new System.Drawing.Size(38, 16);
            this.labelClClDiffTrimFrom.TabIndex = 7;
            this.labelClClDiffTrimFrom.Text = "From";
            // 
            // buttonClClDiffAddTrim
            // 
            this.buttonClClDiffAddTrim.Location = new System.Drawing.Point(472, 381);
            this.buttonClClDiffAddTrim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClClDiffAddTrim.Name = "buttonClClDiffAddTrim";
            this.buttonClClDiffAddTrim.Size = new System.Drawing.Size(115, 25);
            this.buttonClClDiffAddTrim.TabIndex = 6;
            this.buttonClClDiffAddTrim.Text = "Add Trim";
            this.buttonClClDiffAddTrim.UseVisualStyleBackColor = true;
            this.buttonClClDiffAddTrim.Click += new System.EventHandler(this.ButtonClClDiffAddTrim_Click);
            // 
            // listViewClClDiffTrim
            // 
            this.listViewClClDiffTrim.CheckBoxes = true;
            this.listViewClClDiffTrim.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderClClDiffTrimFrom,
            this.columnHeaderClClDiffTrimTo,
            this.columnHeaderClClDiffTrimVal});
            this.listViewClClDiffTrim.HideSelection = false;
            this.listViewClClDiffTrim.Location = new System.Drawing.Point(16, 216);
            this.listViewClClDiffTrim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewClClDiffTrim.Name = "listViewClClDiffTrim";
            this.listViewClClDiffTrim.Size = new System.Drawing.Size(432, 146);
            this.listViewClClDiffTrim.TabIndex = 5;
            this.listViewClClDiffTrim.UseCompatibleStateImageBehavior = false;
            this.listViewClClDiffTrim.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderClClDiffTrimFrom
            // 
            this.columnHeaderClClDiffTrimFrom.Text = "From";
            // 
            // columnHeaderClClDiffTrimTo
            // 
            this.columnHeaderClClDiffTrimTo.Text = "To";
            // 
            // columnHeaderClClDiffTrimVal
            // 
            this.columnHeaderClClDiffTrimVal.Text = "Trim";
            // 
            // textBoxClClDiffTrimValue
            // 
            this.textBoxClClDiffTrimValue.Location = new System.Drawing.Point(310, 381);
            this.textBoxClClDiffTrimValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClClDiffTrimValue.Name = "textBoxClClDiffTrimValue";
            this.textBoxClClDiffTrimValue.Size = new System.Drawing.Size(140, 22);
            this.textBoxClClDiffTrimValue.TabIndex = 4;
            this.textBoxClClDiffTrimValue.TextChanged += new System.EventHandler(this.TextBoxClClDiffTrimValue_TextChanged);
            this.textBoxClClDiffTrimValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxClClDiffTrimValue_KeyPress);
            // 
            // textBoxClClDiffTrimTo
            // 
            this.textBoxClClDiffTrimTo.Location = new System.Drawing.Point(163, 381);
            this.textBoxClClDiffTrimTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClClDiffTrimTo.Name = "textBoxClClDiffTrimTo";
            this.textBoxClClDiffTrimTo.Size = new System.Drawing.Size(140, 22);
            this.textBoxClClDiffTrimTo.TabIndex = 3;
            this.textBoxClClDiffTrimTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxClClDiffTrimTo_KeyPress);
            // 
            // textBoxClClDiffTrimFrom
            // 
            this.textBoxClClDiffTrimFrom.Location = new System.Drawing.Point(16, 381);
            this.textBoxClClDiffTrimFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClClDiffTrimFrom.Name = "textBoxClClDiffTrimFrom";
            this.textBoxClClDiffTrimFrom.Size = new System.Drawing.Size(140, 22);
            this.textBoxClClDiffTrimFrom.TabIndex = 2;
            this.textBoxClClDiffTrimFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxClClDiffTrimFrom_KeyPress);
            // 
            // labelDefaultClClSameFinish
            // 
            this.labelDefaultClClSameFinish.AutoSize = true;
            this.labelDefaultClClSameFinish.Location = new System.Drawing.Point(15, 82);
            this.labelDefaultClClSameFinish.Name = "labelDefaultClClSameFinish";
            this.labelDefaultClClSameFinish.Size = new System.Drawing.Size(153, 16);
            this.labelDefaultClClSameFinish.TabIndex = 1;
            this.labelDefaultClClSameFinish.Text = "Coil Polish Default Finish";
            // 
            // comboBoxDefaultClClSameFinish
            // 
            this.comboBoxDefaultClClSameFinish.FormattingEnabled = true;
            this.comboBoxDefaultClClSameFinish.Location = new System.Drawing.Point(211, 82);
            this.comboBoxDefaultClClSameFinish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxDefaultClClSameFinish.Name = "comboBoxDefaultClClSameFinish";
            this.comboBoxDefaultClClSameFinish.Size = new System.Drawing.Size(181, 24);
            this.comboBoxDefaultClClSameFinish.TabIndex = 0;
            this.comboBoxDefaultClClSameFinish.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDefaultClClSameFinish_SelectedIndexChanged);
            // 
            // tabPageReportDrive
            // 
            this.tabPageReportDrive.Controls.Add(this.cbReportDrive);
            this.tabPageReportDrive.Controls.Add(this.label2);
            this.tabPageReportDrive.Location = new System.Drawing.Point(4, 25);
            this.tabPageReportDrive.Name = "tabPageReportDrive";
            this.tabPageReportDrive.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReportDrive.Size = new System.Drawing.Size(1091, 620);
            this.tabPageReportDrive.TabIndex = 10;
            this.tabPageReportDrive.Text = "Reports Drive";
            this.tabPageReportDrive.UseVisualStyleBackColor = true;
            // 
            // cbReportDrive
            // 
            this.cbReportDrive.FormattingEnabled = true;
            this.cbReportDrive.Location = new System.Drawing.Point(130, 31);
            this.cbReportDrive.Name = "cbReportDrive";
            this.cbReportDrive.Size = new System.Drawing.Size(104, 24);
            this.cbReportDrive.TabIndex = 1;
            this.cbReportDrive.SelectedIndexChanged += new System.EventHandler(this.cbReportDrive_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Drive Letter";
            // 
            // tabPageWorkers
            // 
            this.tabPageWorkers.Controls.Add(this.buttonAddWorker);
            this.tabPageWorkers.Controls.Add(this.dataGridViewWorker);
            this.tabPageWorkers.Location = new System.Drawing.Point(4, 25);
            this.tabPageWorkers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageWorkers.Name = "tabPageWorkers";
            this.tabPageWorkers.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageWorkers.Size = new System.Drawing.Size(1091, 620);
            this.tabPageWorkers.TabIndex = 8;
            this.tabPageWorkers.Text = "Workers";
            this.tabPageWorkers.UseVisualStyleBackColor = true;
            // 
            // buttonAddWorker
            // 
            this.buttonAddWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddWorker.Location = new System.Drawing.Point(902, 535);
            this.buttonAddWorker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddWorker.Name = "buttonAddWorker";
            this.buttonAddWorker.Size = new System.Drawing.Size(220, 34);
            this.buttonAddWorker.TabIndex = 1;
            this.buttonAddWorker.Text = "Add Worker";
            this.buttonAddWorker.UseVisualStyleBackColor = true;
            this.buttonAddWorker.Click += new System.EventHandler(this.ButtonAddWorker_Click);
            // 
            // dataGridViewWorker
            // 
            this.dataGridViewWorker.AllowUserToAddRows = false;
            this.dataGridViewWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWorker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWorker.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkerFirstName,
            this.WorkerLastName,
            this.WorkerActive,
            this.WorkerID});
            this.dataGridViewWorker.Location = new System.Drawing.Point(11, 2);
            this.dataGridViewWorker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewWorker.Name = "dataGridViewWorker";
            this.dataGridViewWorker.RowHeadersWidth = 51;
            this.dataGridViewWorker.RowTemplate.Height = 24;
            this.dataGridViewWorker.Size = new System.Drawing.Size(1291, 505);
            this.dataGridViewWorker.TabIndex = 0;
            this.dataGridViewWorker.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewWorker_CellEndEdit);
            // 
            // WorkerFirstName
            // 
            this.WorkerFirstName.HeaderText = "First Name";
            this.WorkerFirstName.MinimumWidth = 6;
            this.WorkerFirstName.Name = "WorkerFirstName";
            this.WorkerFirstName.Width = 125;
            // 
            // WorkerLastName
            // 
            this.WorkerLastName.HeaderText = "Last Name";
            this.WorkerLastName.MinimumWidth = 6;
            this.WorkerLastName.Name = "WorkerLastName";
            this.WorkerLastName.Width = 125;
            // 
            // WorkerActive
            // 
            this.WorkerActive.HeaderText = "Active";
            this.WorkerActive.MinimumWidth = 6;
            this.WorkerActive.Name = "WorkerActive";
            this.WorkerActive.Width = 125;
            // 
            // WorkerID
            // 
            this.WorkerID.HeaderText = "workerID";
            this.WorkerID.MinimumWidth = 6;
            this.WorkerID.Name = "WorkerID";
            this.WorkerID.Visible = false;
            this.WorkerID.Width = 125;
            // 
            // tabPageLeadTime
            // 
            this.tabPageLeadTime.Controls.Add(this.dataGridViewLeadTimes);
            this.tabPageLeadTime.Location = new System.Drawing.Point(4, 25);
            this.tabPageLeadTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageLeadTime.Name = "tabPageLeadTime";
            this.tabPageLeadTime.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageLeadTime.Size = new System.Drawing.Size(1091, 620);
            this.tabPageLeadTime.TabIndex = 5;
            this.tabPageLeadTime.Text = "Lead Times";
            this.tabPageLeadTime.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLeadTimes
            // 
            this.dataGridViewLeadTimes.AllowUserToAddRows = false;
            this.dataGridViewLeadTimes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewLeadTimes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLeadTimes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMachine,
            this.colLeadTime,
            this.colDate});
            this.dataGridViewLeadTimes.Location = new System.Drawing.Point(25, 20);
            this.dataGridViewLeadTimes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewLeadTimes.Name = "dataGridViewLeadTimes";
            this.dataGridViewLeadTimes.RowHeadersWidth = 51;
            this.dataGridViewLeadTimes.RowTemplate.Height = 24;
            this.dataGridViewLeadTimes.Size = new System.Drawing.Size(904, 700);
            this.dataGridViewLeadTimes.TabIndex = 0;
            this.dataGridViewLeadTimes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewLeadTimes_CellEndEdit);
            this.dataGridViewLeadTimes.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewLeadTimes_EditingControlShowing);
            // 
            // colMachine
            // 
            this.colMachine.FillWeight = 300F;
            this.colMachine.HeaderText = "Machine";
            this.colMachine.MinimumWidth = 6;
            this.colMachine.Name = "colMachine";
            this.colMachine.ReadOnly = true;
            this.colMachine.Width = 87;
            // 
            // colLeadTime
            // 
            this.colLeadTime.HeaderText = "Days";
            this.colLeadTime.MinimumWidth = 6;
            this.colLeadTime.Name = "colLeadTime";
            this.colLeadTime.Width = 68;
            // 
            // colDate
            // 
            this.colDate.FillWeight = 200F;
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 65;
            // 
            // tabPagePrinters
            // 
            this.tabPagePrinters.Controls.Add(this.labelShippingLabels);
            this.tabPagePrinters.Controls.Add(this.comboBoxShippingLabelPrinter);
            this.tabPagePrinters.Controls.Add(this.labelTagPrinter);
            this.tabPagePrinters.Controls.Add(this.comboBoxTagLabelPrinter);
            this.tabPagePrinters.Location = new System.Drawing.Point(4, 25);
            this.tabPagePrinters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePrinters.Name = "tabPagePrinters";
            this.tabPagePrinters.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePrinters.Size = new System.Drawing.Size(1091, 620);
            this.tabPagePrinters.TabIndex = 1;
            this.tabPagePrinters.Text = "Printers";
            this.tabPagePrinters.UseVisualStyleBackColor = true;
            // 
            // labelShippingLabels
            // 
            this.labelShippingLabels.AutoSize = true;
            this.labelShippingLabels.Location = new System.Drawing.Point(64, 128);
            this.labelShippingLabels.Name = "labelShippingLabels";
            this.labelShippingLabels.Size = new System.Drawing.Size(104, 16);
            this.labelShippingLabels.TabIndex = 3;
            this.labelShippingLabels.Text = "Shipping Labels";
            // 
            // comboBoxShippingLabelPrinter
            // 
            this.comboBoxShippingLabelPrinter.FormattingEnabled = true;
            this.comboBoxShippingLabelPrinter.Location = new System.Drawing.Point(179, 126);
            this.comboBoxShippingLabelPrinter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxShippingLabelPrinter.Name = "comboBoxShippingLabelPrinter";
            this.comboBoxShippingLabelPrinter.Size = new System.Drawing.Size(436, 24);
            this.comboBoxShippingLabelPrinter.TabIndex = 2;
            this.comboBoxShippingLabelPrinter.SelectedIndexChanged += new System.EventHandler(this.ComboBoxShippingLabelPrinter_SelectedIndexChanged);
            // 
            // labelTagPrinter
            // 
            this.labelTagPrinter.AutoSize = true;
            this.labelTagPrinter.Location = new System.Drawing.Point(93, 57);
            this.labelTagPrinter.Name = "labelTagPrinter";
            this.labelTagPrinter.Size = new System.Drawing.Size(73, 16);
            this.labelTagPrinter.TabIndex = 1;
            this.labelTagPrinter.Text = "Tag Printer";
            // 
            // comboBoxTagLabelPrinter
            // 
            this.comboBoxTagLabelPrinter.FormattingEnabled = true;
            this.comboBoxTagLabelPrinter.Location = new System.Drawing.Point(179, 52);
            this.comboBoxTagLabelPrinter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxTagLabelPrinter.Name = "comboBoxTagLabelPrinter";
            this.comboBoxTagLabelPrinter.Size = new System.Drawing.Size(437, 24);
            this.comboBoxTagLabelPrinter.TabIndex = 0;
            this.comboBoxTagLabelPrinter.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTagLabelPrinter_SelectedIndexChanged);
            // 
            // tabPageOrderFlow
            // 
            this.tabPageOrderFlow.Controls.Add(this.buttonOrdFlowDelConnections);
            this.tabPageOrderFlow.Controls.Add(this.buttonOrdFlowAddConnection);
            this.tabPageOrderFlow.Controls.Add(this.comboBoxOrdFlowToMachine);
            this.tabPageOrderFlow.Controls.Add(this.comboBoxOrdFlowFromMachine);
            this.tabPageOrderFlow.Controls.Add(this.listViewOrderFlowMachines);
            this.tabPageOrderFlow.Location = new System.Drawing.Point(4, 25);
            this.tabPageOrderFlow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageOrderFlow.Name = "tabPageOrderFlow";
            this.tabPageOrderFlow.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageOrderFlow.Size = new System.Drawing.Size(1091, 620);
            this.tabPageOrderFlow.TabIndex = 3;
            this.tabPageOrderFlow.Text = "Order Flow";
            this.tabPageOrderFlow.UseVisualStyleBackColor = true;
            // 
            // buttonOrdFlowDelConnections
            // 
            this.buttonOrdFlowDelConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOrdFlowDelConnections.Location = new System.Drawing.Point(581, 615);
            this.buttonOrdFlowDelConnections.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOrdFlowDelConnections.Name = "buttonOrdFlowDelConnections";
            this.buttonOrdFlowDelConnections.Size = new System.Drawing.Size(213, 48);
            this.buttonOrdFlowDelConnections.TabIndex = 4;
            this.buttonOrdFlowDelConnections.Text = "Remove Connections";
            this.buttonOrdFlowDelConnections.UseVisualStyleBackColor = true;
            this.buttonOrdFlowDelConnections.Click += new System.EventHandler(this.ButtonOrdFlowDelConnections_Click);
            // 
            // buttonOrdFlowAddConnection
            // 
            this.buttonOrdFlowAddConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOrdFlowAddConnection.Location = new System.Drawing.Point(832, 615);
            this.buttonOrdFlowAddConnection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOrdFlowAddConnection.Name = "buttonOrdFlowAddConnection";
            this.buttonOrdFlowAddConnection.Size = new System.Drawing.Size(213, 48);
            this.buttonOrdFlowAddConnection.TabIndex = 3;
            this.buttonOrdFlowAddConnection.Text = "Add Connection";
            this.buttonOrdFlowAddConnection.UseVisualStyleBackColor = true;
            this.buttonOrdFlowAddConnection.Click += new System.EventHandler(this.ButtonOrdFlowAddConnection_Click);
            // 
            // comboBoxOrdFlowToMachine
            // 
            this.comboBoxOrdFlowToMachine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOrdFlowToMachine.FormattingEnabled = true;
            this.comboBoxOrdFlowToMachine.Location = new System.Drawing.Point(555, 583);
            this.comboBoxOrdFlowToMachine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxOrdFlowToMachine.Name = "comboBoxOrdFlowToMachine";
            this.comboBoxOrdFlowToMachine.Size = new System.Drawing.Size(492, 24);
            this.comboBoxOrdFlowToMachine.TabIndex = 2;
            // 
            // comboBoxOrdFlowFromMachine
            // 
            this.comboBoxOrdFlowFromMachine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxOrdFlowFromMachine.FormattingEnabled = true;
            this.comboBoxOrdFlowFromMachine.Location = new System.Drawing.Point(19, 583);
            this.comboBoxOrdFlowFromMachine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxOrdFlowFromMachine.Name = "comboBoxOrdFlowFromMachine";
            this.comboBoxOrdFlowFromMachine.Size = new System.Drawing.Size(423, 24);
            this.comboBoxOrdFlowFromMachine.TabIndex = 1;
            this.comboBoxOrdFlowFromMachine.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOrdFlowFromMachine_SelectedIndexChanged);
            // 
            // listViewOrderFlowMachines
            // 
            this.listViewOrderFlowMachines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewOrderFlowMachines.CheckBoxes = true;
            this.listViewOrderFlowMachines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOrdFlowFromMachine,
            this.colOrdFlowToMachine});
            this.listViewOrderFlowMachines.HideSelection = false;
            this.listViewOrderFlowMachines.Location = new System.Drawing.Point(7, 7);
            this.listViewOrderFlowMachines.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewOrderFlowMachines.Name = "listViewOrderFlowMachines";
            this.listViewOrderFlowMachines.Size = new System.Drawing.Size(1253, 559);
            this.listViewOrderFlowMachines.TabIndex = 0;
            this.listViewOrderFlowMachines.UseCompatibleStateImageBehavior = false;
            this.listViewOrderFlowMachines.View = System.Windows.Forms.View.Details;
            // 
            // colOrdFlowFromMachine
            // 
            this.colOrdFlowFromMachine.Text = "From Machine";
            this.colOrdFlowFromMachine.Width = 300;
            // 
            // colOrdFlowToMachine
            // 
            this.colOrdFlowToMachine.Text = "To Machine";
            this.colOrdFlowToMachine.Width = 375;
            // 
            // tabPageSkidPricing
            // 
            this.tabPageSkidPricing.Controls.Add(this.buttonDeleteSkidPrice);
            this.tabPageSkidPricing.Controls.Add(this.labelTestPriceValue);
            this.tabPageSkidPricing.Controls.Add(this.labelTestPrice);
            this.tabPageSkidPricing.Controls.Add(this.buttonSkidPriceTest);
            this.tabPageSkidPricing.Controls.Add(this.buttonAddPrice);
            this.tabPageSkidPricing.Controls.Add(this.dataGridViewSkidPricing);
            this.tabPageSkidPricing.Controls.Add(this.comboBoxSkidTypeID);
            this.tabPageSkidPricing.Controls.Add(this.comboBoxSkidDescription);
            this.tabPageSkidPricing.Controls.Add(this.labelSkidType);
            this.tabPageSkidPricing.Controls.Add(this.labelTierLevel);
            this.tabPageSkidPricing.Controls.Add(this.comboBoxTierLevel);
            this.tabPageSkidPricing.Location = new System.Drawing.Point(4, 25);
            this.tabPageSkidPricing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageSkidPricing.Name = "tabPageSkidPricing";
            this.tabPageSkidPricing.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageSkidPricing.Size = new System.Drawing.Size(1091, 620);
            this.tabPageSkidPricing.TabIndex = 6;
            this.tabPageSkidPricing.Text = "Skid Pricing";
            this.tabPageSkidPricing.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteSkidPrice
            // 
            this.buttonDeleteSkidPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteSkidPrice.Location = new System.Drawing.Point(16, 586);
            this.buttonDeleteSkidPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDeleteSkidPrice.Name = "buttonDeleteSkidPrice";
            this.buttonDeleteSkidPrice.Size = new System.Drawing.Size(179, 30);
            this.buttonDeleteSkidPrice.TabIndex = 10;
            this.buttonDeleteSkidPrice.Text = "Delete Price";
            this.buttonDeleteSkidPrice.UseVisualStyleBackColor = true;
            this.buttonDeleteSkidPrice.Click += new System.EventHandler(this.ButtonDeleteSkidPrice_Click);
            // 
            // labelTestPriceValue
            // 
            this.labelTestPriceValue.AutoSize = true;
            this.labelTestPriceValue.Location = new System.Drawing.Point(653, 47);
            this.labelTestPriceValue.Name = "labelTestPriceValue";
            this.labelTestPriceValue.Size = new System.Drawing.Size(0, 16);
            this.labelTestPriceValue.TabIndex = 9;
            // 
            // labelTestPrice
            // 
            this.labelTestPrice.AutoSize = true;
            this.labelTestPrice.Location = new System.Drawing.Point(653, 20);
            this.labelTestPrice.Name = "labelTestPrice";
            this.labelTestPrice.Size = new System.Drawing.Size(38, 16);
            this.labelTestPrice.TabIndex = 8;
            this.labelTestPrice.Text = "Price";
            // 
            // buttonSkidPriceTest
            // 
            this.buttonSkidPriceTest.Location = new System.Drawing.Point(520, 32);
            this.buttonSkidPriceTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSkidPriceTest.Name = "buttonSkidPriceTest";
            this.buttonSkidPriceTest.Size = new System.Drawing.Size(93, 34);
            this.buttonSkidPriceTest.TabIndex = 7;
            this.buttonSkidPriceTest.Text = "Test";
            this.buttonSkidPriceTest.UseVisualStyleBackColor = true;
            this.buttonSkidPriceTest.Click += new System.EventHandler(this.ButtonSkidPriceTest_Click);
            // 
            // buttonAddPrice
            // 
            this.buttonAddPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddPrice.Location = new System.Drawing.Point(242, 586);
            this.buttonAddPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddPrice.Name = "buttonAddPrice";
            this.buttonAddPrice.Size = new System.Drawing.Size(179, 30);
            this.buttonAddPrice.TabIndex = 6;
            this.buttonAddPrice.Text = "Add Price";
            this.buttonAddPrice.UseVisualStyleBackColor = true;
            this.buttonAddPrice.Click += new System.EventHandler(this.ButtonAddPrice_Click);
            // 
            // dataGridViewSkidPricing
            // 
            this.dataGridViewSkidPricing.AllowUserToAddRows = false;
            this.dataGridViewSkidPricing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSkidPricing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSkidPricing.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSPFromWidth,
            this.dgvSPToWidth,
            this.dgvSPFromLength,
            this.dgvSPToLength,
            this.dgvSPPrice});
            this.dataGridViewSkidPricing.Location = new System.Drawing.Point(16, 128);
            this.dataGridViewSkidPricing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewSkidPricing.Name = "dataGridViewSkidPricing";
            this.dataGridViewSkidPricing.RowHeadersWidth = 51;
            this.dataGridViewSkidPricing.RowTemplate.Height = 24;
            this.dataGridViewSkidPricing.Size = new System.Drawing.Size(1235, 382);
            this.dataGridViewSkidPricing.TabIndex = 5;
            this.dataGridViewSkidPricing.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewSkidPricing_CellEndEdit);
            this.dataGridViewSkidPricing.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewSkidPricing_CellEnter);
            // 
            // dgvSPFromWidth
            // 
            this.dgvSPFromWidth.HeaderText = "From Width";
            this.dgvSPFromWidth.MinimumWidth = 6;
            this.dgvSPFromWidth.Name = "dgvSPFromWidth";
            this.dgvSPFromWidth.Width = 125;
            // 
            // dgvSPToWidth
            // 
            this.dgvSPToWidth.HeaderText = "To Width";
            this.dgvSPToWidth.MinimumWidth = 6;
            this.dgvSPToWidth.Name = "dgvSPToWidth";
            this.dgvSPToWidth.Width = 125;
            // 
            // dgvSPFromLength
            // 
            this.dgvSPFromLength.HeaderText = "From Length";
            this.dgvSPFromLength.MinimumWidth = 6;
            this.dgvSPFromLength.Name = "dgvSPFromLength";
            this.dgvSPFromLength.Width = 125;
            // 
            // dgvSPToLength
            // 
            this.dgvSPToLength.HeaderText = "To Length";
            this.dgvSPToLength.MinimumWidth = 6;
            this.dgvSPToLength.Name = "dgvSPToLength";
            this.dgvSPToLength.Width = 125;
            // 
            // dgvSPPrice
            // 
            this.dgvSPPrice.HeaderText = "Price";
            this.dgvSPPrice.MinimumWidth = 6;
            this.dgvSPPrice.Name = "dgvSPPrice";
            this.dgvSPPrice.Width = 125;
            // 
            // comboBoxSkidTypeID
            // 
            this.comboBoxSkidTypeID.FormattingEnabled = true;
            this.comboBoxSkidTypeID.Location = new System.Drawing.Point(308, 66);
            this.comboBoxSkidTypeID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSkidTypeID.Name = "comboBoxSkidTypeID";
            this.comboBoxSkidTypeID.Size = new System.Drawing.Size(160, 24);
            this.comboBoxSkidTypeID.TabIndex = 4;
            this.comboBoxSkidTypeID.Visible = false;
            // 
            // comboBoxSkidDescription
            // 
            this.comboBoxSkidDescription.FormattingEnabled = true;
            this.comboBoxSkidDescription.Location = new System.Drawing.Point(107, 66);
            this.comboBoxSkidDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSkidDescription.Name = "comboBoxSkidDescription";
            this.comboBoxSkidDescription.Size = new System.Drawing.Size(160, 24);
            this.comboBoxSkidDescription.TabIndex = 3;
            this.comboBoxSkidDescription.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSkidDescription_SelectedIndexChanged);
            // 
            // labelSkidType
            // 
            this.labelSkidType.AutoSize = true;
            this.labelSkidType.Location = new System.Drawing.Point(5, 66);
            this.labelSkidType.Name = "labelSkidType";
            this.labelSkidType.Size = new System.Drawing.Size(69, 16);
            this.labelSkidType.TabIndex = 2;
            this.labelSkidType.Text = "Skid Type";
            // 
            // labelTierLevel
            // 
            this.labelTierLevel.AutoSize = true;
            this.labelTierLevel.Location = new System.Drawing.Point(5, 20);
            this.labelTierLevel.Name = "labelTierLevel";
            this.labelTierLevel.Size = new System.Drawing.Size(67, 16);
            this.labelTierLevel.TabIndex = 1;
            this.labelTierLevel.Text = "Tier Level";
            // 
            // comboBoxTierLevel
            // 
            this.comboBoxTierLevel.FormattingEnabled = true;
            this.comboBoxTierLevel.Location = new System.Drawing.Point(107, 20);
            this.comboBoxTierLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxTierLevel.Name = "comboBoxTierLevel";
            this.comboBoxTierLevel.Size = new System.Drawing.Size(160, 24);
            this.comboBoxTierLevel.TabIndex = 0;
            this.comboBoxTierLevel.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTierLevel_SelectedIndexChanged);
            // 
            // tabPageProcPricing
            // 
            this.tabPageProcPricing.Controls.Add(this.labelProcPriceResults);
            this.tabPageProcPricing.Controls.Add(this.label3);
            this.tabPageProcPricing.Controls.Add(this.comboBoxProcMachineID);
            this.tabPageProcPricing.Controls.Add(this.comboBoxProcMachineDesc);
            this.tabPageProcPricing.Controls.Add(this.labelProcMachine);
            this.tabPageProcPricing.Controls.Add(this.buttonProcPriceDelete);
            this.tabPageProcPricing.Controls.Add(this.label1);
            this.tabPageProcPricing.Controls.Add(this.labelProcPrice);
            this.tabPageProcPricing.Controls.Add(this.buttonProcTest);
            this.tabPageProcPricing.Controls.Add(this.buttonProcPricAdd);
            this.tabPageProcPricing.Controls.Add(this.dataGridViewProcPricing);
            this.tabPageProcPricing.Controls.Add(this.comboBoxProcSteelTypeID);
            this.tabPageProcPricing.Controls.Add(this.comboBoxProcSteelTypeDesc);
            this.tabPageProcPricing.Controls.Add(this.labelProcSteelType);
            this.tabPageProcPricing.Controls.Add(this.labelProcTierLevel);
            this.tabPageProcPricing.Controls.Add(this.comboBoxProcTierLevel);
            this.tabPageProcPricing.Location = new System.Drawing.Point(4, 25);
            this.tabPageProcPricing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageProcPricing.Name = "tabPageProcPricing";
            this.tabPageProcPricing.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageProcPricing.Size = new System.Drawing.Size(1091, 620);
            this.tabPageProcPricing.TabIndex = 7;
            this.tabPageProcPricing.Text = "Proc Pricing";
            this.tabPageProcPricing.UseVisualStyleBackColor = true;
            // 
            // labelProcPriceResults
            // 
            this.labelProcPriceResults.AutoSize = true;
            this.labelProcPriceResults.Location = new System.Drawing.Point(652, 48);
            this.labelProcPriceResults.Name = "labelProcPriceResults";
            this.labelProcPriceResults.Size = new System.Drawing.Size(0, 16);
            this.labelProcPriceResults.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(656, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 25;
            // 
            // comboBoxProcMachineID
            // 
            this.comboBoxProcMachineID.FormattingEnabled = true;
            this.comboBoxProcMachineID.Location = new System.Drawing.Point(308, 105);
            this.comboBoxProcMachineID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxProcMachineID.Name = "comboBoxProcMachineID";
            this.comboBoxProcMachineID.Size = new System.Drawing.Size(160, 24);
            this.comboBoxProcMachineID.TabIndex = 24;
            this.comboBoxProcMachineID.Visible = false;
            // 
            // comboBoxProcMachineDesc
            // 
            this.comboBoxProcMachineDesc.FormattingEnabled = true;
            this.comboBoxProcMachineDesc.Location = new System.Drawing.Point(107, 103);
            this.comboBoxProcMachineDesc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxProcMachineDesc.Name = "comboBoxProcMachineDesc";
            this.comboBoxProcMachineDesc.Size = new System.Drawing.Size(160, 24);
            this.comboBoxProcMachineDesc.TabIndex = 23;
            this.comboBoxProcMachineDesc.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProcMachineDesc_SelectedIndexChanged);
            // 
            // labelProcMachine
            // 
            this.labelProcMachine.AutoSize = true;
            this.labelProcMachine.Location = new System.Drawing.Point(5, 108);
            this.labelProcMachine.Name = "labelProcMachine";
            this.labelProcMachine.Size = new System.Drawing.Size(58, 16);
            this.labelProcMachine.TabIndex = 22;
            this.labelProcMachine.Text = "Machine";
            // 
            // buttonProcPriceDelete
            // 
            this.buttonProcPriceDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcPriceDelete.Location = new System.Drawing.Point(720, 573);
            this.buttonProcPriceDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonProcPriceDelete.Name = "buttonProcPriceDelete";
            this.buttonProcPriceDelete.Size = new System.Drawing.Size(179, 30);
            this.buttonProcPriceDelete.TabIndex = 21;
            this.buttonProcPriceDelete.Text = "Delete Price";
            this.buttonProcPriceDelete.UseVisualStyleBackColor = true;
            this.buttonProcPriceDelete.Click += new System.EventHandler(this.ButtonProcPriceDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(652, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 20;
            // 
            // labelProcPrice
            // 
            this.labelProcPrice.AutoSize = true;
            this.labelProcPrice.Location = new System.Drawing.Point(652, 22);
            this.labelProcPrice.Name = "labelProcPrice";
            this.labelProcPrice.Size = new System.Drawing.Size(38, 16);
            this.labelProcPrice.TabIndex = 19;
            this.labelProcPrice.Text = "Price";
            // 
            // buttonProcTest
            // 
            this.buttonProcTest.Location = new System.Drawing.Point(520, 32);
            this.buttonProcTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonProcTest.Name = "buttonProcTest";
            this.buttonProcTest.Size = new System.Drawing.Size(93, 34);
            this.buttonProcTest.TabIndex = 18;
            this.buttonProcTest.Text = "Test";
            this.buttonProcTest.UseVisualStyleBackColor = true;
            this.buttonProcTest.Click += new System.EventHandler(this.ButtonProcTest_Click);
            // 
            // buttonProcPricAdd
            // 
            this.buttonProcPricAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProcPricAdd.Location = new System.Drawing.Point(946, 573);
            this.buttonProcPricAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonProcPricAdd.Name = "buttonProcPricAdd";
            this.buttonProcPricAdd.Size = new System.Drawing.Size(179, 30);
            this.buttonProcPricAdd.TabIndex = 17;
            this.buttonProcPricAdd.Text = "Add Price";
            this.buttonProcPricAdd.UseVisualStyleBackColor = true;
            this.buttonProcPricAdd.Click += new System.EventHandler(this.ButtonProcPricAdd_Click);
            // 
            // dataGridViewProcPricing
            // 
            this.dataGridViewProcPricing.AllowUserToAddRows = false;
            this.dataGridViewProcPricing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProcPricing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProcPricing.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvProcFromThickness,
            this.dgvProcToThickness,
            this.dgvProcFromWidth,
            this.dgvProcToWidth,
            this.dgvProcFromLength,
            this.dgvProcToLength,
            this.dgvProcPrice});
            this.dataGridViewProcPricing.Location = new System.Drawing.Point(9, 142);
            this.dataGridViewProcPricing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewProcPricing.Name = "dataGridViewProcPricing";
            this.dataGridViewProcPricing.RowHeadersWidth = 51;
            this.dataGridViewProcPricing.RowTemplate.Height = 24;
            this.dataGridViewProcPricing.Size = new System.Drawing.Size(1244, 382);
            this.dataGridViewProcPricing.TabIndex = 16;
            // 
            // dgvProcFromThickness
            // 
            this.dgvProcFromThickness.HeaderText = "From Thickness";
            this.dgvProcFromThickness.MinimumWidth = 6;
            this.dgvProcFromThickness.Name = "dgvProcFromThickness";
            this.dgvProcFromThickness.Width = 125;
            // 
            // dgvProcToThickness
            // 
            this.dgvProcToThickness.HeaderText = "To Thickness";
            this.dgvProcToThickness.MinimumWidth = 6;
            this.dgvProcToThickness.Name = "dgvProcToThickness";
            this.dgvProcToThickness.Width = 125;
            // 
            // dgvProcFromWidth
            // 
            this.dgvProcFromWidth.HeaderText = "From Width";
            this.dgvProcFromWidth.MinimumWidth = 6;
            this.dgvProcFromWidth.Name = "dgvProcFromWidth";
            this.dgvProcFromWidth.Width = 125;
            // 
            // dgvProcToWidth
            // 
            this.dgvProcToWidth.HeaderText = "To Width";
            this.dgvProcToWidth.MinimumWidth = 6;
            this.dgvProcToWidth.Name = "dgvProcToWidth";
            this.dgvProcToWidth.Width = 125;
            // 
            // dgvProcFromLength
            // 
            this.dgvProcFromLength.HeaderText = "From Length";
            this.dgvProcFromLength.MinimumWidth = 6;
            this.dgvProcFromLength.Name = "dgvProcFromLength";
            this.dgvProcFromLength.Width = 125;
            // 
            // dgvProcToLength
            // 
            this.dgvProcToLength.HeaderText = "To Length";
            this.dgvProcToLength.MinimumWidth = 6;
            this.dgvProcToLength.Name = "dgvProcToLength";
            this.dgvProcToLength.Width = 125;
            // 
            // dgvProcPrice
            // 
            this.dgvProcPrice.HeaderText = "Price";
            this.dgvProcPrice.MinimumWidth = 6;
            this.dgvProcPrice.Name = "dgvProcPrice";
            this.dgvProcPrice.Width = 125;
            // 
            // comboBoxProcSteelTypeID
            // 
            this.comboBoxProcSteelTypeID.FormattingEnabled = true;
            this.comboBoxProcSteelTypeID.Location = new System.Drawing.Point(308, 62);
            this.comboBoxProcSteelTypeID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxProcSteelTypeID.Name = "comboBoxProcSteelTypeID";
            this.comboBoxProcSteelTypeID.Size = new System.Drawing.Size(160, 24);
            this.comboBoxProcSteelTypeID.TabIndex = 15;
            this.comboBoxProcSteelTypeID.Visible = false;
            // 
            // comboBoxProcSteelTypeDesc
            // 
            this.comboBoxProcSteelTypeDesc.FormattingEnabled = true;
            this.comboBoxProcSteelTypeDesc.Location = new System.Drawing.Point(107, 62);
            this.comboBoxProcSteelTypeDesc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxProcSteelTypeDesc.Name = "comboBoxProcSteelTypeDesc";
            this.comboBoxProcSteelTypeDesc.Size = new System.Drawing.Size(160, 24);
            this.comboBoxProcSteelTypeDesc.TabIndex = 14;
            this.comboBoxProcSteelTypeDesc.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProcSteelTypeDesc_SelectedIndexChanged);
            // 
            // labelProcSteelType
            // 
            this.labelProcSteelType.AutoSize = true;
            this.labelProcSteelType.Location = new System.Drawing.Point(5, 64);
            this.labelProcSteelType.Name = "labelProcSteelType";
            this.labelProcSteelType.Size = new System.Drawing.Size(73, 16);
            this.labelProcSteelType.TabIndex = 13;
            this.labelProcSteelType.Text = "Steel Type";
            // 
            // labelProcTierLevel
            // 
            this.labelProcTierLevel.AutoSize = true;
            this.labelProcTierLevel.Location = new System.Drawing.Point(5, 20);
            this.labelProcTierLevel.Name = "labelProcTierLevel";
            this.labelProcTierLevel.Size = new System.Drawing.Size(67, 16);
            this.labelProcTierLevel.TabIndex = 12;
            this.labelProcTierLevel.Text = "Tier Level";
            // 
            // comboBoxProcTierLevel
            // 
            this.comboBoxProcTierLevel.FormattingEnabled = true;
            this.comboBoxProcTierLevel.Location = new System.Drawing.Point(107, 20);
            this.comboBoxProcTierLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxProcTierLevel.Name = "comboBoxProcTierLevel";
            this.comboBoxProcTierLevel.Size = new System.Drawing.Size(160, 24);
            this.comboBoxProcTierLevel.TabIndex = 11;
            this.comboBoxProcTierLevel.SelectedIndexChanged += new System.EventHandler(this.ComboBoxProcTierLevel_SelectedIndexChanged);
            // 
            // tabPageSteelTypes
            // 
            this.tabPageSteelTypes.Controls.Add(this.buttonSTAddFinish);
            this.tabPageSteelTypes.Controls.Add(this.listBoxSTFinish);
            this.tabPageSteelTypes.Controls.Add(this.buttonSteelTypeAddAlloy);
            this.tabPageSteelTypes.Controls.Add(this.dataGridViewSteelTypeAlloys);
            this.tabPageSteelTypes.Controls.Add(this.buttonSteelTypeAdd);
            this.tabPageSteelTypes.Controls.Add(this.listBoxSteelTypes);
            this.tabPageSteelTypes.Location = new System.Drawing.Point(4, 25);
            this.tabPageSteelTypes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageSteelTypes.Name = "tabPageSteelTypes";
            this.tabPageSteelTypes.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageSteelTypes.Size = new System.Drawing.Size(1091, 620);
            this.tabPageSteelTypes.TabIndex = 8;
            this.tabPageSteelTypes.Text = "Steel Types";
            this.tabPageSteelTypes.UseVisualStyleBackColor = true;
            // 
            // buttonSTAddFinish
            // 
            this.buttonSTAddFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSTAddFinish.Location = new System.Drawing.Point(227, 507);
            this.buttonSTAddFinish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSTAddFinish.Name = "buttonSTAddFinish";
            this.buttonSTAddFinish.Size = new System.Drawing.Size(148, 42);
            this.buttonSTAddFinish.TabIndex = 5;
            this.buttonSTAddFinish.Text = "Add Finish";
            this.buttonSTAddFinish.UseVisualStyleBackColor = true;
            this.buttonSTAddFinish.Click += new System.EventHandler(this.ButtonSTAddFinish_Click);
            // 
            // listBoxSTFinish
            // 
            this.listBoxSTFinish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxSTFinish.FormattingEnabled = true;
            this.listBoxSTFinish.ItemHeight = 16;
            this.listBoxSTFinish.Location = new System.Drawing.Point(227, 27);
            this.listBoxSTFinish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxSTFinish.Name = "listBoxSTFinish";
            this.listBoxSTFinish.Size = new System.Drawing.Size(167, 468);
            this.listBoxSTFinish.TabIndex = 4;
            this.listBoxSTFinish.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxSTFinish_MouseDoubleClick);
            // 
            // buttonSteelTypeAddAlloy
            // 
            this.buttonSteelTypeAddAlloy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSteelTypeAddAlloy.Location = new System.Drawing.Point(420, 507);
            this.buttonSteelTypeAddAlloy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSteelTypeAddAlloy.Name = "buttonSteelTypeAddAlloy";
            this.buttonSteelTypeAddAlloy.Size = new System.Drawing.Size(148, 42);
            this.buttonSteelTypeAddAlloy.TabIndex = 3;
            this.buttonSteelTypeAddAlloy.Text = "Add Alloy";
            this.buttonSteelTypeAddAlloy.UseVisualStyleBackColor = true;
            this.buttonSteelTypeAddAlloy.Click += new System.EventHandler(this.ButtonSteelTypeAddAlloy_Click);
            // 
            // dataGridViewSteelTypeAlloys
            // 
            this.dataGridViewSteelTypeAlloys.AllowUserToAddRows = false;
            this.dataGridViewSteelTypeAlloys.AllowUserToDeleteRows = false;
            this.dataGridViewSteelTypeAlloys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSteelTypeAlloys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSteelTypeAlloys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSTAlloy,
            this.dgvSTAlloyID,
            this.dgvSTDensity,
            this.dgvSTDisplayOrder,
            this.dgvSTPrice});
            this.dataGridViewSteelTypeAlloys.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewSteelTypeAlloys.Location = new System.Drawing.Point(419, 27);
            this.dataGridViewSteelTypeAlloys.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewSteelTypeAlloys.Name = "dataGridViewSteelTypeAlloys";
            this.dataGridViewSteelTypeAlloys.RowHeadersWidth = 51;
            this.dataGridViewSteelTypeAlloys.RowTemplate.Height = 24;
            this.dataGridViewSteelTypeAlloys.Size = new System.Drawing.Size(684, 468);
            this.dataGridViewSteelTypeAlloys.TabIndex = 2;
            this.dataGridViewSteelTypeAlloys.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewSteelTypeAlloys_CellEndEdit);
            this.dataGridViewSteelTypeAlloys.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewSteelTypeAlloys_EditingControlShowing);
            // 
            // dgvSTAlloy
            // 
            this.dgvSTAlloy.HeaderText = "Alloy";
            this.dgvSTAlloy.MinimumWidth = 6;
            this.dgvSTAlloy.Name = "dgvSTAlloy";
            this.dgvSTAlloy.Width = 125;
            // 
            // dgvSTAlloyID
            // 
            this.dgvSTAlloyID.HeaderText = "AlloyID";
            this.dgvSTAlloyID.MinimumWidth = 6;
            this.dgvSTAlloyID.Name = "dgvSTAlloyID";
            this.dgvSTAlloyID.Visible = false;
            this.dgvSTAlloyID.Width = 125;
            // 
            // dgvSTDensity
            // 
            this.dgvSTDensity.HeaderText = "Density";
            this.dgvSTDensity.MinimumWidth = 6;
            this.dgvSTDensity.Name = "dgvSTDensity";
            this.dgvSTDensity.Width = 125;
            // 
            // dgvSTDisplayOrder
            // 
            this.dgvSTDisplayOrder.HeaderText = "Display Order";
            this.dgvSTDisplayOrder.MinimumWidth = 6;
            this.dgvSTDisplayOrder.Name = "dgvSTDisplayOrder";
            this.dgvSTDisplayOrder.Width = 125;
            // 
            // dgvSTPrice
            // 
            this.dgvSTPrice.HeaderText = "Price";
            this.dgvSTPrice.MinimumWidth = 6;
            this.dgvSTPrice.Name = "dgvSTPrice";
            this.dgvSTPrice.ReadOnly = true;
            this.dgvSTPrice.Width = 125;
            // 
            // buttonSteelTypeAdd
            // 
            this.buttonSteelTypeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSteelTypeAdd.Location = new System.Drawing.Point(36, 507);
            this.buttonSteelTypeAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSteelTypeAdd.Name = "buttonSteelTypeAdd";
            this.buttonSteelTypeAdd.Size = new System.Drawing.Size(148, 42);
            this.buttonSteelTypeAdd.TabIndex = 1;
            this.buttonSteelTypeAdd.Text = "Add Steel Type";
            this.buttonSteelTypeAdd.UseVisualStyleBackColor = true;
            this.buttonSteelTypeAdd.Click += new System.EventHandler(this.ButtonSteelTypeAdd_Click);
            // 
            // listBoxSteelTypes
            // 
            this.listBoxSteelTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxSteelTypes.FormattingEnabled = true;
            this.listBoxSteelTypes.ItemHeight = 16;
            this.listBoxSteelTypes.Location = new System.Drawing.Point(36, 27);
            this.listBoxSteelTypes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxSteelTypes.Name = "listBoxSteelTypes";
            this.listBoxSteelTypes.Size = new System.Drawing.Size(164, 468);
            this.listBoxSteelTypes.TabIndex = 0;
            this.listBoxSteelTypes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxSteelTypes_MouseClick);
            this.listBoxSteelTypes.SelectedIndexChanged += new System.EventHandler(this.ListBoxSteelTypes_SelectedIndexChanged);
            this.listBoxSteelTypes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxSteelTypes_MouseDoubleClick);
            this.listBoxSteelTypes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBoxSteelTypes_MouseDown);
            // 
            // tabPageSTPricing
            // 
            this.tabPageSTPricing.Controls.Add(this.listViewSPHistory);
            this.tabPageSTPricing.Controls.Add(this.labelSPPrice);
            this.tabPageSTPricing.Controls.Add(this.chartSPHistory);
            this.tabPageSTPricing.Controls.Add(this.listViewSPPrice);
            this.tabPageSTPricing.Location = new System.Drawing.Point(4, 25);
            this.tabPageSTPricing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageSTPricing.Name = "tabPageSTPricing";
            this.tabPageSTPricing.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageSTPricing.Size = new System.Drawing.Size(1091, 620);
            this.tabPageSTPricing.TabIndex = 9;
            this.tabPageSTPricing.Text = "Steel Prices";
            this.tabPageSTPricing.UseVisualStyleBackColor = true;
            // 
            // listViewSPHistory
            // 
            this.listViewSPHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewSPHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSPHistoryPrice,
            this.columnHeaderSPHistoryDate});
            this.listViewSPHistory.HideSelection = false;
            this.listViewSPHistory.Location = new System.Drawing.Point(272, 26);
            this.listViewSPHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewSPHistory.Name = "listViewSPHistory";
            this.listViewSPHistory.Size = new System.Drawing.Size(267, 532);
            this.listViewSPHistory.TabIndex = 1;
            this.listViewSPHistory.UseCompatibleStateImageBehavior = false;
            this.listViewSPHistory.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSPHistoryPrice
            // 
            this.columnHeaderSPHistoryPrice.Text = "Price";
            this.columnHeaderSPHistoryPrice.Width = 44;
            // 
            // columnHeaderSPHistoryDate
            // 
            this.columnHeaderSPHistoryDate.Text = "Date";
            this.columnHeaderSPHistoryDate.Width = 133;
            // 
            // labelSPPrice
            // 
            this.labelSPPrice.AutoSize = true;
            this.labelSPPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSPPrice.ForeColor = System.Drawing.Color.Red;
            this.labelSPPrice.Location = new System.Drawing.Point(21, 6);
            this.labelSPPrice.Name = "labelSPPrice";
            this.labelSPPrice.Size = new System.Drawing.Size(213, 16);
            this.labelSPPrice.TabIndex = 3;
            this.labelSPPrice.Text = "Double Click To Update Price";
            // 
            // chartSPHistory
            // 
            this.chartSPHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartSPHistory.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSPHistory.Legends.Add(legend1);
            this.chartSPHistory.Location = new System.Drawing.Point(521, 26);
            this.chartSPHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartSPHistory.Name = "chartSPHistory";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Price";
            this.chartSPHistory.Series.Add(series1);
            this.chartSPHistory.Size = new System.Drawing.Size(707, 532);
            this.chartSPHistory.TabIndex = 2;
            this.chartSPHistory.Text = "chart1";
            // 
            // listViewSPPrice
            // 
            this.listViewSPPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewSPPrice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSPAlloy,
            this.columnHeaderSPPrice});
            this.listViewSPPrice.FullRowSelect = true;
            this.listViewSPPrice.HideSelection = false;
            this.listViewSPPrice.Location = new System.Drawing.Point(24, 26);
            this.listViewSPPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewSPPrice.Name = "listViewSPPrice";
            this.listViewSPPrice.Size = new System.Drawing.Size(241, 532);
            this.listViewSPPrice.TabIndex = 0;
            this.listViewSPPrice.UseCompatibleStateImageBehavior = false;
            this.listViewSPPrice.View = System.Windows.Forms.View.Details;
            this.listViewSPPrice.SelectedIndexChanged += new System.EventHandler(this.ListViewSPPrice_SelectedIndexChanged);
            this.listViewSPPrice.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewSPPrice_MouseDoubleClick);
            // 
            // columnHeaderSPAlloy
            // 
            this.columnHeaderSPAlloy.Text = "Alloy";
            this.columnHeaderSPAlloy.Width = 61;
            // 
            // columnHeaderSPPrice
            // 
            this.columnHeaderSPPrice.Text = "Price";
            this.columnHeaderSPPrice.Width = 91;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Controls.Add(this.labelAboutConnString);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 25);
            this.tabPageAbout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAbout.Size = new System.Drawing.Size(1091, 620);
            this.tabPageAbout.TabIndex = 4;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // labelAboutConnString
            // 
            this.labelAboutConnString.AutoSize = true;
            this.labelAboutConnString.Location = new System.Drawing.Point(49, 46);
            this.labelAboutConnString.Name = "labelAboutConnString";
            this.labelAboutConnString.Size = new System.Drawing.Size(0, 16);
            this.labelAboutConnString.TabIndex = 0;
            // 
            // tabControlProcess
            // 
            this.tabControlProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlProcess.Location = new System.Drawing.Point(874, 9);
            this.tabControlProcess.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlProcess.Name = "tabControlProcess";
            this.tabControlProcess.SelectedIndex = 0;
            this.tabControlProcess.Size = new System.Drawing.Size(497, 25);
            this.tabControlProcess.TabIndex = 5;
            this.tabControlProcess.Visible = false;
            this.tabControlProcess.SelectedIndexChanged += new System.EventHandler(this.TabControlProcess_SelectedIndexChanged);
            // 
            // tabControlMachines
            // 
            this.tabControlMachines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMachines.Location = new System.Drawing.Point(874, 38);
            this.tabControlMachines.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlMachines.Name = "tabControlMachines";
            this.tabControlMachines.SelectedIndex = 0;
            this.tabControlMachines.Size = new System.Drawing.Size(500, 25);
            this.tabControlMachines.TabIndex = 6;
            this.tabControlMachines.Visible = false;
            this.tabControlMachines.SelectedIndexChanged += new System.EventHandler(this.TabControlMachines_SelectedIndexChanged);
            this.tabControlMachines.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlMachines_Selected);
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.panelCoilSheetSame);
            this.tabPageOrders.Controls.Add(this.panelSheetSheetDiff);
            this.tabPageOrders.Controls.Add(this.panelCoilCoilSame);
            this.tabPageOrders.Controls.Add(this.panelClClDiff);
            this.tabPageOrders.Controls.Add(this.panelSheetSheetSame);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 25);
            this.tabPageOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageOrders.Size = new System.Drawing.Size(1099, 617);
            this.tabPageOrders.TabIndex = 5;
            this.tabPageOrders.Text = "Orders";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // panelCoilSheetSame
            // 
            this.panelCoilSheetSame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCoilSheetSame.Controls.Add(this.labelPaperPrice);
            this.panelCoilSheetSame.Controls.Add(this.textBoxPaperPrice);
            this.panelCoilSheetSame.Controls.Add(this.labelSpecialLeadTime);
            this.panelCoilSheetSame.Controls.Add(this.dataGridViewAdders);
            this.panelCoilSheetSame.Controls.Add(this.buttonCTLDeleteRow);
            this.panelCoilSheetSame.Controls.Add(this.buttonAdderDone);
            this.panelCoilSheetSame.Controls.Add(this.textBoxCTLRunSheetComments);
            this.panelCoilSheetSame.Controls.Add(this.labelCTLRunSheetComments);
            this.panelCoilSheetSame.Controls.Add(this.buttonCTLDelete);
            this.panelCoilSheetSame.Controls.Add(this.comboBoxCTLModify);
            this.panelCoilSheetSame.Controls.Add(this.checkBoxCTLModify);
            this.panelCoilSheetSame.Controls.Add(this.labelCTLSendTo);
            this.panelCoilSheetSame.Controls.Add(this.comboBoxCTLSendTo);
            this.panelCoilSheetSame.Controls.Add(this.checkBoxCTLMultiStep);
            this.panelCoilSheetSame.Controls.Add(this.buttonCTLReset);
            this.panelCoilSheetSame.Controls.Add(this.labelCTLPrice);
            this.panelCoilSheetSame.Controls.Add(this.labelCTLPO);
            this.panelCoilSheetSame.Controls.Add(this.labelCTLPromiseDate);
            this.panelCoilSheetSame.Controls.Add(this.checkBoxCTLScrapCredit);
            this.panelCoilSheetSame.Controls.Add(this.textBoxCTLPO);
            this.panelCoilSheetSame.Controls.Add(this.textBoxCTLPrice);
            this.panelCoilSheetSame.Controls.Add(this.dateTimePickerCTLPromiseDate);
            this.panelCoilSheetSame.Controls.Add(this.richTextBoxCTLComments);
            this.panelCoilSheetSame.Controls.Add(this.buttonCTLAddOrder);
            this.panelCoilSheetSame.Controls.Add(this.buttonCTLArrowDown);
            this.panelCoilSheetSame.Controls.Add(this.buttonCTLArrowUp);
            this.panelCoilSheetSame.Controls.Add(this.dataGridViewCTLOrderEntry);
            this.panelCoilSheetSame.Controls.Add(this.listViewCTLCoilList);
            this.panelCoilSheetSame.Controls.Add(this.buttonCTLStartOrder);
            this.panelCoilSheetSame.Location = new System.Drawing.Point(-3, 7);
            this.panelCoilSheetSame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCoilSheetSame.Name = "panelCoilSheetSame";
            this.panelCoilSheetSame.Size = new System.Drawing.Size(1106, 602);
            this.panelCoilSheetSame.TabIndex = 0;
            this.panelCoilSheetSame.Visible = false;
            this.panelCoilSheetSame.VisibleChanged += new System.EventHandler(this.PanelCoilSheetSame_VisibleChanged);
            // 
            // labelPaperPrice
            // 
            this.labelPaperPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPaperPrice.AutoSize = true;
            this.labelPaperPrice.Location = new System.Drawing.Point(696, 481);
            this.labelPaperPrice.Name = "labelPaperPrice";
            this.labelPaperPrice.Size = new System.Drawing.Size(78, 16);
            this.labelPaperPrice.TabIndex = 48;
            this.labelPaperPrice.Text = "Paper Price";
            // 
            // textBoxPaperPrice
            // 
            this.textBoxPaperPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPaperPrice.Location = new System.Drawing.Point(780, 480);
            this.textBoxPaperPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPaperPrice.Name = "textBoxPaperPrice";
            this.textBoxPaperPrice.Size = new System.Drawing.Size(112, 22);
            this.textBoxPaperPrice.TabIndex = 10;
            this.textBoxPaperPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPaperPrice_KeyPress);
            // 
            // labelSpecialLeadTime
            // 
            this.labelSpecialLeadTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSpecialLeadTime.AutoSize = true;
            this.labelSpecialLeadTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpecialLeadTime.ForeColor = System.Drawing.Color.Red;
            this.labelSpecialLeadTime.Location = new System.Drawing.Point(533, 573);
            this.labelSpecialLeadTime.Name = "labelSpecialLeadTime";
            this.labelSpecialLeadTime.Size = new System.Drawing.Size(153, 20);
            this.labelSpecialLeadTime.TabIndex = 46;
            this.labelSpecialLeadTime.Text = "Special Lead Time!";
            this.labelSpecialLeadTime.Visible = false;
            // 
            // dataGridViewAdders
            // 
            this.dataGridViewAdders.AllowUserToAddRows = false;
            this.dataGridViewAdders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.dgvAdderDesc,
            this.dgvAdderPrice});
            this.dataGridViewAdders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewAdders.Location = new System.Drawing.Point(605, 74);
            this.dataGridViewAdders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewAdders.MultiSelect = false;
            this.dataGridViewAdders.Name = "dataGridViewAdders";
            this.dataGridViewAdders.RowHeadersVisible = false;
            this.dataGridViewAdders.RowHeadersWidth = 12;
            this.dataGridViewAdders.RowTemplate.Height = 24;
            this.dataGridViewAdders.Size = new System.Drawing.Size(347, 174);
            this.dataGridViewAdders.TabIndex = 45;
            this.dataGridViewAdders.Visible = false;
            // 
            // colSelect
            // 
            this.colSelect.HeaderText = "Sel";
            this.colSelect.MinimumWidth = 6;
            this.colSelect.Name = "colSelect";
            this.colSelect.Width = 50;
            // 
            // dgvAdderDesc
            // 
            this.dgvAdderDesc.HeaderText = "Adder";
            this.dgvAdderDesc.MinimumWidth = 6;
            this.dgvAdderDesc.Name = "dgvAdderDesc";
            this.dgvAdderDesc.Width = 125;
            // 
            // dgvAdderPrice
            // 
            this.dgvAdderPrice.HeaderText = "Price";
            this.dgvAdderPrice.MinimumWidth = 6;
            this.dgvAdderPrice.Name = "dgvAdderPrice";
            this.dgvAdderPrice.Width = 125;
            // 
            // buttonCTLDeleteRow
            // 
            this.buttonCTLDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCTLDeleteRow.Location = new System.Drawing.Point(751, 442);
            this.buttonCTLDeleteRow.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCTLDeleteRow.Name = "buttonCTLDeleteRow";
            this.buttonCTLDeleteRow.Size = new System.Drawing.Size(163, 27);
            this.buttonCTLDeleteRow.TabIndex = 14;
            this.buttonCTLDeleteRow.Text = "Delete Row";
            this.buttonCTLDeleteRow.UseVisualStyleBackColor = true;
            this.buttonCTLDeleteRow.Visible = false;
            this.buttonCTLDeleteRow.Click += new System.EventHandler(this.ButtonCTLDeleteRow_Click);
            // 
            // buttonAdderDone
            // 
            this.buttonAdderDone.Location = new System.Drawing.Point(448, 202);
            this.buttonAdderDone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdderDone.Name = "buttonAdderDone";
            this.buttonAdderDone.Size = new System.Drawing.Size(99, 27);
            this.buttonAdderDone.TabIndex = 41;
            this.buttonAdderDone.Text = "Done";
            this.buttonAdderDone.UseVisualStyleBackColor = true;
            this.buttonAdderDone.Click += new System.EventHandler(this.ButtonAdderDone_Click);
            // 
            // textBoxCTLRunSheetComments
            // 
            this.textBoxCTLRunSheetComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCTLRunSheetComments.Location = new System.Drawing.Point(643, 529);
            this.textBoxCTLRunSheetComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCTLRunSheetComments.Name = "textBoxCTLRunSheetComments";
            this.textBoxCTLRunSheetComments.Size = new System.Drawing.Size(379, 22);
            this.textBoxCTLRunSheetComments.TabIndex = 12;
            this.textBoxCTLRunSheetComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCTLRunSheetComments_KeyPress);
            // 
            // labelCTLRunSheetComments
            // 
            this.labelCTLRunSheetComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCTLRunSheetComments.AutoSize = true;
            this.labelCTLRunSheetComments.Location = new System.Drawing.Point(491, 534);
            this.labelCTLRunSheetComments.Name = "labelCTLRunSheetComments";
            this.labelCTLRunSheetComments.Size = new System.Drawing.Size(136, 16);
            this.labelCTLRunSheetComments.TabIndex = 38;
            this.labelCTLRunSheetComments.Text = "Run Sheet Comments";
            // 
            // buttonCTLDelete
            // 
            this.buttonCTLDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCTLDelete.Location = new System.Drawing.Point(176, 465);
            this.buttonCTLDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCTLDelete.Name = "buttonCTLDelete";
            this.buttonCTLDelete.Size = new System.Drawing.Size(64, 39);
            this.buttonCTLDelete.TabIndex = 36;
            this.buttonCTLDelete.Text = "Delete";
            this.buttonCTLDelete.UseVisualStyleBackColor = true;
            this.buttonCTLDelete.Visible = false;
            // 
            // comboBoxCTLModify
            // 
            this.comboBoxCTLModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCTLModify.FormattingEnabled = true;
            this.comboBoxCTLModify.Location = new System.Drawing.Point(27, 481);
            this.comboBoxCTLModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxCTLModify.Name = "comboBoxCTLModify";
            this.comboBoxCTLModify.Size = new System.Drawing.Size(141, 24);
            this.comboBoxCTLModify.TabIndex = 2;
            this.comboBoxCTLModify.Visible = false;
            this.comboBoxCTLModify.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCTLModify_SelectedIndexChanged);
            // 
            // checkBoxCTLModify
            // 
            this.checkBoxCTLModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxCTLModify.AutoSize = true;
            this.checkBoxCTLModify.Location = new System.Drawing.Point(5, 458);
            this.checkBoxCTLModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxCTLModify.Name = "checkBoxCTLModify";
            this.checkBoxCTLModify.Size = new System.Drawing.Size(69, 20);
            this.checkBoxCTLModify.TabIndex = 1;
            this.checkBoxCTLModify.Text = "Modify";
            this.checkBoxCTLModify.UseVisualStyleBackColor = true;
            this.checkBoxCTLModify.CheckedChanged += new System.EventHandler(this.CheckBoxCTLModify_CheckedChanged);
            // 
            // labelCTLSendTo
            // 
            this.labelCTLSendTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCTLSendTo.AutoSize = true;
            this.labelCTLSendTo.Location = new System.Drawing.Point(24, 537);
            this.labelCTLSendTo.Name = "labelCTLSendTo";
            this.labelCTLSendTo.Size = new System.Drawing.Size(53, 16);
            this.labelCTLSendTo.TabIndex = 33;
            this.labelCTLSendTo.Text = "Send to";
            this.labelCTLSendTo.Visible = false;
            // 
            // comboBoxCTLSendTo
            // 
            this.comboBoxCTLSendTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCTLSendTo.FormattingEnabled = true;
            this.comboBoxCTLSendTo.Location = new System.Drawing.Point(27, 557);
            this.comboBoxCTLSendTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxCTLSendTo.Name = "comboBoxCTLSendTo";
            this.comboBoxCTLSendTo.Size = new System.Drawing.Size(171, 24);
            this.comboBoxCTLSendTo.TabIndex = 4;
            this.comboBoxCTLSendTo.Visible = false;
            // 
            // checkBoxCTLMultiStep
            // 
            this.checkBoxCTLMultiStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxCTLMultiStep.AutoSize = true;
            this.checkBoxCTLMultiStep.Location = new System.Drawing.Point(5, 516);
            this.checkBoxCTLMultiStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxCTLMultiStep.Name = "checkBoxCTLMultiStep";
            this.checkBoxCTLMultiStep.Size = new System.Drawing.Size(84, 20);
            this.checkBoxCTLMultiStep.TabIndex = 3;
            this.checkBoxCTLMultiStep.Text = "MultiStep";
            this.checkBoxCTLMultiStep.UseVisualStyleBackColor = true;
            // 
            // buttonCTLReset
            // 
            this.buttonCTLReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCTLReset.Location = new System.Drawing.Point(918, 442);
            this.buttonCTLReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCTLReset.Name = "buttonCTLReset";
            this.buttonCTLReset.Size = new System.Drawing.Size(165, 28);
            this.buttonCTLReset.TabIndex = 15;
            this.buttonCTLReset.Text = "Reset All";
            this.buttonCTLReset.UseVisualStyleBackColor = true;
            this.buttonCTLReset.Click += new System.EventHandler(this.ButtonCTLReset_Click);
            // 
            // labelCTLPrice
            // 
            this.labelCTLPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCTLPrice.AutoSize = true;
            this.labelCTLPrice.Location = new System.Drawing.Point(491, 481);
            this.labelCTLPrice.Name = "labelCTLPrice";
            this.labelCTLPrice.Size = new System.Drawing.Size(38, 16);
            this.labelCTLPrice.TabIndex = 28;
            this.labelCTLPrice.Text = "Price";
            // 
            // labelCTLPO
            // 
            this.labelCTLPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCTLPO.AutoSize = true;
            this.labelCTLPO.Location = new System.Drawing.Point(491, 507);
            this.labelCTLPO.Name = "labelCTLPO";
            this.labelCTLPO.Size = new System.Drawing.Size(101, 16);
            this.labelCTLPO.TabIndex = 27;
            this.labelCTLPO.Text = "Purchase Order";
            // 
            // labelCTLPromiseDate
            // 
            this.labelCTLPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCTLPromiseDate.AutoSize = true;
            this.labelCTLPromiseDate.Location = new System.Drawing.Point(247, 552);
            this.labelCTLPromiseDate.Name = "labelCTLPromiseDate";
            this.labelCTLPromiseDate.Size = new System.Drawing.Size(89, 16);
            this.labelCTLPromiseDate.TabIndex = 26;
            this.labelCTLPromiseDate.Text = "Promise Date";
            // 
            // checkBoxCTLScrapCredit
            // 
            this.checkBoxCTLScrapCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxCTLScrapCredit.AutoSize = true;
            this.checkBoxCTLScrapCredit.Location = new System.Drawing.Point(493, 458);
            this.checkBoxCTLScrapCredit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxCTLScrapCredit.Name = "checkBoxCTLScrapCredit";
            this.checkBoxCTLScrapCredit.Size = new System.Drawing.Size(103, 20);
            this.checkBoxCTLScrapCredit.TabIndex = 8;
            this.checkBoxCTLScrapCredit.Text = "Scrap Credit";
            this.checkBoxCTLScrapCredit.UseVisualStyleBackColor = true;
            // 
            // textBoxCTLPO
            // 
            this.textBoxCTLPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCTLPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxCTLPO.Location = new System.Drawing.Point(605, 505);
            this.textBoxCTLPO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCTLPO.Name = "textBoxCTLPO";
            this.textBoxCTLPO.Size = new System.Drawing.Size(227, 22);
            this.textBoxCTLPO.TabIndex = 11;
            this.textBoxCTLPO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCTLPO_KeyPress);
            // 
            // textBoxCTLPrice
            // 
            this.textBoxCTLPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCTLPrice.Location = new System.Drawing.Point(536, 480);
            this.textBoxCTLPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCTLPrice.Name = "textBoxCTLPrice";
            this.textBoxCTLPrice.Size = new System.Drawing.Size(112, 22);
            this.textBoxCTLPrice.TabIndex = 9;
            this.textBoxCTLPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxCTLPrice_KeyPress);
            // 
            // dateTimePickerCTLPromiseDate
            // 
            this.dateTimePickerCTLPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerCTLPromiseDate.Location = new System.Drawing.Point(249, 574);
            this.dateTimePickerCTLPromiseDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerCTLPromiseDate.Name = "dateTimePickerCTLPromiseDate";
            this.dateTimePickerCTLPromiseDate.Size = new System.Drawing.Size(272, 22);
            this.dateTimePickerCTLPromiseDate.TabIndex = 7;
            // 
            // richTextBoxCTLComments
            // 
            this.richTextBoxCTLComments.AcceptsTab = true;
            this.richTextBoxCTLComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxCTLComments.Location = new System.Drawing.Point(249, 472);
            this.richTextBoxCTLComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxCTLComments.MaxLength = 250;
            this.richTextBoxCTLComments.Name = "richTextBoxCTLComments";
            this.richTextBoxCTLComments.Size = new System.Drawing.Size(239, 74);
            this.richTextBoxCTLComments.TabIndex = 6;
            this.richTextBoxCTLComments.Text = "";
            this.richTextBoxCTLComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxCTLComments_KeyPress);
            // 
            // buttonCTLAddOrder
            // 
            this.buttonCTLAddOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCTLAddOrder.Location = new System.Drawing.Point(918, 559);
            this.buttonCTLAddOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCTLAddOrder.Name = "buttonCTLAddOrder";
            this.buttonCTLAddOrder.Size = new System.Drawing.Size(163, 32);
            this.buttonCTLAddOrder.TabIndex = 13;
            this.buttonCTLAddOrder.Text = "AddOrder";
            this.buttonCTLAddOrder.UseVisualStyleBackColor = true;
            this.buttonCTLAddOrder.Visible = false;
            this.buttonCTLAddOrder.Click += new System.EventHandler(this.ButtonCTLAddOrder_Click);
            // 
            // buttonCTLArrowDown
            // 
            this.buttonCTLArrowDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCTLArrowDown.Image = global::ICMS.Properties.Resources.DownArrow1;
            this.buttonCTLArrowDown.Location = new System.Drawing.Point(300, 433);
            this.buttonCTLArrowDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCTLArrowDown.Name = "buttonCTLArrowDown";
            this.buttonCTLArrowDown.Size = new System.Drawing.Size(45, 34);
            this.buttonCTLArrowDown.TabIndex = 44;
            this.buttonCTLArrowDown.UseVisualStyleBackColor = true;
            this.buttonCTLArrowDown.Visible = false;
            this.buttonCTLArrowDown.Click += new System.EventHandler(this.ButtonCTLArrowDown_Click);
            // 
            // buttonCTLArrowUp
            // 
            this.buttonCTLArrowUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCTLArrowUp.Image = global::ICMS.Properties.Resources.UpArrow;
            this.buttonCTLArrowUp.Location = new System.Drawing.Point(249, 433);
            this.buttonCTLArrowUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCTLArrowUp.Name = "buttonCTLArrowUp";
            this.buttonCTLArrowUp.Size = new System.Drawing.Size(45, 34);
            this.buttonCTLArrowUp.TabIndex = 43;
            this.buttonCTLArrowUp.UseVisualStyleBackColor = true;
            this.buttonCTLArrowUp.Visible = false;
            this.buttonCTLArrowUp.Click += new System.EventHandler(this.ButtonCTLArrowUp_Click);
            this.buttonCTLArrowUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonCTLArrowUp_MouseDown);
            // 
            // dataGridViewCTLOrderEntry
            // 
            this.dataGridViewCTLOrderEntry.AllowUserToAddRows = false;
            this.dataGridViewCTLOrderEntry.AllowUserToDeleteRows = false;
            this.dataGridViewCTLOrderEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCTLOrderEntry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewCTLOrderEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCTLOrderEntry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvCTLTagID,
            this.dgvCTLThickness,
            this.dgvCTLWidth,
            this.dgvCTLAlloy,
            this.dgvCTLWeight,
            this.dgvCTLWeightLeft,
            this.dgvCTLPaper,
            this.dgvCTLPVC,
            this.dgvCTLAdder,
            this.dgvCTLAddCut,
            this.dgvCTLSkidType,
            this.dgvCTLCurrSkidPrice,
            this.dgvCTLSkidCount,
            this.dgvCTLPieceCount,
            this.dgvCTLLength,
            this.dgvCTLComments,
            this.dgvCTLSheetWeight,
            this.dgvCTLTheoLBS,
            this.dgvCTLBranch,
            this.dgvCTLBranchID,
            this.dgvCTLAdderID,
            this.dgvCTLAdderPrice,
            this.dgvCTLDensityFactor,
            this.dgvCTLPVCGroupID,
            this.dgvSkidTypeID,
            this.dgvCTLPVCPriceList,
            this.dgvCTLCurrPrice});
            this.dataGridViewCTLOrderEntry.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewCTLOrderEntry.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCTLOrderEntry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewCTLOrderEntry.MultiSelect = false;
            this.dataGridViewCTLOrderEntry.Name = "dataGridViewCTLOrderEntry";
            this.dataGridViewCTLOrderEntry.RowHeadersWidth = 51;
            this.dataGridViewCTLOrderEntry.RowTemplate.Height = 24;
            this.dataGridViewCTLOrderEntry.Size = new System.Drawing.Size(1097, 433);
            this.dataGridViewCTLOrderEntry.TabIndex = 37;
            this.dataGridViewCTLOrderEntry.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridViewCTLOrderEntry_CellBeginEdit);
            this.dataGridViewCTLOrderEntry.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCTLOrderEntry_CellClick);
            this.dataGridViewCTLOrderEntry.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCTLOrderEntry_CellContentClick);
            this.dataGridViewCTLOrderEntry.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCTLOrderEntry_CellEndEdit);
            this.dataGridViewCTLOrderEntry.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCTLOrderEntry_CellEnter);
            this.dataGridViewCTLOrderEntry.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewCTLOrderEntry_EditingControlShowing);
            this.dataGridViewCTLOrderEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataGridViewCTLOrderEntry_KeyPress);
            this.dataGridViewCTLOrderEntry.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewCTLOrderEntry_MouseClick);
            // 
            // dgvCTLTagID
            // 
            this.dgvCTLTagID.FillWeight = 75F;
            this.dgvCTLTagID.HeaderText = "TagID";
            this.dgvCTLTagID.MinimumWidth = 6;
            this.dgvCTLTagID.Name = "dgvCTLTagID";
            this.dgvCTLTagID.ReadOnly = true;
            this.dgvCTLTagID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCTLTagID.Width = 51;
            // 
            // dgvCTLThickness
            // 
            this.dgvCTLThickness.HeaderText = "Thickness";
            this.dgvCTLThickness.MinimumWidth = 6;
            this.dgvCTLThickness.Name = "dgvCTLThickness";
            this.dgvCTLThickness.ReadOnly = true;
            this.dgvCTLThickness.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCTLThickness.Width = 75;
            // 
            // dgvCTLWidth
            // 
            this.dgvCTLWidth.HeaderText = "Width";
            this.dgvCTLWidth.MinimumWidth = 6;
            this.dgvCTLWidth.Name = "dgvCTLWidth";
            this.dgvCTLWidth.ReadOnly = true;
            this.dgvCTLWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCTLWidth.Width = 47;
            // 
            // dgvCTLAlloy
            // 
            this.dgvCTLAlloy.HeaderText = "Alloy";
            this.dgvCTLAlloy.MinimumWidth = 6;
            this.dgvCTLAlloy.Name = "dgvCTLAlloy";
            this.dgvCTLAlloy.ReadOnly = true;
            this.dgvCTLAlloy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCTLAlloy.Width = 43;
            // 
            // dgvCTLWeight
            // 
            this.dgvCTLWeight.HeaderText = "Orig LBS";
            this.dgvCTLWeight.MinimumWidth = 6;
            this.dgvCTLWeight.Name = "dgvCTLWeight";
            this.dgvCTLWeight.ReadOnly = true;
            this.dgvCTLWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCTLWeight.Width = 60;
            // 
            // dgvCTLWeightLeft
            // 
            this.dgvCTLWeightLeft.HeaderText = "WeightLeft";
            this.dgvCTLWeightLeft.MinimumWidth = 6;
            this.dgvCTLWeightLeft.Name = "dgvCTLWeightLeft";
            this.dgvCTLWeightLeft.ReadOnly = true;
            this.dgvCTLWeightLeft.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCTLWeightLeft.Width = 76;
            // 
            // dgvCTLPaper
            // 
            this.dgvCTLPaper.HeaderText = "Paper";
            this.dgvCTLPaper.MinimumWidth = 6;
            this.dgvCTLPaper.Name = "dgvCTLPaper";
            this.dgvCTLPaper.ToolTipText = ".012";
            this.dgvCTLPaper.Width = 50;
            // 
            // dgvCTLPVC
            // 
            this.dgvCTLPVC.HeaderText = "PVC";
            this.dgvCTLPVC.MinimumWidth = 6;
            this.dgvCTLPVC.Name = "dgvCTLPVC";
            this.dgvCTLPVC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCTLPVC.Width = 40;
            // 
            // dgvCTLAdder
            // 
            this.dgvCTLAdder.HeaderText = "Adders";
            this.dgvCTLAdder.MinimumWidth = 6;
            this.dgvCTLAdder.Name = "dgvCTLAdder";
            this.dgvCTLAdder.Width = 57;
            // 
            // dgvCTLAddCut
            // 
            this.dgvCTLAddCut.HeaderText = "AddCut";
            this.dgvCTLAddCut.MinimumWidth = 6;
            this.dgvCTLAddCut.Name = "dgvCTLAddCut";
            this.dgvCTLAddCut.Text = "AddCut";
            this.dgvCTLAddCut.UseColumnTextForButtonValue = true;
            this.dgvCTLAddCut.Width = 57;
            // 
            // dgvCTLSkidType
            // 
            this.dgvCTLSkidType.HeaderText = "Type";
            this.dgvCTLSkidType.MinimumWidth = 6;
            this.dgvCTLSkidType.Name = "dgvCTLSkidType";
            this.dgvCTLSkidType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCTLSkidType.Width = 45;
            // 
            // dgvCTLCurrSkidPrice
            // 
            this.dgvCTLCurrSkidPrice.HeaderText = "Skid Price";
            this.dgvCTLCurrSkidPrice.MinimumWidth = 6;
            this.dgvCTLCurrSkidPrice.Name = "dgvCTLCurrSkidPrice";
            this.dgvCTLCurrSkidPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCTLCurrSkidPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCTLCurrSkidPrice.Width = 67;
            // 
            // dgvCTLSkidCount
            // 
            this.dgvCTLSkidCount.HeaderText = "Skids";
            this.dgvCTLSkidCount.MinimumWidth = 6;
            this.dgvCTLSkidCount.Name = "dgvCTLSkidCount";
            this.dgvCTLSkidCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCTLSkidCount.Width = 47;
            // 
            // dgvCTLPieceCount
            // 
            this.dgvCTLPieceCount.HeaderText = "PCS";
            this.dgvCTLPieceCount.MinimumWidth = 6;
            this.dgvCTLPieceCount.Name = "dgvCTLPieceCount";
            this.dgvCTLPieceCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCTLPieceCount.Width = 40;
            // 
            // dgvCTLLength
            // 
            this.dgvCTLLength.HeaderText = "Length";
            this.dgvCTLLength.MinimumWidth = 6;
            this.dgvCTLLength.Name = "dgvCTLLength";
            this.dgvCTLLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCTLLength.Width = 53;
            // 
            // dgvCTLComments
            // 
            this.dgvCTLComments.HeaderText = "Detail Comments";
            this.dgvCTLComments.MinimumWidth = 6;
            this.dgvCTLComments.Name = "dgvCTLComments";
            this.dgvCTLComments.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCTLComments.Width = 104;
            // 
            // dgvCTLSheetWeight
            // 
            this.dgvCTLSheetWeight.HeaderText = "Sheet#";
            this.dgvCTLSheetWeight.MinimumWidth = 6;
            this.dgvCTLSheetWeight.Name = "dgvCTLSheetWeight";
            this.dgvCTLSheetWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCTLSheetWeight.Width = 55;
            // 
            // dgvCTLTheoLBS
            // 
            this.dgvCTLTheoLBS.HeaderText = "Theo#";
            this.dgvCTLTheoLBS.MinimumWidth = 6;
            this.dgvCTLTheoLBS.Name = "dgvCTLTheoLBS";
            this.dgvCTLTheoLBS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCTLTheoLBS.Width = 52;
            // 
            // dgvCTLBranch
            // 
            this.dgvCTLBranch.HeaderText = "Branch";
            this.dgvCTLBranch.MinimumWidth = 6;
            this.dgvCTLBranch.Name = "dgvCTLBranch";
            this.dgvCTLBranch.Width = 55;
            // 
            // dgvCTLBranchID
            // 
            this.dgvCTLBranchID.HeaderText = "BranchID";
            this.dgvCTLBranchID.MinimumWidth = 6;
            this.dgvCTLBranchID.Name = "dgvCTLBranchID";
            this.dgvCTLBranchID.Visible = false;
            this.dgvCTLBranchID.Width = 68;
            // 
            // dgvCTLAdderID
            // 
            this.dgvCTLAdderID.HeaderText = "AdderID";
            this.dgvCTLAdderID.MinimumWidth = 6;
            this.dgvCTLAdderID.Name = "dgvCTLAdderID";
            this.dgvCTLAdderID.Visible = false;
            this.dgvCTLAdderID.Width = 63;
            // 
            // dgvCTLAdderPrice
            // 
            this.dgvCTLAdderPrice.HeaderText = "adderPrice";
            this.dgvCTLAdderPrice.MinimumWidth = 6;
            this.dgvCTLAdderPrice.Name = "dgvCTLAdderPrice";
            this.dgvCTLAdderPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCTLAdderPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvCTLAdderPrice.Visible = false;
            this.dgvCTLAdderPrice.Width = 103;
            // 
            // dgvCTLDensityFactor
            // 
            this.dgvCTLDensityFactor.HeaderText = "DensityFactor";
            this.dgvCTLDensityFactor.MinimumWidth = 6;
            this.dgvCTLDensityFactor.Name = "dgvCTLDensityFactor";
            this.dgvCTLDensityFactor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvCTLDensityFactor.Visible = false;
            this.dgvCTLDensityFactor.Width = 96;
            // 
            // dgvCTLPVCGroupID
            // 
            this.dgvCTLPVCGroupID.HeaderText = "PVCGroupID";
            this.dgvCTLPVCGroupID.MinimumWidth = 6;
            this.dgvCTLPVCGroupID.Name = "dgvCTLPVCGroupID";
            this.dgvCTLPVCGroupID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCTLPVCGroupID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvCTLPVCGroupID.Visible = false;
            this.dgvCTLPVCGroupID.Width = 113;
            // 
            // dgvSkidTypeID
            // 
            this.dgvSkidTypeID.HeaderText = "skidType";
            this.dgvSkidTypeID.MinimumWidth = 6;
            this.dgvSkidTypeID.Name = "dgvSkidTypeID";
            this.dgvSkidTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSkidTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvSkidTypeID.Visible = false;
            this.dgvSkidTypeID.Width = 93;
            // 
            // dgvCTLPVCPriceList
            // 
            this.dgvCTLPVCPriceList.HeaderText = "PVCPriceList";
            this.dgvCTLPVCPriceList.MinimumWidth = 6;
            this.dgvCTLPVCPriceList.Name = "dgvCTLPVCPriceList";
            this.dgvCTLPVCPriceList.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCTLPVCPriceList.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvCTLPVCPriceList.Visible = false;
            this.dgvCTLPVCPriceList.Width = 114;
            // 
            // dgvCTLCurrPrice
            // 
            this.dgvCTLCurrPrice.HeaderText = "PVCCurrPrice";
            this.dgvCTLCurrPrice.MinimumWidth = 6;
            this.dgvCTLCurrPrice.Name = "dgvCTLCurrPrice";
            this.dgvCTLCurrPrice.Visible = false;
            this.dgvCTLCurrPrice.Width = 118;
            // 
            // listViewCTLCoilList
            // 
            this.listViewCTLCoilList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCTLCoilList.CheckBoxes = true;
            this.listViewCTLCoilList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCTLTagID,
            this.colCTLLocation,
            this.colCTLAlloy,
            this.colCTLThickness,
            this.colCTLWidth,
            this.colCTLLength,
            this.colCTLWeight,
            this.colCTLMill,
            this.colCTLHeat,
            this.colCTLCarbon,
            this.colCTLVendor,
            this.colCTLPO,
            this.colCTLContainer,
            this.colCTLRecDate,
            this.colCTLRecID,
            this.colCTLCoilCount,
            this.colCTLCountryOfOrigin,
            this.colCTLOrders});
            this.listViewCTLCoilList.HideSelection = false;
            this.listViewCTLCoilList.Location = new System.Drawing.Point(-1, 0);
            this.listViewCTLCoilList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewCTLCoilList.Name = "listViewCTLCoilList";
            this.listViewCTLCoilList.Size = new System.Drawing.Size(1099, 434);
            this.listViewCTLCoilList.TabIndex = 3;
            this.listViewCTLCoilList.UseCompatibleStateImageBehavior = false;
            this.listViewCTLCoilList.View = System.Windows.Forms.View.Details;
            this.listViewCTLCoilList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewCSCoilList_ItemChecked);
            // 
            // colCTLTagID
            // 
            this.colCTLTagID.Text = "TagID";
            this.colCTLTagID.Width = 100;
            // 
            // colCTLLocation
            // 
            this.colCTLLocation.Text = "Location";
            // 
            // colCTLAlloy
            // 
            this.colCTLAlloy.Text = "Alloy";
            // 
            // colCTLThickness
            // 
            this.colCTLThickness.Text = "Thickness";
            // 
            // colCTLWidth
            // 
            this.colCTLWidth.Text = "Width";
            // 
            // colCTLLength
            // 
            this.colCTLLength.Text = "Length";
            // 
            // colCTLWeight
            // 
            this.colCTLWeight.Text = "Weight";
            // 
            // colCTLMill
            // 
            this.colCTLMill.Text = "Mill#";
            // 
            // colCTLHeat
            // 
            this.colCTLHeat.Text = "Heat";
            // 
            // colCTLCarbon
            // 
            this.colCTLCarbon.Text = "Carbon";
            // 
            // colCTLVendor
            // 
            this.colCTLVendor.Text = "Vendor";
            // 
            // colCTLPO
            // 
            this.colCTLPO.Text = "PO";
            // 
            // colCTLContainer
            // 
            this.colCTLContainer.Text = "Container";
            // 
            // colCTLRecDate
            // 
            this.colCTLRecDate.Text = "Rec Date";
            // 
            // colCTLRecID
            // 
            this.colCTLRecID.Text = "Rec#";
            // 
            // colCTLCoilCount
            // 
            this.colCTLCoilCount.Text = "Coil Cnt";
            // 
            // colCTLCountryOfOrigin
            // 
            this.colCTLCountryOfOrigin.Text = "Cnt Of Orig";
            // 
            // colCTLOrders
            // 
            this.colCTLOrders.Text = "Orders";
            // 
            // buttonCTLStartOrder
            // 
            this.buttonCTLStartOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCTLStartOrder.Location = new System.Drawing.Point(916, 559);
            this.buttonCTLStartOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCTLStartOrder.Name = "buttonCTLStartOrder";
            this.buttonCTLStartOrder.Size = new System.Drawing.Size(163, 32);
            this.buttonCTLStartOrder.TabIndex = 20;
            this.buttonCTLStartOrder.Text = "Start Order";
            this.buttonCTLStartOrder.UseVisualStyleBackColor = true;
            this.buttonCTLStartOrder.Click += new System.EventHandler(this.ButtonCTLStartOrder_Click);
            // 
            // panelSheetSheetDiff
            // 
            this.panelSheetSheetDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSheetSheetDiff.Controls.Add(this.buttonSSDCancelOrder);
            this.panelSheetSheetDiff.Controls.Add(this.checkBoxSSDScrapCredit);
            this.panelSheetSheetDiff.Controls.Add(this.checkBoxCutFullSkids);
            this.panelSheetSheetDiff.Controls.Add(this.labelSSDSpecialLeadTime);
            this.panelSheetSheetDiff.Controls.Add(this.textBoxSSDRunSheetComments);
            this.panelSheetSheetDiff.Controls.Add(this.labelSSDRunSheetComments);
            this.panelSheetSheetDiff.Controls.Add(this.comboBoxSSDModify);
            this.panelSheetSheetDiff.Controls.Add(this.checkBoxSSDModify);
            this.panelSheetSheetDiff.Controls.Add(this.comboBoxSSDMultiStep);
            this.panelSheetSheetDiff.Controls.Add(this.checkBoxSSDMultiStep);
            this.panelSheetSheetDiff.Controls.Add(this.labelSSDPrice);
            this.panelSheetSheetDiff.Controls.Add(this.labelSSDPO);
            this.panelSheetSheetDiff.Controls.Add(this.labelSSDPromiseDate);
            this.panelSheetSheetDiff.Controls.Add(this.textBoxSSDPurchaseOrder);
            this.panelSheetSheetDiff.Controls.Add(this.textBoxSSDPrice);
            this.panelSheetSheetDiff.Controls.Add(this.dateTimePickerSSDPromiseDate);
            this.panelSheetSheetDiff.Controls.Add(this.richTextBoxSSDComments);
            this.panelSheetSheetDiff.Controls.Add(this.buttonSSDAddOrder);
            this.panelSheetSheetDiff.Controls.Add(this.buttonSSDStartOrder);
            this.panelSheetSheetDiff.Controls.Add(this.listViewSSD);
            this.panelSheetSheetDiff.Controls.Add(this.panelSSDOrderEntry);
            this.panelSheetSheetDiff.Location = new System.Drawing.Point(3, 5);
            this.panelSheetSheetDiff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSheetSheetDiff.Name = "panelSheetSheetDiff";
            this.panelSheetSheetDiff.Size = new System.Drawing.Size(1100, 617);
            this.panelSheetSheetDiff.TabIndex = 4;
            this.panelSheetSheetDiff.VisibleChanged += new System.EventHandler(this.PanelSheetSheetDiff_VisibleChanged);
            // 
            // buttonSSDCancelOrder
            // 
            this.buttonSSDCancelOrder.Location = new System.Drawing.Point(1067, 416);
            this.buttonSSDCancelOrder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSSDCancelOrder.Name = "buttonSSDCancelOrder";
            this.buttonSSDCancelOrder.Size = new System.Drawing.Size(125, 28);
            this.buttonSSDCancelOrder.TabIndex = 83;
            this.buttonSSDCancelOrder.Text = "Cancel";
            this.buttonSSDCancelOrder.UseVisualStyleBackColor = true;
            this.buttonSSDCancelOrder.Visible = false;
            this.buttonSSDCancelOrder.Click += new System.EventHandler(this.ButtonSSDCancelOrder_Click);
            // 
            // checkBoxSSDScrapCredit
            // 
            this.checkBoxSSDScrapCredit.AutoSize = true;
            this.checkBoxSSDScrapCredit.Location = new System.Drawing.Point(21, 534);
            this.checkBoxSSDScrapCredit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxSSDScrapCredit.Name = "checkBoxSSDScrapCredit";
            this.checkBoxSSDScrapCredit.Size = new System.Drawing.Size(103, 20);
            this.checkBoxSSDScrapCredit.TabIndex = 82;
            this.checkBoxSSDScrapCredit.Text = "Scrap Credit";
            this.checkBoxSSDScrapCredit.UseVisualStyleBackColor = true;
            // 
            // checkBoxCutFullSkids
            // 
            this.checkBoxCutFullSkids.AutoSize = true;
            this.checkBoxCutFullSkids.Checked = true;
            this.checkBoxCutFullSkids.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCutFullSkids.Location = new System.Drawing.Point(508, 382);
            this.checkBoxCutFullSkids.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxCutFullSkids.Name = "checkBoxCutFullSkids";
            this.checkBoxCutFullSkids.Size = new System.Drawing.Size(109, 20);
            this.checkBoxCutFullSkids.TabIndex = 80;
            this.checkBoxCutFullSkids.Text = "Cut Full Skids";
            this.checkBoxCutFullSkids.UseVisualStyleBackColor = true;
            // 
            // labelSSDSpecialLeadTime
            // 
            this.labelSSDSpecialLeadTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSDSpecialLeadTime.AutoSize = true;
            this.labelSSDSpecialLeadTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSDSpecialLeadTime.ForeColor = System.Drawing.Color.Red;
            this.labelSSDSpecialLeadTime.Location = new System.Drawing.Point(547, 552);
            this.labelSSDSpecialLeadTime.Name = "labelSSDSpecialLeadTime";
            this.labelSSDSpecialLeadTime.Size = new System.Drawing.Size(153, 20);
            this.labelSSDSpecialLeadTime.TabIndex = 78;
            this.labelSSDSpecialLeadTime.Text = "Special Lead Time!";
            this.labelSSDSpecialLeadTime.Visible = false;
            // 
            // textBoxSSDRunSheetComments
            // 
            this.textBoxSSDRunSheetComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSSDRunSheetComments.Location = new System.Drawing.Point(657, 508);
            this.textBoxSSDRunSheetComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSSDRunSheetComments.Name = "textBoxSSDRunSheetComments";
            this.textBoxSSDRunSheetComments.Size = new System.Drawing.Size(379, 22);
            this.textBoxSSDRunSheetComments.TabIndex = 72;
            this.textBoxSSDRunSheetComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSSDRunSheetComments_KeyPress);
            // 
            // labelSSDRunSheetComments
            // 
            this.labelSSDRunSheetComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSDRunSheetComments.AutoSize = true;
            this.labelSSDRunSheetComments.Location = new System.Drawing.Point(505, 513);
            this.labelSSDRunSheetComments.Name = "labelSSDRunSheetComments";
            this.labelSSDRunSheetComments.Size = new System.Drawing.Size(136, 16);
            this.labelSSDRunSheetComments.TabIndex = 77;
            this.labelSSDRunSheetComments.Text = "Run Sheet Comments";
            // 
            // comboBoxSSDModify
            // 
            this.comboBoxSSDModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxSSDModify.FormattingEnabled = true;
            this.comboBoxSSDModify.Location = new System.Drawing.Point(41, 460);
            this.comboBoxSSDModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSSDModify.Name = "comboBoxSSDModify";
            this.comboBoxSSDModify.Size = new System.Drawing.Size(141, 24);
            this.comboBoxSSDModify.TabIndex = 65;
            this.comboBoxSSDModify.Visible = false;
            // 
            // checkBoxSSDModify
            // 
            this.checkBoxSSDModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxSSDModify.AutoSize = true;
            this.checkBoxSSDModify.Location = new System.Drawing.Point(19, 437);
            this.checkBoxSSDModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxSSDModify.Name = "checkBoxSSDModify";
            this.checkBoxSSDModify.Size = new System.Drawing.Size(69, 20);
            this.checkBoxSSDModify.TabIndex = 64;
            this.checkBoxSSDModify.Text = "Modify";
            this.checkBoxSSDModify.UseVisualStyleBackColor = true;
            // 
            // comboBoxSSDMultiStep
            // 
            this.comboBoxSSDMultiStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxSSDMultiStep.FormattingEnabled = true;
            this.comboBoxSSDMultiStep.Location = new System.Drawing.Point(41, 536);
            this.comboBoxSSDMultiStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSSDMultiStep.Name = "comboBoxSSDMultiStep";
            this.comboBoxSSDMultiStep.Size = new System.Drawing.Size(171, 24);
            this.comboBoxSSDMultiStep.TabIndex = 67;
            this.comboBoxSSDMultiStep.Visible = false;
            // 
            // checkBoxSSDMultiStep
            // 
            this.checkBoxSSDMultiStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxSSDMultiStep.AutoSize = true;
            this.checkBoxSSDMultiStep.Location = new System.Drawing.Point(19, 495);
            this.checkBoxSSDMultiStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxSSDMultiStep.Name = "checkBoxSSDMultiStep";
            this.checkBoxSSDMultiStep.Size = new System.Drawing.Size(84, 20);
            this.checkBoxSSDMultiStep.TabIndex = 66;
            this.checkBoxSSDMultiStep.Text = "MultiStep";
            this.checkBoxSSDMultiStep.UseVisualStyleBackColor = true;
            // 
            // labelSSDPrice
            // 
            this.labelSSDPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSDPrice.AutoSize = true;
            this.labelSSDPrice.Location = new System.Drawing.Point(505, 460);
            this.labelSSDPrice.Name = "labelSSDPrice";
            this.labelSSDPrice.Size = new System.Drawing.Size(38, 16);
            this.labelSSDPrice.TabIndex = 76;
            this.labelSSDPrice.Text = "Price";
            // 
            // labelSSDPO
            // 
            this.labelSSDPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSDPO.AutoSize = true;
            this.labelSSDPO.Location = new System.Drawing.Point(505, 486);
            this.labelSSDPO.Name = "labelSSDPO";
            this.labelSSDPO.Size = new System.Drawing.Size(101, 16);
            this.labelSSDPO.TabIndex = 75;
            this.labelSSDPO.Text = "Purchase Order";
            // 
            // labelSSDPromiseDate
            // 
            this.labelSSDPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSDPromiseDate.AutoSize = true;
            this.labelSSDPromiseDate.Location = new System.Drawing.Point(261, 531);
            this.labelSSDPromiseDate.Name = "labelSSDPromiseDate";
            this.labelSSDPromiseDate.Size = new System.Drawing.Size(89, 16);
            this.labelSSDPromiseDate.TabIndex = 74;
            this.labelSSDPromiseDate.Text = "Promise Date";
            // 
            // textBoxSSDPurchaseOrder
            // 
            this.textBoxSSDPurchaseOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSSDPurchaseOrder.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxSSDPurchaseOrder.Location = new System.Drawing.Point(619, 484);
            this.textBoxSSDPurchaseOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSSDPurchaseOrder.Name = "textBoxSSDPurchaseOrder";
            this.textBoxSSDPurchaseOrder.Size = new System.Drawing.Size(227, 22);
            this.textBoxSSDPurchaseOrder.TabIndex = 71;
            this.textBoxSSDPurchaseOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSSDPurchaseOrder_KeyPress);
            // 
            // textBoxSSDPrice
            // 
            this.textBoxSSDPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSSDPrice.Location = new System.Drawing.Point(549, 459);
            this.textBoxSSDPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSSDPrice.Name = "textBoxSSDPrice";
            this.textBoxSSDPrice.Size = new System.Drawing.Size(112, 22);
            this.textBoxSSDPrice.TabIndex = 70;
            // 
            // dateTimePickerSSDPromiseDate
            // 
            this.dateTimePickerSSDPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerSSDPromiseDate.Location = new System.Drawing.Point(263, 553);
            this.dateTimePickerSSDPromiseDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerSSDPromiseDate.Name = "dateTimePickerSSDPromiseDate";
            this.dateTimePickerSSDPromiseDate.Size = new System.Drawing.Size(272, 22);
            this.dateTimePickerSSDPromiseDate.TabIndex = 69;
            // 
            // richTextBoxSSDComments
            // 
            this.richTextBoxSSDComments.AcceptsTab = true;
            this.richTextBoxSSDComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxSSDComments.Location = new System.Drawing.Point(263, 451);
            this.richTextBoxSSDComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxSSDComments.Name = "richTextBoxSSDComments";
            this.richTextBoxSSDComments.Size = new System.Drawing.Size(239, 74);
            this.richTextBoxSSDComments.TabIndex = 68;
            this.richTextBoxSSDComments.Text = "";
            this.richTextBoxSSDComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxSSDComments_KeyPress);
            // 
            // buttonSSDAddOrder
            // 
            this.buttonSSDAddOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSSDAddOrder.Location = new System.Drawing.Point(678, 549);
            this.buttonSSDAddOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSSDAddOrder.Name = "buttonSSDAddOrder";
            this.buttonSSDAddOrder.Size = new System.Drawing.Size(163, 32);
            this.buttonSSDAddOrder.TabIndex = 79;
            this.buttonSSDAddOrder.Text = "Add Order";
            this.buttonSSDAddOrder.UseVisualStyleBackColor = true;
            this.buttonSSDAddOrder.Visible = false;
            this.buttonSSDAddOrder.Click += new System.EventHandler(this.ButtonSSDAddOrder_Click);
            // 
            // buttonSSDStartOrder
            // 
            this.buttonSSDStartOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSSDStartOrder.Location = new System.Drawing.Point(863, 552);
            this.buttonSSDStartOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSSDStartOrder.Name = "buttonSSDStartOrder";
            this.buttonSSDStartOrder.Size = new System.Drawing.Size(163, 32);
            this.buttonSSDStartOrder.TabIndex = 73;
            this.buttonSSDStartOrder.Text = "Start Order";
            this.buttonSSDStartOrder.UseVisualStyleBackColor = true;
            this.buttonSSDStartOrder.Click += new System.EventHandler(this.ButtonSSDStartOrder_Click);
            // 
            // listViewSSD
            // 
            this.listViewSSD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSSD.CheckBoxes = true;
            this.listViewSSD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader87,
            this.columnHeader88,
            this.columnHeader89,
            this.columnHeader90,
            this.columnHeader91,
            this.columnHeader92,
            this.columnHeader93,
            this.columnHeader94,
            this.columnHeader100,
            this.lvheat,
            this.columnHeader95,
            this.columnHeader96,
            this.columnHeader97,
            this.columnHeader98,
            this.columnHeader99,
            this.lvwSSDOrders});
            this.listViewSSD.FullRowSelect = true;
            this.listViewSSD.HideSelection = false;
            this.listViewSSD.Location = new System.Drawing.Point(1, 0);
            this.listViewSSD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewSSD.MultiSelect = false;
            this.listViewSSD.Name = "listViewSSD";
            this.listViewSSD.Size = new System.Drawing.Size(1090, 423);
            this.listViewSSD.TabIndex = 1;
            this.listViewSSD.UseCompatibleStateImageBehavior = false;
            this.listViewSSD.View = System.Windows.Forms.View.Details;
            this.listViewSSD.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewSSD_ItemChecked);
            // 
            // columnHeader87
            // 
            this.columnHeader87.Text = "SkidID";
            // 
            // columnHeader88
            // 
            this.columnHeader88.Text = "Location";
            this.columnHeader88.Width = 96;
            // 
            // columnHeader89
            // 
            this.columnHeader89.Text = "Pcs";
            // 
            // columnHeader90
            // 
            this.columnHeader90.Text = "Alloy";
            // 
            // columnHeader91
            // 
            this.columnHeader91.Text = "Thick";
            // 
            // columnHeader92
            // 
            this.columnHeader92.Text = "Width";
            // 
            // columnHeader93
            // 
            this.columnHeader93.Text = "Length";
            // 
            // columnHeader94
            // 
            this.columnHeader94.Text = "Weight";
            // 
            // columnHeader100
            // 
            this.columnHeader100.Text = "Mill#";
            // 
            // lvheat
            // 
            this.lvheat.Text = "Heat";
            // 
            // columnHeader95
            // 
            this.columnHeader95.Text = "PVC SQFT";
            this.columnHeader95.Width = 85;
            // 
            // columnHeader96
            // 
            this.columnHeader96.Text = "PI SQFT";
            // 
            // columnHeader97
            // 
            this.columnHeader97.Text = "Comments";
            this.columnHeader97.Width = 200;
            // 
            // columnHeader98
            // 
            this.columnHeader98.Text = "Not Prime";
            this.columnHeader98.Width = 113;
            // 
            // columnHeader99
            // 
            this.columnHeader99.Text = "Branch";
            // 
            // lvwSSDOrders
            // 
            this.lvwSSDOrders.Text = "Orders";
            // 
            // panelSSDOrderEntry
            // 
            this.panelSSDOrderEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSSDOrderEntry.Controls.Add(this.buttonClearAll);
            this.panelSSDOrderEntry.Controls.Add(this.buttonAddCuts);
            this.panelSSDOrderEntry.Controls.Add(this.treeViewSSD);
            this.panelSSDOrderEntry.Controls.Add(this.dgvSSDItems);
            this.panelSSDOrderEntry.Location = new System.Drawing.Point(1, 1);
            this.panelSSDOrderEntry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSSDOrderEntry.Name = "panelSSDOrderEntry";
            this.panelSSDOrderEntry.Size = new System.Drawing.Size(1087, 424);
            this.panelSSDOrderEntry.TabIndex = 81;
            this.panelSSDOrderEntry.Visible = false;
            this.panelSSDOrderEntry.VisibleChanged += new System.EventHandler(this.PanelSSDOrderEntry_VisibleChanged);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearAll.Location = new System.Drawing.Point(883, 382);
            this.buttonClearAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(131, 33);
            this.buttonClearAll.TabIndex = 5;
            this.buttonClearAll.Text = "Clear All Cuts";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.ButtonClearAll_Click);
            // 
            // buttonAddCuts
            // 
            this.buttonAddCuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddCuts.Location = new System.Drawing.Point(736, 382);
            this.buttonAddCuts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAddCuts.Name = "buttonAddCuts";
            this.buttonAddCuts.Size = new System.Drawing.Size(131, 33);
            this.buttonAddCuts.TabIndex = 4;
            this.buttonAddCuts.Text = "Add Cut";
            this.buttonAddCuts.UseVisualStyleBackColor = true;
            this.buttonAddCuts.Click += new System.EventHandler(this.ButtonAddCuts_Click);
            // 
            // treeViewSSD
            // 
            this.treeViewSSD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewSSD.HideSelection = false;
            this.treeViewSSD.Location = new System.Drawing.Point(736, 9);
            this.treeViewSSD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeViewSSD.Name = "treeViewSSD";
            this.treeViewSSD.Size = new System.Drawing.Size(337, 371);
            this.treeViewSSD.TabIndex = 3;
            this.treeViewSSD.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewSSD_AfterSelect);
            this.treeViewSSD.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewSSD_NodeMouseClick);
            this.treeViewSSD.Enter += new System.EventHandler(this.TreeViewSSD_Enter);
            this.treeViewSSD.Leave += new System.EventHandler(this.TreeViewSSD_Leave);
            this.treeViewSSD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TreeViewSSD_MouseClick);
            this.treeViewSSD.Validating += new System.ComponentModel.CancelEventHandler(this.TreeViewSSD_Validating);
            // 
            // dgvSSDItems
            // 
            this.dgvSSDItems.AllowUserToAddRows = false;
            this.dgvSSDItems.AllowUserToDeleteRows = false;
            this.dgvSSDItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSSDItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSSDItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSSDHeat,
            this.dgvSSDAlloy,
            this.dgvSSDPieceCount,
            this.dgvSSDWidth,
            this.dgvSSDLength,
            this.dgvSSDSkidIDs,
            this.dgvSSDCoilTagSuffix,
            this.dgvSSDOrigPcs,
            this.dgvSSDCutPcs});
            this.dgvSSDItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSSDItems.Location = new System.Drawing.Point(4, 9);
            this.dgvSSDItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSSDItems.MultiSelect = false;
            this.dgvSSDItems.Name = "dgvSSDItems";
            this.dgvSSDItems.RowHeadersWidth = 51;
            this.dgvSSDItems.RowTemplate.Height = 24;
            this.dgvSSDItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSSDItems.Size = new System.Drawing.Size(718, 372);
            this.dgvSSDItems.TabIndex = 2;
            this.dgvSSDItems.SelectionChanged += new System.EventHandler(this.DgvSSDItems_SelectionChanged);
            // 
            // dgvSSDHeat
            // 
            this.dgvSSDHeat.HeaderText = "Heat";
            this.dgvSSDHeat.MinimumWidth = 6;
            this.dgvSSDHeat.Name = "dgvSSDHeat";
            this.dgvSSDHeat.ReadOnly = true;
            this.dgvSSDHeat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSDHeat.Width = 125;
            // 
            // dgvSSDAlloy
            // 
            this.dgvSSDAlloy.HeaderText = "Alloy";
            this.dgvSSDAlloy.MinimumWidth = 6;
            this.dgvSSDAlloy.Name = "dgvSSDAlloy";
            this.dgvSSDAlloy.ReadOnly = true;
            this.dgvSSDAlloy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSDAlloy.Width = 125;
            // 
            // dgvSSDPieceCount
            // 
            this.dgvSSDPieceCount.HeaderText = "Pieces";
            this.dgvSSDPieceCount.MinimumWidth = 6;
            this.dgvSSDPieceCount.Name = "dgvSSDPieceCount";
            this.dgvSSDPieceCount.ReadOnly = true;
            this.dgvSSDPieceCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSDPieceCount.Width = 125;
            // 
            // dgvSSDWidth
            // 
            this.dgvSSDWidth.HeaderText = "Width";
            this.dgvSSDWidth.MinimumWidth = 6;
            this.dgvSSDWidth.Name = "dgvSSDWidth";
            this.dgvSSDWidth.ReadOnly = true;
            this.dgvSSDWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSDWidth.Width = 125;
            // 
            // dgvSSDLength
            // 
            this.dgvSSDLength.HeaderText = "Length";
            this.dgvSSDLength.MinimumWidth = 6;
            this.dgvSSDLength.Name = "dgvSSDLength";
            this.dgvSSDLength.ReadOnly = true;
            this.dgvSSDLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSDLength.Width = 125;
            // 
            // dgvSSDSkidIDs
            // 
            this.dgvSSDSkidIDs.HeaderText = "SkidIDs";
            this.dgvSSDSkidIDs.MaxDropDownItems = 12;
            this.dgvSSDSkidIDs.MinimumWidth = 6;
            this.dgvSSDSkidIDs.Name = "dgvSSDSkidIDs";
            this.dgvSSDSkidIDs.Width = 125;
            // 
            // dgvSSDCoilTagSuffix
            // 
            this.dgvSSDCoilTagSuffix.HeaderText = "CoilTagSuffix";
            this.dgvSSDCoilTagSuffix.MinimumWidth = 6;
            this.dgvSSDCoilTagSuffix.Name = "dgvSSDCoilTagSuffix";
            this.dgvSSDCoilTagSuffix.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSSDCoilTagSuffix.Visible = false;
            this.dgvSSDCoilTagSuffix.Width = 125;
            // 
            // dgvSSDOrigPcs
            // 
            this.dgvSSDOrigPcs.HeaderText = "OrigPcs";
            this.dgvSSDOrigPcs.MinimumWidth = 6;
            this.dgvSSDOrigPcs.Name = "dgvSSDOrigPcs";
            this.dgvSSDOrigPcs.Visible = false;
            this.dgvSSDOrigPcs.Width = 125;
            // 
            // dgvSSDCutPcs
            // 
            this.dgvSSDCutPcs.HeaderText = "CutPcs";
            this.dgvSSDCutPcs.MinimumWidth = 6;
            this.dgvSSDCutPcs.Name = "dgvSSDCutPcs";
            this.dgvSSDCutPcs.Visible = false;
            this.dgvSSDCutPcs.Width = 125;
            // 
            // panelCoilCoilSame
            // 
            this.panelCoilCoilSame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCoilCoilSame.Controls.Add(this.buttonClClSameDelete);
            this.panelCoilCoilSame.Controls.Add(this.comboBoxClClSameModify);
            this.panelCoilCoilSame.Controls.Add(this.checkBoxClClSameModify);
            this.panelCoilCoilSame.Controls.Add(this.labelClClSameMultiToMachine);
            this.panelCoilCoilSame.Controls.Add(this.comboBoxClClSameToMachine);
            this.panelCoilCoilSame.Controls.Add(this.checkBoxClClSameMultiStep);
            this.panelCoilCoilSame.Controls.Add(this.buttonClClSameReset);
            this.panelCoilCoilSame.Controls.Add(this.labelClClSamePrice);
            this.panelCoilCoilSame.Controls.Add(this.labelClClSamePO);
            this.panelCoilCoilSame.Controls.Add(this.labelClClSamePromiseDate);
            this.panelCoilCoilSame.Controls.Add(this.checkBoxClClSameScrap);
            this.panelCoilCoilSame.Controls.Add(this.textBoxClClSamePO);
            this.panelCoilCoilSame.Controls.Add(this.textBoxClClSamePrice);
            this.panelCoilCoilSame.Controls.Add(this.dateTimePickerClClSamePromise);
            this.panelCoilCoilSame.Controls.Add(this.richTextBoxClClSameComments);
            this.panelCoilCoilSame.Controls.Add(this.dataGridViewCLCLSame);
            this.panelCoilCoilSame.Controls.Add(this.listViewClClSame);
            this.panelCoilCoilSame.Controls.Add(this.buttonCLCLSameStartOrder);
            this.panelCoilCoilSame.Controls.Add(this.buttonClClSameAddOrder);
            this.panelCoilCoilSame.Location = new System.Drawing.Point(1, 7);
            this.panelCoilCoilSame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCoilCoilSame.Name = "panelCoilCoilSame";
            this.panelCoilCoilSame.Size = new System.Drawing.Size(1102, 615);
            this.panelCoilCoilSame.TabIndex = 0;
            this.panelCoilCoilSame.Visible = false;
            this.panelCoilCoilSame.VisibleChanged += new System.EventHandler(this.PanelCoilCoilSame_VisibleChanged);
            // 
            // buttonClClSameDelete
            // 
            this.buttonClClSameDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClClSameDelete.Location = new System.Drawing.Point(184, 479);
            this.buttonClClSameDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClClSameDelete.Name = "buttonClClSameDelete";
            this.buttonClClSameDelete.Size = new System.Drawing.Size(76, 39);
            this.buttonClClSameDelete.TabIndex = 19;
            this.buttonClClSameDelete.Text = "Delete";
            this.buttonClClSameDelete.UseVisualStyleBackColor = true;
            this.buttonClClSameDelete.Visible = false;
            this.buttonClClSameDelete.Click += new System.EventHandler(this.ButtonClClSameDelete_Click);
            // 
            // comboBoxClClSameModify
            // 
            this.comboBoxClClSameModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxClClSameModify.FormattingEnabled = true;
            this.comboBoxClClSameModify.Location = new System.Drawing.Point(35, 495);
            this.comboBoxClClSameModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxClClSameModify.Name = "comboBoxClClSameModify";
            this.comboBoxClClSameModify.Size = new System.Drawing.Size(141, 24);
            this.comboBoxClClSameModify.TabIndex = 18;
            this.comboBoxClClSameModify.Visible = false;
            this.comboBoxClClSameModify.SelectedIndexChanged += new System.EventHandler(this.ComboBoxClClSameModify_SelectedIndexChanged);
            // 
            // checkBoxClClSameModify
            // 
            this.checkBoxClClSameModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxClClSameModify.AutoSize = true;
            this.checkBoxClClSameModify.Location = new System.Drawing.Point(13, 471);
            this.checkBoxClClSameModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxClClSameModify.Name = "checkBoxClClSameModify";
            this.checkBoxClClSameModify.Size = new System.Drawing.Size(69, 20);
            this.checkBoxClClSameModify.TabIndex = 17;
            this.checkBoxClClSameModify.Text = "Modify";
            this.checkBoxClClSameModify.UseVisualStyleBackColor = true;
            this.checkBoxClClSameModify.CheckedChanged += new System.EventHandler(this.CheckBoxClClSameModify_CheckedChanged);
            // 
            // labelClClSameMultiToMachine
            // 
            this.labelClClSameMultiToMachine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClClSameMultiToMachine.AutoSize = true;
            this.labelClClSameMultiToMachine.Location = new System.Drawing.Point(32, 550);
            this.labelClClSameMultiToMachine.Name = "labelClClSameMultiToMachine";
            this.labelClClSameMultiToMachine.Size = new System.Drawing.Size(53, 16);
            this.labelClClSameMultiToMachine.TabIndex = 16;
            this.labelClClSameMultiToMachine.Text = "Send to";
            this.labelClClSameMultiToMachine.Visible = false;
            // 
            // comboBoxClClSameToMachine
            // 
            this.comboBoxClClSameToMachine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxClClSameToMachine.FormattingEnabled = true;
            this.comboBoxClClSameToMachine.Location = new System.Drawing.Point(35, 570);
            this.comboBoxClClSameToMachine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxClClSameToMachine.Name = "comboBoxClClSameToMachine";
            this.comboBoxClClSameToMachine.Size = new System.Drawing.Size(171, 24);
            this.comboBoxClClSameToMachine.TabIndex = 15;
            this.comboBoxClClSameToMachine.Visible = false;
            // 
            // checkBoxClClSameMultiStep
            // 
            this.checkBoxClClSameMultiStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxClClSameMultiStep.AutoSize = true;
            this.checkBoxClClSameMultiStep.Location = new System.Drawing.Point(13, 529);
            this.checkBoxClClSameMultiStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxClClSameMultiStep.Name = "checkBoxClClSameMultiStep";
            this.checkBoxClClSameMultiStep.Size = new System.Drawing.Size(84, 20);
            this.checkBoxClClSameMultiStep.TabIndex = 14;
            this.checkBoxClClSameMultiStep.Text = "MultiStep";
            this.checkBoxClClSameMultiStep.UseVisualStyleBackColor = true;
            this.checkBoxClClSameMultiStep.CheckedChanged += new System.EventHandler(this.CheckBoxClClSameMultiStep_CheckedChanged);
            // 
            // buttonClClSameReset
            // 
            this.buttonClClSameReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClClSameReset.Location = new System.Drawing.Point(895, 484);
            this.buttonClClSameReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClClSameReset.Name = "buttonClClSameReset";
            this.buttonClClSameReset.Size = new System.Drawing.Size(165, 28);
            this.buttonClClSameReset.TabIndex = 13;
            this.buttonClClSameReset.Text = "Reset All";
            this.buttonClClSameReset.UseVisualStyleBackColor = true;
            this.buttonClClSameReset.Click += new System.EventHandler(this.ButtonClClSameReset_Click);
            // 
            // labelClClSamePrice
            // 
            this.labelClClSamePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClClSamePrice.AutoSize = true;
            this.labelClClSamePrice.Location = new System.Drawing.Point(565, 505);
            this.labelClClSamePrice.Name = "labelClClSamePrice";
            this.labelClClSamePrice.Size = new System.Drawing.Size(38, 16);
            this.labelClClSamePrice.TabIndex = 11;
            this.labelClClSamePrice.Text = "Price";
            // 
            // labelClClSamePO
            // 
            this.labelClClSamePO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClClSamePO.AutoSize = true;
            this.labelClClSamePO.Location = new System.Drawing.Point(565, 558);
            this.labelClClSamePO.Name = "labelClClSamePO";
            this.labelClClSamePO.Size = new System.Drawing.Size(101, 16);
            this.labelClClSamePO.TabIndex = 10;
            this.labelClClSamePO.Text = "Purchase Order";
            // 
            // labelClClSamePromiseDate
            // 
            this.labelClClSamePromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClClSamePromiseDate.AutoSize = true;
            this.labelClClSamePromiseDate.Location = new System.Drawing.Point(267, 558);
            this.labelClClSamePromiseDate.Name = "labelClClSamePromiseDate";
            this.labelClClSamePromiseDate.Size = new System.Drawing.Size(89, 16);
            this.labelClClSamePromiseDate.TabIndex = 9;
            this.labelClClSamePromiseDate.Text = "Promise Date";
            // 
            // checkBoxClClSameScrap
            // 
            this.checkBoxClClSameScrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxClClSameScrap.AutoSize = true;
            this.checkBoxClClSameScrap.Location = new System.Drawing.Point(565, 477);
            this.checkBoxClClSameScrap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxClClSameScrap.Name = "checkBoxClClSameScrap";
            this.checkBoxClClSameScrap.Size = new System.Drawing.Size(103, 20);
            this.checkBoxClClSameScrap.TabIndex = 8;
            this.checkBoxClClSameScrap.Text = "Scrap Credit";
            this.checkBoxClClSameScrap.UseVisualStyleBackColor = true;
            // 
            // textBoxClClSamePO
            // 
            this.textBoxClClSamePO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxClClSamePO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxClClSamePO.Location = new System.Drawing.Point(565, 577);
            this.textBoxClClSamePO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClClSamePO.Name = "textBoxClClSamePO";
            this.textBoxClClSamePO.Size = new System.Drawing.Size(227, 22);
            this.textBoxClClSamePO.TabIndex = 7;
            this.textBoxClClSamePO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxClClSamePO_KeyPress);
            // 
            // textBoxClClSamePrice
            // 
            this.textBoxClClSamePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxClClSamePrice.Location = new System.Drawing.Point(565, 524);
            this.textBoxClClSamePrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClClSamePrice.Name = "textBoxClClSamePrice";
            this.textBoxClClSamePrice.Size = new System.Drawing.Size(112, 22);
            this.textBoxClClSamePrice.TabIndex = 6;
            this.textBoxClClSamePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxClClSamePrice_KeyPress);
            // 
            // dateTimePickerClClSamePromise
            // 
            this.dateTimePickerClClSamePromise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerClClSamePromise.Location = new System.Drawing.Point(269, 577);
            this.dateTimePickerClClSamePromise.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerClClSamePromise.Name = "dateTimePickerClClSamePromise";
            this.dateTimePickerClClSamePromise.Size = new System.Drawing.Size(272, 22);
            this.dateTimePickerClClSamePromise.TabIndex = 5;
            // 
            // richTextBoxClClSameComments
            // 
            this.richTextBoxClClSameComments.AcceptsTab = true;
            this.richTextBoxClClSameComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxClClSameComments.Location = new System.Drawing.Point(269, 473);
            this.richTextBoxClClSameComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxClClSameComments.Name = "richTextBoxClClSameComments";
            this.richTextBoxClClSameComments.Size = new System.Drawing.Size(239, 74);
            this.richTextBoxClClSameComments.TabIndex = 4;
            this.richTextBoxClClSameComments.Text = "";
            this.richTextBoxClClSameComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxClClSameComments_KeyPress);
            // 
            // dataGridViewCLCLSame
            // 
            this.dataGridViewCLCLSame.AllowUserToAddRows = false;
            this.dataGridViewCLCLSame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCLCLSame.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewCLCLSame.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCLCLSame.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClClSameCoilTagID,
            this.colClCLSameThickness,
            this.colClClSameWidth,
            this.colClClSameAlloy,
            this.colClClSameOrigFinish,
            this.colClClSameNewFinish,
            this.colClClSameOrigLBS,
            this.colClClSamePolishLBS,
            this.colClClSameCoilCnt,
            this.colClClSamePolWeights,
            this.colClClSamePaper,
            this.colClClSameNewFinishID,
            this.colClClSameCoilFinish});
            this.dataGridViewCLCLSame.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewCLCLSame.Location = new System.Drawing.Point(-1, 2);
            this.dataGridViewCLCLSame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewCLCLSame.Name = "dataGridViewCLCLSame";
            this.dataGridViewCLCLSame.RowHeadersWidth = 51;
            this.dataGridViewCLCLSame.RowTemplate.Height = 24;
            this.dataGridViewCLCLSame.Size = new System.Drawing.Size(1095, 450);
            this.dataGridViewCLCLSame.TabIndex = 3;
            this.dataGridViewCLCLSame.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCLCLSame_CellEndEdit);
            this.dataGridViewCLCLSame.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCLCLSame_CellEndEdit);
            this.dataGridViewCLCLSame.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCLCLSame_CellEnter);
            this.dataGridViewCLCLSame.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewCLCLSame_DataError);
            this.dataGridViewCLCLSame.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewCLCLSame_EditingControlShowing);
            // 
            // colClClSameCoilTagID
            // 
            this.colClClSameCoilTagID.FillWeight = 150F;
            this.colClClSameCoilTagID.HeaderText = "TagID";
            this.colClClSameCoilTagID.MinimumWidth = 6;
            this.colClClSameCoilTagID.Name = "colClClSameCoilTagID";
            this.colClClSameCoilTagID.ReadOnly = true;
            this.colClClSameCoilTagID.Width = 74;
            // 
            // colClCLSameThickness
            // 
            this.colClCLSameThickness.HeaderText = "Thickness";
            this.colClCLSameThickness.MinimumWidth = 6;
            this.colClCLSameThickness.Name = "colClCLSameThickness";
            this.colClCLSameThickness.ReadOnly = true;
            this.colClCLSameThickness.Width = 98;
            // 
            // colClClSameWidth
            // 
            this.colClClSameWidth.HeaderText = "Width";
            this.colClClSameWidth.MinimumWidth = 6;
            this.colClClSameWidth.Name = "colClClSameWidth";
            this.colClClSameWidth.ReadOnly = true;
            this.colClClSameWidth.Width = 70;
            // 
            // colClClSameAlloy
            // 
            this.colClClSameAlloy.HeaderText = "Alloy";
            this.colClClSameAlloy.MinimumWidth = 6;
            this.colClClSameAlloy.Name = "colClClSameAlloy";
            this.colClClSameAlloy.ReadOnly = true;
            this.colClClSameAlloy.Width = 66;
            // 
            // colClClSameOrigFinish
            // 
            this.colClClSameOrigFinish.HeaderText = "Orig Finish";
            this.colClClSameOrigFinish.MinimumWidth = 6;
            this.colClClSameOrigFinish.Name = "colClClSameOrigFinish";
            this.colClClSameOrigFinish.ReadOnly = true;
            this.colClClSameOrigFinish.Width = 99;
            // 
            // colClClSameNewFinish
            // 
            this.colClClSameNewFinish.HeaderText = "New Finish";
            this.colClClSameNewFinish.MinimumWidth = 6;
            this.colClClSameNewFinish.Name = "colClClSameNewFinish";
            this.colClClSameNewFinish.Width = 78;
            // 
            // colClClSameOrigLBS
            // 
            this.colClClSameOrigLBS.HeaderText = "Orig LBS";
            this.colClClSameOrigLBS.MinimumWidth = 6;
            this.colClClSameOrigLBS.Name = "colClClSameOrigLBS";
            this.colClClSameOrigLBS.ReadOnly = true;
            this.colClClSameOrigLBS.Width = 89;
            // 
            // colClClSamePolishLBS
            // 
            this.colClClSamePolishLBS.HeaderText = "Polish LBS";
            this.colClClSamePolishLBS.MinimumWidth = 6;
            this.colClClSamePolishLBS.Name = "colClClSamePolishLBS";
            this.colClClSamePolishLBS.Width = 101;
            // 
            // colClClSameCoilCnt
            // 
            this.colClClSameCoilCnt.HeaderText = "#Coils";
            this.colClClSameCoilCnt.MinimumWidth = 6;
            this.colClClSameCoilCnt.Name = "colClClSameCoilCnt";
            this.colClClSameCoilCnt.Width = 73;
            // 
            // colClClSamePolWeights
            // 
            this.colClClSamePolWeights.HeaderText = "Weights";
            this.colClClSamePolWeights.MinimumWidth = 6;
            this.colClClSamePolWeights.Name = "colClClSamePolWeights";
            this.colClClSamePolWeights.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colClClSamePolWeights.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colClClSamePolWeights.Width = 85;
            // 
            // colClClSamePaper
            // 
            this.colClClSamePaper.HeaderText = "Paper";
            this.colClClSamePaper.MinimumWidth = 6;
            this.colClClSamePaper.Name = "colClClSamePaper";
            this.colClClSamePaper.Width = 50;
            // 
            // colClClSameNewFinishID
            // 
            this.colClClSameNewFinishID.HeaderText = "New Fin ID";
            this.colClClSameNewFinishID.MinimumWidth = 6;
            this.colClClSameNewFinishID.Name = "colClClSameNewFinishID";
            this.colClClSameNewFinishID.Visible = false;
            this.colClClSameNewFinishID.Width = 77;
            // 
            // colClClSameCoilFinish
            // 
            this.colClClSameCoilFinish.HeaderText = "CoilFinishes";
            this.colClClSameCoilFinish.MinimumWidth = 6;
            this.colClClSameCoilFinish.Name = "colClClSameCoilFinish";
            this.colClClSameCoilFinish.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colClClSameCoilFinish.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colClClSameCoilFinish.Width = 109;
            // 
            // listViewClClSame
            // 
            this.listViewClClSame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewClClSame.CheckBoxes = true;
            this.listViewClClSame.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.lvCCSOrders});
            this.listViewClClSame.HideSelection = false;
            this.listViewClClSame.Location = new System.Drawing.Point(-1, 2);
            this.listViewClClSame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewClClSame.Name = "listViewClClSame";
            this.listViewClClSame.Size = new System.Drawing.Size(1094, 452);
            this.listViewClClSame.TabIndex = 2;
            this.listViewClClSame.UseCompatibleStateImageBehavior = false;
            this.listViewClClSame.View = System.Windows.Forms.View.Details;
            this.listViewClClSame.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewClClSame_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tag ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Location";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Alloy";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thickness";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Width";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Length";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Weight";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Mill#";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Heat";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Carbon";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Vendor";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "PO";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Container";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Rec Date";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Rec#";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Coil Cnt";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Cnt Of Orig";
            // 
            // lvCCSOrders
            // 
            this.lvCCSOrders.Text = "Orders";
            // 
            // buttonCLCLSameStartOrder
            // 
            this.buttonCLCLSameStartOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCLCLSameStartOrder.Location = new System.Drawing.Point(895, 555);
            this.buttonCLCLSameStartOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCLCLSameStartOrder.Name = "buttonCLCLSameStartOrder";
            this.buttonCLCLSameStartOrder.Size = new System.Drawing.Size(165, 36);
            this.buttonCLCLSameStartOrder.TabIndex = 1;
            this.buttonCLCLSameStartOrder.Text = "Start Order";
            this.buttonCLCLSameStartOrder.UseVisualStyleBackColor = true;
            this.buttonCLCLSameStartOrder.Click += new System.EventHandler(this.ButtonClClSameStartOrder_Click);
            // 
            // buttonClClSameAddOrder
            // 
            this.buttonClClSameAddOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClClSameAddOrder.Location = new System.Drawing.Point(895, 555);
            this.buttonClClSameAddOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClClSameAddOrder.Name = "buttonClClSameAddOrder";
            this.buttonClClSameAddOrder.Size = new System.Drawing.Size(165, 36);
            this.buttonClClSameAddOrder.TabIndex = 12;
            this.buttonClClSameAddOrder.Text = "AddOrder";
            this.buttonClClSameAddOrder.UseVisualStyleBackColor = true;
            this.buttonClClSameAddOrder.Visible = false;
            this.buttonClClSameAddOrder.Click += new System.EventHandler(this.ButtonClClSameAddOrder_Click);
            // 
            // panelClClDiff
            // 
            this.panelClClDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelClClDiff.Controls.Add(this.labelClClDiffMasterSequence);
            this.panelClClDiff.Controls.Add(this.labelClClDiffMasterFrom);
            this.panelClClDiff.Controls.Add(this.buttonClClDiffResetCuts);
            this.panelClClDiff.Controls.Add(this.buttonClClDiffModifyDelte);
            this.panelClClDiff.Controls.Add(this.comboBoxClClDiffModify);
            this.panelClClDiff.Controls.Add(this.checkBoxClClDiffModify);
            this.panelClClDiff.Controls.Add(this.labelClClDiffMultSendTo);
            this.panelClClDiff.Controls.Add(this.comboBoxClClDiffSendTo);
            this.panelClClDiff.Controls.Add(this.checkBoxClClDiffMultStep);
            this.panelClClDiff.Controls.Add(this.labelClClDiffPrice);
            this.panelClClDiff.Controls.Add(this.labelClClDiffPO);
            this.panelClClDiff.Controls.Add(this.labelClClDiffPromiseDate);
            this.panelClClDiff.Controls.Add(this.checkBoxClClDiffScrapCredit);
            this.panelClClDiff.Controls.Add(this.textBoxClClDiffPO);
            this.panelClClDiff.Controls.Add(this.textBoxClClDiffPrice);
            this.panelClClDiff.Controls.Add(this.dateTimePickerClClDiffPromiseDate);
            this.panelClClDiff.Controls.Add(this.richTextBoxClClDiffComments);
            this.panelClClDiff.Controls.Add(this.buttonClClDiffReset);
            this.panelClClDiff.Controls.Add(this.buttonClClDiffStartOrder);
            this.panelClClDiff.Controls.Add(this.buttonClClDiffAddOrder);
            this.panelClClDiff.Controls.Add(this.dataGridViewClClDiff);
            this.panelClClDiff.Controls.Add(this.listViewClClDiff);
            this.panelClClDiff.Location = new System.Drawing.Point(4, 2);
            this.panelClClDiff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelClClDiff.Name = "panelClClDiff";
            this.panelClClDiff.Size = new System.Drawing.Size(1096, 618);
            this.panelClClDiff.TabIndex = 2;
            this.panelClClDiff.VisibleChanged += new System.EventHandler(this.PanelClClDiff_VisibleChanged);
            // 
            // labelClClDiffMasterSequence
            // 
            this.labelClClDiffMasterSequence.AutoSize = true;
            this.labelClClDiffMasterSequence.Location = new System.Drawing.Point(128, 626);
            this.labelClClDiffMasterSequence.Name = "labelClClDiffMasterSequence";
            this.labelClClDiffMasterSequence.Size = new System.Drawing.Size(14, 16);
            this.labelClClDiffMasterSequence.TabIndex = 40;
            this.labelClClDiffMasterSequence.Text = "0";
            // 
            // labelClClDiffMasterFrom
            // 
            this.labelClClDiffMasterFrom.AutoSize = true;
            this.labelClClDiffMasterFrom.Location = new System.Drawing.Point(128, 603);
            this.labelClClDiffMasterFrom.Name = "labelClClDiffMasterFrom";
            this.labelClClDiffMasterFrom.Size = new System.Drawing.Size(14, 16);
            this.labelClClDiffMasterFrom.TabIndex = 39;
            this.labelClClDiffMasterFrom.Text = "0";
            // 
            // buttonClClDiffResetCuts
            // 
            this.buttonClClDiffResetCuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClClDiffResetCuts.Location = new System.Drawing.Point(951, 506);
            this.buttonClClDiffResetCuts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClClDiffResetCuts.Name = "buttonClClDiffResetCuts";
            this.buttonClClDiffResetCuts.Size = new System.Drawing.Size(131, 25);
            this.buttonClClDiffResetCuts.TabIndex = 38;
            this.buttonClClDiffResetCuts.Text = "Reset Cuts";
            this.buttonClClDiffResetCuts.UseVisualStyleBackColor = true;
            this.buttonClClDiffResetCuts.Visible = false;
            this.buttonClClDiffResetCuts.Click += new System.EventHandler(this.ButtonClClDiffResetCuts_Click);
            // 
            // buttonClClDiffModifyDelte
            // 
            this.buttonClClDiffModifyDelte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClClDiffModifyDelte.Location = new System.Drawing.Point(181, 490);
            this.buttonClClDiffModifyDelte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClClDiffModifyDelte.Name = "buttonClClDiffModifyDelte";
            this.buttonClClDiffModifyDelte.Size = new System.Drawing.Size(76, 39);
            this.buttonClClDiffModifyDelte.TabIndex = 33;
            this.buttonClClDiffModifyDelte.Text = "Delete";
            this.buttonClClDiffModifyDelte.UseVisualStyleBackColor = true;
            this.buttonClClDiffModifyDelte.Visible = false;
            this.buttonClClDiffModifyDelte.Click += new System.EventHandler(this.ButtonClClDiffModifyDelte_Click);
            // 
            // comboBoxClClDiffModify
            // 
            this.comboBoxClClDiffModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxClClDiffModify.FormattingEnabled = true;
            this.comboBoxClClDiffModify.Location = new System.Drawing.Point(32, 506);
            this.comboBoxClClDiffModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxClClDiffModify.Name = "comboBoxClClDiffModify";
            this.comboBoxClClDiffModify.Size = new System.Drawing.Size(141, 24);
            this.comboBoxClClDiffModify.TabIndex = 32;
            this.comboBoxClClDiffModify.Visible = false;
            this.comboBoxClClDiffModify.SelectedIndexChanged += new System.EventHandler(this.ComboBoxClClDiffModify_SelectedIndexChanged);
            // 
            // checkBoxClClDiffModify
            // 
            this.checkBoxClClDiffModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxClClDiffModify.AutoSize = true;
            this.checkBoxClClDiffModify.Location = new System.Drawing.Point(11, 481);
            this.checkBoxClClDiffModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxClClDiffModify.Name = "checkBoxClClDiffModify";
            this.checkBoxClClDiffModify.Size = new System.Drawing.Size(69, 20);
            this.checkBoxClClDiffModify.TabIndex = 31;
            this.checkBoxClClDiffModify.Text = "Modify";
            this.checkBoxClClDiffModify.UseVisualStyleBackColor = true;
            this.checkBoxClClDiffModify.CheckedChanged += new System.EventHandler(this.CheckBoxClClDiffModify_CheckedChanged);
            // 
            // labelClClDiffMultSendTo
            // 
            this.labelClClDiffMultSendTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClClDiffMultSendTo.AutoSize = true;
            this.labelClClDiffMultSendTo.Location = new System.Drawing.Point(29, 559);
            this.labelClClDiffMultSendTo.Name = "labelClClDiffMultSendTo";
            this.labelClClDiffMultSendTo.Size = new System.Drawing.Size(53, 16);
            this.labelClClDiffMultSendTo.TabIndex = 30;
            this.labelClClDiffMultSendTo.Text = "Send to";
            this.labelClClDiffMultSendTo.Visible = false;
            // 
            // comboBoxClClDiffSendTo
            // 
            this.comboBoxClClDiffSendTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxClClDiffSendTo.FormattingEnabled = true;
            this.comboBoxClClDiffSendTo.Location = new System.Drawing.Point(32, 578);
            this.comboBoxClClDiffSendTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxClClDiffSendTo.Name = "comboBoxClClDiffSendTo";
            this.comboBoxClClDiffSendTo.Size = new System.Drawing.Size(171, 24);
            this.comboBoxClClDiffSendTo.TabIndex = 29;
            this.comboBoxClClDiffSendTo.Visible = false;
            // 
            // checkBoxClClDiffMultStep
            // 
            this.checkBoxClClDiffMultStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxClClDiffMultStep.AutoSize = true;
            this.checkBoxClClDiffMultStep.Location = new System.Drawing.Point(11, 539);
            this.checkBoxClClDiffMultStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxClClDiffMultStep.Name = "checkBoxClClDiffMultStep";
            this.checkBoxClClDiffMultStep.Size = new System.Drawing.Size(84, 20);
            this.checkBoxClClDiffMultStep.TabIndex = 28;
            this.checkBoxClClDiffMultStep.Text = "MultiStep";
            this.checkBoxClClDiffMultStep.UseVisualStyleBackColor = true;
            this.checkBoxClClDiffMultStep.CheckedChanged += new System.EventHandler(this.CheckBoxClClDiffMultStep_CheckedChanged);
            // 
            // labelClClDiffPrice
            // 
            this.labelClClDiffPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClClDiffPrice.AutoSize = true;
            this.labelClClDiffPrice.Location = new System.Drawing.Point(563, 513);
            this.labelClClDiffPrice.Name = "labelClClDiffPrice";
            this.labelClClDiffPrice.Size = new System.Drawing.Size(38, 16);
            this.labelClClDiffPrice.TabIndex = 27;
            this.labelClClDiffPrice.Text = "Price";
            // 
            // labelClClDiffPO
            // 
            this.labelClClDiffPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClClDiffPO.AutoSize = true;
            this.labelClClDiffPO.Location = new System.Drawing.Point(563, 566);
            this.labelClClDiffPO.Name = "labelClClDiffPO";
            this.labelClClDiffPO.Size = new System.Drawing.Size(101, 16);
            this.labelClClDiffPO.TabIndex = 26;
            this.labelClClDiffPO.Text = "Purchase Order";
            // 
            // labelClClDiffPromiseDate
            // 
            this.labelClClDiffPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClClDiffPromiseDate.AutoSize = true;
            this.labelClClDiffPromiseDate.Location = new System.Drawing.Point(264, 566);
            this.labelClClDiffPromiseDate.Name = "labelClClDiffPromiseDate";
            this.labelClClDiffPromiseDate.Size = new System.Drawing.Size(89, 16);
            this.labelClClDiffPromiseDate.TabIndex = 25;
            this.labelClClDiffPromiseDate.Text = "Promise Date";
            // 
            // checkBoxClClDiffScrapCredit
            // 
            this.checkBoxClClDiffScrapCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxClClDiffScrapCredit.AutoSize = true;
            this.checkBoxClClDiffScrapCredit.Location = new System.Drawing.Point(563, 485);
            this.checkBoxClClDiffScrapCredit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxClClDiffScrapCredit.Name = "checkBoxClClDiffScrapCredit";
            this.checkBoxClClDiffScrapCredit.Size = new System.Drawing.Size(103, 20);
            this.checkBoxClClDiffScrapCredit.TabIndex = 24;
            this.checkBoxClClDiffScrapCredit.Text = "Scrap Credit";
            this.checkBoxClClDiffScrapCredit.UseVisualStyleBackColor = true;
            // 
            // textBoxClClDiffPO
            // 
            this.textBoxClClDiffPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxClClDiffPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxClClDiffPO.Location = new System.Drawing.Point(563, 586);
            this.textBoxClClDiffPO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClClDiffPO.Name = "textBoxClClDiffPO";
            this.textBoxClClDiffPO.Size = new System.Drawing.Size(227, 22);
            this.textBoxClClDiffPO.TabIndex = 23;
            // 
            // textBoxClClDiffPrice
            // 
            this.textBoxClClDiffPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxClClDiffPrice.Location = new System.Drawing.Point(563, 533);
            this.textBoxClClDiffPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClClDiffPrice.Name = "textBoxClClDiffPrice";
            this.textBoxClClDiffPrice.Size = new System.Drawing.Size(112, 22);
            this.textBoxClClDiffPrice.TabIndex = 22;
            // 
            // dateTimePickerClClDiffPromiseDate
            // 
            this.dateTimePickerClClDiffPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerClClDiffPromiseDate.Location = new System.Drawing.Point(267, 586);
            this.dateTimePickerClClDiffPromiseDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerClClDiffPromiseDate.Name = "dateTimePickerClClDiffPromiseDate";
            this.dateTimePickerClClDiffPromiseDate.Size = new System.Drawing.Size(272, 22);
            this.dateTimePickerClClDiffPromiseDate.TabIndex = 21;
            // 
            // richTextBoxClClDiffComments
            // 
            this.richTextBoxClClDiffComments.AcceptsTab = true;
            this.richTextBoxClClDiffComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxClClDiffComments.Location = new System.Drawing.Point(267, 481);
            this.richTextBoxClClDiffComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxClClDiffComments.Name = "richTextBoxClClDiffComments";
            this.richTextBoxClClDiffComments.Size = new System.Drawing.Size(239, 74);
            this.richTextBoxClClDiffComments.TabIndex = 20;
            this.richTextBoxClClDiffComments.Text = "";
            // 
            // buttonClClDiffReset
            // 
            this.buttonClClDiffReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClClDiffReset.Location = new System.Drawing.Point(951, 479);
            this.buttonClClDiffReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClClDiffReset.Name = "buttonClClDiffReset";
            this.buttonClClDiffReset.Size = new System.Drawing.Size(131, 25);
            this.buttonClClDiffReset.TabIndex = 5;
            this.buttonClClDiffReset.Text = "Reset All";
            this.buttonClClDiffReset.UseVisualStyleBackColor = true;
            this.buttonClClDiffReset.Visible = false;
            this.buttonClClDiffReset.Click += new System.EventHandler(this.ButtonClClDiffReset_Click);
            // 
            // buttonClClDiffStartOrder
            // 
            this.buttonClClDiffStartOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClClDiffStartOrder.Location = new System.Drawing.Point(951, 565);
            this.buttonClClDiffStartOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClClDiffStartOrder.Name = "buttonClClDiffStartOrder";
            this.buttonClClDiffStartOrder.Size = new System.Drawing.Size(131, 34);
            this.buttonClClDiffStartOrder.TabIndex = 4;
            this.buttonClClDiffStartOrder.Text = "Start Order";
            this.buttonClClDiffStartOrder.UseVisualStyleBackColor = true;
            this.buttonClClDiffStartOrder.Click += new System.EventHandler(this.ButtonClClDiffStartOrder_Click);
            // 
            // buttonClClDiffAddOrder
            // 
            this.buttonClClDiffAddOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClClDiffAddOrder.Location = new System.Drawing.Point(951, 565);
            this.buttonClClDiffAddOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClClDiffAddOrder.Name = "buttonClClDiffAddOrder";
            this.buttonClClDiffAddOrder.Size = new System.Drawing.Size(131, 34);
            this.buttonClClDiffAddOrder.TabIndex = 35;
            this.buttonClClDiffAddOrder.Text = "Add Order";
            this.buttonClClDiffAddOrder.UseVisualStyleBackColor = true;
            this.buttonClClDiffAddOrder.Visible = false;
            this.buttonClClDiffAddOrder.Click += new System.EventHandler(this.ButtonClClDiffAddOrder_Click);
            // 
            // dataGridViewClClDiff
            // 
            this.dataGridViewClClDiff.AllowUserToAddRows = false;
            this.dataGridViewClClDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewClClDiff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewClClDiff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClClDiff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClClDiffTagID,
            this.colClClDiffThickness,
            this.colClClDiffWidth,
            this.colClClDiffAlloy,
            this.colClClDiffBreak,
            this.colClClDiffOrigWeight,
            this.colClClDiffNewWeight,
            this.colClClDiffWidthLeft,
            this.colClClDiffTrimAmount,
            this.colClClDiffCutCount,
            this.colClClDiffPaper,
            this.colClClDiffAddCutButton});
            this.dataGridViewClClDiff.Location = new System.Drawing.Point(-3, 7);
            this.dataGridViewClClDiff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewClClDiff.Name = "dataGridViewClClDiff";
            this.dataGridViewClClDiff.RowHeadersWidth = 51;
            this.dataGridViewClClDiff.RowTemplate.Height = 24;
            this.dataGridViewClClDiff.Size = new System.Drawing.Size(1098, 466);
            this.dataGridViewClClDiff.TabIndex = 34;
            this.dataGridViewClClDiff.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewClClDiff_CellEndEdit);
            this.dataGridViewClClDiff.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewClClDiff_CellEnter);
            // 
            // colClClDiffTagID
            // 
            this.colClClDiffTagID.FillWeight = 75F;
            this.colClClDiffTagID.HeaderText = "TagID";
            this.colClClDiffTagID.MinimumWidth = 6;
            this.colClClDiffTagID.Name = "colClClDiffTagID";
            this.colClClDiffTagID.ReadOnly = true;
            this.colClClDiffTagID.Width = 74;
            // 
            // colClClDiffThickness
            // 
            this.colClClDiffThickness.HeaderText = "Thickness";
            this.colClClDiffThickness.MinimumWidth = 6;
            this.colClClDiffThickness.Name = "colClClDiffThickness";
            this.colClClDiffThickness.ReadOnly = true;
            this.colClClDiffThickness.Width = 98;
            // 
            // colClClDiffWidth
            // 
            this.colClClDiffWidth.HeaderText = "Width";
            this.colClClDiffWidth.MinimumWidth = 6;
            this.colClClDiffWidth.Name = "colClClDiffWidth";
            this.colClClDiffWidth.ReadOnly = true;
            this.colClClDiffWidth.Width = 70;
            // 
            // colClClDiffAlloy
            // 
            this.colClClDiffAlloy.HeaderText = "Alloy";
            this.colClClDiffAlloy.MinimumWidth = 6;
            this.colClClDiffAlloy.Name = "colClClDiffAlloy";
            this.colClClDiffAlloy.ReadOnly = true;
            this.colClClDiffAlloy.Width = 66;
            // 
            // colClClDiffBreak
            // 
            this.colClClDiffBreak.FillWeight = 50F;
            this.colClClDiffBreak.HeaderText = "Break";
            this.colClClDiffBreak.MinimumWidth = 6;
            this.colClClDiffBreak.Name = "colClClDiffBreak";
            this.colClClDiffBreak.Width = 49;
            // 
            // colClClDiffOrigWeight
            // 
            this.colClClDiffOrigWeight.HeaderText = "Orig LBS";
            this.colClClDiffOrigWeight.MinimumWidth = 6;
            this.colClClDiffOrigWeight.Name = "colClClDiffOrigWeight";
            this.colClClDiffOrigWeight.Width = 89;
            // 
            // colClClDiffNewWeight
            // 
            this.colClClDiffNewWeight.HeaderText = "New LBS";
            this.colClClDiffNewWeight.MinimumWidth = 6;
            this.colClClDiffNewWeight.Name = "colClClDiffNewWeight";
            this.colClClDiffNewWeight.Width = 91;
            // 
            // colClClDiffWidthLeft
            // 
            this.colClClDiffWidthLeft.HeaderText = "Remaining";
            this.colClClDiffWidthLeft.MinimumWidth = 6;
            this.colClClDiffWidthLeft.Name = "colClClDiffWidthLeft";
            this.colClClDiffWidthLeft.ReadOnly = true;
            this.colClClDiffWidthLeft.Width = 101;
            // 
            // colClClDiffTrimAmount
            // 
            this.colClClDiffTrimAmount.HeaderText = "Trim";
            this.colClClDiffTrimAmount.MinimumWidth = 6;
            this.colClClDiffTrimAmount.Name = "colClClDiffTrimAmount";
            this.colClClDiffTrimAmount.Width = 63;
            // 
            // colClClDiffCutCount
            // 
            this.colClClDiffCutCount.HeaderText = "CutCount";
            this.colClClDiffCutCount.MinimumWidth = 6;
            this.colClClDiffCutCount.Name = "colClClDiffCutCount";
            this.colClClDiffCutCount.ReadOnly = true;
            this.colClClDiffCutCount.Width = 89;
            // 
            // colClClDiffPaper
            // 
            this.colClClDiffPaper.HeaderText = "Paper";
            this.colClClDiffPaper.MinimumWidth = 6;
            this.colClClDiffPaper.Name = "colClClDiffPaper";
            this.colClClDiffPaper.Width = 50;
            // 
            // colClClDiffAddCutButton
            // 
            this.colClClDiffAddCutButton.HeaderText = "AddCut";
            this.colClClDiffAddCutButton.MinimumWidth = 6;
            this.colClClDiffAddCutButton.Name = "colClClDiffAddCutButton";
            this.colClClDiffAddCutButton.Text = "Add";
            this.colClClDiffAddCutButton.UseColumnTextForButtonValue = true;
            this.colClClDiffAddCutButton.Width = 57;
            // 
            // listViewClClDiff
            // 
            this.listViewClClDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewClClDiff.CheckBoxes = true;
            this.listViewClClDiff.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24,
            this.columnHeader25,
            this.columnHeader26,
            this.columnHeader27,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader30,
            this.columnHeader31,
            this.columnHeader32,
            this.columnHeader33,
            this.columnHeader34,
            this.lvCCDOrders});
            this.listViewClClDiff.HideSelection = false;
            this.listViewClClDiff.Location = new System.Drawing.Point(-7, 5);
            this.listViewClClDiff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewClClDiff.Name = "listViewClClDiff";
            this.listViewClClDiff.Size = new System.Drawing.Size(1106, 468);
            this.listViewClClDiff.TabIndex = 3;
            this.listViewClClDiff.UseCompatibleStateImageBehavior = false;
            this.listViewClClDiff.View = System.Windows.Forms.View.Details;
            this.listViewClClDiff.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewClClDiff_ItemChecked);
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Tag ID";
            this.columnHeader18.Width = 100;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Location";
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Alloy";
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Thickness";
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Width";
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Length";
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Weight";
            // 
            // columnHeader25
            // 
            this.columnHeader25.Text = "Mill#";
            // 
            // columnHeader26
            // 
            this.columnHeader26.Text = "Heat";
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "Carbon";
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "Vendor";
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "PO";
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "Container";
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "Rec Date";
            // 
            // columnHeader32
            // 
            this.columnHeader32.Text = "Rec#";
            // 
            // columnHeader33
            // 
            this.columnHeader33.Text = "Coil Cnt";
            // 
            // columnHeader34
            // 
            this.columnHeader34.Text = "Cnt Of Orig";
            // 
            // lvCCDOrders
            // 
            this.lvCCDOrders.Text = "Orders";
            // 
            // panelSheetSheetSame
            // 
            this.panelSheetSheetSame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSheetSheetSame.Controls.Add(this.btnSSMCancel);
            this.panelSheetSheetSame.Controls.Add(this.labelSSSmSpecialLeadTime);
            this.panelSheetSheetSame.Controls.Add(this.textBoxSSSmRunSheet);
            this.panelSheetSheetSame.Controls.Add(this.labelSSSmRunSheet);
            this.panelSheetSheetSame.Controls.Add(this.comboBoxSSSmModify);
            this.panelSheetSheetSame.Controls.Add(this.checkBoxSSSmModify);
            this.panelSheetSheetSame.Controls.Add(this.comboBoxSSSmMulti);
            this.panelSheetSheetSame.Controls.Add(this.checkBoxSSSmMultiStep);
            this.panelSheetSheetSame.Controls.Add(this.labelSSSmPrice);
            this.panelSheetSheetSame.Controls.Add(this.labelSSSmPO);
            this.panelSheetSheetSame.Controls.Add(this.labelSSSmPromiseDate);
            this.panelSheetSheetSame.Controls.Add(this.textBoxSSSmPO);
            this.panelSheetSheetSame.Controls.Add(this.textBoxSSSmPrice);
            this.panelSheetSheetSame.Controls.Add(this.dateTimePickerSSSmPromiseDate);
            this.panelSheetSheetSame.Controls.Add(this.richTextBoxSSSmComments);
            this.panelSheetSheetSame.Controls.Add(this.buttonSSSmAddOrder);
            this.panelSheetSheetSame.Controls.Add(this.buttonSSSmStartOrder);
            this.panelSheetSheetSame.Controls.Add(this.listViewSSSmSkidData);
            this.panelSheetSheetSame.Controls.Add(this.dataGridViewSSSmSkid);
            this.panelSheetSheetSame.Location = new System.Drawing.Point(0, 4);
            this.panelSheetSheetSame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSheetSheetSame.Name = "panelSheetSheetSame";
            this.panelSheetSheetSame.Size = new System.Drawing.Size(1103, 617);
            this.panelSheetSheetSame.TabIndex = 3;
            this.panelSheetSheetSame.VisibleChanged += new System.EventHandler(this.PanelSheetSheetSame_VisibleChanged);
            // 
            // btnSSMCancel
            // 
            this.btnSSMCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSSMCancel.Location = new System.Drawing.Point(757, 568);
            this.btnSSMCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSSMCancel.Name = "btnSSMCancel";
            this.btnSSMCancel.Size = new System.Drawing.Size(163, 32);
            this.btnSSMCancel.TabIndex = 65;
            this.btnSSMCancel.Text = "Cancel";
            this.btnSSMCancel.UseVisualStyleBackColor = true;
            this.btnSSMCancel.Click += new System.EventHandler(this.btnSSMCancel_Click);
            // 
            // labelSSSmSpecialLeadTime
            // 
            this.labelSSSmSpecialLeadTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSSmSpecialLeadTime.AutoSize = true;
            this.labelSSSmSpecialLeadTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSSSmSpecialLeadTime.ForeColor = System.Drawing.Color.Red;
            this.labelSSSmSpecialLeadTime.Location = new System.Drawing.Point(531, 582);
            this.labelSSSmSpecialLeadTime.Name = "labelSSSmSpecialLeadTime";
            this.labelSSSmSpecialLeadTime.Size = new System.Drawing.Size(153, 20);
            this.labelSSSmSpecialLeadTime.TabIndex = 61;
            this.labelSSSmSpecialLeadTime.Text = "Special Lead Time!";
            this.labelSSSmSpecialLeadTime.Visible = false;
            // 
            // textBoxSSSmRunSheet
            // 
            this.textBoxSSSmRunSheet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSSSmRunSheet.Location = new System.Drawing.Point(641, 539);
            this.textBoxSSSmRunSheet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSSSmRunSheet.Name = "textBoxSSSmRunSheet";
            this.textBoxSSSmRunSheet.Size = new System.Drawing.Size(390, 22);
            this.textBoxSSSmRunSheet.TabIndex = 55;
            this.textBoxSSSmRunSheet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSSSmRunSheet_KeyPress);
            // 
            // labelSSSmRunSheet
            // 
            this.labelSSSmRunSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSSmRunSheet.AutoSize = true;
            this.labelSSSmRunSheet.Location = new System.Drawing.Point(489, 543);
            this.labelSSSmRunSheet.Name = "labelSSSmRunSheet";
            this.labelSSSmRunSheet.Size = new System.Drawing.Size(136, 16);
            this.labelSSSmRunSheet.TabIndex = 60;
            this.labelSSSmRunSheet.Text = "Run Sheet Comments";
            // 
            // comboBoxSSSmModify
            // 
            this.comboBoxSSSmModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxSSSmModify.FormattingEnabled = true;
            this.comboBoxSSSmModify.Location = new System.Drawing.Point(25, 492);
            this.comboBoxSSSmModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSSSmModify.Name = "comboBoxSSSmModify";
            this.comboBoxSSSmModify.Size = new System.Drawing.Size(141, 24);
            this.comboBoxSSSmModify.TabIndex = 48;
            this.comboBoxSSSmModify.Visible = false;
            // 
            // checkBoxSSSmModify
            // 
            this.checkBoxSSSmModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxSSSmModify.AutoSize = true;
            this.checkBoxSSSmModify.Location = new System.Drawing.Point(3, 466);
            this.checkBoxSSSmModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxSSSmModify.Name = "checkBoxSSSmModify";
            this.checkBoxSSSmModify.Size = new System.Drawing.Size(69, 20);
            this.checkBoxSSSmModify.TabIndex = 47;
            this.checkBoxSSSmModify.Text = "Modify";
            this.checkBoxSSSmModify.UseVisualStyleBackColor = true;
            // 
            // comboBoxSSSmMulti
            // 
            this.comboBoxSSSmMulti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxSSSmMulti.FormattingEnabled = true;
            this.comboBoxSSSmMulti.Location = new System.Drawing.Point(25, 566);
            this.comboBoxSSSmMulti.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSSSmMulti.Name = "comboBoxSSSmMulti";
            this.comboBoxSSSmMulti.Size = new System.Drawing.Size(171, 24);
            this.comboBoxSSSmMulti.TabIndex = 50;
            this.comboBoxSSSmMulti.Visible = false;
            // 
            // checkBoxSSSmMultiStep
            // 
            this.checkBoxSSSmMultiStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxSSSmMultiStep.AutoSize = true;
            this.checkBoxSSSmMultiStep.Location = new System.Drawing.Point(3, 526);
            this.checkBoxSSSmMultiStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxSSSmMultiStep.Name = "checkBoxSSSmMultiStep";
            this.checkBoxSSSmMultiStep.Size = new System.Drawing.Size(84, 20);
            this.checkBoxSSSmMultiStep.TabIndex = 49;
            this.checkBoxSSSmMultiStep.Text = "MultiStep";
            this.checkBoxSSSmMultiStep.UseVisualStyleBackColor = true;
            // 
            // labelSSSmPrice
            // 
            this.labelSSSmPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSSmPrice.AutoSize = true;
            this.labelSSSmPrice.Location = new System.Drawing.Point(489, 492);
            this.labelSSSmPrice.Name = "labelSSSmPrice";
            this.labelSSSmPrice.Size = new System.Drawing.Size(38, 16);
            this.labelSSSmPrice.TabIndex = 59;
            this.labelSSSmPrice.Text = "Price";
            // 
            // labelSSSmPO
            // 
            this.labelSSSmPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSSmPO.AutoSize = true;
            this.labelSSSmPO.Location = new System.Drawing.Point(489, 516);
            this.labelSSSmPO.Name = "labelSSSmPO";
            this.labelSSSmPO.Size = new System.Drawing.Size(101, 16);
            this.labelSSSmPO.TabIndex = 58;
            this.labelSSSmPO.Text = "Purchase Order";
            // 
            // labelSSSmPromiseDate
            // 
            this.labelSSSmPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSSmPromiseDate.AutoSize = true;
            this.labelSSSmPromiseDate.Location = new System.Drawing.Point(245, 559);
            this.labelSSSmPromiseDate.Name = "labelSSSmPromiseDate";
            this.labelSSSmPromiseDate.Size = new System.Drawing.Size(89, 16);
            this.labelSSSmPromiseDate.TabIndex = 57;
            this.labelSSSmPromiseDate.Text = "Promise Date";
            // 
            // textBoxSSSmPO
            // 
            this.textBoxSSSmPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSSSmPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxSSSmPO.Location = new System.Drawing.Point(603, 514);
            this.textBoxSSSmPO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSSSmPO.Name = "textBoxSSSmPO";
            this.textBoxSSSmPO.Size = new System.Drawing.Size(227, 22);
            this.textBoxSSSmPO.TabIndex = 54;
            this.textBoxSSSmPO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSSSmPO_KeyPress);
            // 
            // textBoxSSSmPrice
            // 
            this.textBoxSSSmPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSSSmPrice.Location = new System.Drawing.Point(533, 489);
            this.textBoxSSSmPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSSSmPrice.Name = "textBoxSSSmPrice";
            this.textBoxSSSmPrice.Size = new System.Drawing.Size(112, 22);
            this.textBoxSSSmPrice.TabIndex = 53;
            this.textBoxSSSmPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSSSmPrice_KeyPress);
            // 
            // dateTimePickerSSSmPromiseDate
            // 
            this.dateTimePickerSSSmPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerSSSmPromiseDate.Location = new System.Drawing.Point(247, 583);
            this.dateTimePickerSSSmPromiseDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerSSSmPromiseDate.Name = "dateTimePickerSSSmPromiseDate";
            this.dateTimePickerSSSmPromiseDate.Size = new System.Drawing.Size(272, 22);
            this.dateTimePickerSSSmPromiseDate.TabIndex = 52;
            // 
            // richTextBoxSSSmComments
            // 
            this.richTextBoxSSSmComments.AcceptsTab = true;
            this.richTextBoxSSSmComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxSSSmComments.Location = new System.Drawing.Point(247, 479);
            this.richTextBoxSSSmComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxSSSmComments.Name = "richTextBoxSSSmComments";
            this.richTextBoxSSSmComments.Size = new System.Drawing.Size(239, 74);
            this.richTextBoxSSSmComments.TabIndex = 51;
            this.richTextBoxSSSmComments.Text = "";
            this.richTextBoxSSSmComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxSSSmComments_KeyPress);
            // 
            // buttonSSSmAddOrder
            // 
            this.buttonSSSmAddOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSSSmAddOrder.Location = new System.Drawing.Point(926, 567);
            this.buttonSSSmAddOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSSSmAddOrder.Name = "buttonSSSmAddOrder";
            this.buttonSSSmAddOrder.Size = new System.Drawing.Size(163, 32);
            this.buttonSSSmAddOrder.TabIndex = 63;
            this.buttonSSSmAddOrder.Text = "Add Order";
            this.buttonSSSmAddOrder.UseVisualStyleBackColor = true;
            this.buttonSSSmAddOrder.Click += new System.EventHandler(this.ButtonSSmAddOrder_Click);
            // 
            // buttonSSSmStartOrder
            // 
            this.buttonSSSmStartOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSSSmStartOrder.Location = new System.Drawing.Point(926, 568);
            this.buttonSSSmStartOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSSSmStartOrder.Name = "buttonSSSmStartOrder";
            this.buttonSSSmStartOrder.Size = new System.Drawing.Size(163, 32);
            this.buttonSSSmStartOrder.TabIndex = 56;
            this.buttonSSSmStartOrder.Text = "Start Order";
            this.buttonSSSmStartOrder.UseVisualStyleBackColor = true;
            this.buttonSSSmStartOrder.Click += new System.EventHandler(this.ButtonSSSmStartOrder_Click);
            // 
            // listViewSSSmSkidData
            // 
            this.listViewSSSmSkidData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSSSmSkidData.CheckBoxes = true;
            this.listViewSSSmSkidData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader43,
            this.columnHeader44,
            this.columnHeader45,
            this.columnHeader46,
            this.columnHeader47,
            this.columnHeader48,
            this.columnHeader49,
            this.columnHeader50,
            this.columnHeader101,
            this.columnHeader102,
            this.columnHeader51,
            this.columnHeader52,
            this.columnHeader53,
            this.columnHeader54,
            this.columnHeader55,
            this.lvsssOrders});
            this.listViewSSSmSkidData.FullRowSelect = true;
            this.listViewSSSmSkidData.HideSelection = false;
            this.listViewSSSmSkidData.Location = new System.Drawing.Point(5, -1);
            this.listViewSSSmSkidData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewSSSmSkidData.MultiSelect = false;
            this.listViewSSSmSkidData.Name = "listViewSSSmSkidData";
            this.listViewSSSmSkidData.Size = new System.Drawing.Size(1091, 456);
            this.listViewSSSmSkidData.TabIndex = 62;
            this.listViewSSSmSkidData.UseCompatibleStateImageBehavior = false;
            this.listViewSSSmSkidData.View = System.Windows.Forms.View.Details;
            this.listViewSSSmSkidData.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewSSSmSkidData_ItemChecked);
            // 
            // columnHeader43
            // 
            this.columnHeader43.Text = "SkidID";
            this.columnHeader43.Width = 92;
            // 
            // columnHeader44
            // 
            this.columnHeader44.Text = "Location";
            this.columnHeader44.Width = 79;
            // 
            // columnHeader45
            // 
            this.columnHeader45.Text = "Pcs";
            this.columnHeader45.Width = 45;
            // 
            // columnHeader46
            // 
            this.columnHeader46.Text = "Alloy";
            this.columnHeader46.Width = 70;
            // 
            // columnHeader47
            // 
            this.columnHeader47.Text = "Thick";
            this.columnHeader47.Width = 48;
            // 
            // columnHeader48
            // 
            this.columnHeader48.Text = "Width";
            // 
            // columnHeader49
            // 
            this.columnHeader49.Text = "Length";
            // 
            // columnHeader50
            // 
            this.columnHeader50.Text = "Weight";
            // 
            // columnHeader101
            // 
            this.columnHeader101.Text = "Mill#";
            // 
            // columnHeader102
            // 
            this.columnHeader102.Text = "Heat#";
            // 
            // columnHeader51
            // 
            this.columnHeader51.Text = "PVC SQFT";
            this.columnHeader51.Width = 85;
            // 
            // columnHeader52
            // 
            this.columnHeader52.Text = "PI SQFT";
            // 
            // columnHeader53
            // 
            this.columnHeader53.Text = "Comments";
            this.columnHeader53.Width = 200;
            // 
            // columnHeader54
            // 
            this.columnHeader54.Text = "Not Prime";
            this.columnHeader54.Width = 113;
            // 
            // columnHeader55
            // 
            this.columnHeader55.Text = "Branch";
            // 
            // lvsssOrders
            // 
            this.lvsssOrders.Text = "Orders";
            // 
            // dataGridViewSSSmSkid
            // 
            this.dataGridViewSSSmSkid.AllowUserToAddRows = false;
            this.dataGridViewSSSmSkid.AllowUserToDeleteRows = false;
            this.dataGridViewSSSmSkid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSSSmSkid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewSSSmSkid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewSSSmSkid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSSSmSkid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSSSmBreakSkid,
            this.dgvSSSmSkidID,
            this.dgvSSSmLetter,
            this.dgvSSSmPieces,
            this.dgvSSSmAlloy,
            this.dgvSSSmNewFinish,
            this.dgvSSSmThickness,
            this.dgvSSSmWidth,
            this.dgvSSSmLength,
            this.dgvSSSmWeight,
            this.dgvSSSmPVC,
            this.dgvSSSmPaper,
            this.dgvSSSmLineMark,
            this.dgvSSSmComments,
            this.dgvSSSmBranch,
            this.dgvSSSmBranchID,
            this.dgvSSSmAlloyID,
            this.dgvSSSmFinishID,
            this.dgvSSSmDensityFactor,
            this.dgvSSSmOrigFinish,
            this.dgvSSSmPVCGroupID,
            this.dgvSSSmPVCPriceList,
            this.dgvSSSmCurrPrice});
            this.dataGridViewSSSmSkid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewSSSmSkid.Location = new System.Drawing.Point(3, 1);
            this.dataGridViewSSSmSkid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewSSSmSkid.Name = "dataGridViewSSSmSkid";
            this.dataGridViewSSSmSkid.RowHeadersWidth = 51;
            this.dataGridViewSSSmSkid.RowTemplate.Height = 24;
            this.dataGridViewSSSmSkid.Size = new System.Drawing.Size(1095, 455);
            this.dataGridViewSSSmSkid.TabIndex = 64;
            this.dataGridViewSSSmSkid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewSSSmSkid_CellContentClick);
            this.dataGridViewSSSmSkid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewSSSmSkid_EditingControlShowing);
            // 
            // dgvSSSmBreakSkid
            // 
            this.dgvSSSmBreakSkid.HeaderText = "Break Skid";
            this.dgvSSSmBreakSkid.MinimumWidth = 6;
            this.dgvSSSmBreakSkid.Name = "dgvSSSmBreakSkid";
            this.dgvSSSmBreakSkid.Width = 79;
            // 
            // dgvSSSmSkidID
            // 
            this.dgvSSSmSkidID.HeaderText = "Skid ID";
            this.dgvSSSmSkidID.MinimumWidth = 6;
            this.dgvSSSmSkidID.Name = "dgvSSSmSkidID";
            this.dgvSSSmSkidID.ReadOnly = true;
            this.dgvSSSmSkidID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSSmSkidID.Width = 56;
            // 
            // dgvSSSmLetter
            // 
            this.dgvSSSmLetter.HeaderText = "Letter";
            this.dgvSSSmLetter.MinimumWidth = 6;
            this.dgvSSSmLetter.Name = "dgvSSSmLetter";
            this.dgvSSSmLetter.ReadOnly = true;
            this.dgvSSSmLetter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSSmLetter.Width = 46;
            // 
            // dgvSSSmPieces
            // 
            this.dgvSSSmPieces.HeaderText = "Pieces";
            this.dgvSSSmPieces.MinimumWidth = 6;
            this.dgvSSSmPieces.Name = "dgvSSSmPieces";
            this.dgvSSSmPieces.ReadOnly = true;
            this.dgvSSSmPieces.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSSmPieces.Width = 55;
            // 
            // dgvSSSmAlloy
            // 
            this.dgvSSSmAlloy.HeaderText = "Alloy";
            this.dgvSSSmAlloy.MinimumWidth = 6;
            this.dgvSSSmAlloy.Name = "dgvSSSmAlloy";
            this.dgvSSSmAlloy.ReadOnly = true;
            this.dgvSSSmAlloy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSSmAlloy.Width = 43;
            // 
            // dgvSSSmNewFinish
            // 
            this.dgvSSSmNewFinish.HeaderText = "New Finish";
            this.dgvSSSmNewFinish.MinimumWidth = 6;
            this.dgvSSSmNewFinish.Name = "dgvSSSmNewFinish";
            this.dgvSSSmNewFinish.Width = 78;
            // 
            // dgvSSSmThickness
            // 
            this.dgvSSSmThickness.HeaderText = "Thick";
            this.dgvSSSmThickness.MinimumWidth = 6;
            this.dgvSSSmThickness.Name = "dgvSSSmThickness";
            this.dgvSSSmThickness.ReadOnly = true;
            this.dgvSSSmThickness.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSSmThickness.Width = 46;
            // 
            // dgvSSSmWidth
            // 
            this.dgvSSSmWidth.HeaderText = "Width";
            this.dgvSSSmWidth.MinimumWidth = 6;
            this.dgvSSSmWidth.Name = "dgvSSSmWidth";
            this.dgvSSSmWidth.ReadOnly = true;
            this.dgvSSSmWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSSmWidth.Width = 47;
            // 
            // dgvSSSmLength
            // 
            this.dgvSSSmLength.HeaderText = "Length";
            this.dgvSSSmLength.MinimumWidth = 6;
            this.dgvSSSmLength.Name = "dgvSSSmLength";
            this.dgvSSSmLength.ReadOnly = true;
            this.dgvSSSmLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSSmLength.Width = 53;
            // 
            // dgvSSSmWeight
            // 
            this.dgvSSSmWeight.HeaderText = "Weight";
            this.dgvSSSmWeight.MinimumWidth = 6;
            this.dgvSSSmWeight.Name = "dgvSSSmWeight";
            this.dgvSSSmWeight.ReadOnly = true;
            this.dgvSSSmWeight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSSmWeight.Width = 55;
            // 
            // dgvSSSmPVC
            // 
            this.dgvSSSmPVC.HeaderText = "PVC";
            this.dgvSSSmPVC.MinimumWidth = 6;
            this.dgvSSSmPVC.Name = "dgvSSSmPVC";
            this.dgvSSSmPVC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSSSmPVC.Width = 40;
            // 
            // dgvSSSmPaper
            // 
            this.dgvSSSmPaper.HeaderText = "Paper";
            this.dgvSSSmPaper.MinimumWidth = 6;
            this.dgvSSSmPaper.Name = "dgvSSSmPaper";
            this.dgvSSSmPaper.Width = 50;
            // 
            // dgvSSSmLineMark
            // 
            this.dgvSSSmLineMark.HeaderText = "LM";
            this.dgvSSSmLineMark.MinimumWidth = 6;
            this.dgvSSSmLineMark.Name = "dgvSSSmLineMark";
            this.dgvSSSmLineMark.Width = 31;
            // 
            // dgvSSSmComments
            // 
            this.dgvSSSmComments.HeaderText = "Comments";
            this.dgvSSSmComments.MinimumWidth = 6;
            this.dgvSSSmComments.Name = "dgvSSSmComments";
            this.dgvSSSmComments.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSSmComments.Width = 77;
            // 
            // dgvSSSmBranch
            // 
            this.dgvSSSmBranch.HeaderText = "Branch";
            this.dgvSSSmBranch.MinimumWidth = 6;
            this.dgvSSSmBranch.Name = "dgvSSSmBranch";
            this.dgvSSSmBranch.Width = 55;
            // 
            // dgvSSSmBranchID
            // 
            this.dgvSSSmBranchID.HeaderText = "BranchID";
            this.dgvSSSmBranchID.MinimumWidth = 6;
            this.dgvSSSmBranchID.Name = "dgvSSSmBranchID";
            this.dgvSSSmBranchID.Visible = false;
            this.dgvSSSmBranchID.Width = 68;
            // 
            // dgvSSSmAlloyID
            // 
            this.dgvSSSmAlloyID.HeaderText = "AlloyID";
            this.dgvSSSmAlloyID.MinimumWidth = 6;
            this.dgvSSSmAlloyID.Name = "dgvSSSmAlloyID";
            this.dgvSSSmAlloyID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSSmAlloyID.Visible = false;
            this.dgvSSSmAlloyID.Width = 56;
            // 
            // dgvSSSmFinishID
            // 
            this.dgvSSSmFinishID.HeaderText = "Finish ID";
            this.dgvSSSmFinishID.MinimumWidth = 6;
            this.dgvSSSmFinishID.Name = "dgvSSSmFinishID";
            this.dgvSSSmFinishID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSSSmFinishID.Visible = false;
            this.dgvSSSmFinishID.Width = 64;
            // 
            // dgvSSSmDensityFactor
            // 
            this.dgvSSSmDensityFactor.HeaderText = "Density Factor";
            this.dgvSSSmDensityFactor.MinimumWidth = 6;
            this.dgvSSSmDensityFactor.Name = "dgvSSSmDensityFactor";
            this.dgvSSSmDensityFactor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSSmDensityFactor.Visible = false;
            this.dgvSSSmDensityFactor.Width = 99;
            // 
            // dgvSSSmOrigFinish
            // 
            this.dgvSSSmOrigFinish.HeaderText = "Orig Finish";
            this.dgvSSSmOrigFinish.MinimumWidth = 6;
            this.dgvSSSmOrigFinish.Name = "dgvSSSmOrigFinish";
            this.dgvSSSmOrigFinish.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSSmOrigFinish.Visible = false;
            this.dgvSSSmOrigFinish.Width = 76;
            // 
            // dgvSSSmPVCGroupID
            // 
            this.dgvSSSmPVCGroupID.HeaderText = "PVCGRoupID";
            this.dgvSSSmPVCGroupID.MinimumWidth = 6;
            this.dgvSSSmPVCGroupID.Name = "dgvSSSmPVCGroupID";
            this.dgvSSSmPVCGroupID.Visible = false;
            this.dgvSSSmPVCGroupID.Width = 96;
            // 
            // dgvSSSmPVCPriceList
            // 
            this.dgvSSSmPVCPriceList.HeaderText = "PVCPriceList";
            this.dgvSSSmPVCPriceList.MinimumWidth = 6;
            this.dgvSSSmPVCPriceList.Name = "dgvSSSmPVCPriceList";
            this.dgvSSSmPVCPriceList.Visible = false;
            this.dgvSSSmPVCPriceList.Width = 91;
            // 
            // dgvSSSmCurrPrice
            // 
            this.dgvSSSmCurrPrice.HeaderText = "CurrPrice";
            this.dgvSSSmCurrPrice.MinimumWidth = 6;
            this.dgvSSSmCurrPrice.Name = "dgvSSSmCurrPrice";
            this.dgvSSSmCurrPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSSSmCurrPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvSSSmCurrPrice.Visible = false;
            this.dgvSSSmCurrPrice.Width = 68;
            // 
            // tabPageReports
            // 
            this.tabPageReports.BackColor = System.Drawing.Color.Transparent;
            this.tabPageReports.Controls.Add(this.lblReportTagID);
            this.tabPageReports.Controls.Add(this.tbReportTransferTagID);
            this.tabPageReports.Controls.Add(this.lblReportTransferID);
            this.tabPageReports.Controls.Add(this.tbReportTransferID);
            this.tabPageReports.Controls.Add(this.btnReportTransfer);
            this.tabPageReports.Controls.Add(this.tbReportHistory);
            this.tabPageReports.Controls.Add(this.btnReportHistory);
            this.tabPageReports.Controls.Add(this.lblInventoryUpdate);
            this.tabPageReports.Controls.Add(this.chkBxInventorySkids);
            this.tabPageReports.Controls.Add(this.chkBxInventoryCoils);
            this.tabPageReports.Controls.Add(this.chkBxReportInventoryAllCustomers);
            this.tabPageReports.Controls.Add(this.btnReportInventory);
            this.tabPageReports.Controls.Add(this.tbReportWorkOrder);
            this.tabPageReports.Controls.Add(this.btnReportWorkOrder);
            this.tabPageReports.Controls.Add(this.tbReportShipping);
            this.tabPageReports.Controls.Add(this.btnRepotShipping);
            this.tabPageReports.Controls.Add(this.txtReportRecieving);
            this.tabPageReports.Controls.Add(this.btnReportReceiving);
            this.tabPageReports.Location = new System.Drawing.Point(4, 25);
            this.tabPageReports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageReports.Size = new System.Drawing.Size(1099, 617);
            this.tabPageReports.TabIndex = 4;
            this.tabPageReports.Text = "Reports";
            // 
            // lblReportTagID
            // 
            this.lblReportTagID.AutoSize = true;
            this.lblReportTagID.Location = new System.Drawing.Point(278, 316);
            this.lblReportTagID.Name = "lblReportTagID";
            this.lblReportTagID.Size = new System.Drawing.Size(32, 16);
            this.lblReportTagID.TabIndex = 17;
            this.lblReportTagID.Text = "Tag";
            // 
            // tbReportTransferTagID
            // 
            this.tbReportTransferTagID.Location = new System.Drawing.Point(276, 335);
            this.tbReportTransferTagID.Name = "tbReportTransferTagID";
            this.tbReportTransferTagID.Size = new System.Drawing.Size(125, 22);
            this.tbReportTransferTagID.TabIndex = 16;
            this.tbReportTransferTagID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReportTransferTagID_KeyDown);
            this.tbReportTransferTagID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReportTransferTagID_KeyPress);
            // 
            // lblReportTransferID
            // 
            this.lblReportTransferID.AutoSize = true;
            this.lblReportTransferID.Location = new System.Drawing.Point(147, 316);
            this.lblReportTransferID.Name = "lblReportTransferID";
            this.lblReportTransferID.Size = new System.Drawing.Size(73, 16);
            this.lblReportTransferID.TabIndex = 15;
            this.lblReportTransferID.Text = "Transfer ID";
            // 
            // tbReportTransferID
            // 
            this.tbReportTransferID.Location = new System.Drawing.Point(145, 335);
            this.tbReportTransferID.Name = "tbReportTransferID";
            this.tbReportTransferID.Size = new System.Drawing.Size(125, 22);
            this.tbReportTransferID.TabIndex = 14;
            this.tbReportTransferID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReportTransferID_KeyDown);
            this.tbReportTransferID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReportTransferID_KeyPress);
            // 
            // btnReportTransfer
            // 
            this.btnReportTransfer.Location = new System.Drawing.Point(16, 334);
            this.btnReportTransfer.Name = "btnReportTransfer";
            this.btnReportTransfer.Size = new System.Drawing.Size(101, 25);
            this.btnReportTransfer.TabIndex = 13;
            this.btnReportTransfer.Text = "Transfer";
            this.btnReportTransfer.UseVisualStyleBackColor = true;
            this.btnReportTransfer.Click += new System.EventHandler(this.btnReportTransfer_Click);
            // 
            // tbReportHistory
            // 
            this.tbReportHistory.Location = new System.Drawing.Point(145, 268);
            this.tbReportHistory.Name = "tbReportHistory";
            this.tbReportHistory.Size = new System.Drawing.Size(125, 22);
            this.tbReportHistory.TabIndex = 12;
            this.tbReportHistory.TextChanged += new System.EventHandler(this.tbReportHistory_TextChanged);
            this.tbReportHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReportHistory_KeyDown);
            // 
            // btnReportHistory
            // 
            this.btnReportHistory.Location = new System.Drawing.Point(16, 267);
            this.btnReportHistory.Name = "btnReportHistory";
            this.btnReportHistory.Size = new System.Drawing.Size(101, 25);
            this.btnReportHistory.TabIndex = 11;
            this.btnReportHistory.Text = "History";
            this.btnReportHistory.UseVisualStyleBackColor = true;
            this.btnReportHistory.Click += new System.EventHandler(this.btnReportHistory_Click);
            // 
            // lblInventoryUpdate
            // 
            this.lblInventoryUpdate.AutoSize = true;
            this.lblInventoryUpdate.Location = new System.Drawing.Point(438, 204);
            this.lblInventoryUpdate.Name = "lblInventoryUpdate";
            this.lblInventoryUpdate.Size = new System.Drawing.Size(0, 16);
            this.lblInventoryUpdate.TabIndex = 10;
            // 
            // chkBxInventorySkids
            // 
            this.chkBxInventorySkids.AutoSize = true;
            this.chkBxInventorySkids.Checked = true;
            this.chkBxInventorySkids.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxInventorySkids.Location = new System.Drawing.Point(327, 212);
            this.chkBxInventorySkids.Name = "chkBxInventorySkids";
            this.chkBxInventorySkids.Size = new System.Drawing.Size(63, 20);
            this.chkBxInventorySkids.TabIndex = 9;
            this.chkBxInventorySkids.Text = "Skids";
            this.chkBxInventorySkids.UseVisualStyleBackColor = true;
            // 
            // chkBxInventoryCoils
            // 
            this.chkBxInventoryCoils.AutoSize = true;
            this.chkBxInventoryCoils.Checked = true;
            this.chkBxInventoryCoils.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxInventoryCoils.Location = new System.Drawing.Point(262, 212);
            this.chkBxInventoryCoils.Name = "chkBxInventoryCoils";
            this.chkBxInventoryCoils.Size = new System.Drawing.Size(59, 20);
            this.chkBxInventoryCoils.TabIndex = 8;
            this.chkBxInventoryCoils.Text = "Coils";
            this.chkBxInventoryCoils.UseVisualStyleBackColor = true;
            // 
            // chkBxReportInventoryAllCustomers
            // 
            this.chkBxReportInventoryAllCustomers.AutoSize = true;
            this.chkBxReportInventoryAllCustomers.Location = new System.Drawing.Point(145, 212);
            this.chkBxReportInventoryAllCustomers.Name = "chkBxReportInventoryAllCustomers";
            this.chkBxReportInventoryAllCustomers.Size = new System.Drawing.Size(111, 20);
            this.chkBxReportInventoryAllCustomers.TabIndex = 7;
            this.chkBxReportInventoryAllCustomers.Text = "All Customers";
            this.chkBxReportInventoryAllCustomers.UseVisualStyleBackColor = true;
            this.chkBxReportInventoryAllCustomers.CheckedChanged += new System.EventHandler(this.chkBxReportInventoryAllCustomers_CheckedChanged);
            // 
            // btnReportInventory
            // 
            this.btnReportInventory.Location = new System.Drawing.Point(16, 209);
            this.btnReportInventory.Name = "btnReportInventory";
            this.btnReportInventory.Size = new System.Drawing.Size(101, 25);
            this.btnReportInventory.TabIndex = 6;
            this.btnReportInventory.Text = "Inventory";
            this.btnReportInventory.UseVisualStyleBackColor = true;
            this.btnReportInventory.Click += new System.EventHandler(this.btnReportInventory_Click);
            // 
            // tbReportWorkOrder
            // 
            this.tbReportWorkOrder.Location = new System.Drawing.Point(145, 152);
            this.tbReportWorkOrder.Name = "tbReportWorkOrder";
            this.tbReportWorkOrder.Size = new System.Drawing.Size(125, 22);
            this.tbReportWorkOrder.TabIndex = 5;
            this.tbReportWorkOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReportWorkOrder_KeyDown);
            this.tbReportWorkOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReportWorkOrder_KeyPress);
            // 
            // btnReportWorkOrder
            // 
            this.btnReportWorkOrder.Location = new System.Drawing.Point(16, 151);
            this.btnReportWorkOrder.Name = "btnReportWorkOrder";
            this.btnReportWorkOrder.Size = new System.Drawing.Size(101, 25);
            this.btnReportWorkOrder.TabIndex = 4;
            this.btnReportWorkOrder.Text = "Work Order";
            this.btnReportWorkOrder.UseVisualStyleBackColor = true;
            this.btnReportWorkOrder.Click += new System.EventHandler(this.btnReportWorkOrder_Click);
            // 
            // tbReportShipping
            // 
            this.tbReportShipping.Location = new System.Drawing.Point(145, 94);
            this.tbReportShipping.Name = "tbReportShipping";
            this.tbReportShipping.Size = new System.Drawing.Size(125, 22);
            this.tbReportShipping.TabIndex = 3;
            this.tbReportShipping.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReportShipping_KeyDown);
            this.tbReportShipping.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReportShipping_KeyPress);
            // 
            // btnRepotShipping
            // 
            this.btnRepotShipping.Location = new System.Drawing.Point(16, 93);
            this.btnRepotShipping.Name = "btnRepotShipping";
            this.btnRepotShipping.Size = new System.Drawing.Size(101, 25);
            this.btnRepotShipping.TabIndex = 2;
            this.btnRepotShipping.Text = "Shipping";
            this.btnRepotShipping.UseVisualStyleBackColor = true;
            this.btnRepotShipping.Click += new System.EventHandler(this.btnRepotShipping_Click);
            // 
            // txtReportRecieving
            // 
            this.txtReportRecieving.Location = new System.Drawing.Point(145, 36);
            this.txtReportRecieving.Name = "txtReportRecieving";
            this.txtReportRecieving.Size = new System.Drawing.Size(125, 22);
            this.txtReportRecieving.TabIndex = 1;
            this.txtReportRecieving.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReportRecieving_KeyDown);
            this.txtReportRecieving.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReportRecieving_KeyPress);
            // 
            // btnReportReceiving
            // 
            this.btnReportReceiving.Location = new System.Drawing.Point(16, 35);
            this.btnReportReceiving.Name = "btnReportReceiving";
            this.btnReportReceiving.Size = new System.Drawing.Size(101, 25);
            this.btnReportReceiving.TabIndex = 0;
            this.btnReportReceiving.Text = "Recieving";
            this.btnReportReceiving.UseVisualStyleBackColor = true;
            this.btnReportReceiving.Click += new System.EventHandler(this.btnReportReceiving_Click);
            // 
            // tabPageReceiving
            // 
            this.tabPageReceiving.Controls.Add(this.cbRecPrintLabel);
            this.tabPageReceiving.Controls.Add(this.labelContainer);
            this.tabPageReceiving.Controls.Add(this.textBoxContainer);
            this.tabPageReceiving.Controls.Add(this.dateTimePicker1);
            this.tabPageReceiving.Controls.Add(this.checkBoxPreReceiving);
            this.tabPageReceiving.Controls.Add(this.buttonRecSubmit);
            this.tabPageReceiving.Controls.Add(this.buttonDamageDone);
            this.tabPageReceiving.Controls.Add(this.buttonReceiveDeleteRow);
            this.tabPageReceiving.Controls.Add(this.buttonRecieveAddRow);
            this.tabPageReceiving.Controls.Add(this.checkedListBoxDamage);
            this.tabPageReceiving.Controls.Add(this.dataGridViewReceiving);
            this.tabPageReceiving.Location = new System.Drawing.Point(4, 25);
            this.tabPageReceiving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageReceiving.Name = "tabPageReceiving";
            this.tabPageReceiving.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageReceiving.Size = new System.Drawing.Size(1099, 617);
            this.tabPageReceiving.TabIndex = 3;
            this.tabPageReceiving.Text = "Receiving";
            this.tabPageReceiving.UseVisualStyleBackColor = true;
            // 
            // cbRecPrintLabel
            // 
            this.cbRecPrintLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbRecPrintLabel.AutoSize = true;
            this.cbRecPrintLabel.Checked = true;
            this.cbRecPrintLabel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRecPrintLabel.Location = new System.Drawing.Point(624, 591);
            this.cbRecPrintLabel.Name = "cbRecPrintLabel";
            this.cbRecPrintLabel.Size = new System.Drawing.Size(92, 20);
            this.cbRecPrintLabel.TabIndex = 10;
            this.cbRecPrintLabel.Text = "Print Label";
            this.cbRecPrintLabel.UseVisualStyleBackColor = true;
            // 
            // labelContainer
            // 
            this.labelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelContainer.AutoSize = true;
            this.labelContainer.Location = new System.Drawing.Point(294, 590);
            this.labelContainer.Name = "labelContainer";
            this.labelContainer.Size = new System.Drawing.Size(64, 16);
            this.labelContainer.TabIndex = 9;
            this.labelContainer.Text = "Container";
            // 
            // textBoxContainer
            // 
            this.textBoxContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxContainer.Location = new System.Drawing.Point(369, 590);
            this.textBoxContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxContainer.Name = "textBoxContainer";
            this.textBoxContainer.Size = new System.Drawing.Size(225, 22);
            this.textBoxContainer.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker1.Location = new System.Drawing.Point(8, 588);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(264, 22);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // checkBoxPreReceiving
            // 
            this.checkBoxPreReceiving.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxPreReceiving.AutoSize = true;
            this.checkBoxPreReceiving.Location = new System.Drawing.Point(315, 667);
            this.checkBoxPreReceiving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxPreReceiving.Name = "checkBoxPreReceiving";
            this.checkBoxPreReceiving.Size = new System.Drawing.Size(115, 20);
            this.checkBoxPreReceiving.TabIndex = 6;
            this.checkBoxPreReceiving.Text = "Pre-Receiving";
            this.checkBoxPreReceiving.UseVisualStyleBackColor = true;
            // 
            // buttonRecSubmit
            // 
            this.buttonRecSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRecSubmit.Location = new System.Drawing.Point(698, 539);
            this.buttonRecSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRecSubmit.Name = "buttonRecSubmit";
            this.buttonRecSubmit.Size = new System.Drawing.Size(147, 27);
            this.buttonRecSubmit.TabIndex = 5;
            this.buttonRecSubmit.Text = "Submit";
            this.buttonRecSubmit.UseVisualStyleBackColor = true;
            this.buttonRecSubmit.Click += new System.EventHandler(this.ButtonRecSubmit_Click);
            // 
            // buttonDamageDone
            // 
            this.buttonDamageDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDamageDone.Location = new System.Drawing.Point(-50, 276);
            this.buttonDamageDone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDamageDone.Name = "buttonDamageDone";
            this.buttonDamageDone.Size = new System.Drawing.Size(127, 30);
            this.buttonDamageDone.TabIndex = 4;
            this.buttonDamageDone.Text = "Done";
            this.buttonDamageDone.UseVisualStyleBackColor = true;
            this.buttonDamageDone.Visible = false;
            this.buttonDamageDone.Click += new System.EventHandler(this.ButtonDamageDone_Click);
            // 
            // buttonReceiveDeleteRow
            // 
            this.buttonReceiveDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReceiveDeleteRow.Location = new System.Drawing.Point(143, 544);
            this.buttonReceiveDeleteRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReceiveDeleteRow.Name = "buttonReceiveDeleteRow";
            this.buttonReceiveDeleteRow.Size = new System.Drawing.Size(129, 28);
            this.buttonReceiveDeleteRow.TabIndex = 3;
            this.buttonReceiveDeleteRow.Text = "Delete Row";
            this.buttonReceiveDeleteRow.UseVisualStyleBackColor = true;
            this.buttonReceiveDeleteRow.Click += new System.EventHandler(this.ButtonReceiveDeleteRow_Click);
            // 
            // buttonRecieveAddRow
            // 
            this.buttonRecieveAddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRecieveAddRow.Location = new System.Drawing.Point(8, 544);
            this.buttonRecieveAddRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRecieveAddRow.Name = "buttonRecieveAddRow";
            this.buttonRecieveAddRow.Size = new System.Drawing.Size(129, 28);
            this.buttonRecieveAddRow.TabIndex = 2;
            this.buttonRecieveAddRow.Text = "Add Row";
            this.buttonRecieveAddRow.UseVisualStyleBackColor = true;
            this.buttonRecieveAddRow.Click += new System.EventHandler(this.ButtonRecieveAddRow_Click);
            // 
            // checkedListBoxDamage
            // 
            this.checkedListBoxDamage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxDamage.CheckOnClick = true;
            this.checkedListBoxDamage.FormattingEnabled = true;
            this.checkedListBoxDamage.Location = new System.Drawing.Point(131, 45);
            this.checkedListBoxDamage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBoxDamage.Name = "checkedListBoxDamage";
            this.checkedListBoxDamage.Size = new System.Drawing.Size(311, 361);
            this.checkedListBoxDamage.TabIndex = 1;
            this.checkedListBoxDamage.Visible = false;
            // 
            // dataGridViewReceiving
            // 
            this.dataGridViewReceiving.AllowUserToAddRows = false;
            this.dataGridViewReceiving.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReceiving.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReceiving.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colType,
            this.colUnloader,
            this.colPurchaseOrder,
            this.colMillNumber,
            this.colHeat,
            this.colVendor,
            this.colPieceCount,
            this.colThickness,
            this.colAlloy,
            this.colFinish,
            this.colWidth,
            this.colLength,
            this.colWeight,
            this.colLocation,
            this.colCarbon,
            this.colOriginCountry,
            this.colDamage,
            this.colWorkerID,
            this.colAlloyID,
            this.colFinishID,
            this.colDensityFactor,
            this.colDamageID,
            this.colSteelType,
            this.colRecSteelDesc});
            this.dataGridViewReceiving.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewReceiving.Location = new System.Drawing.Point(13, 6);
            this.dataGridViewReceiving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewReceiving.MultiSelect = false;
            this.dataGridViewReceiving.Name = "dataGridViewReceiving";
            this.dataGridViewReceiving.RowHeadersWidth = 51;
            this.dataGridViewReceiving.RowTemplate.Height = 24;
            this.dataGridViewReceiving.Size = new System.Drawing.Size(1087, 529);
            this.dataGridViewReceiving.TabIndex = 0;
            this.dataGridViewReceiving.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewReceiving_CellClick);
            this.dataGridViewReceiving.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewReceiving_CellEndEdit);
            this.dataGridViewReceiving.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateInfo);
            this.dataGridViewReceiving.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewReceiving_EditingControlShowing);
            // 
            // colType
            // 
            this.colType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colType.HeaderText = "Type";
            this.colType.MinimumWidth = 6;
            this.colType.Name = "colType";
            this.colType.Width = 125;
            // 
            // colUnloader
            // 
            this.colUnloader.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colUnloader.HeaderText = "Unloader";
            this.colUnloader.MinimumWidth = 6;
            this.colUnloader.Name = "colUnloader";
            this.colUnloader.Width = 125;
            // 
            // colPurchaseOrder
            // 
            this.colPurchaseOrder.HeaderText = "PO Num";
            this.colPurchaseOrder.MinimumWidth = 6;
            this.colPurchaseOrder.Name = "colPurchaseOrder";
            this.colPurchaseOrder.Width = 125;
            // 
            // colMillNumber
            // 
            this.colMillNumber.HeaderText = "Mill#";
            this.colMillNumber.MinimumWidth = 6;
            this.colMillNumber.Name = "colMillNumber";
            this.colMillNumber.Width = 125;
            // 
            // colHeat
            // 
            this.colHeat.HeaderText = "Heat#";
            this.colHeat.MinimumWidth = 6;
            this.colHeat.Name = "colHeat";
            this.colHeat.Width = 125;
            // 
            // colVendor
            // 
            this.colVendor.HeaderText = "Vendor";
            this.colVendor.MinimumWidth = 6;
            this.colVendor.Name = "colVendor";
            this.colVendor.Width = 125;
            // 
            // colPieceCount
            // 
            this.colPieceCount.HeaderText = "Piece Count";
            this.colPieceCount.MinimumWidth = 6;
            this.colPieceCount.Name = "colPieceCount";
            this.colPieceCount.Width = 125;
            // 
            // colThickness
            // 
            this.colThickness.HeaderText = "Thickness";
            this.colThickness.MinimumWidth = 6;
            this.colThickness.Name = "colThickness";
            this.colThickness.Width = 125;
            // 
            // colAlloy
            // 
            this.colAlloy.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colAlloy.HeaderText = "Alloy";
            this.colAlloy.MinimumWidth = 6;
            this.colAlloy.Name = "colAlloy";
            this.colAlloy.Width = 125;
            // 
            // colFinish
            // 
            this.colFinish.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colFinish.HeaderText = "Finish";
            this.colFinish.MinimumWidth = 6;
            this.colFinish.Name = "colFinish";
            this.colFinish.Width = 125;
            // 
            // colWidth
            // 
            this.colWidth.HeaderText = "Width";
            this.colWidth.MinimumWidth = 6;
            this.colWidth.Name = "colWidth";
            this.colWidth.Width = 125;
            // 
            // colLength
            // 
            this.colLength.HeaderText = "Length";
            this.colLength.MinimumWidth = 6;
            this.colLength.Name = "colLength";
            this.colLength.Width = 125;
            // 
            // colWeight
            // 
            this.colWeight.HeaderText = "Weight";
            this.colWeight.MinimumWidth = 6;
            this.colWeight.Name = "colWeight";
            this.colWeight.Width = 125;
            // 
            // colLocation
            // 
            this.colLocation.HeaderText = "Location";
            this.colLocation.MinimumWidth = 6;
            this.colLocation.Name = "colLocation";
            this.colLocation.Width = 125;
            // 
            // colCarbon
            // 
            this.colCarbon.HeaderText = "Carbon";
            this.colCarbon.MinimumWidth = 6;
            this.colCarbon.Name = "colCarbon";
            this.colCarbon.Width = 125;
            // 
            // colOriginCountry
            // 
            this.colOriginCountry.HeaderText = "CountryOfOrigin";
            this.colOriginCountry.MinimumWidth = 6;
            this.colOriginCountry.Name = "colOriginCountry";
            this.colOriginCountry.Width = 125;
            // 
            // colDamage
            // 
            this.colDamage.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colDamage.HeaderText = "Damage";
            this.colDamage.MinimumWidth = 6;
            this.colDamage.Name = "colDamage";
            this.colDamage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDamage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDamage.Width = 125;
            // 
            // colWorkerID
            // 
            this.colWorkerID.HeaderText = "WorkerID";
            this.colWorkerID.MinimumWidth = 6;
            this.colWorkerID.Name = "colWorkerID";
            this.colWorkerID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colWorkerID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colWorkerID.Visible = false;
            this.colWorkerID.Width = 125;
            // 
            // colAlloyID
            // 
            this.colAlloyID.HeaderText = "AlloyID";
            this.colAlloyID.MinimumWidth = 6;
            this.colAlloyID.Name = "colAlloyID";
            this.colAlloyID.Visible = false;
            this.colAlloyID.Width = 125;
            // 
            // colFinishID
            // 
            this.colFinishID.HeaderText = "FinishID";
            this.colFinishID.MinimumWidth = 6;
            this.colFinishID.Name = "colFinishID";
            this.colFinishID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFinishID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colFinishID.Visible = false;
            this.colFinishID.Width = 125;
            // 
            // colDensityFactor
            // 
            this.colDensityFactor.HeaderText = "Density";
            this.colDensityFactor.MinimumWidth = 6;
            this.colDensityFactor.Name = "colDensityFactor";
            this.colDensityFactor.Visible = false;
            this.colDensityFactor.Width = 125;
            // 
            // colDamageID
            // 
            this.colDamageID.HeaderText = "DamageID";
            this.colDamageID.MinimumWidth = 6;
            this.colDamageID.Name = "colDamageID";
            this.colDamageID.Visible = false;
            this.colDamageID.Width = 125;
            // 
            // colSteelType
            // 
            this.colSteelType.HeaderText = "SteelType";
            this.colSteelType.MinimumWidth = 6;
            this.colSteelType.Name = "colSteelType";
            this.colSteelType.Visible = false;
            this.colSteelType.Width = 125;
            // 
            // colRecSteelDesc
            // 
            this.colRecSteelDesc.HeaderText = "SteelDesc";
            this.colRecSteelDesc.MinimumWidth = 6;
            this.colRecSteelDesc.Name = "colRecSteelDesc";
            this.colRecSteelDesc.Visible = false;
            this.colRecSteelDesc.Width = 125;
            // 
            // tabPageSkid
            // 
            this.tabPageSkid.Controls.Add(this.listViewSkidData);
            this.tabPageSkid.Location = new System.Drawing.Point(4, 25);
            this.tabPageSkid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageSkid.Name = "tabPageSkid";
            this.tabPageSkid.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageSkid.Size = new System.Drawing.Size(1099, 617);
            this.tabPageSkid.TabIndex = 1;
            this.tabPageSkid.Text = "Skid";
            this.tabPageSkid.UseVisualStyleBackColor = true;
            // 
            // listViewSkidData
            // 
            this.listViewSkidData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSkidData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvSkidID,
            this.lvSkidLocation,
            this.lvPieceCount,
            this.lvSkidAlloy,
            this.lvSkidThickness,
            this.lvSkidWidth,
            this.lvSkidLength,
            this.lvSkidWeight,
            this.lvSkidMillNum,
            this.lvSkidHeat,
            this.lvSkidPVC,
            this.lvSkidPI,
            this.lvSkidComments,
            this.lvSkidNotPrime,
            this.lvSkidBranch,
            this.lvOrders});
            this.listViewSkidData.FullRowSelect = true;
            this.listViewSkidData.HideSelection = false;
            this.listViewSkidData.Location = new System.Drawing.Point(5, 4);
            this.listViewSkidData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewSkidData.MultiSelect = false;
            this.listViewSkidData.Name = "listViewSkidData";
            this.listViewSkidData.Size = new System.Drawing.Size(1094, 568);
            this.listViewSkidData.TabIndex = 0;
            this.listViewSkidData.UseCompatibleStateImageBehavior = false;
            this.listViewSkidData.View = System.Windows.Forms.View.Details;
            this.listViewSkidData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewSkidData_MouseDoubleClick);
            this.listViewSkidData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewSkidData_MouseDown);
            // 
            // lvSkidID
            // 
            this.lvSkidID.Text = "SkidID";
            // 
            // lvSkidLocation
            // 
            this.lvSkidLocation.Text = "Location";
            this.lvSkidLocation.Width = 96;
            // 
            // lvPieceCount
            // 
            this.lvPieceCount.Text = "Pcs";
            // 
            // lvSkidAlloy
            // 
            this.lvSkidAlloy.Text = "Alloy";
            // 
            // lvSkidThickness
            // 
            this.lvSkidThickness.Text = "Thick";
            // 
            // lvSkidWidth
            // 
            this.lvSkidWidth.Text = "Width";
            // 
            // lvSkidLength
            // 
            this.lvSkidLength.Text = "Length";
            // 
            // lvSkidWeight
            // 
            this.lvSkidWeight.Text = "Weight";
            // 
            // lvSkidMillNum
            // 
            this.lvSkidMillNum.Text = "Mill#";
            // 
            // lvSkidHeat
            // 
            this.lvSkidHeat.Text = "Heat";
            // 
            // lvSkidPVC
            // 
            this.lvSkidPVC.Text = "PVC SQFT";
            this.lvSkidPVC.Width = 85;
            // 
            // lvSkidPI
            // 
            this.lvSkidPI.Text = "PI SQFT";
            // 
            // lvSkidComments
            // 
            this.lvSkidComments.Text = "Comments";
            this.lvSkidComments.Width = 200;
            // 
            // lvSkidNotPrime
            // 
            this.lvSkidNotPrime.Text = "Not Prime";
            this.lvSkidNotPrime.Width = 113;
            // 
            // lvSkidBranch
            // 
            this.lvSkidBranch.Text = "Branch";
            // 
            // lvOrders
            // 
            this.lvOrders.Text = "Orders";
            this.lvOrders.Width = 0;
            // 
            // tabPageCoil
            // 
            this.tabPageCoil.Controls.Add(this.ListViewCoilData);
            this.tabPageCoil.Location = new System.Drawing.Point(4, 25);
            this.tabPageCoil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageCoil.Name = "tabPageCoil";
            this.tabPageCoil.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageCoil.Size = new System.Drawing.Size(1099, 617);
            this.tabPageCoil.TabIndex = 0;
            this.tabPageCoil.Text = "Coil";
            this.tabPageCoil.UseVisualStyleBackColor = true;
            // 
            // ListViewCoilData
            // 
            this.ListViewCoilData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewCoilData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hdrTagID,
            this.hdrLocation,
            this.hdrAlloy,
            this.hdrThickness,
            this.hdrWidth,
            this.hdrLength,
            this.hdrWeight,
            this.hdrMillNum,
            this.hdrHeat,
            this.hdrCarbon,
            this.hdrVendor,
            this.hdrPONum,
            this.hdrContainer,
            this.hdrRecDate,
            this.hdrRecID,
            this.hdrCoilCount,
            this.hdrCountryOfOrigin,
            this.hdrOrderInfo});
            this.ListViewCoilData.FullRowSelect = true;
            this.ListViewCoilData.HideSelection = false;
            this.ListViewCoilData.Location = new System.Drawing.Point(0, 0);
            this.ListViewCoilData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListViewCoilData.MultiSelect = false;
            this.ListViewCoilData.Name = "ListViewCoilData";
            this.ListViewCoilData.Size = new System.Drawing.Size(1092, 615);
            this.ListViewCoilData.TabIndex = 0;
            this.ListViewCoilData.UseCompatibleStateImageBehavior = false;
            this.ListViewCoilData.View = System.Windows.Forms.View.Details;
            this.ListViewCoilData.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewCoilData_ColumnClick);
            this.ListViewCoilData.SelectedIndexChanged += new System.EventHandler(this.ListViewCoilData_SelectedIndexChanged);
            this.ListViewCoilData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListViewCoilData_MouseDoubleClick);
            this.ListViewCoilData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListViewCoilData_MouseDown);
            // 
            // hdrTagID
            // 
            this.hdrTagID.Text = "Tag ID";
            this.hdrTagID.Width = 100;
            // 
            // hdrLocation
            // 
            this.hdrLocation.Text = "Location";
            // 
            // hdrAlloy
            // 
            this.hdrAlloy.Text = "Alloy";
            // 
            // hdrThickness
            // 
            this.hdrThickness.Text = "Thickness";
            // 
            // hdrWidth
            // 
            this.hdrWidth.Text = "Width";
            // 
            // hdrLength
            // 
            this.hdrLength.Text = "Length";
            // 
            // hdrWeight
            // 
            this.hdrWeight.Text = "Weight";
            // 
            // hdrMillNum
            // 
            this.hdrMillNum.Text = "Mill#";
            // 
            // hdrHeat
            // 
            this.hdrHeat.Text = "Heat";
            // 
            // hdrCarbon
            // 
            this.hdrCarbon.Text = "Carbon";
            // 
            // hdrVendor
            // 
            this.hdrVendor.Text = "Vendor";
            // 
            // hdrPONum
            // 
            this.hdrPONum.Text = "PO";
            // 
            // hdrContainer
            // 
            this.hdrContainer.Text = "Container";
            // 
            // hdrRecDate
            // 
            this.hdrRecDate.Text = "Rec Date";
            // 
            // hdrRecID
            // 
            this.hdrRecID.Text = "Rec#";
            // 
            // hdrCoilCount
            // 
            this.hdrCoilCount.Text = "Coil Cnt";
            // 
            // hdrCountryOfOrigin
            // 
            this.hdrCountryOfOrigin.Text = "Cnt Of Orig";
            // 
            // hdrOrderInfo
            // 
            this.hdrOrderInfo.Text = "Orders";
            // 
            // tabControlICMS
            // 
            this.tabControlICMS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlICMS.Controls.Add(this.tabPageCoil);
            this.tabControlICMS.Controls.Add(this.tabPageSkid);
            this.tabControlICMS.Controls.Add(this.tabPageOrders);
            this.tabControlICMS.Controls.Add(this.tabPageReceiving);
            this.tabControlICMS.Controls.Add(this.tabPageShipping);
            this.tabControlICMS.Controls.Add(this.tabPageCustomerInfo);
            this.tabControlICMS.Controls.Add(this.tabPageReports);
            this.tabControlICMS.Controls.Add(this.tabPagePVC);
            this.tabControlICMS.Controls.Add(this.tabPageRunSheet);
            this.tabControlICMS.Location = new System.Drawing.Point(267, 67);
            this.tabControlICMS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlICMS.Name = "tabControlICMS";
            this.tabControlICMS.SelectedIndex = 0;
            this.tabControlICMS.Size = new System.Drawing.Size(1107, 646);
            this.tabControlICMS.TabIndex = 3;
            this.tabControlICMS.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControlICMS_DrawItem);
            this.tabControlICMS.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlICMS_Selected);
            // 
            // tabPageShipping
            // 
            this.tabPageShipping.Controls.Add(this.buttonReleaseBOL);
            this.tabPageShipping.Controls.Add(this.checkBoxShipModifyRel);
            this.tabPageShipping.Controls.Add(this.buttonBuildTruck);
            this.tabPageShipping.Controls.Add(this.splitContainerShipping);
            this.tabPageShipping.Controls.Add(this.panelModifyRelease);
            this.tabPageShipping.Controls.Add(this.comboBoxBranchChooser);
            this.tabPageShipping.Controls.Add(this.buttonShipStart);
            this.tabPageShipping.Location = new System.Drawing.Point(4, 25);
            this.tabPageShipping.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageShipping.Name = "tabPageShipping";
            this.tabPageShipping.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageShipping.Size = new System.Drawing.Size(1099, 617);
            this.tabPageShipping.TabIndex = 8;
            this.tabPageShipping.Text = "Shipping";
            this.tabPageShipping.UseVisualStyleBackColor = true;
            // 
            // buttonReleaseBOL
            // 
            this.buttonReleaseBOL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReleaseBOL.Location = new System.Drawing.Point(943, 555);
            this.buttonReleaseBOL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonReleaseBOL.Name = "buttonReleaseBOL";
            this.buttonReleaseBOL.Size = new System.Drawing.Size(152, 33);
            this.buttonReleaseBOL.TabIndex = 4;
            this.buttonReleaseBOL.Text = "Release BOL";
            this.buttonReleaseBOL.UseVisualStyleBackColor = true;
            this.buttonReleaseBOL.Click += new System.EventHandler(this.ButtonReleaseBOL_Click);
            // 
            // checkBoxShipModifyRel
            // 
            this.checkBoxShipModifyRel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxShipModifyRel.AutoSize = true;
            this.checkBoxShipModifyRel.Location = new System.Drawing.Point(191, 562);
            this.checkBoxShipModifyRel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxShipModifyRel.Name = "checkBoxShipModifyRel";
            this.checkBoxShipModifyRel.Size = new System.Drawing.Size(131, 20);
            this.checkBoxShipModifyRel.TabIndex = 3;
            this.checkBoxShipModifyRel.Text = "Modify Releases";
            this.checkBoxShipModifyRel.UseVisualStyleBackColor = true;
            this.checkBoxShipModifyRel.CheckedChanged += new System.EventHandler(this.CheckBoxShipModifyRel_CheckedChanged);
            // 
            // buttonBuildTruck
            // 
            this.buttonBuildTruck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBuildTruck.Location = new System.Drawing.Point(754, 555);
            this.buttonBuildTruck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBuildTruck.Name = "buttonBuildTruck";
            this.buttonBuildTruck.Size = new System.Drawing.Size(152, 33);
            this.buttonBuildTruck.TabIndex = 5;
            this.buttonBuildTruck.Text = "Build out a Truck";
            this.buttonBuildTruck.UseVisualStyleBackColor = true;
            this.buttonBuildTruck.Click += new System.EventHandler(this.ButtonBuildTruck_Click);
            // 
            // splitContainerShipping
            // 
            this.splitContainerShipping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerShipping.Location = new System.Drawing.Point(5, 6);
            this.splitContainerShipping.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerShipping.Name = "splitContainerShipping";
            this.splitContainerShipping.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerShipping.Panel1
            // 
            this.splitContainerShipping.Panel1.Controls.Add(this.listViewShipCoil);
            // 
            // splitContainerShipping.Panel2
            // 
            this.splitContainerShipping.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainerShipping.Panel2.Controls.Add(this.listViewShipSkid);
            this.splitContainerShipping.Size = new System.Drawing.Size(1227, 515);
            this.splitContainerShipping.SplitterDistance = 228;
            this.splitContainerShipping.TabIndex = 0;
            // 
            // listViewShipCoil
            // 
            this.listViewShipCoil.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewShipCoil.CheckBoxes = true;
            this.listViewShipCoil.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader56,
            this.columnHeader57,
            this.columnHeader58,
            this.columnHeader59,
            this.columnHeader60,
            this.columnHeader61,
            this.columnHeader62,
            this.columnHeader63,
            this.columnHeader64,
            this.columnHeader65,
            this.columnHeader66,
            this.columnHeader67,
            this.columnHeader68,
            this.columnHeader69,
            this.columnHeader70,
            this.columnHeader71,
            this.columnHeader72,
            this.columnHeader73});
            this.listViewShipCoil.HideSelection = false;
            this.listViewShipCoil.Location = new System.Drawing.Point(3, 2);
            this.listViewShipCoil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewShipCoil.MultiSelect = false;
            this.listViewShipCoil.Name = "listViewShipCoil";
            this.listViewShipCoil.Size = new System.Drawing.Size(1085, 224);
            this.listViewShipCoil.TabIndex = 1;
            this.listViewShipCoil.UseCompatibleStateImageBehavior = false;
            this.listViewShipCoil.View = System.Windows.Forms.View.Details;
            this.listViewShipCoil.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewShipCoil_ItemChecked);
            this.listViewShipCoil.SelectedIndexChanged += new System.EventHandler(this.ListViewShipCoil_SelectedIndexChanged);
            // 
            // columnHeader56
            // 
            this.columnHeader56.Text = "Tag ID";
            this.columnHeader56.Width = 100;
            // 
            // columnHeader57
            // 
            this.columnHeader57.Text = "Location";
            // 
            // columnHeader58
            // 
            this.columnHeader58.Text = "Alloy";
            // 
            // columnHeader59
            // 
            this.columnHeader59.Text = "Thickness";
            // 
            // columnHeader60
            // 
            this.columnHeader60.Text = "Width";
            // 
            // columnHeader61
            // 
            this.columnHeader61.Text = "Length";
            // 
            // columnHeader62
            // 
            this.columnHeader62.Text = "Weight";
            // 
            // columnHeader63
            // 
            this.columnHeader63.Text = "Mill#";
            // 
            // columnHeader64
            // 
            this.columnHeader64.Text = "Heat";
            // 
            // columnHeader65
            // 
            this.columnHeader65.Text = "Carbon";
            // 
            // columnHeader66
            // 
            this.columnHeader66.Text = "Vendor";
            // 
            // columnHeader67
            // 
            this.columnHeader67.Text = "PO";
            // 
            // columnHeader68
            // 
            this.columnHeader68.Text = "Container";
            // 
            // columnHeader69
            // 
            this.columnHeader69.Text = "Rec Date";
            // 
            // columnHeader70
            // 
            this.columnHeader70.Text = "Rec#";
            // 
            // columnHeader71
            // 
            this.columnHeader71.Text = "Coil Cnt";
            // 
            // columnHeader72
            // 
            this.columnHeader72.Text = "Cnt Of Orig";
            // 
            // columnHeader73
            // 
            this.columnHeader73.Text = "Orders";
            // 
            // listViewShipSkid
            // 
            this.listViewShipSkid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewShipSkid.CheckBoxes = true;
            this.listViewShipSkid.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader74,
            this.columnHeader75,
            this.columnHeader76,
            this.columnHeader77,
            this.columnHeader78,
            this.columnHeader79,
            this.columnHeader80,
            this.columnHeader81,
            this.colshipMillNum,
            this.colShipHeat,
            this.columnHeader82,
            this.columnHeader83,
            this.columnHeader84,
            this.columnHeader85,
            this.columnHeader86});
            this.listViewShipSkid.FullRowSelect = true;
            this.listViewShipSkid.HideSelection = false;
            this.listViewShipSkid.Location = new System.Drawing.Point(1, 3);
            this.listViewShipSkid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewShipSkid.MultiSelect = false;
            this.listViewShipSkid.Name = "listViewShipSkid";
            this.listViewShipSkid.Size = new System.Drawing.Size(1090, 276);
            this.listViewShipSkid.TabIndex = 1;
            this.listViewShipSkid.UseCompatibleStateImageBehavior = false;
            this.listViewShipSkid.View = System.Windows.Forms.View.Details;
            this.listViewShipSkid.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewShipSkid_ItemChecked);
            // 
            // columnHeader74
            // 
            this.columnHeader74.Text = "SkidID";
            // 
            // columnHeader75
            // 
            this.columnHeader75.Text = "Location";
            this.columnHeader75.Width = 96;
            // 
            // columnHeader76
            // 
            this.columnHeader76.Text = "Pcs";
            // 
            // columnHeader77
            // 
            this.columnHeader77.Text = "Alloy";
            // 
            // columnHeader78
            // 
            this.columnHeader78.Text = "Thick";
            // 
            // columnHeader79
            // 
            this.columnHeader79.Text = "Width";
            // 
            // columnHeader80
            // 
            this.columnHeader80.Text = "Length";
            // 
            // columnHeader81
            // 
            this.columnHeader81.Text = "Weight";
            // 
            // colshipMillNum
            // 
            this.colshipMillNum.Text = "Mill#";
            // 
            // colShipHeat
            // 
            this.colShipHeat.Text = "Heat";
            // 
            // columnHeader82
            // 
            this.columnHeader82.Text = "PVC SQFT";
            this.columnHeader82.Width = 85;
            // 
            // columnHeader83
            // 
            this.columnHeader83.Text = "PI SQFT";
            // 
            // columnHeader84
            // 
            this.columnHeader84.Text = "Comments";
            this.columnHeader84.Width = 198;
            // 
            // columnHeader85
            // 
            this.columnHeader85.Text = "Not Prime";
            this.columnHeader85.Width = 113;
            // 
            // columnHeader86
            // 
            this.columnHeader86.Text = "Branch";
            // 
            // panelModifyRelease
            // 
            this.panelModifyRelease.Location = new System.Drawing.Point(227, 253);
            this.panelModifyRelease.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelModifyRelease.Name = "panelModifyRelease";
            this.panelModifyRelease.Size = new System.Drawing.Size(226, 105);
            this.panelModifyRelease.TabIndex = 2;
            this.panelModifyRelease.Visible = false;
            // 
            // comboBoxBranchChooser
            // 
            this.comboBoxBranchChooser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxBranchChooser.FormattingEnabled = true;
            this.comboBoxBranchChooser.Location = new System.Drawing.Point(48, 560);
            this.comboBoxBranchChooser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxBranchChooser.Name = "comboBoxBranchChooser";
            this.comboBoxBranchChooser.Size = new System.Drawing.Size(137, 24);
            this.comboBoxBranchChooser.TabIndex = 6;
            this.comboBoxBranchChooser.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBranchChooser_SelectedIndexChanged);
            // 
            // buttonShipStart
            // 
            this.buttonShipStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonShipStart.Location = new System.Drawing.Point(485, 554);
            this.buttonShipStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonShipStart.Name = "buttonShipStart";
            this.buttonShipStart.Size = new System.Drawing.Size(179, 34);
            this.buttonShipStart.TabIndex = 1;
            this.buttonShipStart.Text = "Enter Ship Info";
            this.buttonShipStart.UseVisualStyleBackColor = true;
            this.buttonShipStart.Click += new System.EventHandler(this.ButtonShipStart_Click);
            // 
            // tabPageCustomerInfo
            // 
            this.tabPageCustomerInfo.Controls.Add(this.buttonCustInfoAddBranch);
            this.tabPageCustomerInfo.Controls.Add(this.dataGridViewBranchInfo);
            this.tabPageCustomerInfo.Controls.Add(this.dataGridViewCustInfo);
            this.tabPageCustomerInfo.Location = new System.Drawing.Point(4, 25);
            this.tabPageCustomerInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageCustomerInfo.Name = "tabPageCustomerInfo";
            this.tabPageCustomerInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageCustomerInfo.Size = new System.Drawing.Size(1099, 617);
            this.tabPageCustomerInfo.TabIndex = 7;
            this.tabPageCustomerInfo.Text = "Cust Info";
            this.tabPageCustomerInfo.UseVisualStyleBackColor = true;
            // 
            // buttonCustInfoAddBranch
            // 
            this.buttonCustInfoAddBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCustInfoAddBranch.Location = new System.Drawing.Point(11, 551);
            this.buttonCustInfoAddBranch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCustInfoAddBranch.Name = "buttonCustInfoAddBranch";
            this.buttonCustInfoAddBranch.Size = new System.Drawing.Size(140, 47);
            this.buttonCustInfoAddBranch.TabIndex = 2;
            this.buttonCustInfoAddBranch.Text = "Add Branch";
            this.buttonCustInfoAddBranch.UseVisualStyleBackColor = true;
            this.buttonCustInfoAddBranch.Click += new System.EventHandler(this.ButtonCustInfoAddBranch_Click);
            // 
            // dataGridViewBranchInfo
            // 
            this.dataGridViewBranchInfo.AllowUserToAddRows = false;
            this.dataGridViewBranchInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBranchInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBranchInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvCBShortBranch,
            this.dgvCBLongBranch,
            this.dgvCBBranchID});
            this.dataGridViewBranchInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewBranchInfo.Location = new System.Drawing.Point(11, 165);
            this.dataGridViewBranchInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewBranchInfo.Name = "dataGridViewBranchInfo";
            this.dataGridViewBranchInfo.RowHeadersWidth = 51;
            this.dataGridViewBranchInfo.RowTemplate.Height = 24;
            this.dataGridViewBranchInfo.Size = new System.Drawing.Size(1085, 382);
            this.dataGridViewBranchInfo.TabIndex = 1;
            this.dataGridViewBranchInfo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewBranchInfo_CellEndEdit);
            this.dataGridViewBranchInfo.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewBranchInfo_EditingControlShowing);
            // 
            // dgvCBShortBranch
            // 
            this.dgvCBShortBranch.HeaderText = "Short Name";
            this.dgvCBShortBranch.MinimumWidth = 6;
            this.dgvCBShortBranch.Name = "dgvCBShortBranch";
            this.dgvCBShortBranch.Width = 125;
            // 
            // dgvCBLongBranch
            // 
            this.dgvCBLongBranch.HeaderText = "Long Branch Name";
            this.dgvCBLongBranch.MinimumWidth = 6;
            this.dgvCBLongBranch.Name = "dgvCBLongBranch";
            this.dgvCBLongBranch.Width = 200;
            // 
            // dgvCBBranchID
            // 
            this.dgvCBBranchID.HeaderText = "BranchID";
            this.dgvCBBranchID.MinimumWidth = 6;
            this.dgvCBBranchID.Name = "dgvCBBranchID";
            this.dgvCBBranchID.Visible = false;
            this.dgvCBBranchID.Width = 125;
            // 
            // dataGridViewCustInfo
            // 
            this.dataGridViewCustInfo.AllowUserToAddRows = false;
            this.dataGridViewCustInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCustInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InfoShortName,
            this.InfoLongName,
            this.InfoAddress1,
            this.InfoAddress2,
            this.InfoCity,
            this.InfoState,
            this.InfoZip,
            this.InfoCountry,
            this.InfoPhone,
            this.InfoFax,
            this.InfoContact,
            this.InfoEmail,
            this.InfoPackaging,
            this.InfoMaxWeight,
            this.InfoPriceTier,
            this.InfoWeightFormula,
            this.InfoQBName,
            this.InfoLeadTime});
            this.dataGridViewCustInfo.Location = new System.Drawing.Point(9, 25);
            this.dataGridViewCustInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewCustInfo.Name = "dataGridViewCustInfo";
            this.dataGridViewCustInfo.RowHeadersWidth = 51;
            this.dataGridViewCustInfo.RowTemplate.Height = 24;
            this.dataGridViewCustInfo.Size = new System.Drawing.Size(1094, 135);
            this.dataGridViewCustInfo.TabIndex = 0;
            this.dataGridViewCustInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCustInfo_CellContentClick);
            this.dataGridViewCustInfo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCustInfo_CellEndEdit);
            // 
            // InfoShortName
            // 
            this.InfoShortName.HeaderText = "ShortName";
            this.InfoShortName.MinimumWidth = 6;
            this.InfoShortName.Name = "InfoShortName";
            this.InfoShortName.Width = 125;
            // 
            // InfoLongName
            // 
            this.InfoLongName.HeaderText = "LongName";
            this.InfoLongName.MinimumWidth = 6;
            this.InfoLongName.Name = "InfoLongName";
            this.InfoLongName.Width = 125;
            // 
            // InfoAddress1
            // 
            this.InfoAddress1.HeaderText = "Address1";
            this.InfoAddress1.MinimumWidth = 6;
            this.InfoAddress1.Name = "InfoAddress1";
            this.InfoAddress1.Width = 125;
            // 
            // InfoAddress2
            // 
            this.InfoAddress2.HeaderText = "Address2";
            this.InfoAddress2.MinimumWidth = 6;
            this.InfoAddress2.Name = "InfoAddress2";
            this.InfoAddress2.Width = 125;
            // 
            // InfoCity
            // 
            this.InfoCity.HeaderText = "City";
            this.InfoCity.MinimumWidth = 6;
            this.InfoCity.Name = "InfoCity";
            this.InfoCity.Width = 125;
            // 
            // InfoState
            // 
            this.InfoState.HeaderText = "State";
            this.InfoState.MinimumWidth = 6;
            this.InfoState.Name = "InfoState";
            this.InfoState.Width = 125;
            // 
            // InfoZip
            // 
            this.InfoZip.HeaderText = "Zip";
            this.InfoZip.MinimumWidth = 6;
            this.InfoZip.Name = "InfoZip";
            this.InfoZip.Width = 125;
            // 
            // InfoCountry
            // 
            this.InfoCountry.HeaderText = "Country";
            this.InfoCountry.MinimumWidth = 6;
            this.InfoCountry.Name = "InfoCountry";
            this.InfoCountry.Width = 125;
            // 
            // InfoPhone
            // 
            this.InfoPhone.HeaderText = "Phone";
            this.InfoPhone.MinimumWidth = 6;
            this.InfoPhone.Name = "InfoPhone";
            this.InfoPhone.Width = 125;
            // 
            // InfoFax
            // 
            this.InfoFax.HeaderText = "Fax";
            this.InfoFax.MinimumWidth = 6;
            this.InfoFax.Name = "InfoFax";
            this.InfoFax.Width = 125;
            // 
            // InfoContact
            // 
            this.InfoContact.HeaderText = "Contact";
            this.InfoContact.MinimumWidth = 6;
            this.InfoContact.Name = "InfoContact";
            this.InfoContact.Width = 125;
            // 
            // InfoEmail
            // 
            this.InfoEmail.HeaderText = "Email";
            this.InfoEmail.MinimumWidth = 6;
            this.InfoEmail.Name = "InfoEmail";
            this.InfoEmail.Width = 125;
            // 
            // InfoPackaging
            // 
            this.InfoPackaging.HeaderText = "Packaging";
            this.InfoPackaging.MinimumWidth = 6;
            this.InfoPackaging.Name = "InfoPackaging";
            this.InfoPackaging.Width = 125;
            // 
            // InfoMaxWeight
            // 
            this.InfoMaxWeight.HeaderText = "MaxWeight";
            this.InfoMaxWeight.MinimumWidth = 6;
            this.InfoMaxWeight.Name = "InfoMaxWeight";
            this.InfoMaxWeight.Width = 125;
            // 
            // InfoPriceTier
            // 
            this.InfoPriceTier.HeaderText = "PriceTier";
            this.InfoPriceTier.MinimumWidth = 6;
            this.InfoPriceTier.Name = "InfoPriceTier";
            this.InfoPriceTier.Width = 125;
            // 
            // InfoWeightFormula
            // 
            this.InfoWeightFormula.HeaderText = "Actual";
            this.InfoWeightFormula.MinimumWidth = 6;
            this.InfoWeightFormula.Name = "InfoWeightFormula";
            this.InfoWeightFormula.Width = 125;
            // 
            // InfoQBName
            // 
            this.InfoQBName.HeaderText = "QBName";
            this.InfoQBName.MinimumWidth = 6;
            this.InfoQBName.Name = "InfoQBName";
            this.InfoQBName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InfoQBName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InfoQBName.Width = 125;
            // 
            // InfoLeadTime
            // 
            this.InfoLeadTime.HeaderText = "LeadTime";
            this.InfoLeadTime.MinimumWidth = 6;
            this.InfoLeadTime.Name = "InfoLeadTime";
            this.InfoLeadTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InfoLeadTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InfoLeadTime.ToolTipText = "Less than zero defaults to machine lead time.  Greater than 0 overrides machine d" +
    "efault.";
            this.InfoLeadTime.Width = 125;
            // 
            // tabPagePVC
            // 
            this.tabPagePVC.Controls.Add(this.tabControlPVC);
            this.tabPagePVC.Location = new System.Drawing.Point(4, 25);
            this.tabPagePVC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVC.Name = "tabPagePVC";
            this.tabPagePVC.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVC.Size = new System.Drawing.Size(1099, 617);
            this.tabPagePVC.TabIndex = 6;
            this.tabPagePVC.Text = "PVC";
            this.tabPagePVC.UseVisualStyleBackColor = true;
            // 
            // tabControlPVC
            // 
            this.tabControlPVC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlPVC.Controls.Add(this.tabPagePVCInventory);
            this.tabControlPVC.Controls.Add(this.tabPagePVCReceiving);
            this.tabControlPVC.Controls.Add(this.tabPagePVCItems);
            this.tabControlPVC.Controls.Add(this.tabPagePVCVendor);
            this.tabControlPVC.Controls.Add(this.tabPagePVCGroup);
            this.tabControlPVC.Controls.Add(this.tabPagePVCAdjust);
            this.tabControlPVC.Location = new System.Drawing.Point(3, 4);
            this.tabControlPVC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlPVC.Name = "tabControlPVC";
            this.tabControlPVC.SelectedIndex = 0;
            this.tabControlPVC.Size = new System.Drawing.Size(1100, 574);
            this.tabControlPVC.TabIndex = 0;
            this.tabControlPVC.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlPVC_Selected);
            // 
            // tabPagePVCInventory
            // 
            this.tabPagePVCInventory.Controls.Add(this.tabControlPVCInventory);
            this.tabPagePVCInventory.Location = new System.Drawing.Point(4, 25);
            this.tabPagePVCInventory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCInventory.Name = "tabPagePVCInventory";
            this.tabPagePVCInventory.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCInventory.Size = new System.Drawing.Size(1092, 545);
            this.tabPagePVCInventory.TabIndex = 0;
            this.tabPagePVCInventory.Text = "Inventory";
            this.tabPagePVCInventory.UseVisualStyleBackColor = true;
            // 
            // tabControlPVCInventory
            // 
            this.tabControlPVCInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlPVCInventory.Controls.Add(this.tabPagePVCInvDetailed);
            this.tabControlPVCInventory.Controls.Add(this.tabPagePVCInvTotals);
            this.tabControlPVCInventory.Location = new System.Drawing.Point(5, 5);
            this.tabControlPVCInventory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlPVCInventory.Name = "tabControlPVCInventory";
            this.tabControlPVCInventory.SelectedIndex = 0;
            this.tabControlPVCInventory.Size = new System.Drawing.Size(967, 506);
            this.tabControlPVCInventory.TabIndex = 1;
            this.tabControlPVCInventory.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControlPVCInventory_Selected);
            // 
            // tabPagePVCInvDetailed
            // 
            this.tabPagePVCInvDetailed.Controls.Add(this.listViewPVCInvDetail);
            this.tabPagePVCInvDetailed.Location = new System.Drawing.Point(4, 25);
            this.tabPagePVCInvDetailed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCInvDetailed.Name = "tabPagePVCInvDetailed";
            this.tabPagePVCInvDetailed.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCInvDetailed.Size = new System.Drawing.Size(959, 477);
            this.tabPagePVCInvDetailed.TabIndex = 0;
            this.tabPagePVCInvDetailed.Text = "Detailed";
            this.tabPagePVCInvDetailed.UseVisualStyleBackColor = true;
            // 
            // listViewPVCInvDetail
            // 
            this.listViewPVCInvDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPVCInvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Customer,
            this.TagID,
            this.Group,
            this.Tack,
            this.Location,
            this.ItemDesc,
            this.columnWidth,
            this.Length});
            this.listViewPVCInvDetail.HideSelection = false;
            this.listViewPVCInvDetail.Location = new System.Drawing.Point(5, 2);
            this.listViewPVCInvDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewPVCInvDetail.Name = "listViewPVCInvDetail";
            this.listViewPVCInvDetail.Size = new System.Drawing.Size(950, 446);
            this.listViewPVCInvDetail.TabIndex = 0;
            this.listViewPVCInvDetail.UseCompatibleStateImageBehavior = false;
            this.listViewPVCInvDetail.View = System.Windows.Forms.View.Details;
            this.listViewPVCInvDetail.SelectedIndexChanged += new System.EventHandler(this.ListViewPVCInvDetail_SelectedIndexChanged);
            // 
            // Customer
            // 
            this.Customer.Text = "Customer";
            this.Customer.Width = 107;
            // 
            // TagID
            // 
            this.TagID.Text = "TagID";
            // 
            // Group
            // 
            this.Group.Text = "Group";
            this.Group.Width = 124;
            // 
            // Tack
            // 
            this.Tack.Text = "Tack";
            // 
            // Location
            // 
            this.Location.Text = "Location";
            this.Location.Width = 79;
            // 
            // ItemDesc
            // 
            this.ItemDesc.Text = "Item";
            this.ItemDesc.Width = 255;
            // 
            // columnWidth
            // 
            this.columnWidth.Text = "Width";
            // 
            // Length
            // 
            this.Length.Text = "Length";
            // 
            // tabPagePVCInvTotals
            // 
            this.tabPagePVCInvTotals.Location = new System.Drawing.Point(4, 25);
            this.tabPagePVCInvTotals.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCInvTotals.Name = "tabPagePVCInvTotals";
            this.tabPagePVCInvTotals.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCInvTotals.Size = new System.Drawing.Size(959, 477);
            this.tabPagePVCInvTotals.TabIndex = 1;
            this.tabPagePVCInvTotals.Text = "Totals";
            this.tabPagePVCInvTotals.UseVisualStyleBackColor = true;
            // 
            // tabPagePVCReceiving
            // 
            this.tabPagePVCReceiving.Controls.Add(this.panelPVCReceiving);
            this.tabPagePVCReceiving.Location = new System.Drawing.Point(4, 25);
            this.tabPagePVCReceiving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCReceiving.Name = "tabPagePVCReceiving";
            this.tabPagePVCReceiving.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCReceiving.Size = new System.Drawing.Size(1092, 545);
            this.tabPagePVCReceiving.TabIndex = 1;
            this.tabPagePVCReceiving.Text = "PVC Receiving";
            this.tabPagePVCReceiving.UseVisualStyleBackColor = true;
            // 
            // panelPVCReceiving
            // 
            this.panelPVCReceiving.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPVCReceiving.Controls.Add(this.checkBoxPVCRecCustomer);
            this.panelPVCReceiving.Controls.Add(this.buttonPVCRecDeleteRow);
            this.panelPVCReceiving.Controls.Add(this.buttonPVCRecAddRow);
            this.panelPVCReceiving.Controls.Add(this.dateTimePicker2);
            this.panelPVCReceiving.Controls.Add(this.labelPVCRecPONum);
            this.panelPVCReceiving.Controls.Add(this.textBoxPVCRecPONum);
            this.panelPVCReceiving.Controls.Add(this.labelPVCRecRefNum);
            this.panelPVCReceiving.Controls.Add(this.textBoxPVCRecRefNumber);
            this.panelPVCReceiving.Controls.Add(this.buttonPVCRecAdd);
            this.panelPVCReceiving.Controls.Add(this.dataGridViewPVCRec);
            this.panelPVCReceiving.Controls.Add(this.comboBoxPVCRecVendors);
            this.panelPVCReceiving.Location = new System.Drawing.Point(5, 5);
            this.panelPVCReceiving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPVCReceiving.Name = "panelPVCReceiving";
            this.panelPVCReceiving.Size = new System.Drawing.Size(1078, 516);
            this.panelPVCReceiving.TabIndex = 0;
            // 
            // checkBoxPVCRecCustomer
            // 
            this.checkBoxPVCRecCustomer.AutoSize = true;
            this.checkBoxPVCRecCustomer.Location = new System.Drawing.Point(557, 18);
            this.checkBoxPVCRecCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxPVCRecCustomer.Name = "checkBoxPVCRecCustomer";
            this.checkBoxPVCRecCustomer.Size = new System.Drawing.Size(131, 20);
            this.checkBoxPVCRecCustomer.TabIndex = 9;
            this.checkBoxPVCRecCustomer.Text = "Customer Owned";
            this.checkBoxPVCRecCustomer.UseVisualStyleBackColor = true;
            this.checkBoxPVCRecCustomer.CheckedChanged += new System.EventHandler(this.CheckBoxPVCRecCustomer_CheckedChanged);
            // 
            // buttonPVCRecDeleteRow
            // 
            this.buttonPVCRecDeleteRow.Location = new System.Drawing.Point(541, 426);
            this.buttonPVCRecDeleteRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPVCRecDeleteRow.Name = "buttonPVCRecDeleteRow";
            this.buttonPVCRecDeleteRow.Size = new System.Drawing.Size(163, 30);
            this.buttonPVCRecDeleteRow.TabIndex = 8;
            this.buttonPVCRecDeleteRow.Text = "Delete Row";
            this.buttonPVCRecDeleteRow.UseVisualStyleBackColor = true;
            this.buttonPVCRecDeleteRow.Click += new System.EventHandler(this.ButtonPVCRecDeleteRow_Click);
            // 
            // buttonPVCRecAddRow
            // 
            this.buttonPVCRecAddRow.Location = new System.Drawing.Point(709, 426);
            this.buttonPVCRecAddRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPVCRecAddRow.Name = "buttonPVCRecAddRow";
            this.buttonPVCRecAddRow.Size = new System.Drawing.Size(163, 30);
            this.buttonPVCRecAddRow.TabIndex = 2;
            this.buttonPVCRecAddRow.Text = "Add Row";
            this.buttonPVCRecAddRow.UseVisualStyleBackColor = true;
            this.buttonPVCRecAddRow.Click += new System.EventHandler(this.ButtonPVCRecAddRow_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker2.Location = new System.Drawing.Point(372, 469);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(248, 22);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // labelPVCRecPONum
            // 
            this.labelPVCRecPONum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPVCRecPONum.AutoSize = true;
            this.labelPVCRecPONum.Location = new System.Drawing.Point(16, 448);
            this.labelPVCRecPONum.Name = "labelPVCRecPONum";
            this.labelPVCRecPONum.Size = new System.Drawing.Size(107, 16);
            this.labelPVCRecPONum.TabIndex = 6;
            this.labelPVCRecPONum.Text = "TSA PO Number";
            // 
            // textBoxPVCRecPONum
            // 
            this.textBoxPVCRecPONum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPVCRecPONum.Location = new System.Drawing.Point(17, 469);
            this.textBoxPVCRecPONum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPVCRecPONum.Name = "textBoxPVCRecPONum";
            this.textBoxPVCRecPONum.Size = new System.Drawing.Size(308, 22);
            this.textBoxPVCRecPONum.TabIndex = 5;
            // 
            // labelPVCRecRefNum
            // 
            this.labelPVCRecRefNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPVCRecRefNum.AutoSize = true;
            this.labelPVCRecRefNum.Location = new System.Drawing.Point(16, 398);
            this.labelPVCRecRefNum.Name = "labelPVCRecRefNum";
            this.labelPVCRecRefNum.Size = new System.Drawing.Size(121, 16);
            this.labelPVCRecRefNum.TabIndex = 4;
            this.labelPVCRecRefNum.Text = "Reference Number";
            // 
            // textBoxPVCRecRefNumber
            // 
            this.textBoxPVCRecRefNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPVCRecRefNumber.Location = new System.Drawing.Point(17, 416);
            this.textBoxPVCRecRefNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPVCRecRefNumber.Name = "textBoxPVCRecRefNumber";
            this.textBoxPVCRecRefNumber.Size = new System.Drawing.Size(308, 22);
            this.textBoxPVCRecRefNumber.TabIndex = 3;
            // 
            // buttonPVCRecAdd
            // 
            this.buttonPVCRecAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPVCRecAdd.Location = new System.Drawing.Point(875, 462);
            this.buttonPVCRecAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPVCRecAdd.Name = "buttonPVCRecAdd";
            this.buttonPVCRecAdd.Size = new System.Drawing.Size(163, 30);
            this.buttonPVCRecAdd.TabIndex = 2;
            this.buttonPVCRecAdd.Text = "Add Order";
            this.buttonPVCRecAdd.UseVisualStyleBackColor = true;
            this.buttonPVCRecAdd.Click += new System.EventHandler(this.ButtonPVCRecAdd_Click);
            // 
            // dataGridViewPVCRec
            // 
            this.dataGridViewPVCRec.AllowUserToAddRows = false;
            this.dataGridViewPVCRec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPVCRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPVCRec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PVCRecItemNumber,
            this.PVCRecItemNumberTextBox,
            this.PVCRecGroupType,
            this.PVCRecRollCount,
            this.PVCRecLocation,
            this.PVCRecPrice,
            this.PVCRecItemWidth,
            this.PVCRecItemLength,
            this.PVCRecTypeID,
            this.PVCRecGroupID,
            this.PVCRecDefWidth,
            this.PVCRecDefLength});
            this.dataGridViewPVCRec.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewPVCRec.Location = new System.Drawing.Point(15, 52);
            this.dataGridViewPVCRec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewPVCRec.Name = "dataGridViewPVCRec";
            this.dataGridViewPVCRec.RowHeadersWidth = 51;
            this.dataGridViewPVCRec.RowTemplate.Height = 24;
            this.dataGridViewPVCRec.Size = new System.Drawing.Size(1058, 335);
            this.dataGridViewPVCRec.TabIndex = 1;
            this.dataGridViewPVCRec.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewPVCRec_CellEnter);
            this.dataGridViewPVCRec.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewPVCRec_EditingControlShowing);
            // 
            // PVCRecItemNumber
            // 
            this.PVCRecItemNumber.HeaderText = "Item Number";
            this.PVCRecItemNumber.MaxDropDownItems = 20;
            this.PVCRecItemNumber.MinimumWidth = 6;
            this.PVCRecItemNumber.Name = "PVCRecItemNumber";
            this.PVCRecItemNumber.Width = 275;
            // 
            // PVCRecItemNumberTextBox
            // 
            this.PVCRecItemNumberTextBox.HeaderText = "ItemNumber";
            this.PVCRecItemNumberTextBox.MinimumWidth = 6;
            this.PVCRecItemNumberTextBox.Name = "PVCRecItemNumberTextBox";
            this.PVCRecItemNumberTextBox.Visible = false;
            this.PVCRecItemNumberTextBox.Width = 275;
            // 
            // PVCRecGroupType
            // 
            this.PVCRecGroupType.HeaderText = "Group";
            this.PVCRecGroupType.MinimumWidth = 6;
            this.PVCRecGroupType.Name = "PVCRecGroupType";
            this.PVCRecGroupType.Visible = false;
            this.PVCRecGroupType.Width = 125;
            // 
            // PVCRecRollCount
            // 
            this.PVCRecRollCount.HeaderText = "Roll Count";
            this.PVCRecRollCount.MinimumWidth = 6;
            this.PVCRecRollCount.Name = "PVCRecRollCount";
            this.PVCRecRollCount.Width = 125;
            // 
            // PVCRecLocation
            // 
            this.PVCRecLocation.HeaderText = "Location";
            this.PVCRecLocation.MinimumWidth = 6;
            this.PVCRecLocation.Name = "PVCRecLocation";
            this.PVCRecLocation.Width = 125;
            // 
            // PVCRecPrice
            // 
            this.PVCRecPrice.HeaderText = "Unit Price";
            this.PVCRecPrice.MinimumWidth = 6;
            this.PVCRecPrice.Name = "PVCRecPrice";
            this.PVCRecPrice.Width = 125;
            // 
            // PVCRecItemWidth
            // 
            this.PVCRecItemWidth.HeaderText = "Width";
            this.PVCRecItemWidth.MinimumWidth = 6;
            this.PVCRecItemWidth.Name = "PVCRecItemWidth";
            this.PVCRecItemWidth.Width = 50;
            // 
            // PVCRecItemLength
            // 
            this.PVCRecItemLength.HeaderText = "Length";
            this.PVCRecItemLength.MinimumWidth = 6;
            this.PVCRecItemLength.Name = "PVCRecItemLength";
            this.PVCRecItemLength.Width = 125;
            // 
            // PVCRecTypeID
            // 
            this.PVCRecTypeID.HeaderText = "TypeID";
            this.PVCRecTypeID.MinimumWidth = 6;
            this.PVCRecTypeID.Name = "PVCRecTypeID";
            this.PVCRecTypeID.Visible = false;
            this.PVCRecTypeID.Width = 125;
            // 
            // PVCRecGroupID
            // 
            this.PVCRecGroupID.HeaderText = "GroupID";
            this.PVCRecGroupID.MinimumWidth = 6;
            this.PVCRecGroupID.Name = "PVCRecGroupID";
            this.PVCRecGroupID.Visible = false;
            this.PVCRecGroupID.Width = 125;
            // 
            // PVCRecDefWidth
            // 
            this.PVCRecDefWidth.HeaderText = "Width";
            this.PVCRecDefWidth.MinimumWidth = 6;
            this.PVCRecDefWidth.Name = "PVCRecDefWidth";
            this.PVCRecDefWidth.Visible = false;
            this.PVCRecDefWidth.Width = 125;
            // 
            // PVCRecDefLength
            // 
            this.PVCRecDefLength.HeaderText = "Length";
            this.PVCRecDefLength.MinimumWidth = 6;
            this.PVCRecDefLength.Name = "PVCRecDefLength";
            this.PVCRecDefLength.Visible = false;
            this.PVCRecDefLength.Width = 125;
            // 
            // comboBoxPVCRecVendors
            // 
            this.comboBoxPVCRecVendors.FormattingEnabled = true;
            this.comboBoxPVCRecVendors.Location = new System.Drawing.Point(13, 16);
            this.comboBoxPVCRecVendors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPVCRecVendors.Name = "comboBoxPVCRecVendors";
            this.comboBoxPVCRecVendors.Size = new System.Drawing.Size(505, 24);
            this.comboBoxPVCRecVendors.TabIndex = 0;
            this.comboBoxPVCRecVendors.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPVCRecVendors_SelectedIndexChanged);
            // 
            // tabPagePVCItems
            // 
            this.tabPagePVCItems.Controls.Add(this.panelPVCItemDesc);
            this.tabPagePVCItems.Location = new System.Drawing.Point(4, 25);
            this.tabPagePVCItems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCItems.Name = "tabPagePVCItems";
            this.tabPagePVCItems.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCItems.Size = new System.Drawing.Size(1092, 545);
            this.tabPagePVCItems.TabIndex = 3;
            this.tabPagePVCItems.Text = "ItemDesc";
            this.tabPagePVCItems.UseVisualStyleBackColor = true;
            // 
            // panelPVCItemDesc
            // 
            this.panelPVCItemDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPVCItemDesc.Controls.Add(this.labelPVCItemAddDesc);
            this.panelPVCItemDesc.Controls.Add(this.lblPVCItemAddItemNumber);
            this.panelPVCItemDesc.Controls.Add(this.lblPVCItemTack);
            this.panelPVCItemDesc.Controls.Add(this.lblPVCItemGroup);
            this.panelPVCItemDesc.Controls.Add(this.buttonPVCItemDelete);
            this.panelPVCItemDesc.Controls.Add(this.comboBoxPVCItemTack);
            this.panelPVCItemDesc.Controls.Add(this.textBoxPVCItemDescAdd);
            this.panelPVCItemDesc.Controls.Add(this.textBoxPVCItemNumberAdd);
            this.panelPVCItemDesc.Controls.Add(this.comboBoxPVCItemGroupAdd);
            this.panelPVCItemDesc.Controls.Add(this.buttonPVCItemsAddItem);
            this.panelPVCItemDesc.Controls.Add(this.comboBoxPVCVendor);
            this.panelPVCItemDesc.Controls.Add(this.listViewPVCItems);
            this.panelPVCItemDesc.Location = new System.Drawing.Point(3, 7);
            this.panelPVCItemDesc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPVCItemDesc.Name = "panelPVCItemDesc";
            this.panelPVCItemDesc.Size = new System.Drawing.Size(1082, 511);
            this.panelPVCItemDesc.TabIndex = 0;
            // 
            // labelPVCItemAddDesc
            // 
            this.labelPVCItemAddDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPVCItemAddDesc.AutoSize = true;
            this.labelPVCItemAddDesc.Location = new System.Drawing.Point(668, 430);
            this.labelPVCItemAddDesc.Name = "labelPVCItemAddDesc";
            this.labelPVCItemAddDesc.Size = new System.Drawing.Size(105, 16);
            this.labelPVCItemAddDesc.TabIndex = 11;
            this.labelPVCItemAddDesc.Text = "PVC Description";
            // 
            // lblPVCItemAddItemNumber
            // 
            this.lblPVCItemAddItemNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPVCItemAddItemNumber.AutoSize = true;
            this.lblPVCItemAddItemNumber.Location = new System.Drawing.Point(444, 430);
            this.lblPVCItemAddItemNumber.Name = "lblPVCItemAddItemNumber";
            this.lblPVCItemAddItemNumber.Size = new System.Drawing.Size(113, 16);
            this.lblPVCItemAddItemNumber.TabIndex = 10;
            this.lblPVCItemAddItemNumber.Text = "PVC Item Number";
            // 
            // lblPVCItemTack
            // 
            this.lblPVCItemTack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPVCItemTack.AutoSize = true;
            this.lblPVCItemTack.Location = new System.Drawing.Point(351, 430);
            this.lblPVCItemTack.Name = "lblPVCItemTack";
            this.lblPVCItemTack.Size = new System.Drawing.Size(38, 16);
            this.lblPVCItemTack.TabIndex = 9;
            this.lblPVCItemTack.Text = "Tack";
            // 
            // lblPVCItemGroup
            // 
            this.lblPVCItemGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPVCItemGroup.AutoSize = true;
            this.lblPVCItemGroup.Location = new System.Drawing.Point(183, 430);
            this.lblPVCItemGroup.Name = "lblPVCItemGroup";
            this.lblPVCItemGroup.Size = new System.Drawing.Size(74, 16);
            this.lblPVCItemGroup.TabIndex = 8;
            this.lblPVCItemGroup.Text = "PVC Group";
            // 
            // buttonPVCItemDelete
            // 
            this.buttonPVCItemDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPVCItemDelete.Location = new System.Drawing.Point(17, 447);
            this.buttonPVCItemDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPVCItemDelete.Name = "buttonPVCItemDelete";
            this.buttonPVCItemDelete.Size = new System.Drawing.Size(115, 25);
            this.buttonPVCItemDelete.TabIndex = 7;
            this.buttonPVCItemDelete.Text = "Delete Items";
            this.buttonPVCItemDelete.UseVisualStyleBackColor = true;
            this.buttonPVCItemDelete.Click += new System.EventHandler(this.ButtonPVCItemDelete_Click);
            // 
            // comboBoxPVCItemTack
            // 
            this.comboBoxPVCItemTack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPVCItemTack.FormattingEnabled = true;
            this.comboBoxPVCItemTack.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.comboBoxPVCItemTack.Location = new System.Drawing.Point(348, 448);
            this.comboBoxPVCItemTack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPVCItemTack.Name = "comboBoxPVCItemTack";
            this.comboBoxPVCItemTack.Size = new System.Drawing.Size(93, 24);
            this.comboBoxPVCItemTack.TabIndex = 6;
            // 
            // textBoxPVCItemDescAdd
            // 
            this.textBoxPVCItemDescAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPVCItemDescAdd.Location = new System.Drawing.Point(671, 448);
            this.textBoxPVCItemDescAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPVCItemDescAdd.Name = "textBoxPVCItemDescAdd";
            this.textBoxPVCItemDescAdd.Size = new System.Drawing.Size(260, 22);
            this.textBoxPVCItemDescAdd.TabIndex = 5;
            // 
            // textBoxPVCItemNumberAdd
            // 
            this.textBoxPVCItemNumberAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPVCItemNumberAdd.Location = new System.Drawing.Point(447, 448);
            this.textBoxPVCItemNumberAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPVCItemNumberAdd.Name = "textBoxPVCItemNumberAdd";
            this.textBoxPVCItemNumberAdd.Size = new System.Drawing.Size(217, 22);
            this.textBoxPVCItemNumberAdd.TabIndex = 4;
            // 
            // comboBoxPVCItemGroupAdd
            // 
            this.comboBoxPVCItemGroupAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPVCItemGroupAdd.FormattingEnabled = true;
            this.comboBoxPVCItemGroupAdd.Location = new System.Drawing.Point(186, 448);
            this.comboBoxPVCItemGroupAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPVCItemGroupAdd.Name = "comboBoxPVCItemGroupAdd";
            this.comboBoxPVCItemGroupAdd.Size = new System.Drawing.Size(159, 24);
            this.comboBoxPVCItemGroupAdd.TabIndex = 3;
            // 
            // buttonPVCItemsAddItem
            // 
            this.buttonPVCItemsAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPVCItemsAddItem.Location = new System.Drawing.Point(938, 442);
            this.buttonPVCItemsAddItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPVCItemsAddItem.Name = "buttonPVCItemsAddItem";
            this.buttonPVCItemsAddItem.Size = new System.Drawing.Size(115, 33);
            this.buttonPVCItemsAddItem.TabIndex = 2;
            this.buttonPVCItemsAddItem.Text = "Add Item";
            this.buttonPVCItemsAddItem.UseVisualStyleBackColor = true;
            this.buttonPVCItemsAddItem.Click += new System.EventHandler(this.ButtonPVCItemsAddItem_Click);
            // 
            // comboBoxPVCVendor
            // 
            this.comboBoxPVCVendor.FormattingEnabled = true;
            this.comboBoxPVCVendor.Location = new System.Drawing.Point(13, 11);
            this.comboBoxPVCVendor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPVCVendor.Name = "comboBoxPVCVendor";
            this.comboBoxPVCVendor.Size = new System.Drawing.Size(537, 24);
            this.comboBoxPVCVendor.TabIndex = 1;
            this.comboBoxPVCVendor.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPVCVendor_SelectedIndexChanged);
            // 
            // listViewPVCItems
            // 
            this.listViewPVCItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPVCItems.CheckBoxes = true;
            this.listViewPVCItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvwPVCItemsGroupName,
            this.lvwPVCItemsTack,
            this.lvwPVCItemsItemNumber,
            this.lvwPVCItemsItemDesc,
            this.lvwPVCItemsWidth,
            this.lvwPVCItemsLength});
            this.listViewPVCItems.HideSelection = false;
            this.listViewPVCItems.Location = new System.Drawing.Point(4, 36);
            this.listViewPVCItems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewPVCItems.Name = "listViewPVCItems";
            this.listViewPVCItems.Size = new System.Drawing.Size(1072, 371);
            this.listViewPVCItems.TabIndex = 0;
            this.listViewPVCItems.UseCompatibleStateImageBehavior = false;
            this.listViewPVCItems.View = System.Windows.Forms.View.Details;
            this.listViewPVCItems.SelectedIndexChanged += new System.EventHandler(this.ListViewPVCItems_SelectedIndexChanged);
            // 
            // lvwPVCItemsGroupName
            // 
            this.lvwPVCItemsGroupName.Text = "Group";
            this.lvwPVCItemsGroupName.Width = 137;
            // 
            // lvwPVCItemsTack
            // 
            this.lvwPVCItemsTack.Text = "Tack";
            this.lvwPVCItemsTack.Width = 68;
            // 
            // lvwPVCItemsItemNumber
            // 
            this.lvwPVCItemsItemNumber.Text = "ItemNumber";
            this.lvwPVCItemsItemNumber.Width = 145;
            // 
            // lvwPVCItemsItemDesc
            // 
            this.lvwPVCItemsItemDesc.Text = "Description";
            this.lvwPVCItemsItemDesc.Width = 190;
            // 
            // lvwPVCItemsWidth
            // 
            this.lvwPVCItemsWidth.Text = "Width";
            // 
            // lvwPVCItemsLength
            // 
            this.lvwPVCItemsLength.Text = "Length";
            // 
            // tabPagePVCVendor
            // 
            this.tabPagePVCVendor.Controls.Add(this.panelPVCVendor);
            this.tabPagePVCVendor.Location = new System.Drawing.Point(4, 25);
            this.tabPagePVCVendor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCVendor.Name = "tabPagePVCVendor";
            this.tabPagePVCVendor.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCVendor.Size = new System.Drawing.Size(1092, 545);
            this.tabPagePVCVendor.TabIndex = 2;
            this.tabPagePVCVendor.Text = "Vendor";
            this.tabPagePVCVendor.UseVisualStyleBackColor = true;
            // 
            // panelPVCVendor
            // 
            this.panelPVCVendor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPVCVendor.Controls.Add(this.buttonPVCVendorDeleteRow);
            this.panelPVCVendor.Controls.Add(this.buttonPVCVendorUpdate);
            this.panelPVCVendor.Controls.Add(this.dataGridViewPVCVendor);
            this.panelPVCVendor.Location = new System.Drawing.Point(5, 6);
            this.panelPVCVendor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPVCVendor.Name = "panelPVCVendor";
            this.panelPVCVendor.Size = new System.Drawing.Size(1072, 516);
            this.panelPVCVendor.TabIndex = 0;
            // 
            // buttonPVCVendorDeleteRow
            // 
            this.buttonPVCVendorDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPVCVendorDeleteRow.Location = new System.Drawing.Point(754, 469);
            this.buttonPVCVendorDeleteRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPVCVendorDeleteRow.Name = "buttonPVCVendorDeleteRow";
            this.buttonPVCVendorDeleteRow.Size = new System.Drawing.Size(137, 32);
            this.buttonPVCVendorDeleteRow.TabIndex = 2;
            this.buttonPVCVendorDeleteRow.Text = "Delete Row";
            this.buttonPVCVendorDeleteRow.UseVisualStyleBackColor = true;
            this.buttonPVCVendorDeleteRow.Click += new System.EventHandler(this.ButtonPVCVendorDeleteRow_Click);
            // 
            // buttonPVCVendorUpdate
            // 
            this.buttonPVCVendorUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPVCVendorUpdate.Location = new System.Drawing.Point(903, 469);
            this.buttonPVCVendorUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPVCVendorUpdate.Name = "buttonPVCVendorUpdate";
            this.buttonPVCVendorUpdate.Size = new System.Drawing.Size(137, 32);
            this.buttonPVCVendorUpdate.TabIndex = 1;
            this.buttonPVCVendorUpdate.Text = "Update";
            this.buttonPVCVendorUpdate.UseVisualStyleBackColor = true;
            this.buttonPVCVendorUpdate.Click += new System.EventHandler(this.ButtonPVCVendorUpdate_Click);
            // 
            // dataGridViewPVCVendor
            // 
            this.dataGridViewPVCVendor.AllowUserToAddRows = false;
            this.dataGridViewPVCVendor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPVCVendor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPVCVendor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvPVCVendorName,
            this.dgvPVCVendorPhone});
            this.dataGridViewPVCVendor.Location = new System.Drawing.Point(3, 2);
            this.dataGridViewPVCVendor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewPVCVendor.Name = "dataGridViewPVCVendor";
            this.dataGridViewPVCVendor.RowHeadersWidth = 51;
            this.dataGridViewPVCVendor.RowTemplate.Height = 24;
            this.dataGridViewPVCVendor.Size = new System.Drawing.Size(1067, 448);
            this.dataGridViewPVCVendor.TabIndex = 0;
            this.dataGridViewPVCVendor.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewPVCVendor_CellEnter);
            // 
            // dgvPVCVendorName
            // 
            this.dgvPVCVendorName.HeaderText = "Vendor";
            this.dgvPVCVendorName.MinimumWidth = 6;
            this.dgvPVCVendorName.Name = "dgvPVCVendorName";
            this.dgvPVCVendorName.Width = 125;
            // 
            // dgvPVCVendorPhone
            // 
            this.dgvPVCVendorPhone.HeaderText = "Phone";
            this.dgvPVCVendorPhone.MinimumWidth = 6;
            this.dgvPVCVendorPhone.Name = "dgvPVCVendorPhone";
            this.dgvPVCVendorPhone.Width = 125;
            // 
            // tabPagePVCGroup
            // 
            this.tabPagePVCGroup.Controls.Add(this.buttonPVCGroupDeleteGroup);
            this.tabPagePVCGroup.Controls.Add(this.buttonPVCGroupAddGroup);
            this.tabPagePVCGroup.Controls.Add(this.listBoxPVCGroupList);
            this.tabPagePVCGroup.Location = new System.Drawing.Point(4, 25);
            this.tabPagePVCGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCGroup.Name = "tabPagePVCGroup";
            this.tabPagePVCGroup.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCGroup.Size = new System.Drawing.Size(1092, 545);
            this.tabPagePVCGroup.TabIndex = 4;
            this.tabPagePVCGroup.Text = "Group";
            this.tabPagePVCGroup.UseVisualStyleBackColor = true;
            // 
            // buttonPVCGroupDeleteGroup
            // 
            this.buttonPVCGroupDeleteGroup.Location = new System.Drawing.Point(279, 95);
            this.buttonPVCGroupDeleteGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPVCGroupDeleteGroup.Name = "buttonPVCGroupDeleteGroup";
            this.buttonPVCGroupDeleteGroup.Size = new System.Drawing.Size(240, 44);
            this.buttonPVCGroupDeleteGroup.TabIndex = 2;
            this.buttonPVCGroupDeleteGroup.Text = "Delete Group";
            this.buttonPVCGroupDeleteGroup.UseVisualStyleBackColor = true;
            this.buttonPVCGroupDeleteGroup.Click += new System.EventHandler(this.ButtonPVCGroupDeleteGroup_Click);
            // 
            // buttonPVCGroupAddGroup
            // 
            this.buttonPVCGroupAddGroup.Location = new System.Drawing.Point(279, 18);
            this.buttonPVCGroupAddGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPVCGroupAddGroup.Name = "buttonPVCGroupAddGroup";
            this.buttonPVCGroupAddGroup.Size = new System.Drawing.Size(240, 44);
            this.buttonPVCGroupAddGroup.TabIndex = 1;
            this.buttonPVCGroupAddGroup.Text = "Add Group";
            this.buttonPVCGroupAddGroup.UseVisualStyleBackColor = true;
            this.buttonPVCGroupAddGroup.Click += new System.EventHandler(this.ButtonPVCGroupAddGroup_Click);
            // 
            // listBoxPVCGroupList
            // 
            this.listBoxPVCGroupList.FormattingEnabled = true;
            this.listBoxPVCGroupList.ItemHeight = 16;
            this.listBoxPVCGroupList.Location = new System.Drawing.Point(20, 18);
            this.listBoxPVCGroupList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxPVCGroupList.Name = "listBoxPVCGroupList";
            this.listBoxPVCGroupList.Size = new System.Drawing.Size(201, 500);
            this.listBoxPVCGroupList.TabIndex = 0;
            this.listBoxPVCGroupList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxPVCGroupList_MouseDoubleClick);
            // 
            // tabPagePVCAdjust
            // 
            this.tabPagePVCAdjust.Controls.Add(this.TxtEdit);
            this.tabPagePVCAdjust.Controls.Add(this.groupBoxPVCAdjustReason);
            this.tabPagePVCAdjust.Controls.Add(this.buttonPVCAdjInv);
            this.tabPagePVCAdjust.Controls.Add(this.listViewPVCAdjInv);
            this.tabPagePVCAdjust.Location = new System.Drawing.Point(4, 25);
            this.tabPagePVCAdjust.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCAdjust.Name = "tabPagePVCAdjust";
            this.tabPagePVCAdjust.Size = new System.Drawing.Size(1092, 545);
            this.tabPagePVCAdjust.TabIndex = 5;
            this.tabPagePVCAdjust.Text = "Adjust Inventory";
            this.tabPagePVCAdjust.UseVisualStyleBackColor = true;
            // 
            // TxtEdit
            // 
            this.TxtEdit.Location = new System.Drawing.Point(537, 214);
            this.TxtEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtEdit.Name = "TxtEdit";
            this.TxtEdit.Size = new System.Drawing.Size(251, 22);
            this.TxtEdit.TabIndex = 4;
            this.TxtEdit.Visible = false;
            this.TxtEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtEdit_KeyPress);
            this.TxtEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtEdit_KeyUp);
            this.TxtEdit.Leave += new System.EventHandler(this.TxtEdit_Leave);
            // 
            // groupBoxPVCAdjustReason
            // 
            this.groupBoxPVCAdjustReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxPVCAdjustReason.Controls.Add(this.radioButtonPVCAdjUsed);
            this.groupBoxPVCAdjustReason.Controls.Add(this.radioButtonPVCAdjSold);
            this.groupBoxPVCAdjustReason.Controls.Add(this.radioButtonPVCAdjNotFound);
            this.groupBoxPVCAdjustReason.Location = new System.Drawing.Point(11, 465);
            this.groupBoxPVCAdjustReason.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxPVCAdjustReason.Name = "groupBoxPVCAdjustReason";
            this.groupBoxPVCAdjustReason.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxPVCAdjustReason.Size = new System.Drawing.Size(849, 53);
            this.groupBoxPVCAdjustReason.TabIndex = 3;
            this.groupBoxPVCAdjustReason.TabStop = false;
            this.groupBoxPVCAdjustReason.Text = "Reason";
            // 
            // radioButtonPVCAdjUsed
            // 
            this.radioButtonPVCAdjUsed.AutoSize = true;
            this.radioButtonPVCAdjUsed.Checked = true;
            this.radioButtonPVCAdjUsed.Location = new System.Drawing.Point(173, 22);
            this.radioButtonPVCAdjUsed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonPVCAdjUsed.Name = "radioButtonPVCAdjUsed";
            this.radioButtonPVCAdjUsed.Size = new System.Drawing.Size(116, 20);
            this.radioButtonPVCAdjUsed.TabIndex = 2;
            this.radioButtonPVCAdjUsed.TabStop = true;
            this.radioButtonPVCAdjUsed.Tag = "-3";
            this.radioButtonPVCAdjUsed.Text = "Used on Order";
            this.radioButtonPVCAdjUsed.UseVisualStyleBackColor = true;
            this.radioButtonPVCAdjUsed.CheckedChanged += new System.EventHandler(this.RadioButtonPVCAdjUsed_CheckedChanged);
            // 
            // radioButtonPVCAdjSold
            // 
            this.radioButtonPVCAdjSold.AutoSize = true;
            this.radioButtonPVCAdjSold.Location = new System.Drawing.Point(111, 22);
            this.radioButtonPVCAdjSold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonPVCAdjSold.Name = "radioButtonPVCAdjSold";
            this.radioButtonPVCAdjSold.Size = new System.Drawing.Size(56, 20);
            this.radioButtonPVCAdjSold.TabIndex = 1;
            this.radioButtonPVCAdjSold.Tag = "-2";
            this.radioButtonPVCAdjSold.Text = "Sold";
            this.radioButtonPVCAdjSold.UseVisualStyleBackColor = true;
            this.radioButtonPVCAdjSold.CheckedChanged += new System.EventHandler(this.RadioButtonPVCAdjSold_CheckedChanged);
            // 
            // radioButtonPVCAdjNotFound
            // 
            this.radioButtonPVCAdjNotFound.AutoSize = true;
            this.radioButtonPVCAdjNotFound.Location = new System.Drawing.Point(11, 22);
            this.radioButtonPVCAdjNotFound.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonPVCAdjNotFound.Name = "radioButtonPVCAdjNotFound";
            this.radioButtonPVCAdjNotFound.Size = new System.Drawing.Size(90, 20);
            this.radioButtonPVCAdjNotFound.TabIndex = 0;
            this.radioButtonPVCAdjNotFound.Tag = "-1";
            this.radioButtonPVCAdjNotFound.Text = "Not Found";
            this.radioButtonPVCAdjNotFound.UseVisualStyleBackColor = true;
            this.radioButtonPVCAdjNotFound.CheckedChanged += new System.EventHandler(this.RadioButtonPVCAdjNotFound_CheckedChanged);
            // 
            // buttonPVCAdjInv
            // 
            this.buttonPVCAdjInv.Location = new System.Drawing.Point(875, 487);
            this.buttonPVCAdjInv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPVCAdjInv.Name = "buttonPVCAdjInv";
            this.buttonPVCAdjInv.Size = new System.Drawing.Size(215, 44);
            this.buttonPVCAdjInv.TabIndex = 2;
            this.buttonPVCAdjInv.Text = "Remove from Inventory";
            this.buttonPVCAdjInv.UseVisualStyleBackColor = true;
            this.buttonPVCAdjInv.Click += new System.EventHandler(this.ButtonPVCAdjInv_Click);
            // 
            // listViewPVCAdjInv
            // 
            this.listViewPVCAdjInv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPVCAdjInv.CheckBoxes = true;
            this.listViewPVCAdjInv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader35,
            this.columnHeader36,
            this.columnHeader37,
            this.columnHeader38,
            this.columnHeader42,
            this.columnHeader39,
            this.columnHeader40,
            this.columnHeader41});
            this.listViewPVCAdjInv.HideSelection = false;
            this.listViewPVCAdjInv.Location = new System.Drawing.Point(-5, 2);
            this.listViewPVCAdjInv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewPVCAdjInv.Name = "listViewPVCAdjInv";
            this.listViewPVCAdjInv.Size = new System.Drawing.Size(1089, 456);
            this.listViewPVCAdjInv.TabIndex = 1;
            this.listViewPVCAdjInv.UseCompatibleStateImageBehavior = false;
            this.listViewPVCAdjInv.View = System.Windows.Forms.View.Details;
            this.listViewPVCAdjInv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListViewPVCAdjInv_MouseDown);
            this.listViewPVCAdjInv.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListViewPVCAdjInv_MouseUp);
            // 
            // columnHeader35
            // 
            this.columnHeader35.Text = "Customer";
            this.columnHeader35.Width = 107;
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "TagID";
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "Group";
            this.columnHeader37.Width = 124;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "Tack";
            // 
            // columnHeader42
            // 
            this.columnHeader42.Text = "Location";
            this.columnHeader42.Width = 191;
            // 
            // columnHeader39
            // 
            this.columnHeader39.Text = "Item";
            this.columnHeader39.Width = 255;
            // 
            // columnHeader40
            // 
            this.columnHeader40.Text = "Width";
            // 
            // columnHeader41
            // 
            this.columnHeader41.Text = "Length";
            // 
            // tabPageRunSheet
            // 
            this.tabPageRunSheet.Controls.Add(this.lvwRunSheet);
            this.tabPageRunSheet.Controls.Add(this.tabControlOrderMachines);
            this.tabPageRunSheet.Location = new System.Drawing.Point(4, 25);
            this.tabPageRunSheet.Name = "tabPageRunSheet";
            this.tabPageRunSheet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRunSheet.Size = new System.Drawing.Size(1099, 617);
            this.tabPageRunSheet.TabIndex = 9;
            this.tabPageRunSheet.Text = "Run Sheet";
            this.tabPageRunSheet.UseVisualStyleBackColor = true;
            // 
            // lvwRunSheet
            // 
            this.lvwRunSheet.AllowDrop = true;
            this.lvwRunSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwRunSheet.FullRowSelect = true;
            this.lvwRunSheet.HideSelection = false;
            this.lvwRunSheet.Location = new System.Drawing.Point(-1, 32);
            this.lvwRunSheet.Name = "lvwRunSheet";
            this.lvwRunSheet.Size = new System.Drawing.Size(1092, 582);
            this.lvwRunSheet.TabIndex = 1;
            this.lvwRunSheet.UseCompatibleStateImageBehavior = false;
            this.lvwRunSheet.View = System.Windows.Forms.View.Details;
            this.lvwRunSheet.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvwRunSheet_ItemDrag);
            this.lvwRunSheet.SelectedIndexChanged += new System.EventHandler(this.lvwRunSheet_SelectedIndexChanged);
            this.lvwRunSheet.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwRunSheet_DragDrop);
            this.lvwRunSheet.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvwRunSheet_DragEnter);
            this.lvwRunSheet.DragOver += new System.Windows.Forms.DragEventHandler(this.lvwRunSheet_DragOver);
            this.lvwRunSheet.DragLeave += new System.EventHandler(this.lvwRunSheet_DragLeave);
            this.lvwRunSheet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvwRunSheet_MouseDown);
            this.lvwRunSheet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwRunSheet_MouseUp);
            // 
            // tabControlOrderMachines
            // 
            this.tabControlOrderMachines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlOrderMachines.Location = new System.Drawing.Point(3, 3);
            this.tabControlOrderMachines.Name = "tabControlOrderMachines";
            this.tabControlOrderMachines.SelectedIndex = 0;
            this.tabControlOrderMachines.Size = new System.Drawing.Size(1097, 28);
            this.tabControlOrderMachines.TabIndex = 0;
            this.tabControlOrderMachines.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlOrderMachines_DrawItem);
            this.tabControlOrderMachines.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlOrderMachines_Selected);
            // 
            // checkBoxCloseOrders
            // 
            this.checkBoxCloseOrders.AutoSize = true;
            this.checkBoxCloseOrders.Location = new System.Drawing.Point(483, 4);
            this.checkBoxCloseOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxCloseOrders.Name = "checkBoxCloseOrders";
            this.checkBoxCloseOrders.Size = new System.Drawing.Size(108, 20);
            this.checkBoxCloseOrders.TabIndex = 7;
            this.checkBoxCloseOrders.Text = "Close Orders";
            this.checkBoxCloseOrders.UseVisualStyleBackColor = true;
            this.checkBoxCloseOrders.CheckedChanged += new System.EventHandler(this.CheckBoxCloseOrders_CheckedChanged);
            // 
            // contextMenuStripAddVertical
            // 
            this.contextMenuStripAddVertical.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripAddVertical.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearItem});
            this.contextMenuStripAddVertical.Name = "contextMenuStripAddVertical";
            this.contextMenuStripAddVertical.Size = new System.Drawing.Size(147, 28);
            // 
            // ClearItem
            // 
            this.ClearItem.Name = "ClearItem";
            this.ClearItem.Size = new System.Drawing.Size(146, 24);
            this.ClearItem.Text = "Clear Item";
            this.ClearItem.Click += new System.EventHandler(this.ClearItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMenuPrintLabel,
            this.transferCoilToolStripMenuItem,
            this.historyToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(149, 76);
            // 
            // toolMenuPrintLabel
            // 
            this.toolMenuPrintLabel.Name = "toolMenuPrintLabel";
            this.toolMenuPrintLabel.Size = new System.Drawing.Size(148, 24);
            this.toolMenuPrintLabel.Text = "Print Label";
            this.toolMenuPrintLabel.Click += new System.EventHandler(this.toolMenuPrintLabel_Click);
            // 
            // transferCoilToolStripMenuItem
            // 
            this.transferCoilToolStripMenuItem.Name = "transferCoilToolStripMenuItem";
            this.transferCoilToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.transferCoilToolStripMenuItem.Text = "Transfer";
            this.transferCoilToolStripMenuItem.Click += new System.EventHandler(this.transferCoilToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.historyToolStripMenuItem.Text = "History";
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printSkidLabel,
            this.transferSkidToolStripMenuItem,
            this.historyToolStripMenuItem1});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(149, 76);
            // 
            // printSkidLabel
            // 
            this.printSkidLabel.Name = "printSkidLabel";
            this.printSkidLabel.Size = new System.Drawing.Size(148, 24);
            this.printSkidLabel.Text = "Print Label";
            this.printSkidLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.printSkidLabel_MouseDown);
            // 
            // transferSkidToolStripMenuItem
            // 
            this.transferSkidToolStripMenuItem.Name = "transferSkidToolStripMenuItem";
            this.transferSkidToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.transferSkidToolStripMenuItem.Text = "Transfer";
            this.transferSkidToolStripMenuItem.Click += new System.EventHandler(this.transferSkidToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem1
            // 
            this.historyToolStripMenuItem1.Name = "historyToolStripMenuItem1";
            this.historyToolStripMenuItem1.Size = new System.Drawing.Size(148, 24);
            this.historyToolStripMenuItem1.Text = "History";
            this.historyToolStripMenuItem1.Click += new System.EventHandler(this.historyToolStripMenuItem1_Click);
            // 
            // btAddCustomer
            // 
            this.btAddCustomer.Location = new System.Drawing.Point(6, 35);
            this.btAddCustomer.Name = "btAddCustomer";
            this.btAddCustomer.Size = new System.Drawing.Size(110, 24);
            this.btAddCustomer.TabIndex = 8;
            this.btAddCustomer.Text = "Add Customer";
            this.btAddCustomer.UseVisualStyleBackColor = true;
            this.btAddCustomer.Click += new System.EventHandler(this.btAddCustomer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(710, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // FormICMSMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 726);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TreeViewCustomer);
            this.Controls.Add(this.btAddCustomer);
            this.Controls.Add(this.checkBoxInactiveCustomers);
            this.Controls.Add(this.tabControlProcess);
            this.Controls.Add(this.tabControlPlantLocations);
            this.Controls.Add(this.tabControlMachines);
            this.Controls.Add(this.checkBoxCloseOrders);
            this.Controls.Add(this.tabControlICMS);
            this.Controls.Add(this.tabControlSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormICMSMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ICMS 2.0";
            this.Load += new System.EventHandler(this.FormICMSMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageDefaultMachines.ResumeLayout(false);
            this.tabPageDefaultMachines.PerformLayout();
            this.groupBoxDefaultScrapUnit.ResumeLayout(false);
            this.groupBoxDefaultScrapUnit.PerformLayout();
            this.tabPageReportDrive.ResumeLayout(false);
            this.tabPageReportDrive.PerformLayout();
            this.tabPageWorkers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorker)).EndInit();
            this.tabPageLeadTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeadTimes)).EndInit();
            this.tabPagePrinters.ResumeLayout(false);
            this.tabPagePrinters.PerformLayout();
            this.tabPageOrderFlow.ResumeLayout(false);
            this.tabPageSkidPricing.ResumeLayout(false);
            this.tabPageSkidPricing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSkidPricing)).EndInit();
            this.tabPageProcPricing.ResumeLayout(false);
            this.tabPageProcPricing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcPricing)).EndInit();
            this.tabPageSteelTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSteelTypeAlloys)).EndInit();
            this.tabPageSTPricing.ResumeLayout(false);
            this.tabPageSTPricing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSPHistory)).EndInit();
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageAbout.PerformLayout();
            this.tabPageOrders.ResumeLayout(false);
            this.panelCoilSheetSame.ResumeLayout(false);
            this.panelCoilSheetSame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCTLOrderEntry)).EndInit();
            this.panelSheetSheetDiff.ResumeLayout(false);
            this.panelSheetSheetDiff.PerformLayout();
            this.panelSSDOrderEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSSDItems)).EndInit();
            this.panelCoilCoilSame.ResumeLayout(false);
            this.panelCoilCoilSame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCLCLSame)).EndInit();
            this.panelClClDiff.ResumeLayout(false);
            this.panelClClDiff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClClDiff)).EndInit();
            this.panelSheetSheetSame.ResumeLayout(false);
            this.panelSheetSheetSame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSSSmSkid)).EndInit();
            this.tabPageReports.ResumeLayout(false);
            this.tabPageReports.PerformLayout();
            this.tabPageReceiving.ResumeLayout(false);
            this.tabPageReceiving.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceiving)).EndInit();
            this.tabPageSkid.ResumeLayout(false);
            this.tabPageCoil.ResumeLayout(false);
            this.tabControlICMS.ResumeLayout(false);
            this.tabPageShipping.ResumeLayout(false);
            this.tabPageShipping.PerformLayout();
            this.splitContainerShipping.Panel1.ResumeLayout(false);
            this.splitContainerShipping.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerShipping)).EndInit();
            this.splitContainerShipping.ResumeLayout(false);
            this.tabPageCustomerInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBranchInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustInfo)).EndInit();
            this.tabPagePVC.ResumeLayout(false);
            this.tabControlPVC.ResumeLayout(false);
            this.tabPagePVCInventory.ResumeLayout(false);
            this.tabControlPVCInventory.ResumeLayout(false);
            this.tabPagePVCInvDetailed.ResumeLayout(false);
            this.tabPagePVCReceiving.ResumeLayout(false);
            this.panelPVCReceiving.ResumeLayout(false);
            this.panelPVCReceiving.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPVCRec)).EndInit();
            this.tabPagePVCItems.ResumeLayout(false);
            this.panelPVCItemDesc.ResumeLayout(false);
            this.panelPVCItemDesc.PerformLayout();
            this.tabPagePVCVendor.ResumeLayout(false);
            this.panelPVCVendor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPVCVendor)).EndInit();
            this.tabPagePVCGroup.ResumeLayout(false);
            this.tabPagePVCAdjust.ResumeLayout(false);
            this.tabPagePVCAdjust.PerformLayout();
            this.groupBoxPVCAdjustReason.ResumeLayout(false);
            this.groupBoxPVCAdjustReason.PerformLayout();
            this.tabPageRunSheet.ResumeLayout(false);
            this.contextMenuStripAddVertical.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TreeViewCustomer;
        private System.Windows.Forms.CheckBox checkBoxInactiveCustomers;
        private System.Windows.Forms.TabControl tabControlPlantLocations;
        private TabControl tabControlSettings;
        private TabPage tabPagePrinters;
        private Label labelShippingLabels;
        private ComboBox comboBoxShippingLabelPrinter;
        private Label labelTagPrinter;
        private ComboBox comboBoxTagLabelPrinter;
        private TabControl tabControlProcess;
        private TabControl tabControlMachines;
        private TabPage tabPageDefaultMachines;
        private Label labelDefaultClClSameFinish;
        private ComboBox comboBoxDefaultClClSameFinish;
        private TabPage tabPageOrderFlow;
        private Button buttonOrdFlowDelConnections;
        private Button buttonOrdFlowAddConnection;
        private ComboBox comboBoxOrdFlowToMachine;
        private ComboBox comboBoxOrdFlowFromMachine;
        private ListView listViewOrderFlowMachines;
        private ColumnHeader colOrdFlowFromMachine;
        private ColumnHeader colOrdFlowToMachine;
        private Label labelClClDiffTrimVal;
        private Label labelClClDiffTrimTo;
        private Label labelClClDiffTrimFrom;
        private Button buttonClClDiffAddTrim;
        private ListView listViewClClDiffTrim;
        private ColumnHeader columnHeaderClClDiffTrimFrom;
        private ColumnHeader columnHeaderClClDiffTrimTo;
        private ColumnHeader columnHeaderClClDiffTrimVal;
        private TextBox textBoxClClDiffTrimValue;
        private TextBox textBoxClClDiffTrimTo;
        private TextBox textBoxClClDiffTrimFrom;
        private ComboBox comboBoxClClDiffTrim;
        private Button buttonClClDiffTrimRemove;
        private TabPage tabPageAbout;
        private Label labelAboutConnString;
        private TextBox textBoxDefaultsCTLThickDiscrepency;
        private Label labelCTLThicknessDiscrepency;
        private Button buttonDefaultCTLThickDiscUpdate;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem balanceToToolStripMenuItem;
        private TabPage tabPageLeadTime;
        private DataGridView dataGridViewLeadTimes;
        private DataGridViewTextBoxColumn colMachine;
        private DataGridViewTextBoxColumn colLeadTime;
        private DataGridViewTextBoxColumn colDate;
        private TabPage tabPageOrders;
        private Panel panelCoilSheetSame;
        private Button buttonCTLDeleteRow;
        private Button buttonAdderDone;
        private TextBox textBoxCTLRunSheetComments;
        private Label labelCTLRunSheetComments;
        private Button buttonCTLDelete;
        private ComboBox comboBoxCTLModify;
        private CheckBox checkBoxCTLModify;
        private Label labelCTLSendTo;
        private ComboBox comboBoxCTLSendTo;
        private CheckBox checkBoxCTLMultiStep;
        private Button buttonCTLReset;
        private Label labelCTLPrice;
        private Label labelCTLPO;
        private Label labelCTLPromiseDate;
        private CheckBox checkBoxCTLScrapCredit;
        private TextBox textBoxCTLPO;
        private TextBox textBoxCTLPrice;
        private DateTimePicker dateTimePickerCTLPromiseDate;
        private RichTextBox richTextBoxCTLComments;
        private Button buttonCTLStartOrder;
        private Button buttonCTLAddOrder;
        private DataGridView dataGridViewCTLOrderEntry;
        private ListView listViewCTLCoilList;
        private ColumnHeader colCTLTagID;
        private ColumnHeader colCTLLocation;
        private ColumnHeader colCTLAlloy;
        private ColumnHeader colCTLThickness;
        private ColumnHeader colCTLWidth;
        private ColumnHeader colCTLLength;
        private ColumnHeader colCTLWeight;
        private ColumnHeader colCTLMill;
        private ColumnHeader colCTLHeat;
        private ColumnHeader colCTLCarbon;
        private ColumnHeader colCTLVendor;
        private ColumnHeader colCTLPO;
        private ColumnHeader colCTLContainer;
        private ColumnHeader colCTLRecDate;
        private ColumnHeader colCTLRecID;
        private ColumnHeader colCTLCoilCount;
        private ColumnHeader colCTLCountryOfOrigin;
        private Panel panelCoilCoilSame;
        private Button buttonClClSameDelete;
        private ComboBox comboBoxClClSameModify;
        private CheckBox checkBoxClClSameModify;
        private Label labelClClSameMultiToMachine;
        private ComboBox comboBoxClClSameToMachine;
        private CheckBox checkBoxClClSameMultiStep;
        private Button buttonClClSameReset;
        private Label labelClClSamePrice;
        private Label labelClClSamePO;
        private Label labelClClSamePromiseDate;
        private CheckBox checkBoxClClSameScrap;
        private TextBox textBoxClClSamePO;
        private TextBox textBoxClClSamePrice;
        private DateTimePicker dateTimePickerClClSamePromise;
        private RichTextBox richTextBoxClClSameComments;
        private Button buttonClClSameAddOrder;
        private Button buttonCLCLSameStartOrder;
        private DataGridView dataGridViewCLCLSame;
        private ListView listViewClClSame;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private Panel panelClClDiff;
        private Label labelClClDiffMasterSequence;
        private Label labelClClDiffMasterFrom;
        private Button buttonClClDiffResetCuts;
        private Button buttonClClDiffModifyDelte;
        private ComboBox comboBoxClClDiffModify;
        private CheckBox checkBoxClClDiffModify;
        private Label labelClClDiffMultSendTo;
        private ComboBox comboBoxClClDiffSendTo;
        private CheckBox checkBoxClClDiffMultStep;
        private Label labelClClDiffPrice;
        private Label labelClClDiffPO;
        private Label labelClClDiffPromiseDate;
        private CheckBox checkBoxClClDiffScrapCredit;
        private TextBox textBoxClClDiffPO;
        private TextBox textBoxClClDiffPrice;
        private DateTimePicker dateTimePickerClClDiffPromiseDate;
        private RichTextBox richTextBoxClClDiffComments;
        private Button buttonClClDiffReset;
        private DataGridView dataGridViewClClDiff;
        private DataGridViewTextBoxColumn colClClDiffTagID;
        private DataGridViewTextBoxColumn colClClDiffThickness;
        private DataGridViewTextBoxColumn colClClDiffWidth;
        private DataGridViewTextBoxColumn colClClDiffAlloy;
        private DataGridViewCheckBoxColumn colClClDiffBreak;
        private DataGridViewTextBoxColumn colClClDiffOrigWeight;
        private DataGridViewTextBoxColumn colClClDiffNewWeight;
        private DataGridViewTextBoxColumn colClClDiffWidthLeft;
        private DataGridViewTextBoxColumn colClClDiffTrimAmount;
        private DataGridViewTextBoxColumn colClClDiffCutCount;
        private DataGridViewCheckBoxColumn colClClDiffPaper;
        private DataGridViewButtonColumn colClClDiffAddCutButton;
        private ListView listViewClClDiff;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader20;
        private ColumnHeader columnHeader21;
        private ColumnHeader columnHeader22;
        private ColumnHeader columnHeader23;
        private ColumnHeader columnHeader24;
        private ColumnHeader columnHeader25;
        private ColumnHeader columnHeader26;
        private ColumnHeader columnHeader27;
        private ColumnHeader columnHeader28;
        private ColumnHeader columnHeader29;
        private ColumnHeader columnHeader30;
        private ColumnHeader columnHeader31;
        private ColumnHeader columnHeader32;
        private ColumnHeader columnHeader33;
        private ColumnHeader columnHeader34;
        private Button buttonClClDiffAddOrder;
        private Button buttonClClDiffStartOrder;
        public TabPage tabPageReports;
        private TabPage tabPageReceiving;
        private Label labelContainer;
        private TextBox textBoxContainer;
        private DateTimePicker dateTimePicker1;
        private CheckBox checkBoxPreReceiving;
        private Button buttonRecSubmit;
        private Button buttonDamageDone;
        private Button buttonReceiveDeleteRow;
        private Button buttonRecieveAddRow;
        private CheckedListBox checkedListBoxDamage;
        private DataGridView dataGridViewReceiving;
        private TabPage tabPageSkid;
        private TabPage tabPageCoil;
        private ListView ListViewCoilData;
        private ColumnHeader hdrTagID;
        private ColumnHeader hdrLocation;
        private ColumnHeader hdrAlloy;
        private ColumnHeader hdrThickness;
        private ColumnHeader hdrWidth;
        private ColumnHeader hdrLength;
        private ColumnHeader hdrWeight;
        private ColumnHeader hdrMillNum;
        private ColumnHeader hdrHeat;
        private ColumnHeader hdrCarbon;
        private ColumnHeader hdrVendor;
        private ColumnHeader hdrPONum;
        private ColumnHeader hdrContainer;
        private ColumnHeader hdrRecDate;
        private ColumnHeader hdrRecID;
        private ColumnHeader hdrCoilCount;
        private ColumnHeader hdrCountryOfOrigin;
        private TabControl tabControlICMS;
        private DataGridView dataGridViewAdders;
        private DataGridViewCheckBoxColumn colSelect;
        private DataGridViewTextBoxColumn dgvAdderDesc;
        private DataGridViewTextBoxColumn dgvAdderPrice;
        private TabPage tabPagePVC;
        private TabControl tabControlPVC;
        private TabPage tabPagePVCInventory;
        private TabPage tabPagePVCReceiving;
        private TabPage tabPagePVCVendor;
        private TabPage tabPagePVCItems;
        private Panel panelPVCVendor;
        private Button buttonPVCVendorDeleteRow;
        private Button buttonPVCVendorUpdate;
        private DataGridView dataGridViewPVCVendor;
        private DataGridViewTextBoxColumn dgvPVCVendorName;
        private DataGridViewTextBoxColumn dgvPVCVendorPhone;
        private Panel panelPVCItemDesc;
        private ComboBox comboBoxPVCVendor;
        private ListView listViewPVCItems;
        private ColumnHeader lvwPVCItemsItemNumber;
        private ColumnHeader lvwPVCItemsItemDesc;
        private ColumnHeader lvwPVCItemsWidth;
        private ColumnHeader lvwPVCItemsLength;
        private Button buttonPVCItemsAddItem;
        private TabPage tabPagePVCGroup;
        private ListBox listBoxPVCGroupList;
        private Button buttonPVCGroupDeleteGroup;
        private Button buttonPVCGroupAddGroup;
        private ColumnHeader lvwPVCItemsGroupName;
        private TextBox textBoxPVCItemDescAdd;
        private TextBox textBoxPVCItemNumberAdd;
        private ComboBox comboBoxPVCItemGroupAdd;
        private ComboBox comboBoxPVCItemTack;
        private ColumnHeader lvwPVCItemsTack;
        private Panel panelPVCReceiving;
        private ComboBox comboBoxPVCRecVendors;
        private DataGridView dataGridViewPVCRec;
        private DateTimePicker dateTimePicker2;
        private Label labelPVCRecPONum;
        private TextBox textBoxPVCRecPONum;
        private Label labelPVCRecRefNum;
        private TextBox textBoxPVCRecRefNumber;
        private Button buttonPVCRecAdd;
        private Button buttonPVCRecDeleteRow;
        private Button buttonPVCRecAddRow;
        private Button buttonPVCItemDelete;
        private TabControl tabControlPVCInventory;
        private TabPage tabPagePVCInvDetailed;
        private ListView listViewPVCInvDetail;
        private ColumnHeader Customer;
        private ColumnHeader TagID;
        private ColumnHeader Group;
        private ColumnHeader Tack;
        private ColumnHeader columnWidth;
        private ColumnHeader Length;
        private TabPage tabPagePVCInvTotals;
        private CheckBox checkBoxPVCRecCustomer;
        private ColumnHeader ItemDesc;
        private TabPage tabPagePVCAdjust;
        private ListView listViewPVCAdjInv;
        private ColumnHeader columnHeader35;
        private ColumnHeader columnHeader36;
        private ColumnHeader columnHeader37;
        private ColumnHeader columnHeader38;
        private ColumnHeader columnHeader39;
        private ColumnHeader columnHeader40;
        private ColumnHeader columnHeader41;
        private GroupBox groupBoxPVCAdjustReason;
        private RadioButton radioButtonPVCAdjUsed;
        private RadioButton radioButtonPVCAdjSold;
        private RadioButton radioButtonPVCAdjNotFound;
        private Button buttonPVCAdjInv;
        private TextBox TxtEdit;
        private ColumnHeader hdrOrderInfo;
        private ColumnHeader colCTLOrders;
        private TabPage tabPageCustomerInfo;
        private DataGridView dataGridViewCustInfo;
        private DataGridViewTextBoxColumn InfoShortName;
        private DataGridViewTextBoxColumn InfoLongName;
        private DataGridViewTextBoxColumn InfoAddress1;
        private DataGridViewTextBoxColumn InfoAddress2;
        private DataGridViewTextBoxColumn InfoCity;
        private DataGridViewTextBoxColumn InfoState;
        private DataGridViewTextBoxColumn InfoZip;
        private DataGridViewTextBoxColumn InfoCountry;
        private DataGridViewTextBoxColumn InfoPhone;
        private DataGridViewTextBoxColumn InfoFax;
        private DataGridViewTextBoxColumn InfoContact;
        private DataGridViewTextBoxColumn InfoEmail;
        private DataGridViewTextBoxColumn InfoPackaging;
        private DataGridViewTextBoxColumn InfoMaxWeight;
        private DataGridViewTextBoxColumn InfoPriceTier;
        private DataGridViewCheckBoxColumn InfoWeightFormula;
        private DataGridViewTextBoxColumn InfoQBName;
        private DataGridViewTextBoxColumn InfoLeadTime;
        private TabPage tabPageWorkers;
        private DataGridView dataGridViewWorker;
        private DataGridViewTextBoxColumn WorkerFirstName;
        private DataGridViewTextBoxColumn WorkerLastName;
        private DataGridViewCheckBoxColumn WorkerActive;
        private DataGridViewTextBoxColumn WorkerID;
        private Button buttonAddWorker;
        private DataGridViewComboBoxColumn PVCRecItemNumber;
        private DataGridViewTextBoxColumn PVCRecItemNumberTextBox;
        private DataGridViewComboBoxColumn PVCRecGroupType;
        private DataGridViewTextBoxColumn PVCRecRollCount;
        private DataGridViewTextBoxColumn PVCRecLocation;
        private DataGridViewTextBoxColumn PVCRecPrice;
        private DataGridViewTextBoxColumn PVCRecItemWidth;
        private DataGridViewTextBoxColumn PVCRecItemLength;
        private DataGridViewComboBoxColumn PVCRecTypeID;
        private DataGridViewComboBoxColumn PVCRecGroupID;
        private DataGridViewComboBoxColumn PVCRecDefWidth;
        private DataGridViewComboBoxColumn PVCRecDefLength;
        private new ColumnHeader Location;
        private Label labelSpecialLeadTime;
        private ColumnHeader columnHeader42;
        private Label labelPaperPrice;
        private TextBox textBoxPaperPrice;
        private TabPage tabPageSkidPricing;
        private Label labelTierLevel;
        private ComboBox comboBoxTierLevel;
        private ComboBox comboBoxSkidTypeID;
        private ComboBox comboBoxSkidDescription;
        private Label labelSkidType;
        private Button buttonAddPrice;
        private DataGridView dataGridViewSkidPricing;
        private DataGridViewTextBoxColumn dgvSPFromWidth;
        private DataGridViewTextBoxColumn dgvSPToWidth;
        private DataGridViewTextBoxColumn dgvSPFromLength;
        private DataGridViewTextBoxColumn dgvSPToLength;
        private DataGridViewTextBoxColumn dgvSPPrice;
        private Label labelTestPriceValue;
        private Label labelTestPrice;
        private Button buttonSkidPriceTest;
        private Button buttonDeleteSkidPrice;
        private TabPage tabPageProcPricing;
        private Button buttonProcPriceDelete;
        private Label label1;
        private Label labelProcPrice;
        private Button buttonProcTest;
        private Button buttonProcPricAdd;
        private DataGridView dataGridViewProcPricing;
        private ComboBox comboBoxProcSteelTypeID;
        private ComboBox comboBoxProcSteelTypeDesc;
        private Label labelProcSteelType;
        private Label labelProcTierLevel;
        private ComboBox comboBoxProcTierLevel;
        private ComboBox comboBoxProcMachineID;
        private ComboBox comboBoxProcMachineDesc;
        private Label labelProcMachine;
        private TabPage tabPageSteelTypes;
        private Button buttonSteelTypeAdd;
        private ListBox listBoxSteelTypes;
        private Button buttonSteelTypeAddAlloy;
        private DataGridView dataGridViewSteelTypeAlloys;
        private DataGridViewTextBoxColumn dgvSTAlloy;
        private DataGridViewTextBoxColumn dgvSTAlloyID;
        private DataGridViewTextBoxColumn dgvSTDensity;
        private DataGridViewTextBoxColumn dgvSTDisplayOrder;
        private DataGridViewTextBoxColumn dgvSTPrice;
        private ListBox listBoxSTFinish;
        private Button buttonSTAddFinish;
        private TabPage tabPageSTPricing;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSPHistory;
        private ListView listViewSPHistory;
        private ColumnHeader columnHeaderSPHistoryPrice;
        private ColumnHeader columnHeaderSPHistoryDate;
        private ListView listViewSPPrice;
        private ColumnHeader columnHeaderSPAlloy;
        private ColumnHeader columnHeaderSPPrice;
        private Label labelSPPrice;
        private DataGridView dataGridViewBranchInfo;
        private Button buttonCustInfoAddBranch;
        private DataGridViewTextBoxColumn dgvCBShortBranch;
        private DataGridViewTextBoxColumn dgvCBLongBranch;
        private DataGridViewTextBoxColumn dgvCBBranchID;
        private DataGridViewTextBoxColumn dgvProcFromThickness;
        private DataGridViewTextBoxColumn dgvProcToThickness;
        private DataGridViewTextBoxColumn dgvProcFromWidth;
        private DataGridViewTextBoxColumn dgvProcToWidth;
        private DataGridViewTextBoxColumn dgvProcFromLength;
        private DataGridViewTextBoxColumn dgvProcToLength;
        private DataGridViewTextBoxColumn dgvProcPrice;
        private Label label3;
        private Label labelProcPriceResults;
        private CheckBox checkBoxCloseOrders;
        private GroupBox groupBoxDefaultScrapUnit;
        private RadioButton radioButtonScrapUnitLBS;
        private RadioButton radioButtonScrapUnitInches;
        private ListView listViewSkidData;
        private ColumnHeader lvSkidID;
        private ColumnHeader lvSkidLocation;
        private ColumnHeader lvPieceCount;
        private ColumnHeader lvSkidAlloy;
        private ColumnHeader lvSkidThickness;
        private ColumnHeader lvSkidWidth;
        private ColumnHeader lvSkidLength;
        private ColumnHeader lvSkidWeight;
        private ColumnHeader lvSkidPVC;
        private ColumnHeader lvSkidPI;
        private ColumnHeader lvSkidComments;
        private ColumnHeader lvSkidNotPrime;
        private Panel panelSheetSheetSame;
        private Label labelSSSmSpecialLeadTime;
        private TextBox textBoxSSSmRunSheet;
        private Label labelSSSmRunSheet;
        private ComboBox comboBoxSSSmModify;
        private CheckBox checkBoxSSSmModify;
        private ComboBox comboBoxSSSmMulti;
        private CheckBox checkBoxSSSmMultiStep;
        private Label labelSSSmPrice;
        private Label labelSSSmPO;
        private Label labelSSSmPromiseDate;
        private TextBox textBoxSSSmPO;
        private TextBox textBoxSSSmPrice;
        private DateTimePicker dateTimePickerSSSmPromiseDate;
        private RichTextBox richTextBoxSSSmComments;
        private Button buttonSSSmStartOrder;
        private ListView listViewSSSmSkidData;
        private ColumnHeader columnHeader43;
        private ColumnHeader columnHeader44;
        private ColumnHeader columnHeader45;
        private ColumnHeader columnHeader46;
        private ColumnHeader columnHeader47;
        private ColumnHeader columnHeader48;
        private ColumnHeader columnHeader49;
        private ColumnHeader columnHeader50;
        private ColumnHeader columnHeader51;
        private ColumnHeader columnHeader52;
        private ColumnHeader columnHeader53;
        private ColumnHeader columnHeader54;
        private Button buttonSSSmAddOrder;
        private DataGridView dataGridViewSSSmSkid;
        private Label labelDefaultSSSmFinish;
        private ComboBox comboBoxDefaultSSSmFinish;
        private DataGridViewTextBoxColumn dgvCTLTagID;
        private DataGridViewTextBoxColumn dgvCTLThickness;
        private DataGridViewTextBoxColumn dgvCTLWidth;
        private DataGridViewTextBoxColumn dgvCTLAlloy;
        private DataGridViewTextBoxColumn dgvCTLWeight;
        private DataGridViewTextBoxColumn dgvCTLWeightLeft;
        private DataGridViewCheckBoxColumn dgvCTLPaper;
        private DataGridViewComboBoxColumn dgvCTLPVC;
        private DataGridViewComboBoxColumn dgvCTLAdder;
        private DataGridViewButtonColumn dgvCTLAddCut;
        private DataGridViewComboBoxColumn dgvCTLSkidType;
        private DataGridViewTextBoxColumn dgvCTLCurrSkidPrice;
        private DataGridViewTextBoxColumn dgvCTLSkidCount;
        private DataGridViewTextBoxColumn dgvCTLPieceCount;
        private DataGridViewTextBoxColumn dgvCTLLength;
        private DataGridViewTextBoxColumn dgvCTLComments;
        private DataGridViewTextBoxColumn dgvCTLSheetWeight;
        private DataGridViewTextBoxColumn dgvCTLTheoLBS;
        private DataGridViewComboBoxColumn dgvCTLBranch;
        private DataGridViewComboBoxColumn dgvCTLBranchID;
        private DataGridViewComboBoxColumn dgvCTLAdderID;
        private DataGridViewComboBoxColumn dgvCTLAdderPrice;
        private DataGridViewTextBoxColumn dgvCTLDensityFactor;
        private DataGridViewComboBoxColumn dgvCTLPVCGroupID;
        private DataGridViewComboBoxColumn dgvSkidTypeID;
        private DataGridViewComboBoxColumn dgvCTLPVCPriceList;
        private DataGridViewTextBoxColumn dgvCTLCurrPrice;
        private ColumnHeader lvSkidBranch;
        private ColumnHeader columnHeader55;
        private DataGridViewCheckBoxColumn dgvSSSmBreakSkid;
        private DataGridViewTextBoxColumn dgvSSSmSkidID;
        private DataGridViewTextBoxColumn dgvSSSmLetter;
        private DataGridViewTextBoxColumn dgvSSSmPieces;
        private DataGridViewTextBoxColumn dgvSSSmAlloy;
        private DataGridViewComboBoxColumn dgvSSSmNewFinish;
        private DataGridViewTextBoxColumn dgvSSSmThickness;
        private DataGridViewTextBoxColumn dgvSSSmWidth;
        private DataGridViewTextBoxColumn dgvSSSmLength;
        private DataGridViewTextBoxColumn dgvSSSmWeight;
        private DataGridViewComboBoxColumn dgvSSSmPVC;
        private DataGridViewCheckBoxColumn dgvSSSmPaper;
        private DataGridViewCheckBoxColumn dgvSSSmLineMark;
        private DataGridViewTextBoxColumn dgvSSSmComments;
        private DataGridViewComboBoxColumn dgvSSSmBranch;
        private DataGridViewComboBoxColumn dgvSSSmBranchID;
        private DataGridViewTextBoxColumn dgvSSSmAlloyID;
        private DataGridViewComboBoxColumn dgvSSSmFinishID;
        private DataGridViewTextBoxColumn dgvSSSmDensityFactor;
        private DataGridViewTextBoxColumn dgvSSSmOrigFinish;
        private DataGridViewComboBoxColumn dgvSSSmPVCGroupID;
        private DataGridViewComboBoxColumn dgvSSSmPVCPriceList;
        private DataGridViewTextBoxColumn dgvSSSmCurrPrice;
        private TabPage tabPageShipping;
        private Panel panelSheetSheetDiff;
        private SplitContainer splitContainerShipping;
        private ListView listViewShipCoil;
        private ColumnHeader columnHeader56;
        private ColumnHeader columnHeader57;
        private ColumnHeader columnHeader58;
        private ColumnHeader columnHeader59;
        private ColumnHeader columnHeader60;
        private ColumnHeader columnHeader61;
        private ColumnHeader columnHeader62;
        private ColumnHeader columnHeader63;
        private ColumnHeader columnHeader64;
        private ColumnHeader columnHeader65;
        private ColumnHeader columnHeader66;
        private ColumnHeader columnHeader67;
        private ColumnHeader columnHeader68;
        private ColumnHeader columnHeader69;
        private ColumnHeader columnHeader70;
        private ColumnHeader columnHeader71;
        private ColumnHeader columnHeader72;
        private ColumnHeader columnHeader73;
        private ListView listViewShipSkid;
        private ColumnHeader columnHeader74;
        private ColumnHeader columnHeader75;
        private ColumnHeader columnHeader76;
        private ColumnHeader columnHeader77;
        private ColumnHeader columnHeader78;
        private ColumnHeader columnHeader79;
        private ColumnHeader columnHeader80;
        private ColumnHeader columnHeader81;
        private ColumnHeader columnHeader82;
        private ColumnHeader columnHeader83;
        private ColumnHeader columnHeader84;
        private ColumnHeader columnHeader85;
        private ColumnHeader columnHeader86;
        private ListView listViewSSD;
        private ColumnHeader columnHeader87;
        private ColumnHeader columnHeader88;
        private ColumnHeader columnHeader89;
        private ColumnHeader columnHeader90;
        private ColumnHeader columnHeader91;
        private ColumnHeader columnHeader92;
        private ColumnHeader columnHeader93;
        private ColumnHeader columnHeader94;
        private ColumnHeader columnHeader95;
        private ColumnHeader columnHeader96;
        private ColumnHeader columnHeader97;
        private ColumnHeader columnHeader98;
        private ColumnHeader columnHeader99;
        private ColumnHeader lvSkidMillNum;
        private ColumnHeader lvSkidHeat;
        private ColumnHeader columnHeader100;
        private ColumnHeader lvheat;
        private ColumnHeader columnHeader101;
        private ColumnHeader columnHeader102;
        private Label labelSSDSpecialLeadTime;
        private TextBox textBoxSSDRunSheetComments;
        private Label labelSSDRunSheetComments;
        private ComboBox comboBoxSSDModify;
        private CheckBox checkBoxSSDModify;
        private ComboBox comboBoxSSDMultiStep;
        private CheckBox checkBoxSSDMultiStep;
        private Label labelSSDPrice;
        private Label labelSSDPO;
        private Label labelSSDPromiseDate;
        private TextBox textBoxSSDPurchaseOrder;
        private TextBox textBoxSSDPrice;
        private DateTimePicker dateTimePickerSSDPromiseDate;
        private RichTextBox richTextBoxSSDComments;
        private Button buttonSSDAddOrder;
        private Button buttonSSDStartOrder;
        private TextBox textBoxHoldDown;
        private Label labelMachineHoldDown;
        private Button buttonUpdateHoldDown;
        private CheckBox checkBoxCutFullSkids;
        private Panel panelSSDOrderEntry;
        private DataGridView dgvSSDItems;
        private TreeView treeViewSSD;
        private Button buttonAddCuts;
        private Button buttonClearAll;
        private ContextMenuStrip contextMenuStripAddVertical;
        private ToolStripMenuItem ClearItem;
        private DataGridViewTextBoxColumn dgvSSDHeat;
        private DataGridViewTextBoxColumn dgvSSDAlloy;
        private DataGridViewTextBoxColumn dgvSSDPieceCount;
        private DataGridViewTextBoxColumn dgvSSDWidth;
        private DataGridViewTextBoxColumn dgvSSDLength;
        private DataGridViewComboBoxColumn dgvSSDSkidIDs;
        private DataGridViewComboBoxColumn dgvSSDCoilTagSuffix;
        private DataGridViewComboBoxColumn dgvSSDOrigPcs;
        private DataGridViewComboBoxColumn dgvSSDCutPcs;
        private CheckBox checkBoxSSDScrapCredit;
        private Button buttonSSDCancelOrder;
        private ColumnHeader lvwSSDOrders;
        private ColumnHeader lvOrders;
        private ColumnHeader lvsssOrders;
        private ColumnHeader lvCCSOrders;
        private ColumnHeader lvCCDOrders;
        private ColumnHeader colshipMillNum;
        private ColumnHeader colShipHeat;
        private Button buttonReleaseBOL;
        private CheckBox checkBoxShipModifyRel;
        private Button buttonBuildTruck;
        private Panel panelModifyRelease;
        private ComboBox comboBoxBranchChooser;
        private Button buttonShipStart;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem toolMenuPrintLabel;
        private ContextMenuStrip contextMenuStrip3;
        private ToolStripMenuItem printSkidLabel;
        private TextBox txtReportRecieving;
        private Button btnReportReceiving;
        private TabPage tabPageReportDrive;
        private ComboBox cbReportDrive;
        private Label label2;
        private Button btnRepotShipping;
        private TextBox tbReportShipping;
        private Button btnSSMCancel;
        private DataGridViewComboBoxColumn colType;
        private DataGridViewComboBoxColumn colUnloader;
        private DataGridViewTextBoxColumn colPurchaseOrder;
        private DataGridViewTextBoxColumn colMillNumber;
        private DataGridViewTextBoxColumn colHeat;
        private DataGridViewTextBoxColumn colVendor;
        private DataGridViewTextBoxColumn colPieceCount;
        private DataGridViewTextBoxColumn colThickness;
        private DataGridViewComboBoxColumn colAlloy;
        private DataGridViewComboBoxColumn colFinish;
        private DataGridViewTextBoxColumn colWidth;
        private DataGridViewTextBoxColumn colLength;
        private DataGridViewTextBoxColumn colWeight;
        private DataGridViewTextBoxColumn colLocation;
        private DataGridViewTextBoxColumn colCarbon;
        private DataGridViewTextBoxColumn colOriginCountry;
        private DataGridViewComboBoxColumn colDamage;
        private DataGridViewComboBoxColumn colWorkerID;
        private DataGridViewComboBoxColumn colAlloyID;
        private DataGridViewComboBoxColumn colFinishID;
        private DataGridViewComboBoxColumn colDensityFactor;
        private DataGridViewComboBoxColumn colDamageID;
        private DataGridViewComboBoxColumn colSteelType;
        private DataGridViewComboBoxColumn colRecSteelDesc;
        private CheckBox cbRecPrintLabel;
        private Button btnReportWorkOrder;
        private TextBox tbReportWorkOrder;
        private Button btAddCustomer;
        private Button btAddMachine;
        private CheckBox chkBxReportInventoryAllCustomers;
        private Button btnReportInventory;
        private CheckBox chkBxInventoryCoils;
        private CheckBox chkBxInventorySkids;
        private Label lblInventoryUpdate;
        private Button buttonCTLArrowDown;
        private Button buttonCTLArrowUp;
        private ToolStripMenuItem transferCoilToolStripMenuItem;
        private ToolStripMenuItem transferSkidToolStripMenuItem;
        private ToolStripMenuItem historyToolStripMenuItem;
        private ToolStripMenuItem historyToolStripMenuItem1;
        private TextBox tbReportHistory;
        private Button btnReportHistory;
        private DataGridViewTextBoxColumn colClClSameCoilTagID;
        private DataGridViewTextBoxColumn colClCLSameThickness;
        private DataGridViewTextBoxColumn colClClSameWidth;
        private DataGridViewTextBoxColumn colClClSameAlloy;
        private DataGridViewTextBoxColumn colClClSameOrigFinish;
        private DataGridViewComboBoxColumn colClClSameNewFinish;
        private DataGridViewTextBoxColumn colClClSameOrigLBS;
        private DataGridViewTextBoxColumn colClClSamePolishLBS;
        private DataGridViewTextBoxColumn colClClSameCoilCnt;
        private DataGridViewComboBoxColumn colClClSamePolWeights;
        private DataGridViewCheckBoxColumn colClClSamePaper;
        private DataGridViewComboBoxColumn colClClSameNewFinishID;
        private DataGridViewComboBoxColumn colClClSameCoilFinish;
        private TabPage tabPageRunSheet;
        private ListView lvwRunSheet;
        private TabControl tabControlOrderMachines;
        private Label label4;
        private TextBox tbReportTransferID;
        private Button btnReportTransfer;
        private Label lblReportTagID;
        private TextBox tbReportTransferTagID;
        private Label lblReportTransferID;
        private Label labelPVCItemAddDesc;
        private Label lblPVCItemAddItemNumber;
        private Label lblPVCItemTack;
        private Label lblPVCItemGroup;
    }
}

