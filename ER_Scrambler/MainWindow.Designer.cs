namespace ER_Scrambler
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.t_ModPath = new System.Windows.Forms.TextBox();
            this.b_SelectModPath = new System.Windows.Forms.Button();
            this.b_Scramble = new System.Windows.Forms.Button();
            this.folderBrowserDialog_ModPath = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Bullet = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.c_Bullet_Spam = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.c_Bullet_AnySpEffect = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.c_Bullet_AnyVFX = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.c_Scramble_Bullet = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.c_Weapon_AnyVFX = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.c_Weapon_AnySpEffect = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.c_Weapon_RestrictedScramble = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.c_Scramble_Weapon = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.c_Rings_AnySpEffect = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.c_Rings_RestrictedScramble = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.c_Scramble_Rings = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.c_Armor_AnySpEffect = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.c_Armor_LimitedScramble = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.c_Scramble_Armor = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.c_Spell_AnyVFX = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.c_Spell_LimitedScramble = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.c_Scramble_Spells = new System.Windows.Forms.CheckBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label23 = new System.Windows.Forms.Label();
            this.c_Goods_Skip_KeyItems = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.c_Goods_LimitedScramble = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.c_Scramble_Goods = new System.Windows.Forms.CheckBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label26 = new System.Windows.Forms.Label();
            this.c_Scramble_Faces = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.c_Char_LimitedScramble = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.c_Scramble_Char = new System.Windows.Forms.CheckBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.c_Scramble_AssetParam = new System.Windows.Forms.CheckBox();
            this.l_status = new System.Windows.Forms.Label();
            this.t_seed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.b_ToggleOn = new System.Windows.Forms.Button();
            this.b_ToggleOff = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Bullet.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path to Mod";
            // 
            // t_ModPath
            // 
            this.t_ModPath.Location = new System.Drawing.Point(12, 46);
            this.t_ModPath.Name = "t_ModPath";
            this.t_ModPath.ReadOnly = true;
            this.t_ModPath.Size = new System.Drawing.Size(163, 23);
            this.t_ModPath.TabIndex = 1;
            // 
            // b_SelectModPath
            // 
            this.b_SelectModPath.Location = new System.Drawing.Point(181, 46);
            this.b_SelectModPath.Name = "b_SelectModPath";
            this.b_SelectModPath.Size = new System.Drawing.Size(100, 23);
            this.b_SelectModPath.TabIndex = 2;
            this.b_SelectModPath.Text = "Select Folder";
            this.b_SelectModPath.UseVisualStyleBackColor = true;
            this.b_SelectModPath.Click += new System.EventHandler(this.b_SelectModPath_Click);
            // 
            // b_Scramble
            // 
            this.b_Scramble.Location = new System.Drawing.Point(455, 46);
            this.b_Scramble.Name = "b_Scramble";
            this.b_Scramble.Size = new System.Drawing.Size(100, 23);
            this.b_Scramble.TabIndex = 3;
            this.b_Scramble.Text = "Scramble Mod";
            this.b_Scramble.UseVisualStyleBackColor = true;
            this.b_Scramble.Click += new System.EventHandler(this.b_Scramble_Click);
            // 
            // folderBrowserDialog_ModPath
            // 
            this.folderBrowserDialog_ModPath.RootFolder = System.Environment.SpecialFolder.MyDocuments;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(12, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 268);
            this.panel1.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Bullet);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(667, 262);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_Bullet
            // 
            this.tabPage_Bullet.Controls.Add(this.label20);
            this.tabPage_Bullet.Controls.Add(this.c_Bullet_Spam);
            this.tabPage_Bullet.Controls.Add(this.label12);
            this.tabPage_Bullet.Controls.Add(this.c_Bullet_AnySpEffect);
            this.tabPage_Bullet.Controls.Add(this.label4);
            this.tabPage_Bullet.Controls.Add(this.c_Bullet_AnyVFX);
            this.tabPage_Bullet.Controls.Add(this.label3);
            this.tabPage_Bullet.Controls.Add(this.c_Scramble_Bullet);
            this.tabPage_Bullet.Location = new System.Drawing.Point(4, 24);
            this.tabPage_Bullet.Name = "tabPage_Bullet";
            this.tabPage_Bullet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Bullet.Size = new System.Drawing.Size(659, 234);
            this.tabPage_Bullet.TabIndex = 0;
            this.tabPage_Bullet.Text = "Bullet";
            this.tabPage_Bullet.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(267, 113);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(270, 15);
            this.label20.TabIndex = 16;
            this.label20.Text = "Allows insane bullet scrambling, may crash game.";
            // 
            // c_Bullet_Spam
            // 
            this.c_Bullet_Spam.AutoSize = true;
            this.c_Bullet_Spam.Location = new System.Drawing.Point(6, 112);
            this.c_Bullet_Spam.Name = "c_Bullet_Spam";
            this.c_Bullet_Spam.Size = new System.Drawing.Size(144, 19);
            this.c_Bullet_Spam.TabIndex = 15;
            this.c_Bullet_Spam.Text = "Enable Bullet Madness\r\n";
            this.c_Bullet_Spam.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(267, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(316, 30);
            this.label12.TabIndex = 14;
            this.label12.Text = "Allow any SpEffect to be scrambled into the relevant fields,\r\nnot just those that" +
    " were already assigned.";
            // 
            // c_Bullet_AnySpEffect
            // 
            this.c_Bullet_AnySpEffect.AutoSize = true;
            this.c_Bullet_AnySpEffect.Location = new System.Drawing.Point(6, 73);
            this.c_Bullet_AnySpEffect.Name = "c_Bullet_AnySpEffect";
            this.c_Bullet_AnySpEffect.Size = new System.Drawing.Size(124, 19);
            this.c_Bullet_AnySpEffect.TabIndex = 13;
            this.c_Bullet_AnySpEffect.Text = "Allow any SpEffect";
            this.c_Bullet_AnySpEffect.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "The VFX scramble will use all possible VFX instead of\r\njust those that were assig" +
    "ned already.";
            // 
            // c_Bullet_AnyVFX
            // 
            this.c_Bullet_AnyVFX.AutoSize = true;
            this.c_Bullet_AnyVFX.Location = new System.Drawing.Point(6, 31);
            this.c_Bullet_AnyVFX.Name = "c_Bullet_AnyVFX";
            this.c_Bullet_AnyVFX.Size = new System.Drawing.Size(101, 19);
            this.c_Bullet_AnyVFX.TabIndex = 2;
            this.c_Bullet_AnyVFX.Text = "Allow any VFX";
            this.c_Bullet_AnyVFX.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Scramble the Bullet param";
            // 
            // c_Scramble_Bullet
            // 
            this.c_Scramble_Bullet.AutoSize = true;
            this.c_Scramble_Bullet.Location = new System.Drawing.Point(6, 6);
            this.c_Scramble_Bullet.Name = "c_Scramble_Bullet";
            this.c_Scramble_Bullet.Size = new System.Drawing.Size(108, 19);
            this.c_Scramble_Bullet.TabIndex = 0;
            this.c_Scramble_Bullet.Text = "Scramble Bullet";
            this.c_Scramble_Bullet.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.c_Weapon_AnyVFX);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.c_Weapon_AnySpEffect);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.c_Weapon_RestrictedScramble);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.c_Scramble_Weapon);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(659, 234);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Weapons";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(267, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(281, 30);
            this.label13.TabIndex = 14;
            this.label13.Text = "The VFX scramble will use all possible VFX instead of\r\njust those that were assig" +
    "ned already.";
            // 
            // c_Weapon_AnyVFX
            // 
            this.c_Weapon_AnyVFX.AutoSize = true;
            this.c_Weapon_AnyVFX.Location = new System.Drawing.Point(6, 95);
            this.c_Weapon_AnyVFX.Name = "c_Weapon_AnyVFX";
            this.c_Weapon_AnyVFX.Size = new System.Drawing.Size(101, 19);
            this.c_Weapon_AnyVFX.TabIndex = 13;
            this.c_Weapon_AnyVFX.Text = "Allow any VFX";
            this.c_Weapon_AnyVFX.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(267, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(316, 30);
            this.label11.TabIndex = 12;
            this.label11.Text = "Allow any SpEffect to be scrambled into the relevant fields,\r\nnot just those that" +
    " were already assigned.";
            // 
            // c_Weapon_AnySpEffect
            // 
            this.c_Weapon_AnySpEffect.AutoSize = true;
            this.c_Weapon_AnySpEffect.Location = new System.Drawing.Point(6, 56);
            this.c_Weapon_AnySpEffect.Name = "c_Weapon_AnySpEffect";
            this.c_Weapon_AnySpEffect.Size = new System.Drawing.Size(124, 19);
            this.c_Weapon_AnySpEffect.TabIndex = 11;
            this.c_Weapon_AnySpEffect.Text = "Allow any SpEffect";
            this.c_Weapon_AnySpEffect.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(356, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Only scramble values such as Damage, Scaling, Requirements, etc.";
            // 
            // c_Weapon_RestrictedScramble
            // 
            this.c_Weapon_RestrictedScramble.AutoSize = true;
            this.c_Weapon_RestrictedScramble.Location = new System.Drawing.Point(6, 31);
            this.c_Weapon_RestrictedScramble.Name = "c_Weapon_RestrictedScramble";
            this.c_Weapon_RestrictedScramble.Size = new System.Drawing.Size(140, 19);
            this.c_Weapon_RestrictedScramble.TabIndex = 3;
            this.c_Weapon_RestrictedScramble.Text = "Use Limited Scramble";
            this.c_Weapon_RestrictedScramble.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(267, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(227, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Scramble the EquipParamWeapon param.";
            // 
            // c_Scramble_Weapon
            // 
            this.c_Scramble_Weapon.AutoSize = true;
            this.c_Scramble_Weapon.Location = new System.Drawing.Point(6, 6);
            this.c_Scramble_Weapon.Name = "c_Scramble_Weapon";
            this.c_Scramble_Weapon.Size = new System.Drawing.Size(127, 19);
            this.c_Scramble_Weapon.TabIndex = 0;
            this.c_Scramble_Weapon.Text = "Scramble Weapons";
            this.c_Scramble_Weapon.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.c_Rings_AnySpEffect);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.c_Rings_RestrictedScramble);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.c_Scramble_Rings);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(659, 234);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Rings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(267, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(316, 30);
            this.label10.TabIndex = 10;
            this.label10.Text = "Allow any SpEffect to be scrambled into the relevant fields,\r\nnot just those that" +
    " were already assigned.";
            // 
            // c_Rings_AnySpEffect
            // 
            this.c_Rings_AnySpEffect.AutoSize = true;
            this.c_Rings_AnySpEffect.Location = new System.Drawing.Point(6, 56);
            this.c_Rings_AnySpEffect.Name = "c_Rings_AnySpEffect";
            this.c_Rings_AnySpEffect.Size = new System.Drawing.Size(124, 19);
            this.c_Rings_AnySpEffect.TabIndex = 9;
            this.c_Rings_AnySpEffect.Text = "Allow any SpEffect";
            this.c_Rings_AnySpEffect.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(267, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(274, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Only scramble values such as Weight and SpEffect.";
            // 
            // c_Rings_RestrictedScramble
            // 
            this.c_Rings_RestrictedScramble.AutoSize = true;
            this.c_Rings_RestrictedScramble.Location = new System.Drawing.Point(6, 31);
            this.c_Rings_RestrictedScramble.Name = "c_Rings_RestrictedScramble";
            this.c_Rings_RestrictedScramble.Size = new System.Drawing.Size(140, 19);
            this.c_Rings_RestrictedScramble.TabIndex = 7;
            this.c_Rings_RestrictedScramble.Text = "Use Limited Scramble";
            this.c_Rings_RestrictedScramble.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(267, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(236, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Scramble the EquipParamAccessory param.";
            // 
            // c_Scramble_Rings
            // 
            this.c_Scramble_Rings.AutoSize = true;
            this.c_Scramble_Rings.Location = new System.Drawing.Point(6, 6);
            this.c_Scramble_Rings.Name = "c_Scramble_Rings";
            this.c_Scramble_Rings.Size = new System.Drawing.Size(107, 19);
            this.c_Scramble_Rings.TabIndex = 5;
            this.c_Scramble_Rings.Text = "Scramble Rings";
            this.c_Scramble_Rings.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.c_Armor_AnySpEffect);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.c_Armor_LimitedScramble);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.c_Scramble_Armor);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(659, 234);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Armor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(316, 30);
            this.label9.TabIndex = 16;
            this.label9.Text = "Allow any SpEffect to be scrambled into the relevant fields,\r\nnot just those that" +
    " were already assigned.";
            // 
            // c_Armor_AnySpEffect
            // 
            this.c_Armor_AnySpEffect.AutoSize = true;
            this.c_Armor_AnySpEffect.Location = new System.Drawing.Point(6, 56);
            this.c_Armor_AnySpEffect.Name = "c_Armor_AnySpEffect";
            this.c_Armor_AnySpEffect.Size = new System.Drawing.Size(124, 19);
            this.c_Armor_AnySpEffect.TabIndex = 15;
            this.c_Armor_AnySpEffect.Text = "Allow any SpEffect";
            this.c_Armor_AnySpEffect.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(267, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(331, 15);
            this.label14.TabIndex = 14;
            this.label14.Text = "Only scramble values such as Absorption, Poise, SpEffect, etc.";
            // 
            // c_Armor_LimitedScramble
            // 
            this.c_Armor_LimitedScramble.AutoSize = true;
            this.c_Armor_LimitedScramble.Location = new System.Drawing.Point(6, 31);
            this.c_Armor_LimitedScramble.Name = "c_Armor_LimitedScramble";
            this.c_Armor_LimitedScramble.Size = new System.Drawing.Size(140, 19);
            this.c_Armor_LimitedScramble.TabIndex = 13;
            this.c_Armor_LimitedScramble.Text = "Use Limited Scramble";
            this.c_Armor_LimitedScramble.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(267, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(232, 15);
            this.label15.TabIndex = 12;
            this.label15.Text = "Scramble the EquipParamProtector param.";
            // 
            // c_Scramble_Armor
            // 
            this.c_Scramble_Armor.AutoSize = true;
            this.c_Scramble_Armor.Location = new System.Drawing.Point(6, 6);
            this.c_Scramble_Armor.Name = "c_Scramble_Armor";
            this.c_Scramble_Armor.Size = new System.Drawing.Size(112, 19);
            this.c_Scramble_Armor.TabIndex = 11;
            this.c_Scramble_Armor.Text = "Scramble Armor";
            this.c_Scramble_Armor.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.c_Spell_AnyVFX);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.c_Spell_LimitedScramble);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.c_Scramble_Spells);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(659, 234);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Spells";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(267, 60);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(281, 30);
            this.label19.TabIndex = 24;
            this.label19.Text = "The VFX scramble will use all possible VFX instead of\r\njust those that were assig" +
    "ned already.";
            // 
            // c_Spell_AnyVFX
            // 
            this.c_Spell_AnyVFX.AutoSize = true;
            this.c_Spell_AnyVFX.Location = new System.Drawing.Point(6, 56);
            this.c_Spell_AnyVFX.Name = "c_Spell_AnyVFX";
            this.c_Spell_AnyVFX.Size = new System.Drawing.Size(101, 19);
            this.c_Spell_AnyVFX.TabIndex = 23;
            this.c_Spell_AnyVFX.Text = "Allow any VFX";
            this.c_Spell_AnyVFX.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(267, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(302, 15);
            this.label17.TabIndex = 20;
            this.label17.Text = "Only scramble values such as FP, referenced bullets, etc.";
            // 
            // c_Spell_LimitedScramble
            // 
            this.c_Spell_LimitedScramble.AutoSize = true;
            this.c_Spell_LimitedScramble.Location = new System.Drawing.Point(6, 31);
            this.c_Spell_LimitedScramble.Name = "c_Spell_LimitedScramble";
            this.c_Spell_LimitedScramble.Size = new System.Drawing.Size(140, 19);
            this.c_Spell_LimitedScramble.TabIndex = 19;
            this.c_Spell_LimitedScramble.Text = "Use Limited Scramble";
            this.c_Spell_LimitedScramble.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(267, 6);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(152, 15);
            this.label18.TabIndex = 18;
            this.label18.Text = "Scramble the Magic param.";
            // 
            // c_Scramble_Spells
            // 
            this.c_Scramble_Spells.AutoSize = true;
            this.c_Scramble_Spells.Location = new System.Drawing.Point(6, 6);
            this.c_Scramble_Spells.Name = "c_Scramble_Spells";
            this.c_Scramble_Spells.Size = new System.Drawing.Size(108, 19);
            this.c_Scramble_Spells.TabIndex = 17;
            this.c_Scramble_Spells.Text = "Scramble Spells";
            this.c_Scramble_Spells.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label23);
            this.tabPage6.Controls.Add(this.c_Goods_Skip_KeyItems);
            this.tabPage6.Controls.Add(this.label21);
            this.tabPage6.Controls.Add(this.c_Goods_LimitedScramble);
            this.tabPage6.Controls.Add(this.label22);
            this.tabPage6.Controls.Add(this.c_Scramble_Goods);
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(659, 234);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "Goods";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(267, 56);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(331, 15);
            this.label23.TabIndex = 26;
            this.label23.Text = "Ignore key items such as Crimson Vial, etc during scrambling.";
            // 
            // c_Goods_Skip_KeyItems
            // 
            this.c_Goods_Skip_KeyItems.AutoSize = true;
            this.c_Goods_Skip_KeyItems.Location = new System.Drawing.Point(6, 56);
            this.c_Goods_Skip_KeyItems.Name = "c_Goods_Skip_KeyItems";
            this.c_Goods_Skip_KeyItems.Size = new System.Drawing.Size(114, 19);
            this.c_Goods_Skip_KeyItems.TabIndex = 25;
            this.c_Goods_Skip_KeyItems.Text = "Ignore Key Items";
            this.c_Goods_Skip_KeyItems.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(267, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(288, 15);
            this.label21.TabIndex = 24;
            this.label21.Text = "Only scramble values such as VFX and use animation.";
            // 
            // c_Goods_LimitedScramble
            // 
            this.c_Goods_LimitedScramble.AutoSize = true;
            this.c_Goods_LimitedScramble.Location = new System.Drawing.Point(6, 31);
            this.c_Goods_LimitedScramble.Name = "c_Goods_LimitedScramble";
            this.c_Goods_LimitedScramble.Size = new System.Drawing.Size(140, 19);
            this.c_Goods_LimitedScramble.TabIndex = 23;
            this.c_Goods_LimitedScramble.Text = "Use Limited Scramble";
            this.c_Goods_LimitedScramble.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(267, 6);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(180, 15);
            this.label22.TabIndex = 22;
            this.label22.Text = "Scramble the EquipParamGoods.";
            // 
            // c_Scramble_Goods
            // 
            this.c_Scramble_Goods.AutoSize = true;
            this.c_Scramble_Goods.Location = new System.Drawing.Point(6, 6);
            this.c_Scramble_Goods.Name = "c_Scramble_Goods";
            this.c_Scramble_Goods.Size = new System.Drawing.Size(112, 19);
            this.c_Scramble_Goods.TabIndex = 21;
            this.c_Scramble_Goods.Text = "Scramble Goods";
            this.c_Scramble_Goods.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label26);
            this.tabPage7.Controls.Add(this.c_Scramble_Faces);
            this.tabPage7.Controls.Add(this.label25);
            this.tabPage7.Controls.Add(this.c_Char_LimitedScramble);
            this.tabPage7.Controls.Add(this.label24);
            this.tabPage7.Controls.Add(this.c_Scramble_Char);
            this.tabPage7.Location = new System.Drawing.Point(4, 24);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(659, 234);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Text = "Characters";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(267, 60);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(177, 15);
            this.label26.TabIndex = 27;
            this.label26.Text = "Scramble the FaceParam param.\r\n";
            // 
            // c_Scramble_Faces
            // 
            this.c_Scramble_Faces.AutoSize = true;
            this.c_Scramble_Faces.Location = new System.Drawing.Point(6, 56);
            this.c_Scramble_Faces.Name = "c_Scramble_Faces";
            this.c_Scramble_Faces.Size = new System.Drawing.Size(107, 19);
            this.c_Scramble_Faces.TabIndex = 26;
            this.c_Scramble_Faces.Text = "Scramble Faces";
            this.c_Scramble_Faces.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(267, 31);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(225, 15);
            this.label25.TabIndex = 25;
            this.label25.Text = "Only scramble values such as equipment.";
            // 
            // c_Char_LimitedScramble
            // 
            this.c_Char_LimitedScramble.AutoSize = true;
            this.c_Char_LimitedScramble.Location = new System.Drawing.Point(6, 31);
            this.c_Char_LimitedScramble.Name = "c_Char_LimitedScramble";
            this.c_Char_LimitedScramble.Size = new System.Drawing.Size(140, 19);
            this.c_Char_LimitedScramble.TabIndex = 23;
            this.c_Char_LimitedScramble.Text = "Use Limited Scramble";
            this.c_Char_LimitedScramble.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(267, 6);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(201, 15);
            this.label24.TabIndex = 22;
            this.label24.Text = "Scramble the CharaInitParam param.\r\n";
            // 
            // c_Scramble_Char
            // 
            this.c_Scramble_Char.AutoSize = true;
            this.c_Scramble_Char.Location = new System.Drawing.Point(6, 6);
            this.c_Scramble_Char.Name = "c_Scramble_Char";
            this.c_Scramble_Char.Size = new System.Drawing.Size(192, 19);
            this.c_Scramble_Char.TabIndex = 21;
            this.c_Scramble_Char.Text = "Scramble Player-like Characters";
            this.c_Scramble_Char.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 24);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(659, 234);
            this.tabPage8.TabIndex = 8;
            this.tabPage8.Text = "Enemies";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.c_Scramble_AssetParam);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(659, 234);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "Misc";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(267, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(264, 15);
            this.label16.TabIndex = 20;
            this.label16.Text = "Scramble the AssetEnvironmentGeometryParam.\r\n";
            // 
            // c_Scramble_AssetParam
            // 
            this.c_Scramble_AssetParam.AutoSize = true;
            this.c_Scramble_AssetParam.Location = new System.Drawing.Point(6, 6);
            this.c_Scramble_AssetParam.Name = "c_Scramble_AssetParam";
            this.c_Scramble_AssetParam.Size = new System.Drawing.Size(168, 19);
            this.c_Scramble_AssetParam.TabIndex = 19;
            this.c_Scramble_AssetParam.Text = "Scramble Asset Parameters";
            this.c_Scramble_AssetParam.UseVisualStyleBackColor = true;
            // 
            // l_status
            // 
            this.l_status.AutoSize = true;
            this.l_status.Location = new System.Drawing.Point(12, 9);
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(36, 15);
            this.l_status.TabIndex = 5;
            this.l_status.Text = "Blank";
            // 
            // t_seed
            // 
            this.t_seed.Location = new System.Drawing.Point(286, 46);
            this.t_seed.Name = "t_seed";
            this.t_seed.ReadOnly = true;
            this.t_seed.Size = new System.Drawing.Size(163, 23);
            this.t_seed.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Random Seed";
            // 
            // b_ToggleOn
            // 
            this.b_ToggleOn.Location = new System.Drawing.Point(610, 16);
            this.b_ToggleOn.Name = "b_ToggleOn";
            this.b_ToggleOn.Size = new System.Drawing.Size(75, 23);
            this.b_ToggleOn.TabIndex = 8;
            this.b_ToggleOn.Text = "Toggle On";
            this.b_ToggleOn.UseVisualStyleBackColor = true;
            this.b_ToggleOn.Click += new System.EventHandler(this.b_ToggleOn_Click);
            // 
            // b_ToggleOff
            // 
            this.b_ToggleOff.Location = new System.Drawing.Point(610, 45);
            this.b_ToggleOff.Name = "b_ToggleOff";
            this.b_ToggleOff.Size = new System.Drawing.Size(75, 23);
            this.b_ToggleOff.TabIndex = 9;
            this.b_ToggleOff.Text = "Toggle Off";
            this.b_ToggleOff.UseVisualStyleBackColor = true;
            this.b_ToggleOff.Click += new System.EventHandler(this.b_ToggleOff_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 354);
            this.Controls.Add(this.b_ToggleOff);
            this.Controls.Add(this.b_ToggleOn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.t_seed);
            this.Controls.Add(this.l_status);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.b_Scramble);
            this.Controls.Add(this.b_SelectModPath);
            this.Controls.Add(this.t_ModPath);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Scrambler";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Bullet.ResumeLayout(false);
            this.tabPage_Bullet.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox t_ModPath;
        private Button b_SelectModPath;
        private Button b_Scramble;
        private FolderBrowserDialog folderBrowserDialog_ModPath;
        private Panel panel1;
        private TabControl tabControl1;
        private TabPage tabPage_Bullet;
        private Label l_status;
        private TextBox t_seed;
        private Label label2;
        private CheckBox c_Scramble_Bullet;
        private Button b_ToggleOn;
        private Button b_ToggleOff;
        private Label label3;
        private CheckBox c_Bullet_AnyVFX;
        private TabPage tabPage1;
        private Label label8;
        private CheckBox c_Scramble_Weapon;
        private Label label4;
        private Label label5;
        private CheckBox c_Weapon_RestrictedScramble;
        private TabPage tabPage2;
        private Label label6;
        private CheckBox c_Rings_RestrictedScramble;
        private Label label7;
        private CheckBox c_Scramble_Rings;
        private Label label10;
        private CheckBox c_Rings_AnySpEffect;
        private Label label11;
        private CheckBox c_Weapon_AnySpEffect;
        private Label label12;
        private CheckBox c_Bullet_AnySpEffect;
        private Label label13;
        private CheckBox c_Weapon_AnyVFX;
        private TabPage tabPage3;
        private Label label9;
        private CheckBox c_Armor_AnySpEffect;
        private Label label14;
        private CheckBox c_Armor_LimitedScramble;
        private Label label15;
        private CheckBox c_Scramble_Armor;
        private TabPage tabPage4;
        private Label label19;
        private CheckBox c_Spell_AnyVFX;
        private Label label17;
        private CheckBox c_Spell_LimitedScramble;
        private Label label18;
        private CheckBox c_Scramble_Spells;
        private TabPage tabPage5;
        private Label label16;
        private CheckBox c_Scramble_AssetParam;
        private Label label20;
        private CheckBox c_Bullet_Spam;
        private TabPage tabPage6;
        private Label label21;
        private CheckBox c_Goods_LimitedScramble;
        private Label label22;
        private CheckBox c_Scramble_Goods;
        private Label label23;
        private CheckBox c_Goods_Skip_KeyItems;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private CheckBox c_Char_LimitedScramble;
        private Label label24;
        private CheckBox c_Scramble_Char;
        private Label label25;
        private CheckBox c_Scramble_Faces;
        private Label label26;
    }
}