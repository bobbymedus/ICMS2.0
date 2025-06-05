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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormICMSMain));
            this.TreeViewCustomer = new System.Windows.Forms.TreeView();
            this.checkBoxInactiveCustomers = new System.Windows.Forms.CheckBox();
            this.tabControlPlantLocations = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.balanceToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPageAdders = new System.Windows.Forms.TabPage();
            this.btnSettingAdderDeactivateAdder = new System.Windows.Forms.Button();
            this.btnSettingAdderAddAdder = new System.Windows.Forms.Button();
            this.groupBoxSettingAddersPriceType = new System.Windows.Forms.GroupBox();
            this.rbSettingAdderPriceTypeLinearInches = new System.Windows.Forms.RadioButton();
            this.rbSettingAdderPriceTypeLinearFt = new System.Windows.Forms.RadioButton();
            this.rbSettingAdderPriceTypeSQFT = new System.Windows.Forms.RadioButton();
            this.rpSettingAdderTypeLBS = new System.Windows.Forms.RadioButton();
            this.lblSettingAdderMinPrice = new System.Windows.Forms.Label();
            this.tbSettingAdderMinPrice = new System.Windows.Forms.TextBox();
            this.lblSettingAdderPrice = new System.Windows.Forms.Label();
            this.tbSettingAdderPrice = new System.Windows.Forms.TextBox();
            this.lblSettingAdderDesc = new System.Windows.Forms.Label();
            this.tbSettingAdderDesc = new System.Windows.Forms.TextBox();
            this.lvwSettingsAdders = new System.Windows.Forms.ListView();
            this.colSettingAdderDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSettingAdderPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSettingAdderMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSettingAdderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.cbSettingsOverideShipLabelPrint = new System.Windows.Forms.CheckBox();
            this.cbOverideShipZebra = new System.Windows.Forms.CheckBox();
            this.cbSettingsOverideTagZebra = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxOverideShipPrinter = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxOverideTagPrinter = new System.Windows.Forms.ComboBox();
            this.lblPrintSetLocationOveride = new System.Windows.Forms.Label();
            this.comboBoxSettingOverideCity = new System.Windows.Forms.ComboBox();
            this.cbSettingsPrintShipLabels = new System.Windows.Forms.CheckBox();
            this.cbSettingsShipLabelZebra = new System.Windows.Forms.CheckBox();
            this.cbSettingsTagPrinterZebra = new System.Windows.Forms.CheckBox();
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
            this.columnHeaderSPHistoryScrap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSPHistoryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelSPPrice = new System.Windows.Forms.Label();
            this.chartSPHistory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listViewSPPrice = new System.Windows.Forms.ListView();
            this.columnHeaderSPAlloy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSPPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSPScrapPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tbTestOrderID = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelAboutConnString = new System.Windows.Forms.Label();
            this.tabControlProcess = new System.Windows.Forms.TabControl();
            this.tabControlMachines = new System.Windows.Forms.TabControl();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.panelSheetSheetSame = new System.Windows.Forms.Panel();
            this.cbShShSmPrintOpTag = new System.Windows.Forms.CheckBox();
            this.btnSSSmAddTag = new System.Windows.Forms.Button();
            this.btnOrderShShSameDeleteRow = new System.Windows.Forms.Button();
            this.btnShShModifyDelete = new System.Windows.Forms.Button();
            this.btnShShSmAdderDone = new System.Windows.Forms.Button();
            this.lblShShSmPaperPrice = new System.Windows.Forms.Label();
            this.tbShShSmPaperPrice = new System.Windows.Forms.TextBox();
            this.dgvShShSmAdders = new System.Windows.Forms.DataGridView();
            this.dgvAdderColSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvSSSmAdderDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmAdderPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dgvSSSmAdders = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSSmBranchID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSSmAdderID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSSmAdderPriceCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSSmAlloyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmFinishID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSSmDensityFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmOrigFinish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSSSmPVCGroupID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSSmPVCPriceList = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvSSSmCurrPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.buttonSSSmAddOrder = new System.Windows.Forms.Button();
            this.buttonSSSmStartOrder = new System.Windows.Forms.Button();
            this.panelCoilCoilSame = new System.Windows.Forms.Panel();
            this.lblClClSmPaperPrice = new System.Windows.Forms.Label();
            this.tbClClSmPaperPrice = new System.Windows.Forms.TextBox();
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
            this.buttonClClSameAddOrder = new System.Windows.Forms.Button();
            this.buttonCLCLSameStartOrder = new System.Windows.Forms.Button();
            this.panelSheetSheetDiff = new System.Windows.Forms.Panel();
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
            this.buttonSSDStartOrder = new System.Windows.Forms.Button();
            this.panelCoilSheetSame = new System.Windows.Forms.Panel();
            this.cbCTLWeightCalc = new System.Windows.Forms.CheckBox();
            this.btnOrderCTLAddTag = new System.Windows.Forms.Button();
            this.cbCTLPaperDefault = new System.Windows.Forms.CheckBox();
            this.cbCTLPrintOperatorTags = new System.Windows.Forms.CheckBox();
            this.buttonCTLReset = new System.Windows.Forms.Button();
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
            this.labelCTLPrice = new System.Windows.Forms.Label();
            this.labelCTLPO = new System.Windows.Forms.Label();
            this.labelCTLPromiseDate = new System.Windows.Forms.Label();
            this.checkBoxCTLScrapCredit = new System.Windows.Forms.CheckBox();
            this.textBoxCTLPO = new System.Windows.Forms.TextBox();
            this.textBoxCTLPrice = new System.Windows.Forms.TextBox();
            this.dateTimePickerCTLPromiseDate = new System.Windows.Forms.DateTimePicker();
            this.richTextBoxCTLComments = new System.Windows.Forms.RichTextBox();
            this.buttonCTLArrowDown = new System.Windows.Forms.Button();
            this.buttonCTLArrowUp = new System.Windows.Forms.Button();
            this.dataGridViewCTLOrderEntry = new System.Windows.Forms.DataGridView();
            this.dgvCTLTagID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLThickness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLAlloy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCTLSkidWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.buttonCTLAddOrder = new System.Windows.Forms.Button();
            this.buttonCTLStartOrder = new System.Windows.Forms.Button();
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
            this.buttonClClDiffStartOrder = new System.Windows.Forms.Button();
            this.buttonClClDiffAddOrder = new System.Windows.Forms.Button();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.panelReportOperatorTags = new System.Windows.Forms.Panel();
            this.btnReportOperatorTag = new System.Windows.Forms.Button();
            this.tbReportOperatorTags = new System.Windows.Forms.TextBox();
            this.panelReportTransfer = new System.Windows.Forms.Panel();
            this.btnReportTransfer = new System.Windows.Forms.Button();
            this.tbReportTransferID = new System.Windows.Forms.TextBox();
            this.lblReportTransferID = new System.Windows.Forms.Label();
            this.tbReportTransferTagID = new System.Windows.Forms.TextBox();
            this.lblReportTagID = new System.Windows.Forms.Label();
            this.panelReportHistory = new System.Windows.Forms.Panel();
            this.lblReportsHistoryMill = new System.Windows.Forms.Label();
            this.tbReportsHistoryMillNum = new System.Windows.Forms.TextBox();
            this.lblReportsHistoryPO = new System.Windows.Forms.Label();
            this.tbReportsHistoryPO = new System.Windows.Forms.TextBox();
            this.lblReportHistoryTagID = new System.Windows.Forms.Label();
            this.btnReportHistory = new System.Windows.Forms.Button();
            this.tbReportHistory = new System.Windows.Forms.TextBox();
            this.panelReportInventory = new System.Windows.Forms.Panel();
            this.btnReportInventory = new System.Windows.Forms.Button();
            this.chkBxReportInventoryAllCustomers = new System.Windows.Forms.CheckBox();
            this.chkBxInventoryCoils = new System.Windows.Forms.CheckBox();
            this.chkBxInventorySkids = new System.Windows.Forms.CheckBox();
            this.lblInventoryUpdate = new System.Windows.Forms.Label();
            this.panelReportWorkOrder = new System.Windows.Forms.Panel();
            this.btnReportWorkOrder = new System.Windows.Forms.Button();
            this.tbReportWorkOrder = new System.Windows.Forms.TextBox();
            this.cbReportWorkORderOperatorTags = new System.Windows.Forms.CheckBox();
            this.panelReportShipping = new System.Windows.Forms.Panel();
            this.tbReportShippingLabels = new System.Windows.Forms.TextBox();
            this.btnReportShippingLabel = new System.Windows.Forms.Button();
            this.btnRepotShipping = new System.Windows.Forms.Button();
            this.tbReportShipping = new System.Windows.Forms.TextBox();
            this.panelReportReceiving = new System.Windows.Forms.Panel();
            this.btnReportReceiving = new System.Windows.Forms.Button();
            this.txtReportRecieving = new System.Windows.Forms.TextBox();
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
            this.tabPageOpenOrders = new System.Windows.Forms.TabPage();
            this.btnOpenOrdersPrint = new System.Windows.Forms.Button();
            this.lvOpenOrderList = new System.Windows.Forms.ListView();
            this.colOpenOrderMachine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpenOrderThickness = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpenOrderWidth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpenOrderOrderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpenOrderPromiseDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpenOrderRunSheetComments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpenOrderCustPO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.RecDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsRunSheetCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsRunSheetAmount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsRunSheetPieces = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbRunSheetCustPO = new System.Windows.Forms.CheckBox();
            this.tabControlOrderMachines = new System.Windows.Forms.TabControl();
            this.lvwRunSheet = new System.Windows.Forms.ListView();
            this.tabPageFix = new System.Windows.Forms.TabPage();
            this.panelFix = new System.Windows.Forms.Panel();
            this.tabFixes = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelFixBackOff = new System.Windows.Forms.Panel();
            this.lblFixBackoff = new System.Windows.Forms.Label();
            this.lblFixOrdid = new System.Windows.Forms.Label();
            this.btnFixBackoff = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFixBackOffCoils = new System.Windows.Forms.ComboBox();
            this.tbFixCoilLocation = new System.Windows.Forms.TextBox();
            this.tbFixOrderID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFixPreviousWeight = new System.Windows.Forms.Label();
            this.lblPrevWeight = new System.Windows.Forms.Label();
            this.btnFixBackOffWeight = new System.Windows.Forms.Button();
            this.lblFixNewWeight = new System.Windows.Forms.Label();
            this.tbFixNewWeight = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelFixAddSkid = new System.Windows.Forms.Panel();
            this.lblFixAddSkid = new System.Windows.Forms.Label();
            this.cbFixSkidAddPVCPriceID = new System.Windows.Forms.ComboBox();
            this.cbFixSkidAddPVCGroup = new System.Windows.Forms.ComboBox();
            this.lblFixSkidAddFinishLabel = new System.Windows.Forms.Label();
            this.lblFixSkidAddFinish = new System.Windows.Forms.Label();
            this.lblFixSkidAddAlloyLabel = new System.Windows.Forms.Label();
            this.lblFixSkidAddAlloy = new System.Windows.Forms.Label();
            this.lblFixSkidAddWidthLabel = new System.Windows.Forms.Label();
            this.lblFixSkidAddWidth = new System.Windows.Forms.Label();
            this.cbFixSkidAddNotPrime = new System.Windows.Forms.CheckBox();
            this.lblFixSkidAddLocation = new System.Windows.Forms.Label();
            this.tbFixSkidAddLocation = new System.Windows.Forms.TextBox();
            this.cbFixSkidAddMaxSeq = new System.Windows.Forms.ComboBox();
            this.btnFixSkidAddInsert = new System.Windows.Forms.Button();
            this.tbFixSkidAddMic3 = new System.Windows.Forms.TextBox();
            this.tbFixSkidAddMic2 = new System.Windows.Forms.TextBox();
            this.lblFixSkidAddMic3 = new System.Windows.Forms.Label();
            this.lblFixSkidAddMic2 = new System.Windows.Forms.Label();
            this.lblFixSkidAddMic1 = new System.Windows.Forms.Label();
            this.tbFixSkidAddMic1 = new System.Windows.Forms.TextBox();
            this.lblFixSkidAddDiag2 = new System.Windows.Forms.Label();
            this.tbFixSkidAddDiag2 = new System.Windows.Forms.TextBox();
            this.lblFixSkidAddDiag1 = new System.Windows.Forms.Label();
            this.tbFixSkidAddDiag1 = new System.Windows.Forms.TextBox();
            this.gbFixSkidAddPaper = new System.Windows.Forms.GroupBox();
            this.rbFixSkidAddPaperNo = new System.Windows.Forms.RadioButton();
            this.rbFixSkidAddPaperYes = new System.Windows.Forms.RadioButton();
            this.gbFixSkidAddPVC = new System.Windows.Forms.GroupBox();
            this.rbFixSkidAddPVCNo = new System.Windows.Forms.RadioButton();
            this.rbFixSkidAddPVCYes = new System.Windows.Forms.RadioButton();
            this.lblFixSkidAddSkidPrice = new System.Windows.Forms.Label();
            this.tbFixSkidAddSkidPrice = new System.Windows.Forms.TextBox();
            this.lblFixSkidAddSkidType = new System.Windows.Forms.Label();
            this.cbFixSkidAddSkidType = new System.Windows.Forms.ComboBox();
            this.lblFixSkidAddLength = new System.Windows.Forms.Label();
            this.tbFixSkidAddLength = new System.Windows.Forms.TextBox();
            this.lblFixSkidAddSheetWeight = new System.Windows.Forms.Label();
            this.tbFixSkidAddSheetWeight = new System.Windows.Forms.TextBox();
            this.lblFixSkidAddPieces = new System.Windows.Forms.Label();
            this.tbFixSkidAddPieces = new System.Windows.Forms.TextBox();
            this.cbFixSkidAddLetters = new System.Windows.Forms.ComboBox();
            this.lblFixSkidAddNewLetter = new System.Windows.Forms.Label();
            this.tbFixSkidAddNewLetter = new System.Windows.Forms.TextBox();
            this.lblFixSkidAddTagID = new System.Windows.Forms.Label();
            this.cbFixSkidAddTagID = new System.Windows.Forms.ComboBox();
            this.lblFixSkidAddComments = new System.Windows.Forms.Label();
            this.tbFixSkidAddComments = new System.Windows.Forms.TextBox();
            this.lblFixAddSkidOrderID = new System.Windows.Forms.Label();
            this.tbFixAddSkidOrderID = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panelFixAddDamage = new System.Windows.Forms.Panel();
            this.lblFixAddDamageTagIDs = new System.Windows.Forms.Label();
            this.btnFixAddDamage = new System.Windows.Forms.Button();
            this.lblFixAddDamageBOL = new System.Windows.Forms.Label();
            this.cbFixAddDamageTagIDs = new System.Windows.Forms.ComboBox();
            this.lblfixAddDamage = new System.Windows.Forms.Label();
            this.tbFixAddDamageBOL = new System.Windows.Forms.TextBox();
            this.clbFixAddDamage = new System.Windows.Forms.CheckedListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panelFixBOL = new System.Windows.Forms.Panel();
            this.btnFixBOLFinish = new System.Windows.Forms.Button();
            this.lblFixBOLNum = new System.Windows.Forms.Label();
            this.tbFixBOLNum = new System.Windows.Forms.TextBox();
            this.cblFixBOLList = new System.Windows.Forms.CheckedListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lvFixOpenBOLs = new System.Windows.Forms.ListView();
            this.columnHeader103 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader104 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader105 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader106 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBoxCloseOrders = new System.Windows.Forms.CheckBox();
            this.contextMenuStripAddVertical = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ClearItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolMenuPrintLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.transferCoilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToSkidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printSkidLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.transferSkidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btAddCustomer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.MenuRunSheetRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.putOnHoldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCustomer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deactivateCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClClDiff = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeCommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSlitWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShippingTransfer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.transferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmPVCLabelPrint = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printPVCLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.tabPageAdders.SuspendLayout();
            this.groupBoxSettingAddersPriceType.SuspendLayout();
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
            this.panelSheetSheetSame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShShSmAdders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSSSmSkid)).BeginInit();
            this.panelCoilCoilSame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCLCLSame)).BeginInit();
            this.panelSheetSheetDiff.SuspendLayout();
            this.panelSSDOrderEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSSDItems)).BeginInit();
            this.panelCoilSheetSame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCTLOrderEntry)).BeginInit();
            this.panelClClDiff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClClDiff)).BeginInit();
            this.tabPageReports.SuspendLayout();
            this.panelReportOperatorTags.SuspendLayout();
            this.panelReportTransfer.SuspendLayout();
            this.panelReportHistory.SuspendLayout();
            this.panelReportInventory.SuspendLayout();
            this.panelReportWorkOrder.SuspendLayout();
            this.panelReportShipping.SuspendLayout();
            this.panelReportReceiving.SuspendLayout();
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
            this.tabPageOpenOrders.SuspendLayout();
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
            this.statusStrip1.SuspendLayout();
            this.tabPageFix.SuspendLayout();
            this.panelFix.SuspendLayout();
            this.tabFixes.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelFixBackOff.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelFixAddSkid.SuspendLayout();
            this.gbFixSkidAddPaper.SuspendLayout();
            this.gbFixSkidAddPVC.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panelFixAddDamage.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panelFixBOL.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.contextMenuStripAddVertical.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.MenuRunSheetRightClick.SuspendLayout();
            this.menuCustomer.SuspendLayout();
            this.MenuClClDiff.SuspendLayout();
            this.menuShippingTransfer.SuspendLayout();
            this.cmPVCLabelPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeViewCustomer
            // 
            this.TreeViewCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TreeViewCustomer.Location = new System.Drawing.Point(5, 64);
            this.TreeViewCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TreeViewCustomer.Name = "TreeViewCustomer";
            this.TreeViewCustomer.ShowRootLines = false;
            this.TreeViewCustomer.Size = new System.Drawing.Size(245, 661);
            this.TreeViewCustomer.TabIndex = 0;
            this.TreeViewCustomer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewCustomer_AfterSelect);
            this.TreeViewCustomer.Enter += new System.EventHandler(this.TreeViewCustomer_Enter);
            this.TreeViewCustomer.Leave += new System.EventHandler(this.TreeViewCustomer_Leave);
            this.TreeViewCustomer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeViewCustomer_MouseDown);
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
            this.checkBoxInactiveCustomers.CheckedChanged += new System.EventHandler(this.checkBoxInactiveCustomers_CheckedChanged);
            // 
            // tabControlPlantLocations
            // 
            this.tabControlPlantLocations.Location = new System.Drawing.Point(267, 34);
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
            this.tabControlSettings.Controls.Add(this.tabPageAdders);
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
            this.tabControlSettings.Size = new System.Drawing.Size(1143, 652);
            this.tabControlSettings.TabIndex = 4;
            this.tabControlSettings.SelectedIndexChanged += new System.EventHandler(this.TabControlSettings_SelectedIndexChanged);
            this.tabControlSettings.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlSettings_Selected);
            // 
            // tabPageAdders
            // 
            this.tabPageAdders.Controls.Add(this.btnSettingAdderDeactivateAdder);
            this.tabPageAdders.Controls.Add(this.btnSettingAdderAddAdder);
            this.tabPageAdders.Controls.Add(this.groupBoxSettingAddersPriceType);
            this.tabPageAdders.Controls.Add(this.lblSettingAdderMinPrice);
            this.tabPageAdders.Controls.Add(this.tbSettingAdderMinPrice);
            this.tabPageAdders.Controls.Add(this.lblSettingAdderPrice);
            this.tabPageAdders.Controls.Add(this.tbSettingAdderPrice);
            this.tabPageAdders.Controls.Add(this.lblSettingAdderDesc);
            this.tabPageAdders.Controls.Add(this.tbSettingAdderDesc);
            this.tabPageAdders.Controls.Add(this.lvwSettingsAdders);
            this.tabPageAdders.Location = new System.Drawing.Point(4, 25);
            this.tabPageAdders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAdders.Name = "tabPageAdders";
            this.tabPageAdders.Size = new System.Drawing.Size(1135, 623);
            this.tabPageAdders.TabIndex = 11;
            this.tabPageAdders.Text = "Adders";
            this.tabPageAdders.UseVisualStyleBackColor = true;
            // 
            // btnSettingAdderDeactivateAdder
            // 
            this.btnSettingAdderDeactivateAdder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettingAdderDeactivateAdder.Location = new System.Drawing.Point(21, 177);
            this.btnSettingAdderDeactivateAdder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSettingAdderDeactivateAdder.Name = "btnSettingAdderDeactivateAdder";
            this.btnSettingAdderDeactivateAdder.Size = new System.Drawing.Size(145, 30);
            this.btnSettingAdderDeactivateAdder.TabIndex = 9;
            this.btnSettingAdderDeactivateAdder.Text = "Deactivate";
            this.btnSettingAdderDeactivateAdder.UseVisualStyleBackColor = true;
            this.btnSettingAdderDeactivateAdder.Click += new System.EventHandler(this.btnSettingAdderDeactivateAdder_Click);
            // 
            // btnSettingAdderAddAdder
            // 
            this.btnSettingAdderAddAdder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettingAdderAddAdder.Location = new System.Drawing.Point(467, 305);
            this.btnSettingAdderAddAdder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSettingAdderAddAdder.Name = "btnSettingAdderAddAdder";
            this.btnSettingAdderAddAdder.Size = new System.Drawing.Size(109, 28);
            this.btnSettingAdderAddAdder.TabIndex = 8;
            this.btnSettingAdderAddAdder.Text = "Add";
            this.btnSettingAdderAddAdder.UseVisualStyleBackColor = true;
            this.btnSettingAdderAddAdder.Click += new System.EventHandler(this.btnSettingAdderAddAdder_Click);
            // 
            // groupBoxSettingAddersPriceType
            // 
            this.groupBoxSettingAddersPriceType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxSettingAddersPriceType.Controls.Add(this.rbSettingAdderPriceTypeLinearInches);
            this.groupBoxSettingAddersPriceType.Controls.Add(this.rbSettingAdderPriceTypeLinearFt);
            this.groupBoxSettingAddersPriceType.Controls.Add(this.rbSettingAdderPriceTypeSQFT);
            this.groupBoxSettingAddersPriceType.Controls.Add(this.rpSettingAdderTypeLBS);
            this.groupBoxSettingAddersPriceType.Location = new System.Drawing.Point(467, 252);
            this.groupBoxSettingAddersPriceType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxSettingAddersPriceType.Name = "groupBoxSettingAddersPriceType";
            this.groupBoxSettingAddersPriceType.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxSettingAddersPriceType.Size = new System.Drawing.Size(439, 47);
            this.groupBoxSettingAddersPriceType.TabIndex = 7;
            this.groupBoxSettingAddersPriceType.TabStop = false;
            this.groupBoxSettingAddersPriceType.Text = "Pricing Type";
            // 
            // rbSettingAdderPriceTypeLinearInches
            // 
            this.rbSettingAdderPriceTypeLinearInches.AutoSize = true;
            this.rbSettingAdderPriceTypeLinearInches.Location = new System.Drawing.Point(315, 18);
            this.rbSettingAdderPriceTypeLinearInches.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbSettingAdderPriceTypeLinearInches.Name = "rbSettingAdderPriceTypeLinearInches";
            this.rbSettingAdderPriceTypeLinearInches.Size = new System.Drawing.Size(107, 20);
            this.rbSettingAdderPriceTypeLinearInches.TabIndex = 3;
            this.rbSettingAdderPriceTypeLinearInches.TabStop = true;
            this.rbSettingAdderPriceTypeLinearInches.Text = "Linear Inches";
            this.rbSettingAdderPriceTypeLinearInches.UseVisualStyleBackColor = true;
            // 
            // rbSettingAdderPriceTypeLinearFt
            // 
            this.rbSettingAdderPriceTypeLinearFt.AutoSize = true;
            this.rbSettingAdderPriceTypeLinearFt.Location = new System.Drawing.Point(171, 18);
            this.rbSettingAdderPriceTypeLinearFt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbSettingAdderPriceTypeLinearFt.Name = "rbSettingAdderPriceTypeLinearFt";
            this.rbSettingAdderPriceTypeLinearFt.Size = new System.Drawing.Size(119, 20);
            this.rbSettingAdderPriceTypeLinearFt.TabIndex = 2;
            this.rbSettingAdderPriceTypeLinearFt.Text = "Linear Footage";
            this.rbSettingAdderPriceTypeLinearFt.UseVisualStyleBackColor = true;
            // 
            // rbSettingAdderPriceTypeSQFT
            // 
            this.rbSettingAdderPriceTypeSQFT.AutoSize = true;
            this.rbSettingAdderPriceTypeSQFT.Location = new System.Drawing.Point(83, 18);
            this.rbSettingAdderPriceTypeSQFT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbSettingAdderPriceTypeSQFT.Name = "rbSettingAdderPriceTypeSQFT";
            this.rbSettingAdderPriceTypeSQFT.Size = new System.Drawing.Size(64, 20);
            this.rbSettingAdderPriceTypeSQFT.TabIndex = 1;
            this.rbSettingAdderPriceTypeSQFT.Text = "SQFT";
            this.rbSettingAdderPriceTypeSQFT.UseVisualStyleBackColor = true;
            // 
            // rpSettingAdderTypeLBS
            // 
            this.rpSettingAdderTypeLBS.AutoSize = true;
            this.rpSettingAdderTypeLBS.Checked = true;
            this.rpSettingAdderTypeLBS.Location = new System.Drawing.Point(5, 18);
            this.rpSettingAdderTypeLBS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rpSettingAdderTypeLBS.Name = "rpSettingAdderTypeLBS";
            this.rpSettingAdderTypeLBS.Size = new System.Drawing.Size(53, 20);
            this.rpSettingAdderTypeLBS.TabIndex = 0;
            this.rpSettingAdderTypeLBS.TabStop = true;
            this.rpSettingAdderTypeLBS.Text = "LBS";
            this.rpSettingAdderTypeLBS.UseVisualStyleBackColor = true;
            // 
            // lblSettingAdderMinPrice
            // 
            this.lblSettingAdderMinPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSettingAdderMinPrice.AutoSize = true;
            this.lblSettingAdderMinPrice.Location = new System.Drawing.Point(336, 252);
            this.lblSettingAdderMinPrice.Name = "lblSettingAdderMinPrice";
            this.lblSettingAdderMinPrice.Size = new System.Drawing.Size(62, 16);
            this.lblSettingAdderMinPrice.TabIndex = 6;
            this.lblSettingAdderMinPrice.Text = "Min Price";
            // 
            // tbSettingAdderMinPrice
            // 
            this.tbSettingAdderMinPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSettingAdderMinPrice.Location = new System.Drawing.Point(335, 271);
            this.tbSettingAdderMinPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSettingAdderMinPrice.MaxLength = 20;
            this.tbSettingAdderMinPrice.Name = "tbSettingAdderMinPrice";
            this.tbSettingAdderMinPrice.Size = new System.Drawing.Size(112, 22);
            this.tbSettingAdderMinPrice.TabIndex = 5;
            this.tbSettingAdderMinPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSettingAdderMinPrice_KeyPress);
            // 
            // lblSettingAdderPrice
            // 
            this.lblSettingAdderPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSettingAdderPrice.AutoSize = true;
            this.lblSettingAdderPrice.Location = new System.Drawing.Point(219, 252);
            this.lblSettingAdderPrice.Name = "lblSettingAdderPrice";
            this.lblSettingAdderPrice.Size = new System.Drawing.Size(38, 16);
            this.lblSettingAdderPrice.TabIndex = 4;
            this.lblSettingAdderPrice.Text = "Price";
            // 
            // tbSettingAdderPrice
            // 
            this.tbSettingAdderPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSettingAdderPrice.Location = new System.Drawing.Point(217, 271);
            this.tbSettingAdderPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSettingAdderPrice.MaxLength = 20;
            this.tbSettingAdderPrice.Name = "tbSettingAdderPrice";
            this.tbSettingAdderPrice.Size = new System.Drawing.Size(112, 22);
            this.tbSettingAdderPrice.TabIndex = 3;
            this.tbSettingAdderPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSettingAdderPrice_KeyPress);
            // 
            // lblSettingAdderDesc
            // 
            this.lblSettingAdderDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSettingAdderDesc.AutoSize = true;
            this.lblSettingAdderDesc.Location = new System.Drawing.Point(19, 252);
            this.lblSettingAdderDesc.Name = "lblSettingAdderDesc";
            this.lblSettingAdderDesc.Size = new System.Drawing.Size(75, 16);
            this.lblSettingAdderDesc.TabIndex = 2;
            this.lblSettingAdderDesc.Text = "Description";
            // 
            // tbSettingAdderDesc
            // 
            this.tbSettingAdderDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSettingAdderDesc.Location = new System.Drawing.Point(17, 271);
            this.tbSettingAdderDesc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSettingAdderDesc.MaxLength = 20;
            this.tbSettingAdderDesc.Name = "tbSettingAdderDesc";
            this.tbSettingAdderDesc.Size = new System.Drawing.Size(193, 22);
            this.tbSettingAdderDesc.TabIndex = 1;
            // 
            // lvwSettingsAdders
            // 
            this.lvwSettingsAdders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSettingsAdders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSettingAdderDesc,
            this.colSettingAdderPrice,
            this.colSettingAdderMin,
            this.colSettingAdderType});
            this.lvwSettingsAdders.FullRowSelect = true;
            this.lvwSettingsAdders.HideSelection = false;
            this.lvwSettingsAdders.Location = new System.Drawing.Point(21, 32);
            this.lvwSettingsAdders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvwSettingsAdders.MultiSelect = false;
            this.lvwSettingsAdders.Name = "lvwSettingsAdders";
            this.lvwSettingsAdders.Size = new System.Drawing.Size(1041, 137);
            this.lvwSettingsAdders.TabIndex = 0;
            this.lvwSettingsAdders.UseCompatibleStateImageBehavior = false;
            this.lvwSettingsAdders.View = System.Windows.Forms.View.Details;
            // 
            // colSettingAdderDesc
            // 
            this.colSettingAdderDesc.Text = "Description";
            this.colSettingAdderDesc.Width = 199;
            // 
            // colSettingAdderPrice
            // 
            this.colSettingAdderPrice.Text = "Price";
            this.colSettingAdderPrice.Width = 106;
            // 
            // colSettingAdderMin
            // 
            this.colSettingAdderMin.Text = "Min Price";
            this.colSettingAdderMin.Width = 130;
            // 
            // colSettingAdderType
            // 
            this.colSettingAdderType.Text = "Type";
            this.colSettingAdderType.Width = 169;
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
            this.tabPageDefaultMachines.Size = new System.Drawing.Size(1135, 623);
            this.tabPageDefaultMachines.TabIndex = 2;
            this.tabPageDefaultMachines.Text = "Machine Defaults";
            this.tabPageDefaultMachines.UseVisualStyleBackColor = true;
            this.tabPageDefaultMachines.Click += new System.EventHandler(this.TabPageDefaultMachines_Click);
            // 
            // btAddMachine
            // 
            this.btAddMachine.Location = new System.Drawing.Point(27, 20);
            this.btAddMachine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.textBoxHoldDown.Location = new System.Drawing.Point(149, 426);
            this.textBoxHoldDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxHoldDown.Name = "textBoxHoldDown";
            this.textBoxHoldDown.Size = new System.Drawing.Size(171, 22);
            this.textBoxHoldDown.TabIndex = 19;
            // 
            // labelMachineHoldDown
            // 
            this.labelMachineHoldDown.AutoSize = true;
            this.labelMachineHoldDown.Location = new System.Drawing.Point(21, 425);
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
            this.groupBoxDefaultScrapUnit.Location = new System.Drawing.Point(23, 514);
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
            this.buttonDefaultCTLThickDiscUpdate.Location = new System.Drawing.Point(341, 471);
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
            this.textBoxDefaultsCTLThickDiscrepency.Location = new System.Drawing.Point(211, 473);
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
            this.labelCTLThicknessDiscrepency.Location = new System.Drawing.Point(13, 478);
            this.labelCTLThicknessDiscrepency.Name = "labelCTLThicknessDiscrepency";
            this.labelCTLThicknessDiscrepency.Size = new System.Drawing.Size(176, 16);
            this.labelCTLThicknessDiscrepency.TabIndex = 12;
            this.labelCTLThicknessDiscrepency.Text = "CTL Thickness Discrepency";
            // 
            // buttonClClDiffTrimRemove
            // 
            this.buttonClClDiffTrimRemove.Location = new System.Drawing.Point(469, 213);
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
            this.labelClClDiffTrimVal.Location = new System.Drawing.Point(309, 367);
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
            this.labelClClDiffTrimFrom.Location = new System.Drawing.Point(21, 367);
            this.labelClClDiffTrimFrom.Name = "labelClClDiffTrimFrom";
            this.labelClClDiffTrimFrom.Size = new System.Drawing.Size(38, 16);
            this.labelClClDiffTrimFrom.TabIndex = 7;
            this.labelClClDiffTrimFrom.Text = "From";
            // 
            // buttonClClDiffAddTrim
            // 
            this.buttonClClDiffAddTrim.Location = new System.Drawing.Point(472, 382);
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
            this.listViewClClDiffTrim.Location = new System.Drawing.Point(16, 217);
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
            this.textBoxClClDiffTrimValue.Location = new System.Drawing.Point(309, 382);
            this.textBoxClClDiffTrimValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClClDiffTrimValue.Name = "textBoxClClDiffTrimValue";
            this.textBoxClClDiffTrimValue.Size = new System.Drawing.Size(140, 22);
            this.textBoxClClDiffTrimValue.TabIndex = 4;
            this.textBoxClClDiffTrimValue.TextChanged += new System.EventHandler(this.TextBoxClClDiffTrimValue_TextChanged);
            this.textBoxClClDiffTrimValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxClClDiffTrimValue_KeyPress);
            // 
            // textBoxClClDiffTrimTo
            // 
            this.textBoxClClDiffTrimTo.Location = new System.Drawing.Point(163, 382);
            this.textBoxClClDiffTrimTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClClDiffTrimTo.Name = "textBoxClClDiffTrimTo";
            this.textBoxClClDiffTrimTo.Size = new System.Drawing.Size(140, 22);
            this.textBoxClClDiffTrimTo.TabIndex = 3;
            this.textBoxClClDiffTrimTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxClClDiffTrimTo_KeyPress);
            // 
            // textBoxClClDiffTrimFrom
            // 
            this.textBoxClClDiffTrimFrom.Location = new System.Drawing.Point(16, 382);
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
            this.tabPageReportDrive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageReportDrive.Name = "tabPageReportDrive";
            this.tabPageReportDrive.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageReportDrive.Size = new System.Drawing.Size(1135, 623);
            this.tabPageReportDrive.TabIndex = 10;
            this.tabPageReportDrive.Text = "Reports Drive";
            this.tabPageReportDrive.UseVisualStyleBackColor = true;
            // 
            // cbReportDrive
            // 
            this.cbReportDrive.FormattingEnabled = true;
            this.cbReportDrive.Location = new System.Drawing.Point(131, 31);
            this.cbReportDrive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.tabPageWorkers.Size = new System.Drawing.Size(1135, 623);
            this.tabPageWorkers.TabIndex = 8;
            this.tabPageWorkers.Text = "Workers";
            this.tabPageWorkers.UseVisualStyleBackColor = true;
            // 
            // buttonAddWorker
            // 
            this.buttonAddWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddWorker.Location = new System.Drawing.Point(779, 535);
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
            this.dataGridViewWorker.Size = new System.Drawing.Size(1168, 505);
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
            this.tabPageLeadTime.Size = new System.Drawing.Size(1135, 623);
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
            this.dataGridViewLeadTimes.Size = new System.Drawing.Size(1092, 607);
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
            this.tabPagePrinters.Controls.Add(this.cbSettingsOverideShipLabelPrint);
            this.tabPagePrinters.Controls.Add(this.cbOverideShipZebra);
            this.tabPagePrinters.Controls.Add(this.cbSettingsOverideTagZebra);
            this.tabPagePrinters.Controls.Add(this.label7);
            this.tabPagePrinters.Controls.Add(this.comboBoxOverideShipPrinter);
            this.tabPagePrinters.Controls.Add(this.label8);
            this.tabPagePrinters.Controls.Add(this.comboBoxOverideTagPrinter);
            this.tabPagePrinters.Controls.Add(this.lblPrintSetLocationOveride);
            this.tabPagePrinters.Controls.Add(this.comboBoxSettingOverideCity);
            this.tabPagePrinters.Controls.Add(this.cbSettingsPrintShipLabels);
            this.tabPagePrinters.Controls.Add(this.cbSettingsShipLabelZebra);
            this.tabPagePrinters.Controls.Add(this.cbSettingsTagPrinterZebra);
            this.tabPagePrinters.Controls.Add(this.labelShippingLabels);
            this.tabPagePrinters.Controls.Add(this.comboBoxShippingLabelPrinter);
            this.tabPagePrinters.Controls.Add(this.labelTagPrinter);
            this.tabPagePrinters.Controls.Add(this.comboBoxTagLabelPrinter);
            this.tabPagePrinters.Location = new System.Drawing.Point(4, 25);
            this.tabPagePrinters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePrinters.Name = "tabPagePrinters";
            this.tabPagePrinters.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePrinters.Size = new System.Drawing.Size(1135, 623);
            this.tabPagePrinters.TabIndex = 1;
            this.tabPagePrinters.Text = "Printers";
            this.tabPagePrinters.UseVisualStyleBackColor = true;
            // 
            // cbSettingsOverideShipLabelPrint
            // 
            this.cbSettingsOverideShipLabelPrint.AutoSize = true;
            this.cbSettingsOverideShipLabelPrint.Location = new System.Drawing.Point(805, 362);
            this.cbSettingsOverideShipLabelPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSettingsOverideShipLabelPrint.Name = "cbSettingsOverideShipLabelPrint";
            this.cbSettingsOverideShipLabelPrint.Size = new System.Drawing.Size(155, 20);
            this.cbSettingsOverideShipLabelPrint.TabIndex = 15;
            this.cbSettingsOverideShipLabelPrint.Text = "Print Shipping Labels";
            this.cbSettingsOverideShipLabelPrint.UseVisualStyleBackColor = true;
            // 
            // cbOverideShipZebra
            // 
            this.cbOverideShipZebra.AutoSize = true;
            this.cbOverideShipZebra.Location = new System.Drawing.Point(660, 365);
            this.cbOverideShipZebra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbOverideShipZebra.Name = "cbOverideShipZebra";
            this.cbOverideShipZebra.Size = new System.Drawing.Size(106, 20);
            this.cbOverideShipZebra.TabIndex = 14;
            this.cbOverideShipZebra.Text = "Zebra Printer";
            this.cbOverideShipZebra.UseVisualStyleBackColor = true;
            // 
            // cbSettingsOverideTagZebra
            // 
            this.cbSettingsOverideTagZebra.AutoSize = true;
            this.cbSettingsOverideTagZebra.Location = new System.Drawing.Point(660, 295);
            this.cbSettingsOverideTagZebra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSettingsOverideTagZebra.Name = "cbSettingsOverideTagZebra";
            this.cbSettingsOverideTagZebra.Size = new System.Drawing.Size(106, 20);
            this.cbSettingsOverideTagZebra.TabIndex = 13;
            this.cbSettingsOverideTagZebra.Text = "Zebra Printer";
            this.cbSettingsOverideTagZebra.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Shipping Labels";
            // 
            // comboBoxOverideShipPrinter
            // 
            this.comboBoxOverideShipPrinter.FormattingEnabled = true;
            this.comboBoxOverideShipPrinter.Location = new System.Drawing.Point(179, 364);
            this.comboBoxOverideShipPrinter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxOverideShipPrinter.Name = "comboBoxOverideShipPrinter";
            this.comboBoxOverideShipPrinter.Size = new System.Drawing.Size(436, 24);
            this.comboBoxOverideShipPrinter.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(93, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Tag Printer";
            // 
            // comboBoxOverideTagPrinter
            // 
            this.comboBoxOverideTagPrinter.FormattingEnabled = true;
            this.comboBoxOverideTagPrinter.Location = new System.Drawing.Point(179, 290);
            this.comboBoxOverideTagPrinter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxOverideTagPrinter.Name = "comboBoxOverideTagPrinter";
            this.comboBoxOverideTagPrinter.Size = new System.Drawing.Size(437, 24);
            this.comboBoxOverideTagPrinter.TabIndex = 9;
            this.comboBoxOverideTagPrinter.SelectedIndexChanged += new System.EventHandler(this.comboBoxOverideTagPrinter_SelectedIndexChanged);
            // 
            // lblPrintSetLocationOveride
            // 
            this.lblPrintSetLocationOveride.AutoSize = true;
            this.lblPrintSetLocationOveride.Location = new System.Drawing.Point(29, 217);
            this.lblPrintSetLocationOveride.Name = "lblPrintSetLocationOveride";
            this.lblPrintSetLocationOveride.Size = new System.Drawing.Size(150, 16);
            this.lblPrintSetLocationOveride.TabIndex = 8;
            this.lblPrintSetLocationOveride.Text = "Overide Location Printer";
            // 
            // comboBoxSettingOverideCity
            // 
            this.comboBoxSettingOverideCity.FormattingEnabled = true;
            this.comboBoxSettingOverideCity.Location = new System.Drawing.Point(32, 236);
            this.comboBoxSettingOverideCity.Name = "comboBoxSettingOverideCity";
            this.comboBoxSettingOverideCity.Size = new System.Drawing.Size(149, 24);
            this.comboBoxSettingOverideCity.TabIndex = 7;
            this.comboBoxSettingOverideCity.SelectedIndexChanged += new System.EventHandler(this.comboBoxSettingOverideCity_SelectedIndexChanged);
            // 
            // cbSettingsPrintShipLabels
            // 
            this.cbSettingsPrintShipLabels.AutoSize = true;
            this.cbSettingsPrintShipLabels.Location = new System.Drawing.Point(805, 124);
            this.cbSettingsPrintShipLabels.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSettingsPrintShipLabels.Name = "cbSettingsPrintShipLabels";
            this.cbSettingsPrintShipLabels.Size = new System.Drawing.Size(155, 20);
            this.cbSettingsPrintShipLabels.TabIndex = 6;
            this.cbSettingsPrintShipLabels.Text = "Print Shipping Labels";
            this.cbSettingsPrintShipLabels.UseVisualStyleBackColor = true;
            this.cbSettingsPrintShipLabels.CheckedChanged += new System.EventHandler(this.cbSettingsPrintShipLabels_CheckedChanged);
            // 
            // cbSettingsShipLabelZebra
            // 
            this.cbSettingsShipLabelZebra.AutoSize = true;
            this.cbSettingsShipLabelZebra.Location = new System.Drawing.Point(660, 127);
            this.cbSettingsShipLabelZebra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSettingsShipLabelZebra.Name = "cbSettingsShipLabelZebra";
            this.cbSettingsShipLabelZebra.Size = new System.Drawing.Size(106, 20);
            this.cbSettingsShipLabelZebra.TabIndex = 5;
            this.cbSettingsShipLabelZebra.Text = "Zebra Printer";
            this.cbSettingsShipLabelZebra.UseVisualStyleBackColor = true;
            this.cbSettingsShipLabelZebra.CheckStateChanged += new System.EventHandler(this.cbSettingsShipLabelZebra_CheckStateChanged);
            // 
            // cbSettingsTagPrinterZebra
            // 
            this.cbSettingsTagPrinterZebra.AutoSize = true;
            this.cbSettingsTagPrinterZebra.Location = new System.Drawing.Point(660, 57);
            this.cbSettingsTagPrinterZebra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSettingsTagPrinterZebra.Name = "cbSettingsTagPrinterZebra";
            this.cbSettingsTagPrinterZebra.Size = new System.Drawing.Size(106, 20);
            this.cbSettingsTagPrinterZebra.TabIndex = 4;
            this.cbSettingsTagPrinterZebra.Text = "Zebra Printer";
            this.cbSettingsTagPrinterZebra.UseVisualStyleBackColor = true;
            this.cbSettingsTagPrinterZebra.CheckStateChanged += new System.EventHandler(this.cbSettingsTagPrinterZebra_CheckStateChanged);
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
            this.tabPageOrderFlow.Size = new System.Drawing.Size(1135, 623);
            this.tabPageOrderFlow.TabIndex = 3;
            this.tabPageOrderFlow.Text = "Order Flow";
            this.tabPageOrderFlow.UseVisualStyleBackColor = true;
            // 
            // buttonOrdFlowDelConnections
            // 
            this.buttonOrdFlowDelConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOrdFlowDelConnections.Location = new System.Drawing.Point(459, 615);
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
            this.buttonOrdFlowAddConnection.Location = new System.Drawing.Point(709, 615);
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
            this.comboBoxOrdFlowToMachine.Location = new System.Drawing.Point(432, 583);
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
            this.listViewOrderFlowMachines.Size = new System.Drawing.Size(1131, 559);
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
            this.tabPageSkidPricing.Size = new System.Drawing.Size(1135, 623);
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
            this.buttonAddPrice.Location = new System.Drawing.Point(243, 586);
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
            this.dataGridViewSkidPricing.Size = new System.Drawing.Size(1112, 425);
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
            this.tabPageProcPricing.Size = new System.Drawing.Size(1135, 623);
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
            this.buttonProcPriceDelete.Location = new System.Drawing.Point(597, 574);
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
            this.buttonProcPricAdd.Location = new System.Drawing.Point(824, 574);
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
            this.dataGridViewProcPricing.Size = new System.Drawing.Size(1121, 427);
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
            this.tabPageSteelTypes.Size = new System.Drawing.Size(1135, 623);
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
            this.dataGridViewSteelTypeAlloys.Size = new System.Drawing.Size(708, 468);
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
            this.tabPageSTPricing.Size = new System.Drawing.Size(1135, 623);
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
            this.columnHeaderSPHistoryScrap,
            this.columnHeaderSPHistoryDate});
            this.listViewSPHistory.HideSelection = false;
            this.listViewSPHistory.Location = new System.Drawing.Point(285, 26);
            this.listViewSPHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewSPHistory.Name = "listViewSPHistory";
            this.listViewSPHistory.Size = new System.Drawing.Size(253, 532);
            this.listViewSPHistory.TabIndex = 1;
            this.listViewSPHistory.UseCompatibleStateImageBehavior = false;
            this.listViewSPHistory.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSPHistoryPrice
            // 
            this.columnHeaderSPHistoryPrice.Text = "Price";
            this.columnHeaderSPHistoryPrice.Width = 44;
            // 
            // columnHeaderSPHistoryScrap
            // 
            this.columnHeaderSPHistoryScrap.Text = "ScrapPrice";
            this.columnHeaderSPHistoryScrap.Width = 87;
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
            this.chartSPHistory.Location = new System.Drawing.Point(539, 26);
            this.chartSPHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartSPHistory.Name = "chartSPHistory";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Price";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.Name = "scrapPrice";
            this.chartSPHistory.Series.Add(series1);
            this.chartSPHistory.Series.Add(series2);
            this.chartSPHistory.Size = new System.Drawing.Size(568, 532);
            this.chartSPHistory.TabIndex = 2;
            this.chartSPHistory.Text = "chart1";
            // 
            // listViewSPPrice
            // 
            this.listViewSPPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewSPPrice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSPAlloy,
            this.columnHeaderSPPrice,
            this.columnHeaderSPScrapPrice});
            this.listViewSPPrice.FullRowSelect = true;
            this.listViewSPPrice.HideSelection = false;
            this.listViewSPPrice.Location = new System.Drawing.Point(24, 26);
            this.listViewSPPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewSPPrice.Name = "listViewSPPrice";
            this.listViewSPPrice.Size = new System.Drawing.Size(256, 532);
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
            this.columnHeaderSPPrice.Width = 56;
            // 
            // columnHeaderSPScrapPrice
            // 
            this.columnHeaderSPScrapPrice.Text = "Scrap Price";
            this.columnHeaderSPScrapPrice.Width = 96;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Controls.Add(this.checkBox1);
            this.tabPageAbout.Controls.Add(this.tbTestOrderID);
            this.tabPageAbout.Controls.Add(this.richTextBox1);
            this.tabPageAbout.Controls.Add(this.labelAboutConnString);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 25);
            this.tabPageAbout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageAbout.Size = new System.Drawing.Size(1135, 623);
            this.tabPageAbout.TabIndex = 4;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(5, 7);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 20);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Debug";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tbTestOrderID
            // 
            this.tbTestOrderID.Location = new System.Drawing.Point(37, 158);
            this.tbTestOrderID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTestOrderID.Name = "tbTestOrderID";
            this.tbTestOrderID.Size = new System.Drawing.Size(100, 22);
            this.tbTestOrderID.TabIndex = 3;
            this.tbTestOrderID.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(221, 107);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(372, 260);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // labelAboutConnString
            // 
            this.labelAboutConnString.AutoSize = true;
            this.labelAboutConnString.Location = new System.Drawing.Point(49, 46);
            this.labelAboutConnString.Name = "labelAboutConnString";
            this.labelAboutConnString.Size = new System.Drawing.Size(0, 16);
            this.labelAboutConnString.TabIndex = 0;
            this.labelAboutConnString.Visible = false;
            // 
            // tabControlProcess
            // 
            this.tabControlProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlProcess.Location = new System.Drawing.Point(881, 5);
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
            this.tabControlMachines.Location = new System.Drawing.Point(881, 34);
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
            this.tabPageOrders.Controls.Add(this.panelSheetSheetSame);
            this.tabPageOrders.Controls.Add(this.panelCoilCoilSame);
            this.tabPageOrders.Controls.Add(this.panelSheetSheetDiff);
            this.tabPageOrders.Controls.Add(this.panelCoilSheetSame);
            this.tabPageOrders.Controls.Add(this.panelClClDiff);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 25);
            this.tabPageOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageOrders.Size = new System.Drawing.Size(1141, 636);
            this.tabPageOrders.TabIndex = 5;
            this.tabPageOrders.Text = "Orders";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // panelSheetSheetSame
            // 
            this.panelSheetSheetSame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSheetSheetSame.Controls.Add(this.cbShShSmPrintOpTag);
            this.panelSheetSheetSame.Controls.Add(this.btnSSSmAddTag);
            this.panelSheetSheetSame.Controls.Add(this.btnOrderShShSameDeleteRow);
            this.panelSheetSheetSame.Controls.Add(this.btnShShModifyDelete);
            this.panelSheetSheetSame.Controls.Add(this.btnShShSmAdderDone);
            this.panelSheetSheetSame.Controls.Add(this.lblShShSmPaperPrice);
            this.panelSheetSheetSame.Controls.Add(this.tbShShSmPaperPrice);
            this.panelSheetSheetSame.Controls.Add(this.dgvShShSmAdders);
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
            this.panelSheetSheetSame.Controls.Add(this.dataGridViewSSSmSkid);
            this.panelSheetSheetSame.Controls.Add(this.listViewSSSmSkidData);
            this.panelSheetSheetSame.Controls.Add(this.buttonSSSmAddOrder);
            this.panelSheetSheetSame.Controls.Add(this.buttonSSSmStartOrder);
            this.panelSheetSheetSame.Location = new System.Drawing.Point(0, 4);
            this.panelSheetSheetSame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSheetSheetSame.Name = "panelSheetSheetSame";
            this.panelSheetSheetSame.Size = new System.Drawing.Size(1137, 626);
            this.panelSheetSheetSame.TabIndex = 3;
            this.panelSheetSheetSame.VisibleChanged += new System.EventHandler(this.PanelSheetSheetSame_VisibleChanged);
            // 
            // cbShShSmPrintOpTag
            // 
            this.cbShShSmPrintOpTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShShSmPrintOpTag.AutoSize = true;
            this.cbShShSmPrintOpTag.Checked = true;
            this.cbShShSmPrintOpTag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShShSmPrintOpTag.Location = new System.Drawing.Point(926, 489);
            this.cbShShSmPrintOpTag.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbShShSmPrintOpTag.Name = "cbShShSmPrintOpTag";
            this.cbShShSmPrintOpTag.Size = new System.Drawing.Size(146, 20);
            this.cbShShSmPrintOpTag.TabIndex = 73;
            this.cbShShSmPrintOpTag.Text = "Print Operator Tags";
            this.cbShShSmPrintOpTag.UseVisualStyleBackColor = true;
            this.cbShShSmPrintOpTag.CheckedChanged += new System.EventHandler(this.cbShShSmPrintOpTag_CheckedChanged);
            // 
            // btnSSSmAddTag
            // 
            this.btnSSSmAddTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSSSmAddTag.Location = new System.Drawing.Point(141, 485);
            this.btnSSSmAddTag.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSSSmAddTag.Name = "btnSSSmAddTag";
            this.btnSSSmAddTag.Size = new System.Drawing.Size(97, 25);
            this.btnSSSmAddTag.TabIndex = 72;
            this.btnSSSmAddTag.Text = "Add Tag";
            this.btnSSSmAddTag.UseVisualStyleBackColor = true;
            this.btnSSSmAddTag.Visible = false;
            this.btnSSSmAddTag.Click += new System.EventHandler(this.btnSSSmAddTag_Click);
            // 
            // btnOrderShShSameDeleteRow
            // 
            this.btnOrderShShSameDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrderShShSameDeleteRow.Location = new System.Drawing.Point(725, 475);
            this.btnOrderShShSameDeleteRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrderShShSameDeleteRow.Name = "btnOrderShShSameDeleteRow";
            this.btnOrderShShSameDeleteRow.Size = new System.Drawing.Size(163, 32);
            this.btnOrderShShSameDeleteRow.TabIndex = 71;
            this.btnOrderShShSameDeleteRow.Text = "Delete Row";
            this.btnOrderShShSameDeleteRow.UseVisualStyleBackColor = true;
            this.btnOrderShShSameDeleteRow.Click += new System.EventHandler(this.btnOrderShShSameDeleteRow_Click);
            // 
            // btnShShModifyDelete
            // 
            this.btnShShModifyDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShShModifyDelete.Location = new System.Drawing.Point(171, 518);
            this.btnShShModifyDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShShModifyDelete.Name = "btnShShModifyDelete";
            this.btnShShModifyDelete.Size = new System.Drawing.Size(67, 30);
            this.btnShShModifyDelete.TabIndex = 70;
            this.btnShShModifyDelete.Text = "Delete";
            this.btnShShModifyDelete.UseVisualStyleBackColor = true;
            this.btnShShModifyDelete.Visible = false;
            this.btnShShModifyDelete.Click += new System.EventHandler(this.btnShShModifyDelete_Click);
            // 
            // btnShShSmAdderDone
            // 
            this.btnShShSmAdderDone.Location = new System.Drawing.Point(641, 218);
            this.btnShShSmAdderDone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShShSmAdderDone.Name = "btnShShSmAdderDone";
            this.btnShShSmAdderDone.Size = new System.Drawing.Size(93, 30);
            this.btnShShSmAdderDone.TabIndex = 69;
            this.btnShShSmAdderDone.Text = "Done";
            this.btnShShSmAdderDone.UseVisualStyleBackColor = true;
            this.btnShShSmAdderDone.Visible = false;
            this.btnShShSmAdderDone.Click += new System.EventHandler(this.btnShShSmAdderDone_Click);
            // 
            // lblShShSmPaperPrice
            // 
            this.lblShShSmPaperPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShShSmPaperPrice.AutoSize = true;
            this.lblShShSmPaperPrice.Location = new System.Drawing.Point(836, 526);
            this.lblShShSmPaperPrice.Name = "lblShShSmPaperPrice";
            this.lblShShSmPaperPrice.Size = new System.Drawing.Size(78, 16);
            this.lblShShSmPaperPrice.TabIndex = 68;
            this.lblShShSmPaperPrice.Text = "Paper Price";
            // 
            // tbShShSmPaperPrice
            // 
            this.tbShShSmPaperPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbShShSmPaperPrice.Location = new System.Drawing.Point(925, 522);
            this.tbShShSmPaperPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbShShSmPaperPrice.Name = "tbShShSmPaperPrice";
            this.tbShShSmPaperPrice.Size = new System.Drawing.Size(144, 22);
            this.tbShShSmPaperPrice.TabIndex = 67;
            // 
            // dgvShShSmAdders
            // 
            this.dgvShShSmAdders.AllowUserToAddRows = false;
            this.dgvShShSmAdders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShShSmAdders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvAdderColSelect,
            this.dgvSSSmAdderDesc,
            this.dgvSSSmAdderPrice});
            this.dgvShShSmAdders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvShShSmAdders.Location = new System.Drawing.Point(715, 39);
            this.dgvShShSmAdders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvShShSmAdders.MultiSelect = false;
            this.dgvShShSmAdders.Name = "dgvShShSmAdders";
            this.dgvShShSmAdders.RowHeadersVisible = false;
            this.dgvShShSmAdders.RowHeadersWidth = 12;
            this.dgvShShSmAdders.RowTemplate.Height = 24;
            this.dgvShShSmAdders.Size = new System.Drawing.Size(347, 174);
            this.dgvShShSmAdders.TabIndex = 66;
            this.dgvShShSmAdders.Visible = false;
            // 
            // dgvAdderColSelect
            // 
            this.dgvAdderColSelect.HeaderText = "Sel";
            this.dgvAdderColSelect.MinimumWidth = 6;
            this.dgvAdderColSelect.Name = "dgvAdderColSelect";
            this.dgvAdderColSelect.Width = 50;
            // 
            // dgvSSSmAdderDesc
            // 
            this.dgvSSSmAdderDesc.HeaderText = "Adder";
            this.dgvSSSmAdderDesc.MinimumWidth = 6;
            this.dgvSSSmAdderDesc.Name = "dgvSSSmAdderDesc";
            this.dgvSSSmAdderDesc.Width = 125;
            // 
            // dgvSSSmAdderPrice
            // 
            this.dgvSSSmAdderPrice.HeaderText = "Price";
            this.dgvSSSmAdderPrice.MinimumWidth = 6;
            this.dgvSSSmAdderPrice.Name = "dgvSSSmAdderPrice";
            this.dgvSSSmAdderPrice.Width = 125;
            // 
            // btnSSMCancel
            // 
            this.btnSSMCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSSMCancel.Location = new System.Drawing.Point(791, 578);
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
            this.labelSSSmSpecialLeadTime.Location = new System.Drawing.Point(531, 591);
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
            this.textBoxSSSmRunSheet.Location = new System.Drawing.Point(641, 548);
            this.textBoxSSSmRunSheet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSSSmRunSheet.Name = "textBoxSSSmRunSheet";
            this.textBoxSSSmRunSheet.Size = new System.Drawing.Size(424, 22);
            this.textBoxSSSmRunSheet.TabIndex = 55;
            this.textBoxSSSmRunSheet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSSSmRunSheet_KeyPress);
            // 
            // labelSSSmRunSheet
            // 
            this.labelSSSmRunSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSSmRunSheet.AutoSize = true;
            this.labelSSSmRunSheet.Location = new System.Drawing.Point(489, 553);
            this.labelSSSmRunSheet.Name = "labelSSSmRunSheet";
            this.labelSSSmRunSheet.Size = new System.Drawing.Size(136, 16);
            this.labelSSSmRunSheet.TabIndex = 60;
            this.labelSSSmRunSheet.Text = "Run Sheet Comments";
            // 
            // comboBoxSSSmModify
            // 
            this.comboBoxSSSmModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxSSSmModify.FormattingEnabled = true;
            this.comboBoxSSSmModify.Location = new System.Drawing.Point(25, 521);
            this.comboBoxSSSmModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSSSmModify.Name = "comboBoxSSSmModify";
            this.comboBoxSSSmModify.Size = new System.Drawing.Size(141, 24);
            this.comboBoxSSSmModify.TabIndex = 48;
            this.comboBoxSSSmModify.Visible = false;
            this.comboBoxSSSmModify.SelectedIndexChanged += new System.EventHandler(this.comboBoxSSSmModify_SelectedIndexChanged);
            // 
            // checkBoxSSSmModify
            // 
            this.checkBoxSSSmModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxSSSmModify.AutoSize = true;
            this.checkBoxSSSmModify.Location = new System.Drawing.Point(3, 496);
            this.checkBoxSSSmModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxSSSmModify.Name = "checkBoxSSSmModify";
            this.checkBoxSSSmModify.Size = new System.Drawing.Size(69, 20);
            this.checkBoxSSSmModify.TabIndex = 47;
            this.checkBoxSSSmModify.Text = "Modify";
            this.checkBoxSSSmModify.UseVisualStyleBackColor = true;
            this.checkBoxSSSmModify.CheckedChanged += new System.EventHandler(this.checkBoxSSSmModify_CheckedChanged);
            // 
            // comboBoxSSSmMulti
            // 
            this.comboBoxSSSmMulti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxSSSmMulti.FormattingEnabled = true;
            this.comboBoxSSSmMulti.Location = new System.Drawing.Point(25, 575);
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
            this.checkBoxSSSmMultiStep.Location = new System.Drawing.Point(5, 554);
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
            this.labelSSSmPrice.Location = new System.Drawing.Point(489, 501);
            this.labelSSSmPrice.Name = "labelSSSmPrice";
            this.labelSSSmPrice.Size = new System.Drawing.Size(38, 16);
            this.labelSSSmPrice.TabIndex = 59;
            this.labelSSSmPrice.Text = "Price";
            // 
            // labelSSSmPO
            // 
            this.labelSSSmPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSSmPO.AutoSize = true;
            this.labelSSSmPO.Location = new System.Drawing.Point(489, 526);
            this.labelSSSmPO.Name = "labelSSSmPO";
            this.labelSSSmPO.Size = new System.Drawing.Size(101, 16);
            this.labelSSSmPO.TabIndex = 58;
            this.labelSSSmPO.Text = "Purchase Order";
            // 
            // labelSSSmPromiseDate
            // 
            this.labelSSSmPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSSmPromiseDate.AutoSize = true;
            this.labelSSSmPromiseDate.Location = new System.Drawing.Point(245, 569);
            this.labelSSSmPromiseDate.Name = "labelSSSmPromiseDate";
            this.labelSSSmPromiseDate.Size = new System.Drawing.Size(89, 16);
            this.labelSSSmPromiseDate.TabIndex = 57;
            this.labelSSSmPromiseDate.Text = "Promise Date";
            // 
            // textBoxSSSmPO
            // 
            this.textBoxSSSmPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSSSmPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxSSSmPO.Location = new System.Drawing.Point(603, 524);
            this.textBoxSSSmPO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSSSmPO.Name = "textBoxSSSmPO";
            this.textBoxSSSmPO.Size = new System.Drawing.Size(227, 22);
            this.textBoxSSSmPO.TabIndex = 54;
            this.textBoxSSSmPO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSSSmPO_KeyPress);
            // 
            // textBoxSSSmPrice
            // 
            this.textBoxSSSmPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSSSmPrice.Location = new System.Drawing.Point(533, 498);
            this.textBoxSSSmPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSSSmPrice.Name = "textBoxSSSmPrice";
            this.textBoxSSSmPrice.Size = new System.Drawing.Size(112, 22);
            this.textBoxSSSmPrice.TabIndex = 53;
            this.textBoxSSSmPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSSSmPrice_KeyPress);
            // 
            // dateTimePickerSSSmPromiseDate
            // 
            this.dateTimePickerSSSmPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerSSSmPromiseDate.Location = new System.Drawing.Point(247, 592);
            this.dateTimePickerSSSmPromiseDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerSSSmPromiseDate.Name = "dateTimePickerSSSmPromiseDate";
            this.dateTimePickerSSSmPromiseDate.Size = new System.Drawing.Size(272, 22);
            this.dateTimePickerSSSmPromiseDate.TabIndex = 52;
            // 
            // richTextBoxSSSmComments
            // 
            this.richTextBoxSSSmComments.AcceptsTab = true;
            this.richTextBoxSSSmComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxSSSmComments.Location = new System.Drawing.Point(247, 489);
            this.richTextBoxSSSmComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxSSSmComments.Name = "richTextBoxSSSmComments";
            this.richTextBoxSSSmComments.Size = new System.Drawing.Size(239, 74);
            this.richTextBoxSSSmComments.TabIndex = 51;
            this.richTextBoxSSSmComments.Text = "";
            this.richTextBoxSSSmComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxSSSmComments_KeyPress);
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
            this.dgvSSSmAdders,
            this.dgvSSSmBranchID,
            this.dgvSSSmAdderID,
            this.dgvSSSmAdderPriceCol,
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
            this.dataGridViewSSSmSkid.Size = new System.Drawing.Size(1129, 464);
            this.dataGridViewSSSmSkid.TabIndex = 64;
            this.dataGridViewSSSmSkid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSSSmSkid_CellClick);
            this.dataGridViewSSSmSkid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewSSSmSkid_CellContentClick);
            this.dataGridViewSSSmSkid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewSSSmSkid_EditingControlShowing);
            this.dataGridViewSSSmSkid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewSSSmSkid_MouseClick);
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
            this.dgvSSSmComments.MaxInputLength = 50;
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
            // dgvSSSmAdders
            // 
            this.dgvSSSmAdders.HeaderText = "Adders";
            this.dgvSSSmAdders.MinimumWidth = 6;
            this.dgvSSSmAdders.Name = "dgvSSSmAdders";
            this.dgvSSSmAdders.Width = 57;
            // 
            // dgvSSSmBranchID
            // 
            this.dgvSSSmBranchID.HeaderText = "BranchID";
            this.dgvSSSmBranchID.MinimumWidth = 6;
            this.dgvSSSmBranchID.Name = "dgvSSSmBranchID";
            this.dgvSSSmBranchID.Visible = false;
            this.dgvSSSmBranchID.Width = 68;
            // 
            // dgvSSSmAdderID
            // 
            this.dgvSSSmAdderID.HeaderText = "Adder ID";
            this.dgvSSSmAdderID.MinimumWidth = 6;
            this.dgvSSSmAdderID.Name = "dgvSSSmAdderID";
            this.dgvSSSmAdderID.Visible = false;
            this.dgvSSSmAdderID.Width = 66;
            // 
            // dgvSSSmAdderPriceCol
            // 
            this.dgvSSSmAdderPriceCol.HeaderText = "Adder Price";
            this.dgvSSSmAdderPriceCol.MinimumWidth = 6;
            this.dgvSSSmAdderPriceCol.Name = "dgvSSSmAdderPriceCol";
            this.dgvSSSmAdderPriceCol.Visible = false;
            this.dgvSSSmAdderPriceCol.Width = 84;
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
            this.listViewSSSmSkidData.Size = new System.Drawing.Size(1125, 466);
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
            // buttonSSSmAddOrder
            // 
            this.buttonSSSmAddOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSSSmAddOrder.Location = new System.Drawing.Point(960, 576);
            this.buttonSSSmAddOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSSSmAddOrder.Name = "buttonSSSmAddOrder";
            this.buttonSSSmAddOrder.Size = new System.Drawing.Size(163, 32);
            this.buttonSSSmAddOrder.TabIndex = 63;
            this.buttonSSSmAddOrder.Text = "Add Order";
            this.buttonSSSmAddOrder.UseVisualStyleBackColor = true;
            this.buttonSSSmAddOrder.TextChanged += new System.EventHandler(this.buttonSSSmAddOrder_TextChanged);
            this.buttonSSSmAddOrder.Click += new System.EventHandler(this.ButtonSSmAddOrder_Click);
            // 
            // buttonSSSmStartOrder
            // 
            this.buttonSSSmStartOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSSSmStartOrder.Location = new System.Drawing.Point(960, 578);
            this.buttonSSSmStartOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSSSmStartOrder.Name = "buttonSSSmStartOrder";
            this.buttonSSSmStartOrder.Size = new System.Drawing.Size(163, 32);
            this.buttonSSSmStartOrder.TabIndex = 56;
            this.buttonSSSmStartOrder.Text = "Start Order";
            this.buttonSSSmStartOrder.UseVisualStyleBackColor = true;
            this.buttonSSSmStartOrder.Click += new System.EventHandler(this.ButtonSSSmStartOrder_Click);
            // 
            // panelCoilCoilSame
            // 
            this.panelCoilCoilSame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCoilCoilSame.Controls.Add(this.lblClClSmPaperPrice);
            this.panelCoilCoilSame.Controls.Add(this.tbClClSmPaperPrice);
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
            this.panelCoilCoilSame.Controls.Add(this.buttonClClSameAddOrder);
            this.panelCoilCoilSame.Controls.Add(this.buttonCLCLSameStartOrder);
            this.panelCoilCoilSame.Location = new System.Drawing.Point(1, 7);
            this.panelCoilCoilSame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCoilCoilSame.Name = "panelCoilCoilSame";
            this.panelCoilCoilSame.Size = new System.Drawing.Size(1136, 626);
            this.panelCoilCoilSame.TabIndex = 0;
            this.panelCoilCoilSame.Visible = false;
            this.panelCoilCoilSame.VisibleChanged += new System.EventHandler(this.PanelCoilCoilSame_VisibleChanged);
            // 
            // lblClClSmPaperPrice
            // 
            this.lblClClSmPaperPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblClClSmPaperPrice.AutoSize = true;
            this.lblClClSmPaperPrice.Location = new System.Drawing.Point(695, 516);
            this.lblClClSmPaperPrice.Name = "lblClClSmPaperPrice";
            this.lblClClSmPaperPrice.Size = new System.Drawing.Size(78, 16);
            this.lblClClSmPaperPrice.TabIndex = 21;
            this.lblClClSmPaperPrice.Text = "Paper Price";
            // 
            // tbClClSmPaperPrice
            // 
            this.tbClClSmPaperPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbClClSmPaperPrice.Location = new System.Drawing.Point(695, 535);
            this.tbClClSmPaperPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbClClSmPaperPrice.Name = "tbClClSmPaperPrice";
            this.tbClClSmPaperPrice.Size = new System.Drawing.Size(112, 22);
            this.tbClClSmPaperPrice.TabIndex = 20;
            this.tbClClSmPaperPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbClClSmPaperPrice_KeyPress);
            // 
            // buttonClClSameDelete
            // 
            this.buttonClClSameDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClClSameDelete.Location = new System.Drawing.Point(184, 489);
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
            this.comboBoxClClSameModify.Location = new System.Drawing.Point(35, 505);
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
            this.checkBoxClClSameModify.Location = new System.Drawing.Point(13, 483);
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
            this.labelClClSameMultiToMachine.Location = new System.Drawing.Point(32, 560);
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
            this.comboBoxClClSameToMachine.Location = new System.Drawing.Point(35, 580);
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
            this.checkBoxClClSameMultiStep.Location = new System.Drawing.Point(13, 540);
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
            this.buttonClClSameReset.Location = new System.Drawing.Point(929, 494);
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
            this.labelClClSamePrice.Location = new System.Drawing.Point(565, 516);
            this.labelClClSamePrice.Name = "labelClClSamePrice";
            this.labelClClSamePrice.Size = new System.Drawing.Size(38, 16);
            this.labelClClSamePrice.TabIndex = 11;
            this.labelClClSamePrice.Text = "Price";
            // 
            // labelClClSamePO
            // 
            this.labelClClSamePO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClClSamePO.AutoSize = true;
            this.labelClClSamePO.Location = new System.Drawing.Point(565, 569);
            this.labelClClSamePO.Name = "labelClClSamePO";
            this.labelClClSamePO.Size = new System.Drawing.Size(101, 16);
            this.labelClClSamePO.TabIndex = 10;
            this.labelClClSamePO.Text = "Purchase Order";
            // 
            // labelClClSamePromiseDate
            // 
            this.labelClClSamePromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClClSamePromiseDate.AutoSize = true;
            this.labelClClSamePromiseDate.Location = new System.Drawing.Point(267, 569);
            this.labelClClSamePromiseDate.Name = "labelClClSamePromiseDate";
            this.labelClClSamePromiseDate.Size = new System.Drawing.Size(89, 16);
            this.labelClClSamePromiseDate.TabIndex = 9;
            this.labelClClSamePromiseDate.Text = "Promise Date";
            // 
            // checkBoxClClSameScrap
            // 
            this.checkBoxClClSameScrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxClClSameScrap.AutoSize = true;
            this.checkBoxClClSameScrap.Location = new System.Drawing.Point(565, 489);
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
            this.textBoxClClSamePO.Location = new System.Drawing.Point(565, 588);
            this.textBoxClClSamePO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClClSamePO.Name = "textBoxClClSamePO";
            this.textBoxClClSamePO.Size = new System.Drawing.Size(227, 22);
            this.textBoxClClSamePO.TabIndex = 7;
            this.textBoxClClSamePO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxClClSamePO_KeyPress);
            // 
            // textBoxClClSamePrice
            // 
            this.textBoxClClSamePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxClClSamePrice.Location = new System.Drawing.Point(565, 535);
            this.textBoxClClSamePrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClClSamePrice.Name = "textBoxClClSamePrice";
            this.textBoxClClSamePrice.Size = new System.Drawing.Size(112, 22);
            this.textBoxClClSamePrice.TabIndex = 6;
            this.textBoxClClSamePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxClClSamePrice_KeyPress);
            // 
            // dateTimePickerClClSamePromise
            // 
            this.dateTimePickerClClSamePromise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerClClSamePromise.Location = new System.Drawing.Point(269, 588);
            this.dateTimePickerClClSamePromise.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerClClSamePromise.Name = "dateTimePickerClClSamePromise";
            this.dateTimePickerClClSamePromise.Size = new System.Drawing.Size(272, 22);
            this.dateTimePickerClClSamePromise.TabIndex = 5;
            // 
            // richTextBoxClClSameComments
            // 
            this.richTextBoxClClSameComments.AcceptsTab = true;
            this.richTextBoxClClSameComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxClClSameComments.Location = new System.Drawing.Point(269, 484);
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
            this.dataGridViewCLCLSame.Size = new System.Drawing.Size(1128, 462);
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
            this.colClClSameNewFinishID.Width = 66;
            // 
            // colClClSameCoilFinish
            // 
            this.colClClSameCoilFinish.HeaderText = "CoilFinishes";
            this.colClClSameCoilFinish.MinimumWidth = 6;
            this.colClClSameCoilFinish.Name = "colClClSameCoilFinish";
            this.colClClSameCoilFinish.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colClClSameCoilFinish.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colClClSameCoilFinish.Visible = false;
            this.colClClSameCoilFinish.Width = 87;
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
            this.listViewClClSame.Size = new System.Drawing.Size(1128, 462);
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
            // buttonClClSameAddOrder
            // 
            this.buttonClClSameAddOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClClSameAddOrder.Location = new System.Drawing.Point(929, 565);
            this.buttonClClSameAddOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClClSameAddOrder.Name = "buttonClClSameAddOrder";
            this.buttonClClSameAddOrder.Size = new System.Drawing.Size(165, 36);
            this.buttonClClSameAddOrder.TabIndex = 12;
            this.buttonClClSameAddOrder.Text = "AddOrder";
            this.buttonClClSameAddOrder.UseVisualStyleBackColor = true;
            this.buttonClClSameAddOrder.Visible = false;
            this.buttonClClSameAddOrder.Click += new System.EventHandler(this.ButtonClClSameAddOrder_Click);
            // 
            // buttonCLCLSameStartOrder
            // 
            this.buttonCLCLSameStartOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCLCLSameStartOrder.Location = new System.Drawing.Point(929, 565);
            this.buttonCLCLSameStartOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCLCLSameStartOrder.Name = "buttonCLCLSameStartOrder";
            this.buttonCLCLSameStartOrder.Size = new System.Drawing.Size(165, 36);
            this.buttonCLCLSameStartOrder.TabIndex = 1;
            this.buttonCLCLSameStartOrder.Text = "Start Order";
            this.buttonCLCLSameStartOrder.UseVisualStyleBackColor = true;
            this.buttonCLCLSameStartOrder.Click += new System.EventHandler(this.ButtonClClSameStartOrder_Click);
            // 
            // panelSheetSheetDiff
            // 
            this.panelSheetSheetDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSheetSheetDiff.Controls.Add(this.panelSSDOrderEntry);
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
            this.panelSheetSheetDiff.Controls.Add(this.listViewSSD);
            this.panelSheetSheetDiff.Controls.Add(this.buttonSSDStartOrder);
            this.panelSheetSheetDiff.Location = new System.Drawing.Point(3, 5);
            this.panelSheetSheetDiff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelSheetSheetDiff.Name = "panelSheetSheetDiff";
            this.panelSheetSheetDiff.Size = new System.Drawing.Size(1131, 628);
            this.panelSheetSheetDiff.TabIndex = 4;
            this.panelSheetSheetDiff.VisibleChanged += new System.EventHandler(this.PanelSheetSheetDiff_VisibleChanged);
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
            this.panelSSDOrderEntry.Size = new System.Drawing.Size(1119, 434);
            this.panelSSDOrderEntry.TabIndex = 81;
            this.panelSSDOrderEntry.Visible = false;
            this.panelSSDOrderEntry.VisibleChanged += new System.EventHandler(this.PanelSSDOrderEntry_VisibleChanged);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearAll.Location = new System.Drawing.Point(915, 393);
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
            this.buttonAddCuts.Location = new System.Drawing.Point(768, 393);
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
            this.treeViewSSD.Location = new System.Drawing.Point(768, 9);
            this.treeViewSSD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeViewSSD.Name = "treeViewSSD";
            this.treeViewSSD.Size = new System.Drawing.Size(337, 381);
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
            this.dgvSSDItems.Size = new System.Drawing.Size(749, 382);
            this.dgvSSDItems.TabIndex = 2;
            this.dgvSSDItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSSDItems_EditingControlShowing);
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
            // buttonSSDCancelOrder
            // 
            this.buttonSSDCancelOrder.Location = new System.Drawing.Point(949, 437);
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
            this.labelSSDSpecialLeadTime.Location = new System.Drawing.Point(547, 562);
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
            this.textBoxSSDRunSheetComments.Location = new System.Drawing.Point(657, 521);
            this.textBoxSSDRunSheetComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSSDRunSheetComments.Name = "textBoxSSDRunSheetComments";
            this.textBoxSSDRunSheetComments.Size = new System.Drawing.Size(411, 22);
            this.textBoxSSDRunSheetComments.TabIndex = 72;
            this.textBoxSSDRunSheetComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSSDRunSheetComments_KeyPress);
            // 
            // labelSSDRunSheetComments
            // 
            this.labelSSDRunSheetComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSDRunSheetComments.AutoSize = true;
            this.labelSSDRunSheetComments.Location = new System.Drawing.Point(505, 526);
            this.labelSSDRunSheetComments.Name = "labelSSDRunSheetComments";
            this.labelSSDRunSheetComments.Size = new System.Drawing.Size(136, 16);
            this.labelSSDRunSheetComments.TabIndex = 77;
            this.labelSSDRunSheetComments.Text = "Run Sheet Comments";
            // 
            // comboBoxSSDModify
            // 
            this.comboBoxSSDModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxSSDModify.FormattingEnabled = true;
            this.comboBoxSSDModify.Location = new System.Drawing.Point(41, 473);
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
            this.checkBoxSSDModify.Location = new System.Drawing.Point(19, 451);
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
            this.comboBoxSSDMultiStep.Location = new System.Drawing.Point(41, 548);
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
            this.checkBoxSSDMultiStep.Location = new System.Drawing.Point(19, 508);
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
            this.labelSSDPrice.Location = new System.Drawing.Point(505, 473);
            this.labelSSDPrice.Name = "labelSSDPrice";
            this.labelSSDPrice.Size = new System.Drawing.Size(38, 16);
            this.labelSSDPrice.TabIndex = 76;
            this.labelSSDPrice.Text = "Price";
            // 
            // labelSSDPO
            // 
            this.labelSSDPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSDPO.AutoSize = true;
            this.labelSSDPO.Location = new System.Drawing.Point(505, 498);
            this.labelSSDPO.Name = "labelSSDPO";
            this.labelSSDPO.Size = new System.Drawing.Size(101, 16);
            this.labelSSDPO.TabIndex = 75;
            this.labelSSDPO.Text = "Purchase Order";
            // 
            // labelSSDPromiseDate
            // 
            this.labelSSDPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSSDPromiseDate.AutoSize = true;
            this.labelSSDPromiseDate.Location = new System.Drawing.Point(261, 542);
            this.labelSSDPromiseDate.Name = "labelSSDPromiseDate";
            this.labelSSDPromiseDate.Size = new System.Drawing.Size(89, 16);
            this.labelSSDPromiseDate.TabIndex = 74;
            this.labelSSDPromiseDate.Text = "Promise Date";
            // 
            // textBoxSSDPurchaseOrder
            // 
            this.textBoxSSDPurchaseOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSSDPurchaseOrder.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxSSDPurchaseOrder.Location = new System.Drawing.Point(619, 495);
            this.textBoxSSDPurchaseOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSSDPurchaseOrder.Name = "textBoxSSDPurchaseOrder";
            this.textBoxSSDPurchaseOrder.Size = new System.Drawing.Size(227, 22);
            this.textBoxSSDPurchaseOrder.TabIndex = 71;
            this.textBoxSSDPurchaseOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSSDPurchaseOrder_KeyPress);
            // 
            // textBoxSSDPrice
            // 
            this.textBoxSSDPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSSDPrice.Location = new System.Drawing.Point(549, 471);
            this.textBoxSSDPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSSDPrice.Name = "textBoxSSDPrice";
            this.textBoxSSDPrice.Size = new System.Drawing.Size(112, 22);
            this.textBoxSSDPrice.TabIndex = 70;
            // 
            // dateTimePickerSSDPromiseDate
            // 
            this.dateTimePickerSSDPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerSSDPromiseDate.Location = new System.Drawing.Point(263, 564);
            this.dateTimePickerSSDPromiseDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerSSDPromiseDate.Name = "dateTimePickerSSDPromiseDate";
            this.dateTimePickerSSDPromiseDate.Size = new System.Drawing.Size(272, 22);
            this.dateTimePickerSSDPromiseDate.TabIndex = 69;
            // 
            // richTextBoxSSDComments
            // 
            this.richTextBoxSSDComments.AcceptsTab = true;
            this.richTextBoxSSDComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxSSDComments.Location = new System.Drawing.Point(263, 462);
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
            this.buttonSSDAddOrder.Location = new System.Drawing.Point(709, 560);
            this.buttonSSDAddOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSSDAddOrder.Name = "buttonSSDAddOrder";
            this.buttonSSDAddOrder.Size = new System.Drawing.Size(163, 32);
            this.buttonSSDAddOrder.TabIndex = 79;
            this.buttonSSDAddOrder.Text = "Add Order";
            this.buttonSSDAddOrder.UseVisualStyleBackColor = true;
            this.buttonSSDAddOrder.Visible = false;
            this.buttonSSDAddOrder.Click += new System.EventHandler(this.ButtonSSDAddOrder_Click);
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
            this.listViewSSD.Size = new System.Drawing.Size(1121, 434);
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
            // buttonSSDStartOrder
            // 
            this.buttonSSDStartOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSSDStartOrder.Location = new System.Drawing.Point(895, 562);
            this.buttonSSDStartOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSSDStartOrder.Name = "buttonSSDStartOrder";
            this.buttonSSDStartOrder.Size = new System.Drawing.Size(163, 32);
            this.buttonSSDStartOrder.TabIndex = 73;
            this.buttonSSDStartOrder.Text = "Start Order";
            this.buttonSSDStartOrder.UseVisualStyleBackColor = true;
            this.buttonSSDStartOrder.Click += new System.EventHandler(this.ButtonSSDStartOrder_Click);
            // 
            // panelCoilSheetSame
            // 
            this.panelCoilSheetSame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCoilSheetSame.Controls.Add(this.cbCTLWeightCalc);
            this.panelCoilSheetSame.Controls.Add(this.btnOrderCTLAddTag);
            this.panelCoilSheetSame.Controls.Add(this.cbCTLPaperDefault);
            this.panelCoilSheetSame.Controls.Add(this.cbCTLPrintOperatorTags);
            this.panelCoilSheetSame.Controls.Add(this.buttonCTLReset);
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
            this.panelCoilSheetSame.Controls.Add(this.labelCTLPrice);
            this.panelCoilSheetSame.Controls.Add(this.labelCTLPO);
            this.panelCoilSheetSame.Controls.Add(this.labelCTLPromiseDate);
            this.panelCoilSheetSame.Controls.Add(this.checkBoxCTLScrapCredit);
            this.panelCoilSheetSame.Controls.Add(this.textBoxCTLPO);
            this.panelCoilSheetSame.Controls.Add(this.textBoxCTLPrice);
            this.panelCoilSheetSame.Controls.Add(this.dateTimePickerCTLPromiseDate);
            this.panelCoilSheetSame.Controls.Add(this.richTextBoxCTLComments);
            this.panelCoilSheetSame.Controls.Add(this.buttonCTLArrowDown);
            this.panelCoilSheetSame.Controls.Add(this.buttonCTLArrowUp);
            this.panelCoilSheetSame.Controls.Add(this.dataGridViewCTLOrderEntry);
            this.panelCoilSheetSame.Controls.Add(this.listViewCTLCoilList);
            this.panelCoilSheetSame.Controls.Add(this.buttonCTLAddOrder);
            this.panelCoilSheetSame.Controls.Add(this.buttonCTLStartOrder);
            this.panelCoilSheetSame.Location = new System.Drawing.Point(-3, 7);
            this.panelCoilSheetSame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCoilSheetSame.Name = "panelCoilSheetSame";
            this.panelCoilSheetSame.Size = new System.Drawing.Size(1140, 623);
            this.panelCoilSheetSame.TabIndex = 0;
            this.panelCoilSheetSame.Visible = false;
            this.panelCoilSheetSame.VisibleChanged += new System.EventHandler(this.PanelCoilSheetSame_VisibleChanged);
            // 
            // cbCTLWeightCalc
            // 
            this.cbCTLWeightCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCTLWeightCalc.AutoSize = true;
            this.cbCTLWeightCalc.Location = new System.Drawing.Point(941, 528);
            this.cbCTLWeightCalc.Margin = new System.Windows.Forms.Padding(4);
            this.cbCTLWeightCalc.Name = "cbCTLWeightCalc";
            this.cbCTLWeightCalc.Size = new System.Drawing.Size(66, 20);
            this.cbCTLWeightCalc.TabIndex = 52;
            this.cbCTLWeightCalc.Text = "Actual";
            this.cbCTLWeightCalc.UseVisualStyleBackColor = true;
            // 
            // btnOrderCTLAddTag
            // 
            this.btnOrderCTLAddTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOrderCTLAddTag.Location = new System.Drawing.Point(155, 464);
            this.btnOrderCTLAddTag.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrderCTLAddTag.Name = "btnOrderCTLAddTag";
            this.btnOrderCTLAddTag.Size = new System.Drawing.Size(85, 30);
            this.btnOrderCTLAddTag.TabIndex = 51;
            this.btnOrderCTLAddTag.Text = "Add Tag";
            this.btnOrderCTLAddTag.UseVisualStyleBackColor = true;
            this.btnOrderCTLAddTag.Visible = false;
            this.btnOrderCTLAddTag.Click += new System.EventHandler(this.btnOrderCTLAddTag_Click);
            // 
            // cbCTLPaperDefault
            // 
            this.cbCTLPaperDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCTLPaperDefault.AutoSize = true;
            this.cbCTLPaperDefault.Location = new System.Drawing.Point(942, 502);
            this.cbCTLPaperDefault.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCTLPaperDefault.Name = "cbCTLPaperDefault";
            this.cbCTLPaperDefault.Size = new System.Drawing.Size(111, 20);
            this.cbCTLPaperDefault.TabIndex = 50;
            this.cbCTLPaperDefault.Text = "Default Paper";
            this.cbCTLPaperDefault.UseVisualStyleBackColor = true;
            this.cbCTLPaperDefault.CheckedChanged += new System.EventHandler(this.cbCTLPaperDefault_CheckedChanged);
            // 
            // cbCTLPrintOperatorTags
            // 
            this.cbCTLPrintOperatorTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCTLPrintOperatorTags.AutoSize = true;
            this.cbCTLPrintOperatorTags.Checked = true;
            this.cbCTLPrintOperatorTags.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCTLPrintOperatorTags.Location = new System.Drawing.Point(800, 587);
            this.cbCTLPrintOperatorTags.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCTLPrintOperatorTags.Name = "cbCTLPrintOperatorTags";
            this.cbCTLPrintOperatorTags.Size = new System.Drawing.Size(146, 20);
            this.cbCTLPrintOperatorTags.TabIndex = 49;
            this.cbCTLPrintOperatorTags.Text = "Print Operator Tags";
            this.cbCTLPrintOperatorTags.UseVisualStyleBackColor = true;
            // 
            // buttonCTLReset
            // 
            this.buttonCTLReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCTLReset.Location = new System.Drawing.Point(952, 463);
            this.buttonCTLReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCTLReset.Name = "buttonCTLReset";
            this.buttonCTLReset.Size = new System.Drawing.Size(165, 28);
            this.buttonCTLReset.TabIndex = 15;
            this.buttonCTLReset.Text = "Reset All";
            this.buttonCTLReset.UseVisualStyleBackColor = true;
            this.buttonCTLReset.Click += new System.EventHandler(this.ButtonCTLReset_Click);
            // 
            // labelPaperPrice
            // 
            this.labelPaperPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPaperPrice.AutoSize = true;
            this.labelPaperPrice.Location = new System.Drawing.Point(696, 503);
            this.labelPaperPrice.Name = "labelPaperPrice";
            this.labelPaperPrice.Size = new System.Drawing.Size(78, 16);
            this.labelPaperPrice.TabIndex = 48;
            this.labelPaperPrice.Text = "Paper Price";
            // 
            // textBoxPaperPrice
            // 
            this.textBoxPaperPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPaperPrice.Location = new System.Drawing.Point(780, 501);
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
            this.labelSpecialLeadTime.Location = new System.Drawing.Point(533, 594);
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
            this.dataGridViewAdders.Location = new System.Drawing.Point(616, 55);
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
            this.buttonCTLDeleteRow.Location = new System.Drawing.Point(785, 463);
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
            this.textBoxCTLRunSheetComments.Location = new System.Drawing.Point(643, 551);
            this.textBoxCTLRunSheetComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCTLRunSheetComments.Name = "textBoxCTLRunSheetComments";
            this.textBoxCTLRunSheetComments.Size = new System.Drawing.Size(413, 22);
            this.textBoxCTLRunSheetComments.TabIndex = 12;
            this.textBoxCTLRunSheetComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCTLRunSheetComments_KeyPress);
            // 
            // labelCTLRunSheetComments
            // 
            this.labelCTLRunSheetComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCTLRunSheetComments.AutoSize = true;
            this.labelCTLRunSheetComments.Location = new System.Drawing.Point(491, 556);
            this.labelCTLRunSheetComments.Name = "labelCTLRunSheetComments";
            this.labelCTLRunSheetComments.Size = new System.Drawing.Size(136, 16);
            this.labelCTLRunSheetComments.TabIndex = 38;
            this.labelCTLRunSheetComments.Text = "Run Sheet Comments";
            // 
            // buttonCTLDelete
            // 
            this.buttonCTLDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCTLDelete.Location = new System.Drawing.Point(180, 494);
            this.buttonCTLDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCTLDelete.Name = "buttonCTLDelete";
            this.buttonCTLDelete.Size = new System.Drawing.Size(64, 39);
            this.buttonCTLDelete.TabIndex = 36;
            this.buttonCTLDelete.Text = "Delete";
            this.buttonCTLDelete.UseVisualStyleBackColor = true;
            this.buttonCTLDelete.Visible = false;
            this.buttonCTLDelete.Click += new System.EventHandler(this.buttonCTLDelete_Click);
            // 
            // comboBoxCTLModify
            // 
            this.comboBoxCTLModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCTLModify.FormattingEnabled = true;
            this.comboBoxCTLModify.Location = new System.Drawing.Point(27, 503);
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
            this.checkBoxCTLModify.Location = new System.Drawing.Point(5, 481);
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
            this.labelCTLSendTo.Location = new System.Drawing.Point(24, 558);
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
            this.comboBoxCTLSendTo.Location = new System.Drawing.Point(27, 580);
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
            this.checkBoxCTLMultiStep.Location = new System.Drawing.Point(5, 539);
            this.checkBoxCTLMultiStep.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxCTLMultiStep.Name = "checkBoxCTLMultiStep";
            this.checkBoxCTLMultiStep.Size = new System.Drawing.Size(84, 20);
            this.checkBoxCTLMultiStep.TabIndex = 3;
            this.checkBoxCTLMultiStep.Text = "MultiStep";
            this.checkBoxCTLMultiStep.UseVisualStyleBackColor = true;
            // 
            // labelCTLPrice
            // 
            this.labelCTLPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCTLPrice.AutoSize = true;
            this.labelCTLPrice.Location = new System.Drawing.Point(491, 503);
            this.labelCTLPrice.Name = "labelCTLPrice";
            this.labelCTLPrice.Size = new System.Drawing.Size(38, 16);
            this.labelCTLPrice.TabIndex = 28;
            this.labelCTLPrice.Text = "Price";
            // 
            // labelCTLPO
            // 
            this.labelCTLPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCTLPO.AutoSize = true;
            this.labelCTLPO.Location = new System.Drawing.Point(491, 528);
            this.labelCTLPO.Name = "labelCTLPO";
            this.labelCTLPO.Size = new System.Drawing.Size(101, 16);
            this.labelCTLPO.TabIndex = 27;
            this.labelCTLPO.Text = "Purchase Order";
            // 
            // labelCTLPromiseDate
            // 
            this.labelCTLPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCTLPromiseDate.AutoSize = true;
            this.labelCTLPromiseDate.Location = new System.Drawing.Point(247, 574);
            this.labelCTLPromiseDate.Name = "labelCTLPromiseDate";
            this.labelCTLPromiseDate.Size = new System.Drawing.Size(89, 16);
            this.labelCTLPromiseDate.TabIndex = 26;
            this.labelCTLPromiseDate.Text = "Promise Date";
            // 
            // checkBoxCTLScrapCredit
            // 
            this.checkBoxCTLScrapCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxCTLScrapCredit.AutoSize = true;
            this.checkBoxCTLScrapCredit.Location = new System.Drawing.Point(493, 481);
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
            this.textBoxCTLPO.Location = new System.Drawing.Point(605, 526);
            this.textBoxCTLPO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCTLPO.Name = "textBoxCTLPO";
            this.textBoxCTLPO.Size = new System.Drawing.Size(227, 22);
            this.textBoxCTLPO.TabIndex = 11;
            this.textBoxCTLPO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCTLPO_KeyPress);
            // 
            // textBoxCTLPrice
            // 
            this.textBoxCTLPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxCTLPrice.Location = new System.Drawing.Point(536, 501);
            this.textBoxCTLPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCTLPrice.Name = "textBoxCTLPrice";
            this.textBoxCTLPrice.Size = new System.Drawing.Size(112, 22);
            this.textBoxCTLPrice.TabIndex = 9;
            this.textBoxCTLPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxCTLPrice_KeyPress);
            // 
            // dateTimePickerCTLPromiseDate
            // 
            this.dateTimePickerCTLPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerCTLPromiseDate.Location = new System.Drawing.Point(249, 594);
            this.dateTimePickerCTLPromiseDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerCTLPromiseDate.Name = "dateTimePickerCTLPromiseDate";
            this.dateTimePickerCTLPromiseDate.Size = new System.Drawing.Size(272, 22);
            this.dateTimePickerCTLPromiseDate.TabIndex = 7;
            // 
            // richTextBoxCTLComments
            // 
            this.richTextBoxCTLComments.AcceptsTab = true;
            this.richTextBoxCTLComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxCTLComments.Location = new System.Drawing.Point(249, 494);
            this.richTextBoxCTLComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxCTLComments.MaxLength = 250;
            this.richTextBoxCTLComments.Name = "richTextBoxCTLComments";
            this.richTextBoxCTLComments.Size = new System.Drawing.Size(239, 74);
            this.richTextBoxCTLComments.TabIndex = 6;
            this.richTextBoxCTLComments.Text = "";
            this.richTextBoxCTLComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxCTLComments_KeyPress);
            // 
            // buttonCTLArrowDown
            // 
            this.buttonCTLArrowDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCTLArrowDown.Image = global::ICMS.Properties.Resources.DownArrow1;
            this.buttonCTLArrowDown.Location = new System.Drawing.Point(300, 455);
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
            this.buttonCTLArrowUp.Location = new System.Drawing.Point(249, 455);
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
            this.dgvCTLSkidWeight,
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
            this.dataGridViewCTLOrderEntry.Size = new System.Drawing.Size(1131, 455);
            this.dataGridViewCTLOrderEntry.TabIndex = 37;
            this.dataGridViewCTLOrderEntry.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridViewCTLOrderEntry_CellBeginEdit);
            this.dataGridViewCTLOrderEntry.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewCTLOrderEntry_CellClick);
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
            // dgvCTLSkidWeight
            // 
            this.dgvCTLSkidWeight.HeaderText = "Skid#";
            this.dgvCTLSkidWeight.MinimumWidth = 6;
            this.dgvCTLSkidWeight.Name = "dgvCTLSkidWeight";
            this.dgvCTLSkidWeight.ReadOnly = true;
            this.dgvCTLSkidWeight.Width = 70;
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
            this.dgvCTLAddCut.Visible = false;
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
            this.listViewCTLCoilList.Size = new System.Drawing.Size(1133, 456);
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
            // buttonCTLAddOrder
            // 
            this.buttonCTLAddOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCTLAddOrder.Location = new System.Drawing.Point(952, 580);
            this.buttonCTLAddOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCTLAddOrder.Name = "buttonCTLAddOrder";
            this.buttonCTLAddOrder.Size = new System.Drawing.Size(163, 32);
            this.buttonCTLAddOrder.TabIndex = 13;
            this.buttonCTLAddOrder.Text = "AddOrder";
            this.buttonCTLAddOrder.UseVisualStyleBackColor = true;
            this.buttonCTLAddOrder.Visible = false;
            this.buttonCTLAddOrder.Click += new System.EventHandler(this.ButtonCTLAddOrder_Click);
            // 
            // buttonCTLStartOrder
            // 
            this.buttonCTLStartOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCTLStartOrder.Location = new System.Drawing.Point(949, 580);
            this.buttonCTLStartOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCTLStartOrder.Name = "buttonCTLStartOrder";
            this.buttonCTLStartOrder.Size = new System.Drawing.Size(163, 32);
            this.buttonCTLStartOrder.TabIndex = 20;
            this.buttonCTLStartOrder.Text = "Start Order";
            this.buttonCTLStartOrder.UseVisualStyleBackColor = true;
            this.buttonCTLStartOrder.Click += new System.EventHandler(this.ButtonCTLStartOrder_Click);
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
            this.panelClClDiff.Controls.Add(this.dataGridViewClClDiff);
            this.panelClClDiff.Controls.Add(this.listViewClClDiff);
            this.panelClClDiff.Controls.Add(this.buttonClClDiffStartOrder);
            this.panelClClDiff.Controls.Add(this.buttonClClDiffAddOrder);
            this.panelClClDiff.Location = new System.Drawing.Point(4, 2);
            this.panelClClDiff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelClClDiff.Name = "panelClClDiff";
            this.panelClClDiff.Size = new System.Drawing.Size(1129, 626);
            this.panelClClDiff.TabIndex = 2;
            this.panelClClDiff.VisibleChanged += new System.EventHandler(this.PanelClClDiff_VisibleChanged);
            // 
            // labelClClDiffMasterSequence
            // 
            this.labelClClDiffMasterSequence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClClDiffMasterSequence.AutoSize = true;
            this.labelClClDiffMasterSequence.Location = new System.Drawing.Point(147, 569);
            this.labelClClDiffMasterSequence.Name = "labelClClDiffMasterSequence";
            this.labelClClDiffMasterSequence.Size = new System.Drawing.Size(14, 16);
            this.labelClClDiffMasterSequence.TabIndex = 40;
            this.labelClClDiffMasterSequence.Text = "0";
            // 
            // labelClClDiffMasterFrom
            // 
            this.labelClClDiffMasterFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClClDiffMasterFrom.AutoSize = true;
            this.labelClClDiffMasterFrom.Location = new System.Drawing.Point(147, 543);
            this.labelClClDiffMasterFrom.Name = "labelClClDiffMasterFrom";
            this.labelClClDiffMasterFrom.Size = new System.Drawing.Size(14, 16);
            this.labelClClDiffMasterFrom.TabIndex = 39;
            this.labelClClDiffMasterFrom.Text = "0";
            // 
            // buttonClClDiffResetCuts
            // 
            this.buttonClClDiffResetCuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClClDiffResetCuts.Location = new System.Drawing.Point(984, 514);
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
            this.buttonClClDiffModifyDelte.Location = new System.Drawing.Point(181, 498);
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
            this.comboBoxClClDiffModify.Location = new System.Drawing.Point(32, 514);
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
            this.checkBoxClClDiffModify.Location = new System.Drawing.Point(11, 490);
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
            this.labelClClDiffMultSendTo.Location = new System.Drawing.Point(29, 567);
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
            this.comboBoxClClDiffSendTo.Location = new System.Drawing.Point(32, 586);
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
            this.checkBoxClClDiffMultStep.Location = new System.Drawing.Point(11, 548);
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
            this.labelClClDiffPrice.Location = new System.Drawing.Point(563, 521);
            this.labelClClDiffPrice.Name = "labelClClDiffPrice";
            this.labelClClDiffPrice.Size = new System.Drawing.Size(38, 16);
            this.labelClClDiffPrice.TabIndex = 27;
            this.labelClClDiffPrice.Text = "Price";
            // 
            // labelClClDiffPO
            // 
            this.labelClClDiffPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClClDiffPO.AutoSize = true;
            this.labelClClDiffPO.Location = new System.Drawing.Point(563, 574);
            this.labelClClDiffPO.Name = "labelClClDiffPO";
            this.labelClClDiffPO.Size = new System.Drawing.Size(101, 16);
            this.labelClClDiffPO.TabIndex = 26;
            this.labelClClDiffPO.Text = "Purchase Order";
            // 
            // labelClClDiffPromiseDate
            // 
            this.labelClClDiffPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClClDiffPromiseDate.AutoSize = true;
            this.labelClClDiffPromiseDate.Location = new System.Drawing.Point(264, 574);
            this.labelClClDiffPromiseDate.Name = "labelClClDiffPromiseDate";
            this.labelClClDiffPromiseDate.Size = new System.Drawing.Size(89, 16);
            this.labelClClDiffPromiseDate.TabIndex = 25;
            this.labelClClDiffPromiseDate.Text = "Promise Date";
            // 
            // checkBoxClClDiffScrapCredit
            // 
            this.checkBoxClClDiffScrapCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxClClDiffScrapCredit.AutoSize = true;
            this.checkBoxClClDiffScrapCredit.Location = new System.Drawing.Point(563, 494);
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
            this.textBoxClClDiffPO.Location = new System.Drawing.Point(563, 594);
            this.textBoxClClDiffPO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClClDiffPO.Name = "textBoxClClDiffPO";
            this.textBoxClClDiffPO.Size = new System.Drawing.Size(227, 22);
            this.textBoxClClDiffPO.TabIndex = 23;
            // 
            // textBoxClClDiffPrice
            // 
            this.textBoxClClDiffPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxClClDiffPrice.Location = new System.Drawing.Point(563, 542);
            this.textBoxClClDiffPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxClClDiffPrice.Name = "textBoxClClDiffPrice";
            this.textBoxClClDiffPrice.Size = new System.Drawing.Size(112, 22);
            this.textBoxClClDiffPrice.TabIndex = 22;
            // 
            // dateTimePickerClClDiffPromiseDate
            // 
            this.dateTimePickerClClDiffPromiseDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerClClDiffPromiseDate.Location = new System.Drawing.Point(267, 594);
            this.dateTimePickerClClDiffPromiseDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerClClDiffPromiseDate.Name = "dateTimePickerClClDiffPromiseDate";
            this.dateTimePickerClClDiffPromiseDate.Size = new System.Drawing.Size(272, 22);
            this.dateTimePickerClClDiffPromiseDate.TabIndex = 21;
            // 
            // richTextBoxClClDiffComments
            // 
            this.richTextBoxClClDiffComments.AcceptsTab = true;
            this.richTextBoxClClDiffComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxClClDiffComments.Location = new System.Drawing.Point(267, 489);
            this.richTextBoxClClDiffComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxClClDiffComments.Name = "richTextBoxClClDiffComments";
            this.richTextBoxClClDiffComments.Size = new System.Drawing.Size(239, 74);
            this.richTextBoxClClDiffComments.TabIndex = 20;
            this.richTextBoxClClDiffComments.Text = "";
            // 
            // buttonClClDiffReset
            // 
            this.buttonClClDiffReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClClDiffReset.Location = new System.Drawing.Point(984, 487);
            this.buttonClClDiffReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClClDiffReset.Name = "buttonClClDiffReset";
            this.buttonClClDiffReset.Size = new System.Drawing.Size(131, 25);
            this.buttonClClDiffReset.TabIndex = 5;
            this.buttonClClDiffReset.Text = "Reset All";
            this.buttonClClDiffReset.UseVisualStyleBackColor = true;
            this.buttonClClDiffReset.Visible = false;
            this.buttonClClDiffReset.Click += new System.EventHandler(this.ButtonClClDiffReset_Click);
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
            this.dataGridViewClClDiff.Size = new System.Drawing.Size(1131, 474);
            this.dataGridViewClClDiff.TabIndex = 34;
            this.dataGridViewClClDiff.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClClDiff_CellContentClick);
            this.dataGridViewClClDiff.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewClClDiff_CellEndEdit);
            this.dataGridViewClClDiff.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewClClDiff_CellEnter);
            this.dataGridViewClClDiff.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewClClDiff_CellMouseUp);
            this.dataGridViewClClDiff.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewClClDiff_MouseClick);
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
            this.colClClDiffOrigWeight.ReadOnly = true;
            this.colClClDiffOrigWeight.Width = 89;
            // 
            // colClClDiffNewWeight
            // 
            this.colClClDiffNewWeight.HeaderText = "New LBS";
            this.colClClDiffNewWeight.MinimumWidth = 6;
            this.colClClDiffNewWeight.Name = "colClClDiffNewWeight";
            this.colClClDiffNewWeight.ReadOnly = true;
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
            this.listViewClClDiff.Size = new System.Drawing.Size(1139, 477);
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
            // buttonClClDiffStartOrder
            // 
            this.buttonClClDiffStartOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClClDiffStartOrder.Location = new System.Drawing.Point(984, 574);
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
            this.buttonClClDiffAddOrder.Location = new System.Drawing.Point(984, 574);
            this.buttonClClDiffAddOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClClDiffAddOrder.Name = "buttonClClDiffAddOrder";
            this.buttonClClDiffAddOrder.Size = new System.Drawing.Size(131, 34);
            this.buttonClClDiffAddOrder.TabIndex = 35;
            this.buttonClClDiffAddOrder.Text = "Add Order";
            this.buttonClClDiffAddOrder.UseVisualStyleBackColor = true;
            this.buttonClClDiffAddOrder.Visible = false;
            this.buttonClClDiffAddOrder.Click += new System.EventHandler(this.ButtonClClDiffAddOrder_Click);
            // 
            // tabPageReports
            // 
            this.tabPageReports.BackColor = System.Drawing.Color.Transparent;
            this.tabPageReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPageReports.Controls.Add(this.panelReportOperatorTags);
            this.tabPageReports.Controls.Add(this.panelReportTransfer);
            this.tabPageReports.Controls.Add(this.panelReportHistory);
            this.tabPageReports.Controls.Add(this.panelReportInventory);
            this.tabPageReports.Controls.Add(this.panelReportWorkOrder);
            this.tabPageReports.Controls.Add(this.panelReportShipping);
            this.tabPageReports.Controls.Add(this.panelReportReceiving);
            this.tabPageReports.Location = new System.Drawing.Point(4, 25);
            this.tabPageReports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageReports.Size = new System.Drawing.Size(1141, 636);
            this.tabPageReports.TabIndex = 4;
            this.tabPageReports.Text = "Reports";
            // 
            // panelReportOperatorTags
            // 
            this.panelReportOperatorTags.Controls.Add(this.btnReportOperatorTag);
            this.panelReportOperatorTags.Controls.Add(this.tbReportOperatorTags);
            this.panelReportOperatorTags.Location = new System.Drawing.Point(21, 388);
            this.panelReportOperatorTags.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelReportOperatorTags.Name = "panelReportOperatorTags";
            this.panelReportOperatorTags.Size = new System.Drawing.Size(1103, 57);
            this.panelReportOperatorTags.TabIndex = 27;
            // 
            // btnReportOperatorTag
            // 
            this.btnReportOperatorTag.Location = new System.Drawing.Point(29, 15);
            this.btnReportOperatorTag.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReportOperatorTag.Name = "btnReportOperatorTag";
            this.btnReportOperatorTag.Size = new System.Drawing.Size(124, 25);
            this.btnReportOperatorTag.TabIndex = 18;
            this.btnReportOperatorTag.Text = "Operator Tags";
            this.btnReportOperatorTag.UseVisualStyleBackColor = true;
            this.btnReportOperatorTag.Click += new System.EventHandler(this.btnReportOperatorTag_Click);
            // 
            // tbReportOperatorTags
            // 
            this.tbReportOperatorTags.Location = new System.Drawing.Point(157, 16);
            this.tbReportOperatorTags.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReportOperatorTags.Name = "tbReportOperatorTags";
            this.tbReportOperatorTags.Size = new System.Drawing.Size(125, 22);
            this.tbReportOperatorTags.TabIndex = 19;
            this.tbReportOperatorTags.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReportOperatorTags_KeyDown);
            this.tbReportOperatorTags.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReportOperatorTags_KeyPress);
            // 
            // panelReportTransfer
            // 
            this.panelReportTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelReportTransfer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReportTransfer.Controls.Add(this.btnReportTransfer);
            this.panelReportTransfer.Controls.Add(this.tbReportTransferID);
            this.panelReportTransfer.Controls.Add(this.lblReportTransferID);
            this.panelReportTransfer.Controls.Add(this.tbReportTransferTagID);
            this.panelReportTransfer.Controls.Add(this.lblReportTagID);
            this.panelReportTransfer.Location = new System.Drawing.Point(21, 327);
            this.panelReportTransfer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelReportTransfer.Name = "panelReportTransfer";
            this.panelReportTransfer.Size = new System.Drawing.Size(1103, 56);
            this.panelReportTransfer.TabIndex = 26;
            // 
            // btnReportTransfer
            // 
            this.btnReportTransfer.Location = new System.Drawing.Point(28, 18);
            this.btnReportTransfer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReportTransfer.Name = "btnReportTransfer";
            this.btnReportTransfer.Size = new System.Drawing.Size(101, 25);
            this.btnReportTransfer.TabIndex = 13;
            this.btnReportTransfer.Text = "Transfer";
            this.btnReportTransfer.UseVisualStyleBackColor = true;
            this.btnReportTransfer.Click += new System.EventHandler(this.btnReportTransfer_Click);
            // 
            // tbReportTransferID
            // 
            this.tbReportTransferID.Location = new System.Drawing.Point(157, 18);
            this.tbReportTransferID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReportTransferID.Name = "tbReportTransferID";
            this.tbReportTransferID.Size = new System.Drawing.Size(125, 22);
            this.tbReportTransferID.TabIndex = 14;
            this.tbReportTransferID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReportTransferID_KeyDown);
            this.tbReportTransferID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReportTransferID_KeyPress);
            // 
            // lblReportTransferID
            // 
            this.lblReportTransferID.AutoSize = true;
            this.lblReportTransferID.Location = new System.Drawing.Point(157, 1);
            this.lblReportTransferID.Name = "lblReportTransferID";
            this.lblReportTransferID.Size = new System.Drawing.Size(73, 16);
            this.lblReportTransferID.TabIndex = 15;
            this.lblReportTransferID.Text = "Transfer ID";
            // 
            // tbReportTransferTagID
            // 
            this.tbReportTransferTagID.Location = new System.Drawing.Point(288, 18);
            this.tbReportTransferTagID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReportTransferTagID.Name = "tbReportTransferTagID";
            this.tbReportTransferTagID.Size = new System.Drawing.Size(125, 22);
            this.tbReportTransferTagID.TabIndex = 16;
            this.tbReportTransferTagID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReportTransferTagID_KeyDown);
            this.tbReportTransferTagID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReportTransferTagID_KeyPress);
            // 
            // lblReportTagID
            // 
            this.lblReportTagID.AutoSize = true;
            this.lblReportTagID.Location = new System.Drawing.Point(289, 1);
            this.lblReportTagID.Name = "lblReportTagID";
            this.lblReportTagID.Size = new System.Drawing.Size(32, 16);
            this.lblReportTagID.TabIndex = 17;
            this.lblReportTagID.Text = "Tag";
            // 
            // panelReportHistory
            // 
            this.panelReportHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelReportHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReportHistory.Controls.Add(this.lblReportsHistoryMill);
            this.panelReportHistory.Controls.Add(this.tbReportsHistoryMillNum);
            this.panelReportHistory.Controls.Add(this.lblReportsHistoryPO);
            this.panelReportHistory.Controls.Add(this.tbReportsHistoryPO);
            this.panelReportHistory.Controls.Add(this.lblReportHistoryTagID);
            this.panelReportHistory.Controls.Add(this.btnReportHistory);
            this.panelReportHistory.Controls.Add(this.tbReportHistory);
            this.panelReportHistory.Location = new System.Drawing.Point(21, 266);
            this.panelReportHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelReportHistory.Name = "panelReportHistory";
            this.panelReportHistory.Size = new System.Drawing.Size(1103, 56);
            this.panelReportHistory.TabIndex = 25;
            // 
            // lblReportsHistoryMill
            // 
            this.lblReportsHistoryMill.AutoSize = true;
            this.lblReportsHistoryMill.Location = new System.Drawing.Point(560, -1);
            this.lblReportsHistoryMill.Name = "lblReportsHistoryMill";
            this.lblReportsHistoryMill.Size = new System.Drawing.Size(34, 16);
            this.lblReportsHistoryMill.TabIndex = 17;
            this.lblReportsHistoryMill.Text = "Mill#";
            // 
            // tbReportsHistoryMillNum
            // 
            this.tbReportsHistoryMillNum.Location = new System.Drawing.Point(559, 15);
            this.tbReportsHistoryMillNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReportsHistoryMillNum.Name = "tbReportsHistoryMillNum";
            this.tbReportsHistoryMillNum.Size = new System.Drawing.Size(229, 22);
            this.tbReportsHistoryMillNum.TabIndex = 16;
            this.tbReportsHistoryMillNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReportsHistoryMillNum_KeyDown);
            this.tbReportsHistoryMillNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReportsHistoryMillNum_KeyPress);
            // 
            // lblReportsHistoryPO
            // 
            this.lblReportsHistoryPO.AutoSize = true;
            this.lblReportsHistoryPO.Location = new System.Drawing.Point(309, 1);
            this.lblReportsHistoryPO.Name = "lblReportsHistoryPO";
            this.lblReportsHistoryPO.Size = new System.Drawing.Size(101, 16);
            this.lblReportsHistoryPO.TabIndex = 15;
            this.lblReportsHistoryPO.Text = "Purchase Order";
            // 
            // tbReportsHistoryPO
            // 
            this.tbReportsHistoryPO.Location = new System.Drawing.Point(308, 17);
            this.tbReportsHistoryPO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReportsHistoryPO.Name = "tbReportsHistoryPO";
            this.tbReportsHistoryPO.Size = new System.Drawing.Size(229, 22);
            this.tbReportsHistoryPO.TabIndex = 14;
            this.tbReportsHistoryPO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReportsHistoryPO_KeyDown);
            this.tbReportsHistoryPO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReportsHistoryPO_KeyPress);
            // 
            // lblReportHistoryTagID
            // 
            this.lblReportHistoryTagID.AutoSize = true;
            this.lblReportHistoryTagID.Location = new System.Drawing.Point(171, 1);
            this.lblReportHistoryTagID.Name = "lblReportHistoryTagID";
            this.lblReportHistoryTagID.Size = new System.Drawing.Size(32, 16);
            this.lblReportHistoryTagID.TabIndex = 13;
            this.lblReportHistoryTagID.Text = "Tag";
            // 
            // btnReportHistory
            // 
            this.btnReportHistory.Location = new System.Drawing.Point(28, 15);
            this.btnReportHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReportHistory.Name = "btnReportHistory";
            this.btnReportHistory.Size = new System.Drawing.Size(101, 25);
            this.btnReportHistory.TabIndex = 11;
            this.btnReportHistory.Text = "History";
            this.btnReportHistory.UseVisualStyleBackColor = true;
            this.btnReportHistory.Click += new System.EventHandler(this.btnReportHistory_Click);
            // 
            // tbReportHistory
            // 
            this.tbReportHistory.Location = new System.Drawing.Point(157, 17);
            this.tbReportHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReportHistory.Name = "tbReportHistory";
            this.tbReportHistory.Size = new System.Drawing.Size(125, 22);
            this.tbReportHistory.TabIndex = 12;
            this.tbReportHistory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReportHistory_KeyDown);
            this.tbReportHistory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReportHistory_KeyPress);
            // 
            // panelReportInventory
            // 
            this.panelReportInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReportInventory.Controls.Add(this.btnReportInventory);
            this.panelReportInventory.Controls.Add(this.chkBxReportInventoryAllCustomers);
            this.panelReportInventory.Controls.Add(this.chkBxInventoryCoils);
            this.panelReportInventory.Controls.Add(this.chkBxInventorySkids);
            this.panelReportInventory.Controls.Add(this.lblInventoryUpdate);
            this.panelReportInventory.Location = new System.Drawing.Point(21, 206);
            this.panelReportInventory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelReportInventory.Name = "panelReportInventory";
            this.panelReportInventory.Size = new System.Drawing.Size(1103, 56);
            this.panelReportInventory.TabIndex = 24;
            // 
            // btnReportInventory
            // 
            this.btnReportInventory.Location = new System.Drawing.Point(21, 14);
            this.btnReportInventory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReportInventory.Name = "btnReportInventory";
            this.btnReportInventory.Size = new System.Drawing.Size(101, 25);
            this.btnReportInventory.TabIndex = 6;
            this.btnReportInventory.Text = "Inventory";
            this.btnReportInventory.UseVisualStyleBackColor = true;
            this.btnReportInventory.Click += new System.EventHandler(this.btnReportInventory_Click);
            // 
            // chkBxReportInventoryAllCustomers
            // 
            this.chkBxReportInventoryAllCustomers.AutoSize = true;
            this.chkBxReportInventoryAllCustomers.Location = new System.Drawing.Point(151, 17);
            this.chkBxReportInventoryAllCustomers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkBxReportInventoryAllCustomers.Name = "chkBxReportInventoryAllCustomers";
            this.chkBxReportInventoryAllCustomers.Size = new System.Drawing.Size(111, 20);
            this.chkBxReportInventoryAllCustomers.TabIndex = 7;
            this.chkBxReportInventoryAllCustomers.Text = "All Customers";
            this.chkBxReportInventoryAllCustomers.UseVisualStyleBackColor = true;
            this.chkBxReportInventoryAllCustomers.CheckedChanged += new System.EventHandler(this.chkBxReportInventoryAllCustomers_CheckedChanged);
            // 
            // chkBxInventoryCoils
            // 
            this.chkBxInventoryCoils.AutoSize = true;
            this.chkBxInventoryCoils.Checked = true;
            this.chkBxInventoryCoils.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxInventoryCoils.Location = new System.Drawing.Point(267, 17);
            this.chkBxInventoryCoils.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkBxInventoryCoils.Name = "chkBxInventoryCoils";
            this.chkBxInventoryCoils.Size = new System.Drawing.Size(59, 20);
            this.chkBxInventoryCoils.TabIndex = 8;
            this.chkBxInventoryCoils.Text = "Coils";
            this.chkBxInventoryCoils.UseVisualStyleBackColor = true;
            // 
            // chkBxInventorySkids
            // 
            this.chkBxInventorySkids.AutoSize = true;
            this.chkBxInventorySkids.Checked = true;
            this.chkBxInventorySkids.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBxInventorySkids.Location = new System.Drawing.Point(332, 17);
            this.chkBxInventorySkids.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkBxInventorySkids.Name = "chkBxInventorySkids";
            this.chkBxInventorySkids.Size = new System.Drawing.Size(63, 20);
            this.chkBxInventorySkids.TabIndex = 9;
            this.chkBxInventorySkids.Text = "Skids";
            this.chkBxInventorySkids.UseVisualStyleBackColor = true;
            // 
            // lblInventoryUpdate
            // 
            this.lblInventoryUpdate.AutoSize = true;
            this.lblInventoryUpdate.Location = new System.Drawing.Point(441, -2);
            this.lblInventoryUpdate.Name = "lblInventoryUpdate";
            this.lblInventoryUpdate.Size = new System.Drawing.Size(0, 16);
            this.lblInventoryUpdate.TabIndex = 10;
            // 
            // panelReportWorkOrder
            // 
            this.panelReportWorkOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelReportWorkOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReportWorkOrder.Controls.Add(this.btnReportWorkOrder);
            this.panelReportWorkOrder.Controls.Add(this.tbReportWorkOrder);
            this.panelReportWorkOrder.Controls.Add(this.cbReportWorkORderOperatorTags);
            this.panelReportWorkOrder.Location = new System.Drawing.Point(21, 144);
            this.panelReportWorkOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelReportWorkOrder.Name = "panelReportWorkOrder";
            this.panelReportWorkOrder.Size = new System.Drawing.Size(1103, 56);
            this.panelReportWorkOrder.TabIndex = 23;
            // 
            // btnReportWorkOrder
            // 
            this.btnReportWorkOrder.Location = new System.Drawing.Point(20, 14);
            this.btnReportWorkOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReportWorkOrder.Name = "btnReportWorkOrder";
            this.btnReportWorkOrder.Size = new System.Drawing.Size(101, 25);
            this.btnReportWorkOrder.TabIndex = 4;
            this.btnReportWorkOrder.Text = "Work Order";
            this.btnReportWorkOrder.UseVisualStyleBackColor = true;
            this.btnReportWorkOrder.Click += new System.EventHandler(this.btnReportWorkOrder_Click);
            // 
            // tbReportWorkOrder
            // 
            this.tbReportWorkOrder.Location = new System.Drawing.Point(149, 15);
            this.tbReportWorkOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReportWorkOrder.Name = "tbReportWorkOrder";
            this.tbReportWorkOrder.Size = new System.Drawing.Size(125, 22);
            this.tbReportWorkOrder.TabIndex = 5;
            this.tbReportWorkOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReportWorkOrder_KeyDown);
            this.tbReportWorkOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReportWorkOrder_KeyPress);
            // 
            // cbReportWorkORderOperatorTags
            // 
            this.cbReportWorkORderOperatorTags.AutoSize = true;
            this.cbReportWorkORderOperatorTags.Location = new System.Drawing.Point(308, 17);
            this.cbReportWorkORderOperatorTags.Margin = new System.Windows.Forms.Padding(4);
            this.cbReportWorkORderOperatorTags.Name = "cbReportWorkORderOperatorTags";
            this.cbReportWorkORderOperatorTags.Size = new System.Drawing.Size(146, 20);
            this.cbReportWorkORderOperatorTags.TabIndex = 20;
            this.cbReportWorkORderOperatorTags.Text = "Print Operator Tags";
            this.cbReportWorkORderOperatorTags.UseVisualStyleBackColor = true;
            // 
            // panelReportShipping
            // 
            this.panelReportShipping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelReportShipping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReportShipping.Controls.Add(this.tbReportShippingLabels);
            this.panelReportShipping.Controls.Add(this.btnReportShippingLabel);
            this.panelReportShipping.Controls.Add(this.btnRepotShipping);
            this.panelReportShipping.Controls.Add(this.tbReportShipping);
            this.panelReportShipping.Location = new System.Drawing.Point(21, 82);
            this.panelReportShipping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelReportShipping.Name = "panelReportShipping";
            this.panelReportShipping.Size = new System.Drawing.Size(1101, 56);
            this.panelReportShipping.TabIndex = 22;
            // 
            // tbReportShippingLabels
            // 
            this.tbReportShippingLabels.Location = new System.Drawing.Point(467, 18);
            this.tbReportShippingLabels.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReportShippingLabels.Name = "tbReportShippingLabels";
            this.tbReportShippingLabels.Size = new System.Drawing.Size(125, 22);
            this.tbReportShippingLabels.TabIndex = 5;
            this.tbReportShippingLabels.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReportShippingLabels_KeyDown);
            this.tbReportShippingLabels.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReportShippingLabels_KeyPress);
            // 
            // btnReportShippingLabel
            // 
            this.btnReportShippingLabel.Location = new System.Drawing.Point(339, 16);
            this.btnReportShippingLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReportShippingLabel.Name = "btnReportShippingLabel";
            this.btnReportShippingLabel.Size = new System.Drawing.Size(123, 25);
            this.btnReportShippingLabel.TabIndex = 4;
            this.btnReportShippingLabel.Text = "Print All Labels";
            this.btnReportShippingLabel.UseVisualStyleBackColor = true;
            this.btnReportShippingLabel.Click += new System.EventHandler(this.btnReportShippingLabel_Click);
            // 
            // btnRepotShipping
            // 
            this.btnRepotShipping.Location = new System.Drawing.Point(21, 16);
            this.btnRepotShipping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRepotShipping.Name = "btnRepotShipping";
            this.btnRepotShipping.Size = new System.Drawing.Size(101, 25);
            this.btnRepotShipping.TabIndex = 2;
            this.btnRepotShipping.Text = "Shipping";
            this.btnRepotShipping.UseVisualStyleBackColor = true;
            this.btnRepotShipping.Click += new System.EventHandler(this.btnRepotShipping_Click);
            // 
            // tbReportShipping
            // 
            this.tbReportShipping.Location = new System.Drawing.Point(149, 16);
            this.tbReportShipping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReportShipping.Name = "tbReportShipping";
            this.tbReportShipping.Size = new System.Drawing.Size(125, 22);
            this.tbReportShipping.TabIndex = 3;
            this.tbReportShipping.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReportShipping_KeyDown);
            this.tbReportShipping.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReportShipping_KeyPress);
            // 
            // panelReportReceiving
            // 
            this.panelReportReceiving.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelReportReceiving.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReportReceiving.Controls.Add(this.btnReportReceiving);
            this.panelReportReceiving.Controls.Add(this.txtReportRecieving);
            this.panelReportReceiving.Location = new System.Drawing.Point(21, 22);
            this.panelReportReceiving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelReportReceiving.Name = "panelReportReceiving";
            this.panelReportReceiving.Size = new System.Drawing.Size(1101, 56);
            this.panelReportReceiving.TabIndex = 21;
            // 
            // btnReportReceiving
            // 
            this.btnReportReceiving.Location = new System.Drawing.Point(20, 15);
            this.btnReportReceiving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReportReceiving.Name = "btnReportReceiving";
            this.btnReportReceiving.Size = new System.Drawing.Size(101, 25);
            this.btnReportReceiving.TabIndex = 0;
            this.btnReportReceiving.Text = "Recieving";
            this.btnReportReceiving.UseVisualStyleBackColor = true;
            this.btnReportReceiving.Click += new System.EventHandler(this.btnReportReceiving_Click);
            // 
            // txtReportRecieving
            // 
            this.txtReportRecieving.Location = new System.Drawing.Point(149, 16);
            this.txtReportRecieving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReportRecieving.Name = "txtReportRecieving";
            this.txtReportRecieving.Size = new System.Drawing.Size(125, 22);
            this.txtReportRecieving.TabIndex = 1;
            this.txtReportRecieving.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReportRecieving_KeyDown);
            this.txtReportRecieving.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReportRecieving_KeyPress);
            // 
            // tabPageReceiving
            // 
            this.tabPageReceiving.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.tabPageReceiving.Size = new System.Drawing.Size(1141, 636);
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
            this.cbRecPrintLabel.Location = new System.Drawing.Point(629, 591);
            this.cbRecPrintLabel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.labelContainer.Location = new System.Drawing.Point(304, 591);
            this.labelContainer.Name = "labelContainer";
            this.labelContainer.Size = new System.Drawing.Size(64, 16);
            this.labelContainer.TabIndex = 9;
            this.labelContainer.Text = "Container";
            // 
            // textBoxContainer
            // 
            this.textBoxContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxContainer.Location = new System.Drawing.Point(387, 591);
            this.textBoxContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxContainer.Name = "textBoxContainer";
            this.textBoxContainer.Size = new System.Drawing.Size(225, 22);
            this.textBoxContainer.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 591);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(264, 22);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // checkBoxPreReceiving
            // 
            this.checkBoxPreReceiving.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxPreReceiving.AutoSize = true;
            this.checkBoxPreReceiving.Location = new System.Drawing.Point(320, 753);
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
            this.buttonRecSubmit.Location = new System.Drawing.Point(757, 548);
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
            this.buttonDamageDone.Location = new System.Drawing.Point(-175, 274);
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
            this.buttonReceiveDeleteRow.Location = new System.Drawing.Point(160, 546);
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
            this.buttonRecieveAddRow.Location = new System.Drawing.Point(16, 546);
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
            this.checkedListBoxDamage.Location = new System.Drawing.Point(8, 53);
            this.checkedListBoxDamage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBoxDamage.Name = "checkedListBoxDamage";
            this.checkedListBoxDamage.Size = new System.Drawing.Size(311, 310);
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
            this.dataGridViewReceiving.Location = new System.Drawing.Point(3, 4);
            this.dataGridViewReceiving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewReceiving.MultiSelect = false;
            this.dataGridViewReceiving.Name = "dataGridViewReceiving";
            this.dataGridViewReceiving.RowHeadersWidth = 51;
            this.dataGridViewReceiving.RowTemplate.Height = 24;
            this.dataGridViewReceiving.Size = new System.Drawing.Size(1115, 529);
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
            this.tabPageSkid.Size = new System.Drawing.Size(1141, 636);
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
            this.listViewSkidData.Location = new System.Drawing.Point(0, 4);
            this.listViewSkidData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewSkidData.MultiSelect = false;
            this.listViewSkidData.Name = "listViewSkidData";
            this.listViewSkidData.Size = new System.Drawing.Size(1125, 613);
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
            this.tabPageCoil.Size = new System.Drawing.Size(1141, 636);
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
            this.ListViewCoilData.Location = new System.Drawing.Point(0, 4);
            this.ListViewCoilData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListViewCoilData.MultiSelect = false;
            this.ListViewCoilData.Name = "ListViewCoilData";
            this.ListViewCoilData.Size = new System.Drawing.Size(1135, 614);
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
            this.tabControlICMS.Controls.Add(this.tabPageOpenOrders);
            this.tabControlICMS.Controls.Add(this.tabPageCustomerInfo);
            this.tabControlICMS.Controls.Add(this.tabPageReports);
            this.tabControlICMS.Controls.Add(this.tabPagePVC);
            this.tabControlICMS.Controls.Add(this.tabPageRunSheet);
            this.tabControlICMS.Controls.Add(this.tabPageFix);
            this.tabControlICMS.Location = new System.Drawing.Point(267, 66);
            this.tabControlICMS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlICMS.Name = "tabControlICMS";
            this.tabControlICMS.SelectedIndex = 0;
            this.tabControlICMS.Size = new System.Drawing.Size(1149, 665);
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
            this.tabPageShipping.Size = new System.Drawing.Size(1141, 636);
            this.tabPageShipping.TabIndex = 8;
            this.tabPageShipping.Text = "Shipping";
            this.tabPageShipping.UseVisualStyleBackColor = true;
            // 
            // buttonReleaseBOL
            // 
            this.buttonReleaseBOL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReleaseBOL.Location = new System.Drawing.Point(836, 586);
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
            this.checkBoxShipModifyRel.Location = new System.Drawing.Point(165, 593);
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
            this.buttonBuildTruck.Location = new System.Drawing.Point(629, 586);
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
            this.splitContainerShipping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerShipping.Location = new System.Drawing.Point(5, 5);
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
            this.splitContainerShipping.Size = new System.Drawing.Size(1099, 544);
            this.splitContainerShipping.SplitterDistance = 237;
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
            this.listViewShipCoil.FullRowSelect = true;
            this.listViewShipCoil.HideSelection = false;
            this.listViewShipCoil.Location = new System.Drawing.Point(3, 2);
            this.listViewShipCoil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewShipCoil.MultiSelect = false;
            this.listViewShipCoil.Name = "listViewShipCoil";
            this.listViewShipCoil.Size = new System.Drawing.Size(1079, 181);
            this.listViewShipCoil.TabIndex = 1;
            this.listViewShipCoil.UseCompatibleStateImageBehavior = false;
            this.listViewShipCoil.View = System.Windows.Forms.View.Details;
            this.listViewShipCoil.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewShipCoil_ItemChecked);
            this.listViewShipCoil.SelectedIndexChanged += new System.EventHandler(this.ListViewShipCoil_SelectedIndexChanged);
            this.listViewShipCoil.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewShipCoil_MouseDown);
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
            this.listViewShipSkid.Location = new System.Drawing.Point(0, 2);
            this.listViewShipSkid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewShipSkid.MultiSelect = false;
            this.listViewShipSkid.Name = "listViewShipSkid";
            this.listViewShipSkid.Size = new System.Drawing.Size(1081, 233);
            this.listViewShipSkid.TabIndex = 1;
            this.listViewShipSkid.UseCompatibleStateImageBehavior = false;
            this.listViewShipSkid.View = System.Windows.Forms.View.Details;
            this.listViewShipSkid.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewShipSkid_ItemChecked);
            this.listViewShipSkid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewShipSkid_MouseDown);
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
            this.panelModifyRelease.Location = new System.Drawing.Point(9, 478);
            this.panelModifyRelease.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelModifyRelease.Name = "panelModifyRelease";
            this.panelModifyRelease.Size = new System.Drawing.Size(227, 105);
            this.panelModifyRelease.TabIndex = 2;
            this.panelModifyRelease.Visible = false;
            // 
            // comboBoxBranchChooser
            // 
            this.comboBoxBranchChooser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxBranchChooser.FormattingEnabled = true;
            this.comboBoxBranchChooser.Location = new System.Drawing.Point(9, 591);
            this.comboBoxBranchChooser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxBranchChooser.Name = "comboBoxBranchChooser";
            this.comboBoxBranchChooser.Size = new System.Drawing.Size(137, 24);
            this.comboBoxBranchChooser.TabIndex = 6;
            this.comboBoxBranchChooser.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBranchChooser_SelectedIndexChanged);
            // 
            // buttonShipStart
            // 
            this.buttonShipStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonShipStart.Location = new System.Drawing.Point(377, 585);
            this.buttonShipStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonShipStart.Name = "buttonShipStart";
            this.buttonShipStart.Size = new System.Drawing.Size(179, 34);
            this.buttonShipStart.TabIndex = 1;
            this.buttonShipStart.Text = "Enter Ship Info";
            this.buttonShipStart.UseVisualStyleBackColor = true;
            this.buttonShipStart.Click += new System.EventHandler(this.ButtonShipStart_Click);
            // 
            // tabPageOpenOrders
            // 
            this.tabPageOpenOrders.Controls.Add(this.btnOpenOrdersPrint);
            this.tabPageOpenOrders.Controls.Add(this.lvOpenOrderList);
            this.tabPageOpenOrders.Location = new System.Drawing.Point(4, 25);
            this.tabPageOpenOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageOpenOrders.Name = "tabPageOpenOrders";
            this.tabPageOpenOrders.Size = new System.Drawing.Size(1141, 636);
            this.tabPageOpenOrders.TabIndex = 11;
            this.tabPageOpenOrders.Text = "Open Orders";
            this.tabPageOpenOrders.UseVisualStyleBackColor = true;
            // 
            // btnOpenOrdersPrint
            // 
            this.btnOpenOrdersPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenOrdersPrint.Location = new System.Drawing.Point(951, 2);
            this.btnOpenOrdersPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenOrdersPrint.Name = "btnOpenOrdersPrint";
            this.btnOpenOrdersPrint.Size = new System.Drawing.Size(111, 22);
            this.btnOpenOrdersPrint.TabIndex = 1;
            this.btnOpenOrdersPrint.Text = "Print";
            this.btnOpenOrdersPrint.UseVisualStyleBackColor = true;
            this.btnOpenOrdersPrint.Click += new System.EventHandler(this.btnOpenOrdersPrint_Click);
            // 
            // lvOpenOrderList
            // 
            this.lvOpenOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvOpenOrderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOpenOrderMachine,
            this.colOpenOrderThickness,
            this.colOpenOrderWidth,
            this.colOpenOrderOrderID,
            this.colOpenOrderPromiseDate,
            this.colOpenOrderRunSheetComments,
            this.colOpenOrderCustPO});
            this.lvOpenOrderList.HideSelection = false;
            this.lvOpenOrderList.Location = new System.Drawing.Point(17, 28);
            this.lvOpenOrderList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvOpenOrderList.Name = "lvOpenOrderList";
            this.lvOpenOrderList.Size = new System.Drawing.Size(1104, 574);
            this.lvOpenOrderList.TabIndex = 0;
            this.lvOpenOrderList.UseCompatibleStateImageBehavior = false;
            this.lvOpenOrderList.View = System.Windows.Forms.View.Details;
            // 
            // colOpenOrderMachine
            // 
            this.colOpenOrderMachine.Text = "Machine";
            // 
            // colOpenOrderThickness
            // 
            this.colOpenOrderThickness.Text = "Thickness";
            // 
            // colOpenOrderWidth
            // 
            this.colOpenOrderWidth.Text = "Width";
            // 
            // colOpenOrderOrderID
            // 
            this.colOpenOrderOrderID.Text = "Order#";
            // 
            // colOpenOrderPromiseDate
            // 
            this.colOpenOrderPromiseDate.Text = "Due Date";
            // 
            // colOpenOrderRunSheetComments
            // 
            this.colOpenOrderRunSheetComments.Text = "Run Sheet Comments";
            // 
            // colOpenOrderCustPO
            // 
            this.colOpenOrderCustPO.Text = "Cust PO";
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
            this.tabPageCustomerInfo.Size = new System.Drawing.Size(1141, 636);
            this.tabPageCustomerInfo.TabIndex = 7;
            this.tabPageCustomerInfo.Text = "Cust Info";
            this.tabPageCustomerInfo.UseVisualStyleBackColor = true;
            // 
            // buttonCustInfoAddBranch
            // 
            this.buttonCustInfoAddBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCustInfoAddBranch.Location = new System.Drawing.Point(11, 562);
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
            this.dataGridViewBranchInfo.Size = new System.Drawing.Size(1119, 393);
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
            this.dataGridViewCustInfo.Size = new System.Drawing.Size(1120, 135);
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
            this.tabPagePVC.Size = new System.Drawing.Size(1141, 636);
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
            this.tabControlPVC.Size = new System.Drawing.Size(1127, 574);
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
            this.tabPagePVCInventory.Size = new System.Drawing.Size(1119, 545);
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
            this.tabControlPVCInventory.Size = new System.Drawing.Size(1096, 506);
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
            this.tabPagePVCInvDetailed.Size = new System.Drawing.Size(1088, 477);
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
            this.Length,
            this.RecDate});
            this.listViewPVCInvDetail.FullRowSelect = true;
            this.listViewPVCInvDetail.HideSelection = false;
            this.listViewPVCInvDetail.Location = new System.Drawing.Point(5, 2);
            this.listViewPVCInvDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewPVCInvDetail.Name = "listViewPVCInvDetail";
            this.listViewPVCInvDetail.Size = new System.Drawing.Size(1056, 443);
            this.listViewPVCInvDetail.TabIndex = 0;
            this.listViewPVCInvDetail.UseCompatibleStateImageBehavior = false;
            this.listViewPVCInvDetail.View = System.Windows.Forms.View.Details;
            this.listViewPVCInvDetail.SelectedIndexChanged += new System.EventHandler(this.ListViewPVCInvDetail_SelectedIndexChanged);
            this.listViewPVCInvDetail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewPVCInvDetail_MouseDown);
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
            // RecDate
            // 
            this.RecDate.Text = "Date";
            // 
            // tabPagePVCInvTotals
            // 
            this.tabPagePVCInvTotals.Location = new System.Drawing.Point(4, 25);
            this.tabPagePVCInvTotals.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCInvTotals.Name = "tabPagePVCInvTotals";
            this.tabPagePVCInvTotals.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePVCInvTotals.Size = new System.Drawing.Size(1088, 477);
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
            this.tabPagePVCReceiving.Size = new System.Drawing.Size(1119, 545);
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
            this.panelPVCReceiving.Size = new System.Drawing.Size(1105, 516);
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
            this.labelPVCRecPONum.Location = new System.Drawing.Point(16, 447);
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
            this.textBoxPVCRecRefNumber.Location = new System.Drawing.Point(17, 415);
            this.textBoxPVCRecRefNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPVCRecRefNumber.Name = "textBoxPVCRecRefNumber";
            this.textBoxPVCRecRefNumber.Size = new System.Drawing.Size(308, 22);
            this.textBoxPVCRecRefNumber.TabIndex = 3;
            // 
            // buttonPVCRecAdd
            // 
            this.buttonPVCRecAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPVCRecAdd.Location = new System.Drawing.Point(903, 462);
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
            this.dataGridViewPVCRec.Size = new System.Drawing.Size(1085, 335);
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
            this.tabPagePVCItems.Size = new System.Drawing.Size(1119, 545);
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
            this.panelPVCItemDesc.Size = new System.Drawing.Size(1109, 511);
            this.panelPVCItemDesc.TabIndex = 0;
            // 
            // labelPVCItemAddDesc
            // 
            this.labelPVCItemAddDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPVCItemAddDesc.AutoSize = true;
            this.labelPVCItemAddDesc.Location = new System.Drawing.Point(695, 430);
            this.labelPVCItemAddDesc.Name = "labelPVCItemAddDesc";
            this.labelPVCItemAddDesc.Size = new System.Drawing.Size(105, 16);
            this.labelPVCItemAddDesc.TabIndex = 11;
            this.labelPVCItemAddDesc.Text = "PVC Description";
            // 
            // lblPVCItemAddItemNumber
            // 
            this.lblPVCItemAddItemNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPVCItemAddItemNumber.AutoSize = true;
            this.lblPVCItemAddItemNumber.Location = new System.Drawing.Point(471, 430);
            this.lblPVCItemAddItemNumber.Name = "lblPVCItemAddItemNumber";
            this.lblPVCItemAddItemNumber.Size = new System.Drawing.Size(113, 16);
            this.lblPVCItemAddItemNumber.TabIndex = 10;
            this.lblPVCItemAddItemNumber.Text = "PVC Item Number";
            // 
            // lblPVCItemTack
            // 
            this.lblPVCItemTack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPVCItemTack.AutoSize = true;
            this.lblPVCItemTack.Location = new System.Drawing.Point(379, 430);
            this.lblPVCItemTack.Name = "lblPVCItemTack";
            this.lblPVCItemTack.Size = new System.Drawing.Size(38, 16);
            this.lblPVCItemTack.TabIndex = 9;
            this.lblPVCItemTack.Text = "Tack";
            // 
            // lblPVCItemGroup
            // 
            this.lblPVCItemGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPVCItemGroup.AutoSize = true;
            this.lblPVCItemGroup.Location = new System.Drawing.Point(211, 430);
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
            this.comboBoxPVCItemTack.Location = new System.Drawing.Point(375, 447);
            this.comboBoxPVCItemTack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPVCItemTack.Name = "comboBoxPVCItemTack";
            this.comboBoxPVCItemTack.Size = new System.Drawing.Size(93, 24);
            this.comboBoxPVCItemTack.TabIndex = 6;
            // 
            // textBoxPVCItemDescAdd
            // 
            this.textBoxPVCItemDescAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPVCItemDescAdd.Location = new System.Drawing.Point(699, 447);
            this.textBoxPVCItemDescAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPVCItemDescAdd.Name = "textBoxPVCItemDescAdd";
            this.textBoxPVCItemDescAdd.Size = new System.Drawing.Size(260, 22);
            this.textBoxPVCItemDescAdd.TabIndex = 5;
            // 
            // textBoxPVCItemNumberAdd
            // 
            this.textBoxPVCItemNumberAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPVCItemNumberAdd.Location = new System.Drawing.Point(475, 447);
            this.textBoxPVCItemNumberAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPVCItemNumberAdd.Name = "textBoxPVCItemNumberAdd";
            this.textBoxPVCItemNumberAdd.Size = new System.Drawing.Size(217, 22);
            this.textBoxPVCItemNumberAdd.TabIndex = 4;
            // 
            // comboBoxPVCItemGroupAdd
            // 
            this.comboBoxPVCItemGroupAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPVCItemGroupAdd.FormattingEnabled = true;
            this.comboBoxPVCItemGroupAdd.Location = new System.Drawing.Point(213, 447);
            this.comboBoxPVCItemGroupAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPVCItemGroupAdd.Name = "comboBoxPVCItemGroupAdd";
            this.comboBoxPVCItemGroupAdd.Size = new System.Drawing.Size(159, 24);
            this.comboBoxPVCItemGroupAdd.TabIndex = 3;
            // 
            // buttonPVCItemsAddItem
            // 
            this.buttonPVCItemsAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPVCItemsAddItem.Location = new System.Drawing.Point(965, 442);
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
            this.listViewPVCItems.Size = new System.Drawing.Size(1099, 371);
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
            this.tabPagePVCVendor.Size = new System.Drawing.Size(1119, 545);
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
            this.panelPVCVendor.Size = new System.Drawing.Size(1100, 516);
            this.panelPVCVendor.TabIndex = 0;
            // 
            // buttonPVCVendorDeleteRow
            // 
            this.buttonPVCVendorDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPVCVendorDeleteRow.Location = new System.Drawing.Point(781, 469);
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
            this.buttonPVCVendorUpdate.Location = new System.Drawing.Point(931, 469);
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
            this.dataGridViewPVCVendor.Size = new System.Drawing.Size(1095, 447);
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
            this.tabPagePVCGroup.Size = new System.Drawing.Size(1119, 545);
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
            this.tabPagePVCAdjust.Size = new System.Drawing.Size(1119, 545);
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
            this.groupBoxPVCAdjustReason.Location = new System.Drawing.Point(11, 463);
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
            this.listViewPVCAdjInv.Size = new System.Drawing.Size(1116, 456);
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
            this.tabPageRunSheet.Controls.Add(this.statusStrip1);
            this.tabPageRunSheet.Controls.Add(this.cbRunSheetCustPO);
            this.tabPageRunSheet.Controls.Add(this.tabControlOrderMachines);
            this.tabPageRunSheet.Controls.Add(this.lvwRunSheet);
            this.tabPageRunSheet.Location = new System.Drawing.Point(4, 25);
            this.tabPageRunSheet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageRunSheet.Name = "tabPageRunSheet";
            this.tabPageRunSheet.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageRunSheet.Size = new System.Drawing.Size(1141, 636);
            this.tabPageRunSheet.TabIndex = 9;
            this.tabPageRunSheet.Text = "Run Sheet";
            this.tabPageRunSheet.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRunSheetCount,
            this.toolStripStatusLabel1,
            this.tsRunSheetAmount,
            this.toolStripStatusLabel2,
            this.tsRunSheetPieces});
            this.statusStrip1.Location = new System.Drawing.Point(3, 608);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1135, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsRunSheetCount
            // 
            this.tsRunSheetCount.Name = "tsRunSheetCount";
            this.tsRunSheetCount.Size = new System.Drawing.Size(48, 20);
            this.tsRunSheetCount.Text = "Count";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(41, 20);
            this.toolStripStatusLabel1.Text = "        ";
            // 
            // tsRunSheetAmount
            // 
            this.tsRunSheetAmount.Name = "tsRunSheetAmount";
            this.tsRunSheetAmount.Size = new System.Drawing.Size(33, 20);
            this.tsRunSheetAmount.Text = "LBS";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(41, 20);
            this.toolStripStatusLabel2.Text = "        ";
            // 
            // tsRunSheetPieces
            // 
            this.tsRunSheetPieces.Name = "tsRunSheetPieces";
            this.tsRunSheetPieces.Size = new System.Drawing.Size(0, 20);
            // 
            // cbRunSheetCustPO
            // 
            this.cbRunSheetCustPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRunSheetCustPO.AutoSize = true;
            this.cbRunSheetCustPO.Location = new System.Drawing.Point(967, 5);
            this.cbRunSheetCustPO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbRunSheetCustPO.Name = "cbRunSheetCustPO";
            this.cbRunSheetCustPO.Size = new System.Drawing.Size(108, 20);
            this.cbRunSheetCustPO.TabIndex = 2;
            this.cbRunSheetCustPO.Text = "Customer PO";
            this.cbRunSheetCustPO.UseVisualStyleBackColor = true;
            this.cbRunSheetCustPO.CheckedChanged += new System.EventHandler(this.cbRunSheetCustPO_CheckedChanged);
            // 
            // tabControlOrderMachines
            // 
            this.tabControlOrderMachines.Location = new System.Drawing.Point(3, 2);
            this.tabControlOrderMachines.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlOrderMachines.Name = "tabControlOrderMachines";
            this.tabControlOrderMachines.SelectedIndex = 0;
            this.tabControlOrderMachines.Size = new System.Drawing.Size(949, 28);
            this.tabControlOrderMachines.TabIndex = 0;
            this.tabControlOrderMachines.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlOrderMachines_DrawItem);
            this.tabControlOrderMachines.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlOrderMachines_Selected);
            // 
            // lvwRunSheet
            // 
            this.lvwRunSheet.AllowDrop = true;
            this.lvwRunSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwRunSheet.FullRowSelect = true;
            this.lvwRunSheet.HideSelection = false;
            this.lvwRunSheet.Location = new System.Drawing.Point(0, 34);
            this.lvwRunSheet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvwRunSheet.Name = "lvwRunSheet";
            this.lvwRunSheet.Size = new System.Drawing.Size(1129, 563);
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
            // tabPageFix
            // 
            this.tabPageFix.Controls.Add(this.panelFix);
            this.tabPageFix.Location = new System.Drawing.Point(4, 25);
            this.tabPageFix.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageFix.Name = "tabPageFix";
            this.tabPageFix.Size = new System.Drawing.Size(1141, 636);
            this.tabPageFix.TabIndex = 10;
            this.tabPageFix.Text = "Fix";
            this.tabPageFix.UseVisualStyleBackColor = true;
            // 
            // panelFix
            // 
            this.panelFix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFix.Controls.Add(this.tabFixes);
            this.panelFix.Location = new System.Drawing.Point(4, 4);
            this.panelFix.Margin = new System.Windows.Forms.Padding(4);
            this.panelFix.Name = "panelFix";
            this.panelFix.Size = new System.Drawing.Size(1132, 853);
            this.panelFix.TabIndex = 0;
            // 
            // tabFixes
            // 
            this.tabFixes.Controls.Add(this.tabPage1);
            this.tabFixes.Controls.Add(this.tabPage2);
            this.tabFixes.Controls.Add(this.tabPage3);
            this.tabFixes.Controls.Add(this.tabPage4);
            this.tabFixes.Controls.Add(this.tabPage5);
            this.tabFixes.Location = new System.Drawing.Point(11, 5);
            this.tabFixes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFixes.Name = "tabFixes";
            this.tabFixes.SelectedIndex = 0;
            this.tabFixes.Size = new System.Drawing.Size(1067, 532);
            this.tabFixes.TabIndex = 15;
            this.tabFixes.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabFixes_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelFixBackOff);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1059, 503);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Back Off Fix";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelFixBackOff
            // 
            this.panelFixBackOff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFixBackOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFixBackOff.Controls.Add(this.lblFixBackoff);
            this.panelFixBackOff.Controls.Add(this.lblFixOrdid);
            this.panelFixBackOff.Controls.Add(this.btnFixBackoff);
            this.panelFixBackOff.Controls.Add(this.label6);
            this.panelFixBackOff.Controls.Add(this.cbFixBackOffCoils);
            this.panelFixBackOff.Controls.Add(this.tbFixCoilLocation);
            this.panelFixBackOff.Controls.Add(this.tbFixOrderID);
            this.panelFixBackOff.Controls.Add(this.label5);
            this.panelFixBackOff.Controls.Add(this.lblFixPreviousWeight);
            this.panelFixBackOff.Controls.Add(this.lblPrevWeight);
            this.panelFixBackOff.Controls.Add(this.btnFixBackOffWeight);
            this.panelFixBackOff.Controls.Add(this.lblFixNewWeight);
            this.panelFixBackOff.Controls.Add(this.tbFixNewWeight);
            this.panelFixBackOff.Location = new System.Drawing.Point(5, 21);
            this.panelFixBackOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelFixBackOff.Name = "panelFixBackOff";
            this.panelFixBackOff.Size = new System.Drawing.Size(1047, 445);
            this.panelFixBackOff.TabIndex = 13;
            // 
            // lblFixBackoff
            // 
            this.lblFixBackoff.AutoSize = true;
            this.lblFixBackoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixBackoff.Location = new System.Drawing.Point(451, 0);
            this.lblFixBackoff.Name = "lblFixBackoff";
            this.lblFixBackoff.Size = new System.Drawing.Size(174, 25);
            this.lblFixBackoff.TabIndex = 12;
            this.lblFixBackoff.Text = "Back Off Coil Fix";
            // 
            // lblFixOrdid
            // 
            this.lblFixOrdid.AutoSize = true;
            this.lblFixOrdid.Location = new System.Drawing.Point(120, 38);
            this.lblFixOrdid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFixOrdid.Name = "lblFixOrdid";
            this.lblFixOrdid.Size = new System.Drawing.Size(54, 16);
            this.lblFixOrdid.TabIndex = 8;
            this.lblFixOrdid.Text = "OrderID";
            // 
            // btnFixBackoff
            // 
            this.btnFixBackoff.Location = new System.Drawing.Point(9, 57);
            this.btnFixBackoff.Margin = new System.Windows.Forms.Padding(4);
            this.btnFixBackoff.Name = "btnFixBackoff";
            this.btnFixBackoff.Size = new System.Drawing.Size(107, 25);
            this.btnFixBackoff.TabIndex = 0;
            this.btnFixBackoff.Text = "Find Order";
            this.btnFixBackoff.UseVisualStyleBackColor = true;
            this.btnFixBackoff.Click += new System.EventHandler(this.btnFixBackoff_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 158);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Location";
            // 
            // cbFixBackOffCoils
            // 
            this.cbFixBackOffCoils.FormattingEnabled = true;
            this.cbFixBackOffCoils.Location = new System.Drawing.Point(275, 57);
            this.cbFixBackOffCoils.Margin = new System.Windows.Forms.Padding(4);
            this.cbFixBackOffCoils.Name = "cbFixBackOffCoils";
            this.cbFixBackOffCoils.Size = new System.Drawing.Size(183, 24);
            this.cbFixBackOffCoils.TabIndex = 1;
            this.cbFixBackOffCoils.SelectedIndexChanged += new System.EventHandler(this.cbFixBackOffCoils_SelectedIndexChanged);
            // 
            // tbFixCoilLocation
            // 
            this.tbFixCoilLocation.Location = new System.Drawing.Point(479, 154);
            this.tbFixCoilLocation.Margin = new System.Windows.Forms.Padding(4);
            this.tbFixCoilLocation.Name = "tbFixCoilLocation";
            this.tbFixCoilLocation.Size = new System.Drawing.Size(159, 22);
            this.tbFixCoilLocation.TabIndex = 10;
            // 
            // tbFixOrderID
            // 
            this.tbFixOrderID.Location = new System.Drawing.Point(124, 58);
            this.tbFixOrderID.Margin = new System.Windows.Forms.Padding(4);
            this.tbFixOrderID.Name = "tbFixOrderID";
            this.tbFixOrderID.Size = new System.Drawing.Size(141, 22);
            this.tbFixOrderID.TabIndex = 2;
            this.tbFixOrderID.Enter += new System.EventHandler(this.tbFixOrderID_Enter);
            this.tbFixOrderID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFixOrderID_KeyDown);
            this.tbFixOrderID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFixOrderID_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 37);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tag ID(s)";
            // 
            // lblFixPreviousWeight
            // 
            this.lblFixPreviousWeight.AutoSize = true;
            this.lblFixPreviousWeight.Location = new System.Drawing.Point(485, 62);
            this.lblFixPreviousWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFixPreviousWeight.Name = "lblFixPreviousWeight";
            this.lblFixPreviousWeight.Size = new System.Drawing.Size(105, 16);
            this.lblFixPreviousWeight.TabIndex = 3;
            this.lblFixPreviousWeight.Text = "Previous Weight";
            // 
            // lblPrevWeight
            // 
            this.lblPrevWeight.AutoSize = true;
            this.lblPrevWeight.Location = new System.Drawing.Point(625, 62);
            this.lblPrevWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrevWeight.Name = "lblPrevWeight";
            this.lblPrevWeight.Size = new System.Drawing.Size(0, 16);
            this.lblPrevWeight.TabIndex = 4;
            this.lblPrevWeight.Tag = "";
            // 
            // btnFixBackOffWeight
            // 
            this.btnFixBackOffWeight.Location = new System.Drawing.Point(912, 101);
            this.btnFixBackOffWeight.Margin = new System.Windows.Forms.Padding(4);
            this.btnFixBackOffWeight.Name = "btnFixBackOffWeight";
            this.btnFixBackOffWeight.Size = new System.Drawing.Size(91, 25);
            this.btnFixBackOffWeight.TabIndex = 7;
            this.btnFixBackOffWeight.Text = "Fix";
            this.btnFixBackOffWeight.UseVisualStyleBackColor = true;
            this.btnFixBackOffWeight.Click += new System.EventHandler(this.btnFixBackOffWeight_Click);
            // 
            // lblFixNewWeight
            // 
            this.lblFixNewWeight.AutoSize = true;
            this.lblFixNewWeight.Location = new System.Drawing.Point(369, 124);
            this.lblFixNewWeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFixNewWeight.Name = "lblFixNewWeight";
            this.lblFixNewWeight.Size = new System.Drawing.Size(79, 16);
            this.lblFixNewWeight.TabIndex = 5;
            this.lblFixNewWeight.Text = "New Weight";
            // 
            // tbFixNewWeight
            // 
            this.tbFixNewWeight.Location = new System.Drawing.Point(479, 122);
            this.tbFixNewWeight.Margin = new System.Windows.Forms.Padding(4);
            this.tbFixNewWeight.Name = "tbFixNewWeight";
            this.tbFixNewWeight.Size = new System.Drawing.Size(159, 22);
            this.tbFixNewWeight.TabIndex = 6;
            this.tbFixNewWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFixNewWeight_KeyPress);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelFixAddSkid);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1059, 503);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add Skid";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelFixAddSkid
            // 
            this.panelFixAddSkid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFixAddSkid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFixAddSkid.Controls.Add(this.lblFixAddSkid);
            this.panelFixAddSkid.Controls.Add(this.cbFixSkidAddPVCPriceID);
            this.panelFixAddSkid.Controls.Add(this.cbFixSkidAddPVCGroup);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddFinishLabel);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddFinish);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddAlloyLabel);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddAlloy);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddWidthLabel);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddWidth);
            this.panelFixAddSkid.Controls.Add(this.cbFixSkidAddNotPrime);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddLocation);
            this.panelFixAddSkid.Controls.Add(this.tbFixSkidAddLocation);
            this.panelFixAddSkid.Controls.Add(this.cbFixSkidAddMaxSeq);
            this.panelFixAddSkid.Controls.Add(this.btnFixSkidAddInsert);
            this.panelFixAddSkid.Controls.Add(this.tbFixSkidAddMic3);
            this.panelFixAddSkid.Controls.Add(this.tbFixSkidAddMic2);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddMic3);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddMic2);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddMic1);
            this.panelFixAddSkid.Controls.Add(this.tbFixSkidAddMic1);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddDiag2);
            this.panelFixAddSkid.Controls.Add(this.tbFixSkidAddDiag2);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddDiag1);
            this.panelFixAddSkid.Controls.Add(this.tbFixSkidAddDiag1);
            this.panelFixAddSkid.Controls.Add(this.gbFixSkidAddPaper);
            this.panelFixAddSkid.Controls.Add(this.gbFixSkidAddPVC);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddSkidPrice);
            this.panelFixAddSkid.Controls.Add(this.tbFixSkidAddSkidPrice);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddSkidType);
            this.panelFixAddSkid.Controls.Add(this.cbFixSkidAddSkidType);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddLength);
            this.panelFixAddSkid.Controls.Add(this.tbFixSkidAddLength);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddSheetWeight);
            this.panelFixAddSkid.Controls.Add(this.tbFixSkidAddSheetWeight);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddPieces);
            this.panelFixAddSkid.Controls.Add(this.tbFixSkidAddPieces);
            this.panelFixAddSkid.Controls.Add(this.cbFixSkidAddLetters);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddNewLetter);
            this.panelFixAddSkid.Controls.Add(this.tbFixSkidAddNewLetter);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddTagID);
            this.panelFixAddSkid.Controls.Add(this.cbFixSkidAddTagID);
            this.panelFixAddSkid.Controls.Add(this.lblFixSkidAddComments);
            this.panelFixAddSkid.Controls.Add(this.tbFixSkidAddComments);
            this.panelFixAddSkid.Controls.Add(this.lblFixAddSkidOrderID);
            this.panelFixAddSkid.Controls.Add(this.tbFixAddSkidOrderID);
            this.panelFixAddSkid.Location = new System.Drawing.Point(15, 16);
            this.panelFixAddSkid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelFixAddSkid.Name = "panelFixAddSkid";
            this.panelFixAddSkid.Size = new System.Drawing.Size(1019, 470);
            this.panelFixAddSkid.TabIndex = 12;
            // 
            // lblFixAddSkid
            // 
            this.lblFixAddSkid.AutoSize = true;
            this.lblFixAddSkid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixAddSkid.Location = new System.Drawing.Point(491, 5);
            this.lblFixAddSkid.Name = "lblFixAddSkid";
            this.lblFixAddSkid.Size = new System.Drawing.Size(100, 25);
            this.lblFixAddSkid.TabIndex = 42;
            this.lblFixAddSkid.Text = "Add Skid";
            // 
            // cbFixSkidAddPVCPriceID
            // 
            this.cbFixSkidAddPVCPriceID.FormattingEnabled = true;
            this.cbFixSkidAddPVCPriceID.Location = new System.Drawing.Point(671, 199);
            this.cbFixSkidAddPVCPriceID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFixSkidAddPVCPriceID.Name = "cbFixSkidAddPVCPriceID";
            this.cbFixSkidAddPVCPriceID.Size = new System.Drawing.Size(99, 24);
            this.cbFixSkidAddPVCPriceID.TabIndex = 11;
            // 
            // cbFixSkidAddPVCGroup
            // 
            this.cbFixSkidAddPVCGroup.FormattingEnabled = true;
            this.cbFixSkidAddPVCGroup.Location = new System.Drawing.Point(671, 170);
            this.cbFixSkidAddPVCGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFixSkidAddPVCGroup.Name = "cbFixSkidAddPVCGroup";
            this.cbFixSkidAddPVCGroup.Size = new System.Drawing.Size(260, 24);
            this.cbFixSkidAddPVCGroup.TabIndex = 10;
            this.cbFixSkidAddPVCGroup.SelectedIndexChanged += new System.EventHandler(this.cbFixSkidAddPVCGroup_SelectedIndexChanged);
            this.cbFixSkidAddPVCGroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFixSkidAddPVCGroup_KeyPress);
            // 
            // lblFixSkidAddFinishLabel
            // 
            this.lblFixSkidAddFinishLabel.AutoSize = true;
            this.lblFixSkidAddFinishLabel.Location = new System.Drawing.Point(459, 62);
            this.lblFixSkidAddFinishLabel.Name = "lblFixSkidAddFinishLabel";
            this.lblFixSkidAddFinishLabel.Size = new System.Drawing.Size(42, 16);
            this.lblFixSkidAddFinishLabel.TabIndex = 41;
            this.lblFixSkidAddFinishLabel.Text = "Finish";
            // 
            // lblFixSkidAddFinish
            // 
            this.lblFixSkidAddFinish.AutoSize = true;
            this.lblFixSkidAddFinish.Location = new System.Drawing.Point(459, 81);
            this.lblFixSkidAddFinish.Name = "lblFixSkidAddFinish";
            this.lblFixSkidAddFinish.Size = new System.Drawing.Size(0, 16);
            this.lblFixSkidAddFinish.TabIndex = 40;
            // 
            // lblFixSkidAddAlloyLabel
            // 
            this.lblFixSkidAddAlloyLabel.AutoSize = true;
            this.lblFixSkidAddAlloyLabel.Location = new System.Drawing.Point(395, 62);
            this.lblFixSkidAddAlloyLabel.Name = "lblFixSkidAddAlloyLabel";
            this.lblFixSkidAddAlloyLabel.Size = new System.Drawing.Size(37, 16);
            this.lblFixSkidAddAlloyLabel.TabIndex = 39;
            this.lblFixSkidAddAlloyLabel.Text = "Alloy";
            // 
            // lblFixSkidAddAlloy
            // 
            this.lblFixSkidAddAlloy.AutoSize = true;
            this.lblFixSkidAddAlloy.Location = new System.Drawing.Point(395, 81);
            this.lblFixSkidAddAlloy.Name = "lblFixSkidAddAlloy";
            this.lblFixSkidAddAlloy.Size = new System.Drawing.Size(0, 16);
            this.lblFixSkidAddAlloy.TabIndex = 38;
            // 
            // lblFixSkidAddWidthLabel
            // 
            this.lblFixSkidAddWidthLabel.AutoSize = true;
            this.lblFixSkidAddWidthLabel.Location = new System.Drawing.Point(305, 62);
            this.lblFixSkidAddWidthLabel.Name = "lblFixSkidAddWidthLabel";
            this.lblFixSkidAddWidthLabel.Size = new System.Drawing.Size(41, 16);
            this.lblFixSkidAddWidthLabel.TabIndex = 37;
            this.lblFixSkidAddWidthLabel.Text = "Width";
            // 
            // lblFixSkidAddWidth
            // 
            this.lblFixSkidAddWidth.AutoSize = true;
            this.lblFixSkidAddWidth.Location = new System.Drawing.Point(305, 81);
            this.lblFixSkidAddWidth.Name = "lblFixSkidAddWidth";
            this.lblFixSkidAddWidth.Size = new System.Drawing.Size(14, 16);
            this.lblFixSkidAddWidth.TabIndex = 36;
            this.lblFixSkidAddWidth.Text = "0";
            // 
            // cbFixSkidAddNotPrime
            // 
            this.cbFixSkidAddNotPrime.AutoSize = true;
            this.cbFixSkidAddNotPrime.Location = new System.Drawing.Point(661, 249);
            this.cbFixSkidAddNotPrime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFixSkidAddNotPrime.Name = "cbFixSkidAddNotPrime";
            this.cbFixSkidAddNotPrime.Size = new System.Drawing.Size(88, 20);
            this.cbFixSkidAddNotPrime.TabIndex = 19;
            this.cbFixSkidAddNotPrime.Text = "Not Prime";
            this.cbFixSkidAddNotPrime.UseVisualStyleBackColor = true;
            // 
            // lblFixSkidAddLocation
            // 
            this.lblFixSkidAddLocation.AutoSize = true;
            this.lblFixSkidAddLocation.Location = new System.Drawing.Point(355, 174);
            this.lblFixSkidAddLocation.Name = "lblFixSkidAddLocation";
            this.lblFixSkidAddLocation.Size = new System.Drawing.Size(58, 16);
            this.lblFixSkidAddLocation.TabIndex = 34;
            this.lblFixSkidAddLocation.Text = "Location";
            // 
            // tbFixSkidAddLocation
            // 
            this.tbFixSkidAddLocation.Location = new System.Drawing.Point(357, 192);
            this.tbFixSkidAddLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixSkidAddLocation.MaxLength = 10;
            this.tbFixSkidAddLocation.Name = "tbFixSkidAddLocation";
            this.tbFixSkidAddLocation.Size = new System.Drawing.Size(163, 22);
            this.tbFixSkidAddLocation.TabIndex = 13;
            // 
            // cbFixSkidAddMaxSeq
            // 
            this.cbFixSkidAddMaxSeq.FormattingEnabled = true;
            this.cbFixSkidAddMaxSeq.Location = new System.Drawing.Point(859, 2);
            this.cbFixSkidAddMaxSeq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFixSkidAddMaxSeq.Name = "cbFixSkidAddMaxSeq";
            this.cbFixSkidAddMaxSeq.Size = new System.Drawing.Size(127, 24);
            this.cbFixSkidAddMaxSeq.TabIndex = 32;
            this.cbFixSkidAddMaxSeq.Visible = false;
            // 
            // btnFixSkidAddInsert
            // 
            this.btnFixSkidAddInsert.Location = new System.Drawing.Point(883, 240);
            this.btnFixSkidAddInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFixSkidAddInsert.Name = "btnFixSkidAddInsert";
            this.btnFixSkidAddInsert.Size = new System.Drawing.Size(103, 28);
            this.btnFixSkidAddInsert.TabIndex = 20;
            this.btnFixSkidAddInsert.Text = "Add";
            this.btnFixSkidAddInsert.UseVisualStyleBackColor = true;
            this.btnFixSkidAddInsert.Click += new System.EventHandler(this.btnFixSkidAddInsert_Click);
            // 
            // tbFixSkidAddMic3
            // 
            this.tbFixSkidAddMic3.Location = new System.Drawing.Point(531, 246);
            this.tbFixSkidAddMic3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixSkidAddMic3.Name = "tbFixSkidAddMic3";
            this.tbFixSkidAddMic3.Size = new System.Drawing.Size(97, 22);
            this.tbFixSkidAddMic3.TabIndex = 18;
            this.tbFixSkidAddMic3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFixSkidAddMic3_KeyPress);
            // 
            // tbFixSkidAddMic2
            // 
            this.tbFixSkidAddMic2.Location = new System.Drawing.Point(412, 247);
            this.tbFixSkidAddMic2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixSkidAddMic2.Name = "tbFixSkidAddMic2";
            this.tbFixSkidAddMic2.Size = new System.Drawing.Size(97, 22);
            this.tbFixSkidAddMic2.TabIndex = 17;
            this.tbFixSkidAddMic2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFixSkidAddMic2_KeyPress);
            // 
            // lblFixSkidAddMic3
            // 
            this.lblFixSkidAddMic3.AutoSize = true;
            this.lblFixSkidAddMic3.Location = new System.Drawing.Point(528, 226);
            this.lblFixSkidAddMic3.Name = "lblFixSkidAddMic3";
            this.lblFixSkidAddMic3.Size = new System.Drawing.Size(35, 16);
            this.lblFixSkidAddMic3.TabIndex = 28;
            this.lblFixSkidAddMic3.Text = "Mic3";
            // 
            // lblFixSkidAddMic2
            // 
            this.lblFixSkidAddMic2.AutoSize = true;
            this.lblFixSkidAddMic2.Location = new System.Drawing.Point(409, 226);
            this.lblFixSkidAddMic2.Name = "lblFixSkidAddMic2";
            this.lblFixSkidAddMic2.Size = new System.Drawing.Size(35, 16);
            this.lblFixSkidAddMic2.TabIndex = 27;
            this.lblFixSkidAddMic2.Text = "Mic2";
            // 
            // lblFixSkidAddMic1
            // 
            this.lblFixSkidAddMic1.AutoSize = true;
            this.lblFixSkidAddMic1.Location = new System.Drawing.Point(271, 228);
            this.lblFixSkidAddMic1.Name = "lblFixSkidAddMic1";
            this.lblFixSkidAddMic1.Size = new System.Drawing.Size(35, 16);
            this.lblFixSkidAddMic1.TabIndex = 26;
            this.lblFixSkidAddMic1.Text = "Mic1";
            // 
            // tbFixSkidAddMic1
            // 
            this.tbFixSkidAddMic1.Location = new System.Drawing.Point(275, 247);
            this.tbFixSkidAddMic1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixSkidAddMic1.Name = "tbFixSkidAddMic1";
            this.tbFixSkidAddMic1.Size = new System.Drawing.Size(97, 22);
            this.tbFixSkidAddMic1.TabIndex = 16;
            this.tbFixSkidAddMic1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFixSkidAddMic1_KeyPress);
            // 
            // lblFixSkidAddDiag2
            // 
            this.lblFixSkidAddDiag2.AutoSize = true;
            this.lblFixSkidAddDiag2.Location = new System.Drawing.Point(139, 228);
            this.lblFixSkidAddDiag2.Name = "lblFixSkidAddDiag2";
            this.lblFixSkidAddDiag2.Size = new System.Drawing.Size(43, 16);
            this.lblFixSkidAddDiag2.TabIndex = 24;
            this.lblFixSkidAddDiag2.Text = "Diag2";
            // 
            // tbFixSkidAddDiag2
            // 
            this.tbFixSkidAddDiag2.Location = new System.Drawing.Point(141, 247);
            this.tbFixSkidAddDiag2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixSkidAddDiag2.Name = "tbFixSkidAddDiag2";
            this.tbFixSkidAddDiag2.Size = new System.Drawing.Size(97, 22);
            this.tbFixSkidAddDiag2.TabIndex = 15;
            this.tbFixSkidAddDiag2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFixSkidAddDiag2_KeyPress);
            // 
            // lblFixSkidAddDiag1
            // 
            this.lblFixSkidAddDiag1.AutoSize = true;
            this.lblFixSkidAddDiag1.Location = new System.Drawing.Point(15, 228);
            this.lblFixSkidAddDiag1.Name = "lblFixSkidAddDiag1";
            this.lblFixSkidAddDiag1.Size = new System.Drawing.Size(43, 16);
            this.lblFixSkidAddDiag1.TabIndex = 22;
            this.lblFixSkidAddDiag1.Text = "Diag1";
            // 
            // tbFixSkidAddDiag1
            // 
            this.tbFixSkidAddDiag1.Location = new System.Drawing.Point(19, 247);
            this.tbFixSkidAddDiag1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixSkidAddDiag1.Name = "tbFixSkidAddDiag1";
            this.tbFixSkidAddDiag1.Size = new System.Drawing.Size(97, 22);
            this.tbFixSkidAddDiag1.TabIndex = 14;
            this.tbFixSkidAddDiag1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFixSkidAddDiag1_KeyPress);
            // 
            // gbFixSkidAddPaper
            // 
            this.gbFixSkidAddPaper.Controls.Add(this.rbFixSkidAddPaperNo);
            this.gbFixSkidAddPaper.Controls.Add(this.rbFixSkidAddPaperYes);
            this.gbFixSkidAddPaper.Location = new System.Drawing.Point(804, 122);
            this.gbFixSkidAddPaper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFixSkidAddPaper.Name = "gbFixSkidAddPaper";
            this.gbFixSkidAddPaper.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFixSkidAddPaper.Size = new System.Drawing.Size(127, 42);
            this.gbFixSkidAddPaper.TabIndex = 9;
            this.gbFixSkidAddPaper.TabStop = false;
            this.gbFixSkidAddPaper.Text = "Paper";
            // 
            // rbFixSkidAddPaperNo
            // 
            this.rbFixSkidAddPaperNo.AutoSize = true;
            this.rbFixSkidAddPaperNo.Location = new System.Drawing.Point(69, 18);
            this.rbFixSkidAddPaperNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbFixSkidAddPaperNo.Name = "rbFixSkidAddPaperNo";
            this.rbFixSkidAddPaperNo.Size = new System.Drawing.Size(46, 20);
            this.rbFixSkidAddPaperNo.TabIndex = 1;
            this.rbFixSkidAddPaperNo.Text = "No";
            this.rbFixSkidAddPaperNo.UseVisualStyleBackColor = true;
            // 
            // rbFixSkidAddPaperYes
            // 
            this.rbFixSkidAddPaperYes.AutoSize = true;
            this.rbFixSkidAddPaperYes.Location = new System.Drawing.Point(5, 18);
            this.rbFixSkidAddPaperYes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbFixSkidAddPaperYes.Name = "rbFixSkidAddPaperYes";
            this.rbFixSkidAddPaperYes.Size = new System.Drawing.Size(52, 20);
            this.rbFixSkidAddPaperYes.TabIndex = 0;
            this.rbFixSkidAddPaperYes.Text = "Yes";
            this.rbFixSkidAddPaperYes.UseVisualStyleBackColor = true;
            // 
            // gbFixSkidAddPVC
            // 
            this.gbFixSkidAddPVC.Controls.Add(this.rbFixSkidAddPVCNo);
            this.gbFixSkidAddPVC.Controls.Add(this.rbFixSkidAddPVCYes);
            this.gbFixSkidAddPVC.Location = new System.Drawing.Point(671, 122);
            this.gbFixSkidAddPVC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFixSkidAddPVC.Name = "gbFixSkidAddPVC";
            this.gbFixSkidAddPVC.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFixSkidAddPVC.Size = new System.Drawing.Size(127, 42);
            this.gbFixSkidAddPVC.TabIndex = 8;
            this.gbFixSkidAddPVC.TabStop = false;
            this.gbFixSkidAddPVC.Text = "PVC";
            // 
            // rbFixSkidAddPVCNo
            // 
            this.rbFixSkidAddPVCNo.AutoSize = true;
            this.rbFixSkidAddPVCNo.Location = new System.Drawing.Point(69, 18);
            this.rbFixSkidAddPVCNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbFixSkidAddPVCNo.Name = "rbFixSkidAddPVCNo";
            this.rbFixSkidAddPVCNo.Size = new System.Drawing.Size(46, 20);
            this.rbFixSkidAddPVCNo.TabIndex = 1;
            this.rbFixSkidAddPVCNo.Text = "No";
            this.rbFixSkidAddPVCNo.UseVisualStyleBackColor = true;
            this.rbFixSkidAddPVCNo.CheckedChanged += new System.EventHandler(this.rbFixSkidAddPVCNo_CheckedChanged);
            // 
            // rbFixSkidAddPVCYes
            // 
            this.rbFixSkidAddPVCYes.AutoSize = true;
            this.rbFixSkidAddPVCYes.Location = new System.Drawing.Point(5, 18);
            this.rbFixSkidAddPVCYes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbFixSkidAddPVCYes.Name = "rbFixSkidAddPVCYes";
            this.rbFixSkidAddPVCYes.Size = new System.Drawing.Size(52, 20);
            this.rbFixSkidAddPVCYes.TabIndex = 0;
            this.rbFixSkidAddPVCYes.Text = "Yes";
            this.rbFixSkidAddPVCYes.UseVisualStyleBackColor = true;
            this.rbFixSkidAddPVCYes.CheckedChanged += new System.EventHandler(this.rbFixSkidAddPVCYes_CheckedChanged);
            // 
            // lblFixSkidAddSkidPrice
            // 
            this.lblFixSkidAddSkidPrice.AutoSize = true;
            this.lblFixSkidAddSkidPrice.Location = new System.Drawing.Point(539, 121);
            this.lblFixSkidAddSkidPrice.Name = "lblFixSkidAddSkidPrice";
            this.lblFixSkidAddSkidPrice.Size = new System.Drawing.Size(68, 16);
            this.lblFixSkidAddSkidPrice.TabIndex = 18;
            this.lblFixSkidAddSkidPrice.Text = "Skid Price";
            // 
            // tbFixSkidAddSkidPrice
            // 
            this.tbFixSkidAddSkidPrice.Location = new System.Drawing.Point(541, 139);
            this.tbFixSkidAddSkidPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixSkidAddSkidPrice.Name = "tbFixSkidAddSkidPrice";
            this.tbFixSkidAddSkidPrice.Size = new System.Drawing.Size(97, 22);
            this.tbFixSkidAddSkidPrice.TabIndex = 7;
            this.tbFixSkidAddSkidPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFixSkidAddSkidPrice_KeyPress);
            // 
            // lblFixSkidAddSkidType
            // 
            this.lblFixSkidAddSkidType.AutoSize = true;
            this.lblFixSkidAddSkidType.Location = new System.Drawing.Point(399, 121);
            this.lblFixSkidAddSkidType.Name = "lblFixSkidAddSkidType";
            this.lblFixSkidAddSkidType.Size = new System.Drawing.Size(69, 16);
            this.lblFixSkidAddSkidType.TabIndex = 16;
            this.lblFixSkidAddSkidType.Text = "Skid Type";
            // 
            // cbFixSkidAddSkidType
            // 
            this.cbFixSkidAddSkidType.FormattingEnabled = true;
            this.cbFixSkidAddSkidType.Location = new System.Drawing.Point(403, 139);
            this.cbFixSkidAddSkidType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFixSkidAddSkidType.Name = "cbFixSkidAddSkidType";
            this.cbFixSkidAddSkidType.Size = new System.Drawing.Size(115, 24);
            this.cbFixSkidAddSkidType.TabIndex = 6;
            this.cbFixSkidAddSkidType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFixSkidAddSkidType_KeyPress);
            // 
            // lblFixSkidAddLength
            // 
            this.lblFixSkidAddLength.AutoSize = true;
            this.lblFixSkidAddLength.Location = new System.Drawing.Point(276, 121);
            this.lblFixSkidAddLength.Name = "lblFixSkidAddLength";
            this.lblFixSkidAddLength.Size = new System.Drawing.Size(47, 16);
            this.lblFixSkidAddLength.TabIndex = 14;
            this.lblFixSkidAddLength.Text = "Length";
            // 
            // tbFixSkidAddLength
            // 
            this.tbFixSkidAddLength.Location = new System.Drawing.Point(279, 139);
            this.tbFixSkidAddLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixSkidAddLength.Name = "tbFixSkidAddLength";
            this.tbFixSkidAddLength.Size = new System.Drawing.Size(97, 22);
            this.tbFixSkidAddLength.TabIndex = 5;
            this.tbFixSkidAddLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFixSkidAddLength_KeyPress);
            // 
            // lblFixSkidAddSheetWeight
            // 
            this.lblFixSkidAddSheetWeight.AutoSize = true;
            this.lblFixSkidAddSheetWeight.Location = new System.Drawing.Point(140, 121);
            this.lblFixSkidAddSheetWeight.Name = "lblFixSkidAddSheetWeight";
            this.lblFixSkidAddSheetWeight.Size = new System.Drawing.Size(87, 16);
            this.lblFixSkidAddSheetWeight.TabIndex = 12;
            this.lblFixSkidAddSheetWeight.Text = "Sheet Weight";
            // 
            // tbFixSkidAddSheetWeight
            // 
            this.tbFixSkidAddSheetWeight.Location = new System.Drawing.Point(143, 139);
            this.tbFixSkidAddSheetWeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixSkidAddSheetWeight.Name = "tbFixSkidAddSheetWeight";
            this.tbFixSkidAddSheetWeight.Size = new System.Drawing.Size(97, 22);
            this.tbFixSkidAddSheetWeight.TabIndex = 4;
            this.tbFixSkidAddSheetWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFixSkidAddSheetWeight_KeyPress);
            // 
            // lblFixSkidAddPieces
            // 
            this.lblFixSkidAddPieces.AutoSize = true;
            this.lblFixSkidAddPieces.Location = new System.Drawing.Point(15, 121);
            this.lblFixSkidAddPieces.Name = "lblFixSkidAddPieces";
            this.lblFixSkidAddPieces.Size = new System.Drawing.Size(49, 16);
            this.lblFixSkidAddPieces.TabIndex = 10;
            this.lblFixSkidAddPieces.Text = "Pieces";
            // 
            // tbFixSkidAddPieces
            // 
            this.tbFixSkidAddPieces.Location = new System.Drawing.Point(19, 139);
            this.tbFixSkidAddPieces.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixSkidAddPieces.Name = "tbFixSkidAddPieces";
            this.tbFixSkidAddPieces.Size = new System.Drawing.Size(97, 22);
            this.tbFixSkidAddPieces.TabIndex = 3;
            this.tbFixSkidAddPieces.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFixSkidAddPieces_KeyPress);
            // 
            // cbFixSkidAddLetters
            // 
            this.cbFixSkidAddLetters.FormattingEnabled = true;
            this.cbFixSkidAddLetters.Location = new System.Drawing.Point(741, 5);
            this.cbFixSkidAddLetters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFixSkidAddLetters.Name = "cbFixSkidAddLetters";
            this.cbFixSkidAddLetters.Size = new System.Drawing.Size(111, 24);
            this.cbFixSkidAddLetters.TabIndex = 8;
            this.cbFixSkidAddLetters.Visible = false;
            this.cbFixSkidAddLetters.SelectedIndexChanged += new System.EventHandler(this.cbFixSkidAddLetters_SelectedIndexChanged);
            // 
            // lblFixSkidAddNewLetter
            // 
            this.lblFixSkidAddNewLetter.AutoSize = true;
            this.lblFixSkidAddNewLetter.Location = new System.Drawing.Point(169, 62);
            this.lblFixSkidAddNewLetter.Name = "lblFixSkidAddNewLetter";
            this.lblFixSkidAddNewLetter.Size = new System.Drawing.Size(40, 16);
            this.lblFixSkidAddNewLetter.TabIndex = 7;
            this.lblFixSkidAddNewLetter.Text = "Letter";
            // 
            // tbFixSkidAddNewLetter
            // 
            this.tbFixSkidAddNewLetter.Location = new System.Drawing.Point(172, 79);
            this.tbFixSkidAddNewLetter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixSkidAddNewLetter.Name = "tbFixSkidAddNewLetter";
            this.tbFixSkidAddNewLetter.Size = new System.Drawing.Size(97, 22);
            this.tbFixSkidAddNewLetter.TabIndex = 2;
            // 
            // lblFixSkidAddTagID
            // 
            this.lblFixSkidAddTagID.AutoSize = true;
            this.lblFixSkidAddTagID.Location = new System.Drawing.Point(15, 62);
            this.lblFixSkidAddTagID.Name = "lblFixSkidAddTagID";
            this.lblFixSkidAddTagID.Size = new System.Drawing.Size(48, 16);
            this.lblFixSkidAddTagID.TabIndex = 5;
            this.lblFixSkidAddTagID.Text = "Tag ID";
            // 
            // cbFixSkidAddTagID
            // 
            this.cbFixSkidAddTagID.FormattingEnabled = true;
            this.cbFixSkidAddTagID.Location = new System.Drawing.Point(19, 80);
            this.cbFixSkidAddTagID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFixSkidAddTagID.Name = "cbFixSkidAddTagID";
            this.cbFixSkidAddTagID.Size = new System.Drawing.Size(129, 24);
            this.cbFixSkidAddTagID.TabIndex = 1;
            this.cbFixSkidAddTagID.SelectedIndexChanged += new System.EventHandler(this.cbFixSkidAddTagID_SelectedIndexChanged);
            this.cbFixSkidAddTagID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFixSkidAddTagID_KeyPress);
            // 
            // lblFixSkidAddComments
            // 
            this.lblFixSkidAddComments.AutoSize = true;
            this.lblFixSkidAddComments.Location = new System.Drawing.Point(15, 174);
            this.lblFixSkidAddComments.Name = "lblFixSkidAddComments";
            this.lblFixSkidAddComments.Size = new System.Drawing.Size(71, 16);
            this.lblFixSkidAddComments.TabIndex = 3;
            this.lblFixSkidAddComments.Text = "Comments";
            // 
            // tbFixSkidAddComments
            // 
            this.tbFixSkidAddComments.Location = new System.Drawing.Point(19, 192);
            this.tbFixSkidAddComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixSkidAddComments.MaxLength = 100;
            this.tbFixSkidAddComments.Name = "tbFixSkidAddComments";
            this.tbFixSkidAddComments.Size = new System.Drawing.Size(323, 22);
            this.tbFixSkidAddComments.TabIndex = 12;
            // 
            // lblFixAddSkidOrderID
            // 
            this.lblFixAddSkidOrderID.AutoSize = true;
            this.lblFixAddSkidOrderID.Location = new System.Drawing.Point(15, 5);
            this.lblFixAddSkidOrderID.Name = "lblFixAddSkidOrderID";
            this.lblFixAddSkidOrderID.Size = new System.Drawing.Size(54, 16);
            this.lblFixAddSkidOrderID.TabIndex = 1;
            this.lblFixAddSkidOrderID.Text = "OrderID";
            // 
            // tbFixAddSkidOrderID
            // 
            this.tbFixAddSkidOrderID.Location = new System.Drawing.Point(19, 25);
            this.tbFixAddSkidOrderID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixAddSkidOrderID.Name = "tbFixAddSkidOrderID";
            this.tbFixAddSkidOrderID.Size = new System.Drawing.Size(129, 22);
            this.tbFixAddSkidOrderID.TabIndex = 0;
            this.tbFixAddSkidOrderID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFixAddSkidOrderID_KeyDown);
            this.tbFixAddSkidOrderID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFixAddSkidOrderID_KeyPress);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panelFixAddDamage);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(1059, 503);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Update Damage";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panelFixAddDamage
            // 
            this.panelFixAddDamage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFixAddDamage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFixAddDamage.Controls.Add(this.lblFixAddDamageTagIDs);
            this.panelFixAddDamage.Controls.Add(this.btnFixAddDamage);
            this.panelFixAddDamage.Controls.Add(this.lblFixAddDamageBOL);
            this.panelFixAddDamage.Controls.Add(this.cbFixAddDamageTagIDs);
            this.panelFixAddDamage.Controls.Add(this.lblfixAddDamage);
            this.panelFixAddDamage.Controls.Add(this.tbFixAddDamageBOL);
            this.panelFixAddDamage.Controls.Add(this.clbFixAddDamage);
            this.panelFixAddDamage.Location = new System.Drawing.Point(5, 6);
            this.panelFixAddDamage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelFixAddDamage.Name = "panelFixAddDamage";
            this.panelFixAddDamage.Size = new System.Drawing.Size(1105, 563);
            this.panelFixAddDamage.TabIndex = 14;
            // 
            // lblFixAddDamageTagIDs
            // 
            this.lblFixAddDamageTagIDs.AutoSize = true;
            this.lblFixAddDamageTagIDs.Location = new System.Drawing.Point(197, 41);
            this.lblFixAddDamageTagIDs.Name = "lblFixAddDamageTagIDs";
            this.lblFixAddDamageTagIDs.Size = new System.Drawing.Size(55, 16);
            this.lblFixAddDamageTagIDs.TabIndex = 6;
            this.lblFixAddDamageTagIDs.Text = "Tag IDs";
            // 
            // btnFixAddDamage
            // 
            this.btnFixAddDamage.Location = new System.Drawing.Point(197, 121);
            this.btnFixAddDamage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFixAddDamage.Name = "btnFixAddDamage";
            this.btnFixAddDamage.Size = new System.Drawing.Size(137, 28);
            this.btnFixAddDamage.TabIndex = 5;
            this.btnFixAddDamage.Text = "Update Damage";
            this.btnFixAddDamage.UseVisualStyleBackColor = true;
            this.btnFixAddDamage.Click += new System.EventHandler(this.btnFixAddDamage_Click);
            // 
            // lblFixAddDamageBOL
            // 
            this.lblFixAddDamageBOL.AutoSize = true;
            this.lblFixAddDamageBOL.Location = new System.Drawing.Point(20, 41);
            this.lblFixAddDamageBOL.Name = "lblFixAddDamageBOL";
            this.lblFixAddDamageBOL.Size = new System.Drawing.Size(40, 16);
            this.lblFixAddDamageBOL.TabIndex = 4;
            this.lblFixAddDamageBOL.Text = "BOL#";
            // 
            // cbFixAddDamageTagIDs
            // 
            this.cbFixAddDamageTagIDs.FormattingEnabled = true;
            this.cbFixAddDamageTagIDs.Location = new System.Drawing.Point(197, 60);
            this.cbFixAddDamageTagIDs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFixAddDamageTagIDs.Name = "cbFixAddDamageTagIDs";
            this.cbFixAddDamageTagIDs.Size = new System.Drawing.Size(215, 24);
            this.cbFixAddDamageTagIDs.TabIndex = 3;
            this.cbFixAddDamageTagIDs.SelectedIndexChanged += new System.EventHandler(this.cbFixAddDamageTagIDs_SelectedIndexChanged);
            this.cbFixAddDamageTagIDs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFixAddDamageTagIDs_KeyPress);
            // 
            // lblfixAddDamage
            // 
            this.lblfixAddDamage.AutoSize = true;
            this.lblfixAddDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfixAddDamage.Location = new System.Drawing.Point(473, -1);
            this.lblfixAddDamage.Name = "lblfixAddDamage";
            this.lblfixAddDamage.Size = new System.Drawing.Size(167, 25);
            this.lblfixAddDamage.TabIndex = 2;
            this.lblfixAddDamage.Text = "Update Damage";
            // 
            // tbFixAddDamageBOL
            // 
            this.tbFixAddDamageBOL.Location = new System.Drawing.Point(19, 60);
            this.tbFixAddDamageBOL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixAddDamageBOL.Name = "tbFixAddDamageBOL";
            this.tbFixAddDamageBOL.Size = new System.Drawing.Size(144, 22);
            this.tbFixAddDamageBOL.TabIndex = 1;
            this.tbFixAddDamageBOL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFixAddDamageBOL_KeyDown);
            this.tbFixAddDamageBOL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFixAddDamageBOL_KeyPress);
            // 
            // clbFixAddDamage
            // 
            this.clbFixAddDamage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbFixAddDamage.CheckOnClick = true;
            this.clbFixAddDamage.FormattingEnabled = true;
            this.clbFixAddDamage.Location = new System.Drawing.Point(445, 60);
            this.clbFixAddDamage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clbFixAddDamage.Name = "clbFixAddDamage";
            this.clbFixAddDamage.Size = new System.Drawing.Size(545, 395);
            this.clbFixAddDamage.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panelFixBOL);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(1059, 503);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Fix BOL";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panelFixBOL
            // 
            this.panelFixBOL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFixBOL.Controls.Add(this.btnFixBOLFinish);
            this.panelFixBOL.Controls.Add(this.lblFixBOLNum);
            this.panelFixBOL.Controls.Add(this.tbFixBOLNum);
            this.panelFixBOL.Controls.Add(this.cblFixBOLList);
            this.panelFixBOL.Location = new System.Drawing.Point(11, 14);
            this.panelFixBOL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelFixBOL.Name = "panelFixBOL";
            this.panelFixBOL.Size = new System.Drawing.Size(1027, 470);
            this.panelFixBOL.TabIndex = 0;
            // 
            // btnFixBOLFinish
            // 
            this.btnFixBOLFinish.Location = new System.Drawing.Point(469, 34);
            this.btnFixBOLFinish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFixBOLFinish.Name = "btnFixBOLFinish";
            this.btnFixBOLFinish.Size = new System.Drawing.Size(131, 33);
            this.btnFixBOLFinish.TabIndex = 4;
            this.btnFixBOLFinish.Text = "Finish";
            this.btnFixBOLFinish.UseVisualStyleBackColor = true;
            this.btnFixBOLFinish.Click += new System.EventHandler(this.btnFixBOLFinish_Click);
            // 
            // lblFixBOLNum
            // 
            this.lblFixBOLNum.AutoSize = true;
            this.lblFixBOLNum.Location = new System.Drawing.Point(21, 39);
            this.lblFixBOLNum.Name = "lblFixBOLNum";
            this.lblFixBOLNum.Size = new System.Drawing.Size(40, 16);
            this.lblFixBOLNum.TabIndex = 3;
            this.lblFixBOLNum.Text = "BOL#";
            // 
            // tbFixBOLNum
            // 
            this.tbFixBOLNum.Location = new System.Drawing.Point(67, 37);
            this.tbFixBOLNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFixBOLNum.Name = "tbFixBOLNum";
            this.tbFixBOLNum.Size = new System.Drawing.Size(137, 22);
            this.tbFixBOLNum.TabIndex = 2;
            this.tbFixBOLNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFixBOLNum_KeyDown);
            this.tbFixBOLNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFixBOLNum_KeyPress);
            // 
            // cblFixBOLList
            // 
            this.cblFixBOLList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cblFixBOLList.CheckOnClick = true;
            this.cblFixBOLList.FormattingEnabled = true;
            this.cblFixBOLList.Location = new System.Drawing.Point(631, 20);
            this.cblFixBOLList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cblFixBOLList.Name = "cblFixBOLList";
            this.cblFixBOLList.Size = new System.Drawing.Size(365, 412);
            this.cblFixBOLList.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.lvFixOpenBOLs);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1059, 503);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Open BOLs";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // lvFixOpenBOLs
            // 
            this.lvFixOpenBOLs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFixOpenBOLs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader103,
            this.columnHeader104,
            this.columnHeader105,
            this.columnHeader106});
            this.lvFixOpenBOLs.HideSelection = false;
            this.lvFixOpenBOLs.Location = new System.Drawing.Point(5, 11);
            this.lvFixOpenBOLs.Name = "lvFixOpenBOLs";
            this.lvFixOpenBOLs.Size = new System.Drawing.Size(1037, 486);
            this.lvFixOpenBOLs.TabIndex = 0;
            this.lvFixOpenBOLs.UseCompatibleStateImageBehavior = false;
            this.lvFixOpenBOLs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader103
            // 
            this.columnHeader103.Text = "Customer";
            // 
            // columnHeader104
            // 
            this.columnHeader104.Text = "ShipID";
            // 
            // columnHeader105
            // 
            this.columnHeader105.Text = "Rel Date";
            // 
            // columnHeader106
            // 
            this.columnHeader106.Text = "TagID";
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
            this.historyToolStripMenuItem,
            this.convertToSkidToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(180, 100);
            // 
            // toolMenuPrintLabel
            // 
            this.toolMenuPrintLabel.Name = "toolMenuPrintLabel";
            this.toolMenuPrintLabel.Size = new System.Drawing.Size(179, 24);
            this.toolMenuPrintLabel.Text = "Print Label";
            this.toolMenuPrintLabel.Click += new System.EventHandler(this.toolMenuPrintLabel_Click);
            // 
            // transferCoilToolStripMenuItem
            // 
            this.transferCoilToolStripMenuItem.Name = "transferCoilToolStripMenuItem";
            this.transferCoilToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.transferCoilToolStripMenuItem.Text = "Transfer";
            this.transferCoilToolStripMenuItem.Click += new System.EventHandler(this.transferCoilToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.historyToolStripMenuItem.Text = "History";
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
            // 
            // convertToSkidToolStripMenuItem
            // 
            this.convertToSkidToolStripMenuItem.Name = "convertToSkidToolStripMenuItem";
            this.convertToSkidToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.convertToSkidToolStripMenuItem.Text = "Convert to Skid";
            this.convertToSkidToolStripMenuItem.Visible = false;
            this.convertToSkidToolStripMenuItem.Click += new System.EventHandler(this.convertToSkidToolStripMenuItem_Click);
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
            this.btAddCustomer.Location = new System.Drawing.Point(5, 34);
            this.btAddCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAddCustomer.Name = "btAddCustomer";
            this.btAddCustomer.Size = new System.Drawing.Size(109, 25);
            this.btAddCustomer.TabIndex = 8;
            this.btAddCustomer.Text = "Add Customer";
            this.btAddCustomer.UseVisualStyleBackColor = true;
            this.btAddCustomer.Click += new System.EventHandler(this.btAddCustomer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(709, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            // 
            // MenuRunSheetRightClick
            // 
            this.MenuRunSheetRightClick.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuRunSheetRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.putOnHoldToolStripMenuItem,
            this.commentsToolStripMenuItem});
            this.MenuRunSheetRightClick.Name = "MenuRunSheetRightClick";
            this.MenuRunSheetRightClick.Size = new System.Drawing.Size(160, 52);
            // 
            // putOnHoldToolStripMenuItem
            // 
            this.putOnHoldToolStripMenuItem.Name = "putOnHoldToolStripMenuItem";
            this.putOnHoldToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.putOnHoldToolStripMenuItem.Text = "Put On Hold";
            this.putOnHoldToolStripMenuItem.Click += new System.EventHandler(this.putOnHoldToolStripMenuItem_Click);
            // 
            // commentsToolStripMenuItem
            // 
            this.commentsToolStripMenuItem.Name = "commentsToolStripMenuItem";
            this.commentsToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.commentsToolStripMenuItem.Text = "Comments";
            this.commentsToolStripMenuItem.Click += new System.EventHandler(this.commentsToolStripMenuItem_Click);
            // 
            // menuCustomer
            // 
            this.menuCustomer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuCustomer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deactivateCustomerToolStripMenuItem});
            this.menuCustomer.Name = "menuCustomer";
            this.menuCustomer.Size = new System.Drawing.Size(217, 28);
            // 
            // deactivateCustomerToolStripMenuItem
            // 
            this.deactivateCustomerToolStripMenuItem.Name = "deactivateCustomerToolStripMenuItem";
            this.deactivateCustomerToolStripMenuItem.Size = new System.Drawing.Size(216, 24);
            this.deactivateCustomerToolStripMenuItem.Text = "Deactivate Customer";
            this.deactivateCustomerToolStripMenuItem.Click += new System.EventHandler(this.deactivateCustomerToolStripMenuItem_Click);
            // 
            // MenuClClDiff
            // 
            this.MenuClClDiff.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuClClDiff.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeCommentsToolStripMenuItem,
            this.removeSlitWidthToolStripMenuItem});
            this.MenuClClDiff.Name = "MenuClClDiff";
            this.MenuClClDiff.Size = new System.Drawing.Size(204, 52);
            // 
            // changeCommentsToolStripMenuItem
            // 
            this.changeCommentsToolStripMenuItem.Name = "changeCommentsToolStripMenuItem";
            this.changeCommentsToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.changeCommentsToolStripMenuItem.Text = "Change Comments";
            this.changeCommentsToolStripMenuItem.Click += new System.EventHandler(this.changeCommentsToolStripMenuItem_Click);
            // 
            // removeSlitWidthToolStripMenuItem
            // 
            this.removeSlitWidthToolStripMenuItem.Name = "removeSlitWidthToolStripMenuItem";
            this.removeSlitWidthToolStripMenuItem.Size = new System.Drawing.Size(203, 24);
            this.removeSlitWidthToolStripMenuItem.Text = "Remove Slit Width";
            this.removeSlitWidthToolStripMenuItem.Click += new System.EventHandler(this.removeSlitWidthToolStripMenuItem_Click);
            // 
            // menuShippingTransfer
            // 
            this.menuShippingTransfer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuShippingTransfer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transferToolStripMenuItem});
            this.menuShippingTransfer.Name = "menuShippingTransfer";
            this.menuShippingTransfer.Size = new System.Drawing.Size(251, 28);
            // 
            // transferToolStripMenuItem
            // 
            this.transferToolStripMenuItem.Name = "transferToolStripMenuItem";
            this.transferToolStripMenuItem.Size = new System.Drawing.Size(250, 24);
            this.transferToolStripMenuItem.Text = "Transfer all Checked Items";
            this.transferToolStripMenuItem.Click += new System.EventHandler(this.transferToolStripMenuItem_Click);
            // 
            // cmPVCLabelPrint
            // 
            this.cmPVCLabelPrint.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmPVCLabelPrint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printPVCLabelToolStripMenuItem});
            this.cmPVCLabelPrint.Name = "cmPVCLabelPrint";
            this.cmPVCLabelPrint.Size = new System.Drawing.Size(179, 28);
            // 
            // printPVCLabelToolStripMenuItem
            // 
            this.printPVCLabelToolStripMenuItem.Name = "printPVCLabelToolStripMenuItem";
            this.printPVCLabelToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.printPVCLabelToolStripMenuItem.Text = "Print PVC Label";
            this.printPVCLabelToolStripMenuItem.Click += new System.EventHandler(this.printPVCLabelToolStripMenuItem_Click);
            // 
            // FormICMSMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 734);
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
            this.tabPageAdders.ResumeLayout(false);
            this.tabPageAdders.PerformLayout();
            this.groupBoxSettingAddersPriceType.ResumeLayout(false);
            this.groupBoxSettingAddersPriceType.PerformLayout();
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
            this.panelSheetSheetSame.ResumeLayout(false);
            this.panelSheetSheetSame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShShSmAdders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSSSmSkid)).EndInit();
            this.panelCoilCoilSame.ResumeLayout(false);
            this.panelCoilCoilSame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCLCLSame)).EndInit();
            this.panelSheetSheetDiff.ResumeLayout(false);
            this.panelSheetSheetDiff.PerformLayout();
            this.panelSSDOrderEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSSDItems)).EndInit();
            this.panelCoilSheetSame.ResumeLayout(false);
            this.panelCoilSheetSame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCTLOrderEntry)).EndInit();
            this.panelClClDiff.ResumeLayout(false);
            this.panelClClDiff.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClClDiff)).EndInit();
            this.tabPageReports.ResumeLayout(false);
            this.panelReportOperatorTags.ResumeLayout(false);
            this.panelReportOperatorTags.PerformLayout();
            this.panelReportTransfer.ResumeLayout(false);
            this.panelReportTransfer.PerformLayout();
            this.panelReportHistory.ResumeLayout(false);
            this.panelReportHistory.PerformLayout();
            this.panelReportInventory.ResumeLayout(false);
            this.panelReportInventory.PerformLayout();
            this.panelReportWorkOrder.ResumeLayout(false);
            this.panelReportWorkOrder.PerformLayout();
            this.panelReportShipping.ResumeLayout(false);
            this.panelReportShipping.PerformLayout();
            this.panelReportReceiving.ResumeLayout(false);
            this.panelReportReceiving.PerformLayout();
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
            this.tabPageOpenOrders.ResumeLayout(false);
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
            this.tabPageRunSheet.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPageFix.ResumeLayout(false);
            this.panelFix.ResumeLayout(false);
            this.tabFixes.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelFixBackOff.ResumeLayout(false);
            this.panelFixBackOff.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panelFixAddSkid.ResumeLayout(false);
            this.panelFixAddSkid.PerformLayout();
            this.gbFixSkidAddPaper.ResumeLayout(false);
            this.gbFixSkidAddPaper.PerformLayout();
            this.gbFixSkidAddPVC.ResumeLayout(false);
            this.gbFixSkidAddPVC.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panelFixAddDamage.ResumeLayout(false);
            this.panelFixAddDamage.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panelFixBOL.ResumeLayout(false);
            this.panelFixBOL.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.contextMenuStripAddVertical.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.MenuRunSheetRightClick.ResumeLayout(false);
            this.menuCustomer.ResumeLayout(false);
            this.MenuClClDiff.ResumeLayout(false);
            this.menuShippingTransfer.ResumeLayout(false);
            this.cmPVCLabelPrint.ResumeLayout(false);
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
        private ColumnHeader lvSkidBranch;
        private ColumnHeader columnHeader55;
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
        private ContextMenuStrip MenuRunSheetRightClick;
        private ToolStripMenuItem putOnHoldToolStripMenuItem;
        private ColumnHeader columnHeaderSPScrapPrice;
        private ColumnHeader columnHeaderSPHistoryScrap;
        private RichTextBox richTextBox1;
        private TextBox tbTestOrderID;
        private DataGridView dgvShShSmAdders;
        private Label lblShShSmPaperPrice;
        private TextBox tbShShSmPaperPrice;
        private Button btnShShSmAdderDone;
        private DataGridViewCheckBoxColumn dgvAdderColSelect;
        private DataGridViewTextBoxColumn dgvSSSmAdderDesc;
        private DataGridViewTextBoxColumn dgvSSSmAdderPrice;
        private TabPage tabPageAdders;
        private Button btnShShModifyDelete;
        private ListView lvwSettingsAdders;
        private ColumnHeader colSettingAdderDesc;
        private ColumnHeader colSettingAdderPrice;
        private ColumnHeader colSettingAdderMin;
        private ColumnHeader colSettingAdderType;
        private Label lblSettingAdderMinPrice;
        private TextBox tbSettingAdderMinPrice;
        private Label lblSettingAdderPrice;
        private TextBox tbSettingAdderPrice;
        private Label lblSettingAdderDesc;
        private TextBox tbSettingAdderDesc;
        private GroupBox groupBoxSettingAddersPriceType;
        private RadioButton rbSettingAdderPriceTypeLinearFt;
        private RadioButton rbSettingAdderPriceTypeSQFT;
        private RadioButton rpSettingAdderTypeLBS;
        private Button btnSettingAdderDeactivateAdder;
        private Button btnSettingAdderAddAdder;
        private RadioButton rbSettingAdderPriceTypeLinearInches;
        private CheckBox cbSettingsTagPrinterZebra;
        private CheckBox cbSettingsShipLabelZebra;
        private TextBox tbReportOperatorTags;
        private Button btnReportOperatorTag;
        private CheckBox cbReportWorkORderOperatorTags;
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
        private TabPage tabPageFix;
        private Panel panelFix;
        private TextBox tbFixOrderID;
        private ComboBox cbFixBackOffCoils;
        private Button btnFixBackoff;
        private Label lblPrevWeight;
        private Label lblFixPreviousWeight;
        private Label lblFixNewWeight;
        private TextBox tbFixNewWeight;
        private Button btnFixBackOffWeight;
        private Label label5;
        private Label lblFixOrdid;
        private Label label6;
        private TextBox tbFixCoilLocation;
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
        private DataGridViewComboBoxColumn dgvSSSmAdders;
        private DataGridViewComboBoxColumn dgvSSSmBranchID;
        private DataGridViewComboBoxColumn dgvSSSmAdderID;
        private DataGridViewComboBoxColumn dgvSSSmAdderPriceCol;
        private DataGridViewTextBoxColumn dgvSSSmAlloyID;
        private DataGridViewComboBoxColumn dgvSSSmFinishID;
        private DataGridViewTextBoxColumn dgvSSSmDensityFactor;
        private DataGridViewTextBoxColumn dgvSSSmOrigFinish;
        private DataGridViewComboBoxColumn dgvSSSmPVCGroupID;
        private DataGridViewComboBoxColumn dgvSSSmPVCPriceList;
        private DataGridViewTextBoxColumn dgvSSSmCurrPrice;
        private ToolStripMenuItem commentsToolStripMenuItem;
        private ContextMenuStrip menuCustomer;
        private ToolStripMenuItem deactivateCustomerToolStripMenuItem;
        private CheckBox cbCTLPrintOperatorTags;
        private Panel panelFixBackOff;
        private Panel panelFixAddSkid;
        private Label lblFixAddSkidOrderID;
        private TextBox tbFixAddSkidOrderID;
        private Label lblFixSkidAddTagID;
        private ComboBox cbFixSkidAddTagID;
        private Label lblFixSkidAddComments;
        private TextBox tbFixSkidAddComments;
        private Label lblFixSkidAddSheetWeight;
        private TextBox tbFixSkidAddSheetWeight;
        private Label lblFixSkidAddPieces;
        private TextBox tbFixSkidAddPieces;
        private ComboBox cbFixSkidAddLetters;
        private Label lblFixSkidAddNewLetter;
        private TextBox tbFixSkidAddNewLetter;
        private GroupBox gbFixSkidAddPVC;
        private Label lblFixSkidAddSkidPrice;
        private TextBox tbFixSkidAddSkidPrice;
        private Label lblFixSkidAddSkidType;
        private ComboBox cbFixSkidAddSkidType;
        private Label lblFixSkidAddLength;
        private TextBox tbFixSkidAddLength;
        private GroupBox gbFixSkidAddPaper;
        private RadioButton rbFixSkidAddPaperNo;
        private RadioButton rbFixSkidAddPaperYes;
        private RadioButton rbFixSkidAddPVCNo;
        private RadioButton rbFixSkidAddPVCYes;
        private Label lblFixSkidAddDiag1;
        private TextBox tbFixSkidAddDiag1;
        private Label lblFixSkidAddDiag2;
        private TextBox tbFixSkidAddDiag2;
        private Button btnFixSkidAddInsert;
        private TextBox tbFixSkidAddMic3;
        private TextBox tbFixSkidAddMic2;
        private Label lblFixSkidAddMic3;
        private Label lblFixSkidAddMic2;
        private Label lblFixSkidAddMic1;
        private TextBox tbFixSkidAddMic1;
        private ComboBox cbFixSkidAddMaxSeq;
        private Label lblFixSkidAddLocation;
        private TextBox tbFixSkidAddLocation;
        private CheckBox cbFixSkidAddNotPrime;
        private Label lblFixSkidAddWidthLabel;
        private Label lblFixSkidAddWidth;
        private Label lblFixSkidAddAlloyLabel;
        private Label lblFixSkidAddAlloy;
        private Label lblFixSkidAddFinishLabel;
        private Label lblFixSkidAddFinish;
        private ComboBox cbFixSkidAddPVCGroup;
        private ComboBox cbFixSkidAddPVCPriceID;
        private Label lblFixBackoff;
        private Label lblFixAddSkid;
        private Panel panelFixAddDamage;
        private Label lblfixAddDamage;
        private TextBox tbFixAddDamageBOL;
        private CheckedListBox clbFixAddDamage;
        private Button btnFixAddDamage;
        private Label lblFixAddDamageBOL;
        private ComboBox cbFixAddDamageTagIDs;
        private Label lblFixAddDamageTagIDs;
        private CheckBox cbCTLPaperDefault;
        private Panel panelReportReceiving;
        private Panel panelReportShipping;
        private Button btnRepotShipping;
        private TextBox tbReportShipping;
        private Panel panelReportTransfer;
        private Panel panelReportHistory;
        private Panel panelReportInventory;
        private Panel panelReportWorkOrder;
        private Panel panelReportOperatorTags;
        private Label lblReportHistoryTagID;
        private Label lblReportsHistoryPO;
        private TextBox tbReportsHistoryPO;
        private Label lblReportsHistoryMill;
        private TextBox tbReportsHistoryMillNum;
        private Button btnOrderShShSameDeleteRow;
        private Button btnOrderCTLAddTag;
        private Button btnSSSmAddTag;
        private CheckBox cbRunSheetCustPO;
        private CheckBox checkBox1;
        private Label lblClClSmPaperPrice;
        private TextBox tbClClSmPaperPrice;
        private TabPage tabPageOpenOrders;
        private ListView lvOpenOrderList;
        private ColumnHeader colOpenOrderMachine;
        private ColumnHeader colOpenOrderThickness;
        private ColumnHeader colOpenOrderWidth;
        private ColumnHeader colOpenOrderOrderID;
        private ColumnHeader colOpenOrderPromiseDate;
        private ColumnHeader colOpenOrderRunSheetComments;
        private ColumnHeader colOpenOrderCustPO;
        private Button btnOpenOrdersPrint;
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
        private ContextMenuStrip MenuClClDiff;
        private ToolStripMenuItem changeCommentsToolStripMenuItem;
        private ToolStripMenuItem removeSlitWidthToolStripMenuItem;
        private ToolStripMenuItem convertToSkidToolStripMenuItem;
        private TextBox tbReportShippingLabels;
        private Button btnReportShippingLabel;
        private CheckBox cbSettingsPrintShipLabels;
        private CheckBox cbShShSmPrintOpTag;
        private TabControl tabFixes;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Panel panelFixBOL;
        private CheckedListBox cblFixBOLList;
        private Label lblFixBOLNum;
        private TextBox tbFixBOLNum;
        private Button btnFixBOLFinish;
        private ContextMenuStrip menuShippingTransfer;
        private ToolStripMenuItem transferToolStripMenuItem;
        private CheckBox cbCTLWeightCalc;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsRunSheetCount;
        private ToolStripStatusLabel tsRunSheetAmount;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel tsRunSheetPieces;
        private DataGridViewTextBoxColumn dgvCTLTagID;
        private DataGridViewTextBoxColumn dgvCTLThickness;
        private DataGridViewTextBoxColumn dgvCTLWidth;
        private DataGridViewTextBoxColumn dgvCTLAlloy;
        private DataGridViewTextBoxColumn dgvCTLSkidWeight;
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
        private ContextMenuStrip cmPVCLabelPrint;
        private ToolStripMenuItem printPVCLabelToolStripMenuItem;
        private TabPage tabPage5;
        private ListView lvFixOpenBOLs;
        private ColumnHeader columnHeader103;
        private ColumnHeader columnHeader104;
        private ColumnHeader columnHeader105;
        private ColumnHeader columnHeader106;
        private CheckBox cbSettingsOverideShipLabelPrint;
        private CheckBox cbOverideShipZebra;
        private CheckBox cbSettingsOverideTagZebra;
        private Label label7;
        private ComboBox comboBoxOverideShipPrinter;
        private Label label8;
        private ComboBox comboBoxOverideTagPrinter;
        private Label lblPrintSetLocationOveride;
        private ComboBox comboBoxSettingOverideCity;
        private ColumnHeader RecDate;
    }
}

