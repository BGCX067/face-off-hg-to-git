using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace CSharpFaceOff
{
    class HaarEyeDetector 
    {
        private Color m_ObjCor;
        private Color m_LeftEyeCor;
        private Color m_RightEyeCor;
        private string m_strLeftEyeCascade;
        private string m_strRightEyeCascade;
        protected HaarCascade m_harrDetector;
        protected HaarCascade m_LeftEyeDetector;
        protected HaarCascade m_RightEyeDetector;
        protected Size m_MinEyeSize;
        protected Rectangle m_rcBestEyeDetected;
        protected Rectangle m_rcBestLeftEye;
        protected Rectangle m_rcBestRightEye;

        public HaarEyeDetector()
        {
            m_ObjCor = Color.Red;
            m_LeftEyeCor = Color.Black;
            m_RightEyeCor = Color.Tomato;
        }

        public string LeftEyeCascade
        {
            get
            {
                return m_strLeftEyeCascade;
            }
            set
            {
                m_strLeftEyeCascade = value;
                m_LeftEyeDetector = new HaarCascade(m_strLeftEyeCascade);
            }
        }
        public string RightEyeCascade
        {
            get
            {
                return m_strRightEyeCascade;
            }
            set
            {
                m_strRightEyeCascade = value;
                m_RightEyeDetector = new HaarCascade(m_strRightEyeCascade);
            }
        }
        public Rectangle BestLeftEye
        {
            get
            {
                return m_rcBestLeftEye;
            }
        }

        public Rectangle BestRightEye
        {
            get
            {
                return m_rcBestRightEye;
            }
        }

        public Rectangle BestEyePairDetected
        {
            get
            {
                return m_rcBestEyeDetected;
            }
        }

        public Color DrawColor
        {
            get
            {
                return m_ObjCor;
            }
            set
            {
                m_ObjCor = value;
            }
        }
        public void DetectObj(Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> image)
        {
            if (m_harrDetector == null)
                throw new ArgumentNullException("HaarCascade", "haarCascade not initilized.");

            MCvAvgComp[][] EyeDetected = null;
            MCvAvgComp[][] LeftEyeDetected = null;
            MCvAvgComp[][] RightEyeDetected = null;


            EyeDetected = image.DetectHaarCascade(
                    m_harrDetector,
                    1.1,
                    10,
                    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    m_MinEyeSize);

            if (EyeDetected.Length > 1)
            {
                Rectangle rcROI = image.ROI;

                MCvAvgComp eyepair = EyeDetected[0][0];

                int width = Convert.ToInt32(eyepair.rect.Width * 1.5);
                int height = Convert.ToInt32(eyepair.rect.Height * 1.5);

                Rectangle rectEye = new Rectangle(eyepair.rect.X -10,
                    eyepair.rect.Y - 10, width, height);
                Rectangle rectLeftEye = new Rectangle(eyepair.rect.X - 10,
                    eyepair.rect.Y - 10, width , height );
                Rectangle rectRightEye = new Rectangle(eyepair.rect.X - 10 + width / 2,
                    eyepair.rect.Y - 10, width, height);

                Rectangle rcLeft = Rectangle.Empty;
                Rectangle rcRight = Rectangle.Empty;

                if (rcROI != Rectangle.Empty)
                {
                    rectEye.X += rcROI.X;
                    rectEye.Y += rcROI.Y;

                    rectLeftEye.X += rcROI.X;
                    rectLeftEye.Y += rcROI.Y;

                    rectRightEye.X += rcROI.X;
                    rectRightEye.Y += rcROI.Y;
                }
                image.ROI = rectLeftEye;

                if (m_LeftEyeDetector != null)
                {
                    LeftEyeDetected = image.DetectHaarCascade(
                        m_LeftEyeDetector,
                        1.1,
                        10,
                        Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                        m_MinEyeSize);

                    //Project into no ROI space
                    for (int i = 0; i < LeftEyeDetected[0].Length; i++)
                    {
                        LeftEyeDetected[0][i].rect.X += (rectLeftEye.X);
                        LeftEyeDetected[0][i].rect.Y += (rectLeftEye.Y);
                    }
                }

                image.ROI = rectEye;
                if (LeftEyeDetected[0].Length > 1)
                {// if already detected more than one eyes, then both eye should already be detected
                    foreach (MCvAvgComp eye in LeftEyeDetected[0])
                    {
                        if (rcLeft == Rectangle.Empty || rcLeft.X > eye.rect.X)
                        {
                            rcLeft = eye.rect;
                        }
                        if (rcRight == Rectangle.Empty || rcRight.X < eye.rect.X)
                        {
                            rcRight = eye.rect;
                        }
                    }
                }
                else if (m_RightEyeDetector != null)
                {
                    RightEyeDetected = image.DetectHaarCascade(
                        m_RightEyeDetector,
                        1.1,
                        10,
                        Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                        m_MinEyeSize);
                    //Project into no ROI space
                    for (int i = 0; i < RightEyeDetected[0].Length; i++)
                    {
                        RightEyeDetected[0][i].rect.X += rectEye.X;
                        RightEyeDetected[0][i].rect.Y += rectEye.Y;
                    }
                    // we only need the right eye
                    rcRight = Rectangle.Empty;
                    foreach (MCvAvgComp eye in RightEyeDetected[0])
                    {
                        if (rcRight == Rectangle.Empty || rcRight.X < eye.rect.X)
                        {
                            rcRight = eye.rect;
                        }
                    }
                }
                m_rcBestLeftEye = rcLeft;
                m_rcBestRightEye = rcRight;
                m_rcBestEyeDetected = EyeDetected[0][0].rect;

                //Project into the original ROI
                if (rcROI != Rectangle.Empty)
                {
                    m_rcBestLeftEye.X -= rcROI.X;
                    m_rcBestLeftEye.Y -= rcROI.Y;

                    m_rcBestRightEye.X -= rcROI.X;
                    m_rcBestRightEye.Y -= rcROI.Y;
                }
                image.ROI = rcROI;
            }
            
        }

        public void LoadHaarCascade(string CascadePath)
        {
            m_harrDetector = new HaarCascade(CascadePath);
        }

        public void SetMinObjSize(System.Drawing.Size minSize)
        {
            m_MinEyeSize = minSize;
        }

        public void DrawObj(Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> image)
        {
            //draw the eye pair detected in the 0th channel with color
            image.Draw(m_rcBestEyeDetected, new Bgr(m_ObjCor), 2);
            //draw the left eye detected in the 0th channel with color
            image.Draw(m_rcBestLeftEye, new Bgr(m_LeftEyeCor), 2);
            //draw the right eye detected in the 0th channel with color
            image.Draw(m_rcBestRightEye, new Bgr(m_RightEyeCor), 2);
        }
    }
}
