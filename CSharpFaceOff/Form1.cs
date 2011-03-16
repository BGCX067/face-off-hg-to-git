using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using HaarDetector;
using Emgu.CV.UI;

namespace CSharpFaceOff
{
    public partial class frmMain : Form
    {
        FaceDetector facedetector = new FaceDetector();
        HaarMouthDetector mouthdetector = new HaarMouthDetector();
        HaarNoseDetector nosedetector = new HaarNoseDetector();
        HaarEyeDetector eyedetector = new HaarEyeDetector();

        Image<Bgr, Byte> imageDraging = null;
        Image<Bgr, Byte> imageForeground = null;
        Image<Bgr, Byte> imageBackground = null;

        Rectangle rcfFace = new Rectangle();
        Rectangle rcfLeftEye =new Rectangle();
        Rectangle rcfRightEye = new Rectangle();
        Rectangle rcfMouth = new Rectangle();
        Rectangle rcfNose = new Rectangle();

        Rectangle rcbFace = new Rectangle();
        Rectangle rcbLeftEye = new Rectangle();
        Rectangle rcbRightEye = new Rectangle();
        Rectangle rcbMouth = new Rectangle();
        Rectangle rcbNose = new Rectangle();


        public frmMain()
        {
            InitializeComponent();

            eyedetector.LoadHaarCascade(@"haar\眼睛\haarcascade_mcs_eyepair_big.xml");
            eyedetector.LeftEyeCascade = @"haar\眼睛\haarcascade_mcs_lefteye.xml";
            eyedetector.RightEyeCascade = @"haar\眼睛\haarcascade_mcs_righteye.xml";
            facedetector.LoadHaarCascade(@"haar\人脸\haarcascade_frontalface_alt.xml");
            mouthdetector.LoadHaarCascade(@"haar\鼻子\haarcascade_mcs_nose.xml");
            nosedetector.LoadHaarCascade(@"haar\嘴巴\haarcascade_mcs_mouth.xml");
        }

        frmFace face1 = new frmFace();
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (imageForeground != null)
            {
                facedetector.DetectObj(imageForeground);

                imageForeground.ROI = facedetector.FirstFace;
                mouthdetector.DetectObj(imageForeground);
                nosedetector.DetectObj(imageForeground);
                eyedetector.DetectObj(imageForeground);
                imageForeground.ROI = Rectangle.Empty;

                mouthdetector.FilterResult();
                nosedetector.FilterResult();

                eyedetector.DrawColor = Color.Pink;
                mouthdetector.DrawColor = Color.Yellow;
                nosedetector.DrawColor = Color.White;

                facedetector.DrawObj(imageForeground);
                imageForeground.ROI = facedetector.FirstFace;
                eyedetector.DrawObj(imageForeground);
                mouthdetector.DrawObj(imageForeground);
                nosedetector.DrawObj(imageForeground);
                imageForeground.ROI = Rectangle.Empty;

                rcfFace = facedetector.FirstFace;
                rcfLeftEye = eyedetector.BestLeftEye;
                rcfRightEye = eyedetector.BestRightEye;
                rcfMouth = mouthdetector.BestResult;
                rcfNose = nosedetector.BestResult;

                imgboxBackground.Image = imageForeground;
            }
            if (imageBackground != null)
            {
                facedetector.DetectObj(imageBackground);

                imageBackground.ROI = facedetector.FirstFace;
                mouthdetector.DetectObj(imageBackground);
                nosedetector.DetectObj(imageBackground);
                eyedetector.DetectObj(imageBackground);
                imageBackground.ROI = Rectangle.Empty;

                mouthdetector.FilterResult();
                nosedetector.FilterResult();

                eyedetector.DrawColor = Color.Pink;
                mouthdetector.DrawColor = Color.Yellow;
                nosedetector.DrawColor = Color.White;

                facedetector.DrawObj(imageBackground);
                imageBackground.ROI = facedetector.FirstFace;
                eyedetector.DrawObj(imageBackground);
                mouthdetector.DrawObj(imageBackground);
                nosedetector.DrawObj(imageBackground);
                imageBackground.ROI = Rectangle.Empty;

                rcbFace = facedetector.FirstFace;
                rcbLeftEye = eyedetector.BestLeftEye;
                rcbRightEye = eyedetector.BestRightEye;
                rcbMouth = mouthdetector.BestResult;
                rcbNose = nosedetector.BestResult;

                imgboxBackground.Image = imageBackground;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dlgImagePicker.ShowDialog() == DialogResult.OK)
            {
                imgboxBackground.Image.Save(dlgImagePicker.FileName);
            }
        }

        private void loadAnImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgImagePicker.ShowDialog() == DialogResult.OK)
            {
                Image<Bgr, Byte> image = new Image<Bgr, byte>(dlgImagePicker.FileName);
                frmFace face = new frmFace();
                face.MdiParent = this;
                face.Face = image;
                face.Show();
            }
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            this.imgboxBackground.Visible = false;
            //告诉另外一个窗口要处理数据了
            foreach (Form f in this.MdiChildren)
            {
                Point p = PointToClient(f.Location);
                Rectangle rc = f.ClientRectangle;
                if (e.X > p.X && e.X < (p.X + rc.Width)
                    && e.Y > p.Y && e.Y < (p.Y + rc.Height))
                {
                    f.Focus();
                }
            }

        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            Type type = typeof(Image<Bgr, Byte>);
            imageDraging = e.Data.GetData(type) as Image<Bgr, Byte>;
            if (imageDraging != null)
            {
                this.imgboxBackground.Image = imageDraging;
                e.Effect = DragDropEffects.Copy;
                this.imgboxBackground.Visible = true;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void frmMain_DragLeave(object sender, EventArgs e)
        {
            this.imgboxBackground.Visible = false;
        }

        private void frmMain_DragOver(object sender, DragEventArgs e)
        {
            this.imgboxBackground.Location = PointToClient(new Point(e.X, e.Y));
            e.Effect = DragDropEffects.Move;
        }

        private void imgboxDraging_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void imgboxDraging_DragOver(object sender, DragEventArgs e)
        {

        }

        private void imgboxDraging_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            imageForeground = new Image<Bgr, byte>(@"E:\image\61055233_278029283.jpeg");
            imageBackground = new Image<Bgr, byte>(@"E:\image\AFVTD00Z.jpg");
            imgboxBackground.Image = imageBackground;
            imgboxFore.Image = imageForeground;
        }

        private void imgboxFore_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
