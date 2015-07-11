using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;

namespace Painter
{
    class AboutForm : Form
    {
        private const int FORM_SIZE_X = 284;
        private const int FORM_SIZE_Y = 162;
        private const int LINKLABEL_LOCATION_X = 88;
        private const int LINKLABEL_LOCATION_Y = 40;
        private const int LINK_I_START = 0;
        private const int LINK_I_LENTH = 7;
        private const int LINK_II_START = 10;
        private const int LINK_II_LENTH = 4;
        private const int LINK_III_START = 16;
        private const int LINK_III_LENTH = 4;
        private const int OKBUTTON_LOCATION_X = 197;
        private const int OKBUTTON_LOCATION_Y = 127;
        private const int PICTUREBOX_LOCATION_X = 12;
        private const int PICTUREBOX_LOCATION_Y = 12;
        private const int PICTUREBOX_SIZE_X = 60;
        private const int PICTUREBOX_SIZE_Y = 50;
        private const int NAMELABEL_LOCATION_X = 88;
        private const int NAMELABEL_LOCATION_Y = 99;
        private const int COPYRIGHTLABEL_LOCATION_X = 88;
        private const int COPYRIGHTLABEL_LOCATION_Y = 70;
        private const int PROGRAMNAMELABEL_LOCATION_X = 88;
        private const int PROGRAMNAMELABEL_LOCATION_Y = 12;

        private Label _programNameLabel;
        private Label _copyrightLabel;
        private Label _nameLabel;
        private PictureBox _pictureBox;
        private Button _okButton;
        private LinkLabel _linkLabel;

        public AboutForm()
        {
            Initialize();
        }

        // 設定元件
        private void Initialize()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(AboutForm));
            PrepareComponent();
            ((ISupportInitialize)(_pictureBox)).BeginInit();

            SetProgramNameLabel();
            SetCopyrightLabel();
            SetNameLabel();
            SetPictureBox(resources);
            SetOkButton();
            SetLinkLabel();
            SetAboutSpellingCheckerForm();

            ((ISupportInitialize)(_pictureBox)).EndInit();
        }

        // 設定_aboutSpellingCheckerForm
        private void SetAboutSpellingCheckerForm()
        {
            CancelButton = _okButton;
            ClientSize = new Size(FORM_SIZE_X, FORM_SIZE_Y);
            ControlBox = false;
            Controls.Add(_linkLabel);
            Controls.Add(_okButton);
            Controls.Add(_pictureBox);
            Controls.Add(_nameLabel);
            Controls.Add(_copyrightLabel);
            Controls.Add(_programNameLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "_aboutSpellingCheckerForm";
            Text = "About Painter";
        }

        // 設定_linkLabel
        private void SetLinkLabel()
        {
            _linkLabel.AutoSize = true;
            _linkLabel.Location = new Point(LINKLABEL_LOCATION_X, LINKLABEL_LOCATION_Y);
            _linkLabel.Name = "_linkLabel";
            _linkLabel.Text = "SDT Lab @ CSIE, NTUT";
            _linkLabel.Links.Add(LINK_I_START, LINK_I_LENTH, "http://www.csie.ntut.edu.tw/labsdtl/");
            _linkLabel.Links.Add(LINK_II_START, LINK_II_LENTH, "http://csie.ntut.edu.tw/csie/index_i.htm");
            _linkLabel.Links.Add(LINK_III_START, LINK_III_LENTH, "http://www.ntut.edu.tw/bin/home.php");
            _linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkLabelLinkClicked);
        }

        // 設定_okButton
        private void SetOkButton()
        {
            _okButton.DialogResult = DialogResult.Cancel;
            _okButton.Location = new Point(OKBUTTON_LOCATION_X, OKBUTTON_LOCATION_Y);
            _okButton.Name = "_okButton";
            _okButton.Text = "OK";
        }

        // 設定_pictureBox
        private void SetPictureBox(ComponentResourceManager resources)
        {
            _pictureBox.Image = Properties.Resources.PainterIcon;
            _pictureBox.Location = new Point(PICTUREBOX_LOCATION_X, PICTUREBOX_LOCATION_Y);
            _pictureBox.Name = "_pictureBox";
            _pictureBox.Size = new Size(PICTUREBOX_SIZE_X, PICTUREBOX_SIZE_Y);
            _pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        // 設定_nameLabel
        private void SetNameLabel()
        {
            _nameLabel.AutoSize = true;
            _nameLabel.Location = new Point(NAMELABEL_LOCATION_X, NAMELABEL_LOCATION_Y);
            _nameLabel.Name = "_nameLabel";
            _nameLabel.Text = "王玉玲";
        }

        // 設定_copyrightLabel
        private void SetCopyrightLabel()
        {
            _copyrightLabel.AutoSize = true;
            _copyrightLabel.Location = new Point(COPYRIGHTLABEL_LOCATION_X, COPYRIGHTLABEL_LOCATION_Y);
            _copyrightLabel.Name = "_copyrightLabel";
            _copyrightLabel.Text = "Copyright © 2011 All rights reserved.";
        }

        // 設定_programNameLabel
        private void SetProgramNameLabel()
        {
            _programNameLabel.AutoSize = true;
            _programNameLabel.Location = new Point(PROGRAMNAMELABEL_LOCATION_X, PROGRAMNAMELABEL_LOCATION_Y);
            _programNameLabel.Name = "_programNameLabel";
            _programNameLabel.Text = "Painter";
        }

        // 準備物件
        private void PrepareComponent()
        {
            _programNameLabel = new Label();
            _copyrightLabel = new Label();
            _nameLabel = new Label();
            _pictureBox = new PictureBox();
            _okButton = new Button();
            _linkLabel = new LinkLabel();
        }

        // 按下連結
        private void LinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }
    }
}
