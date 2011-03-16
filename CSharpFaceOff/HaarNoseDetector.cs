using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using HaarDetector;

namespace CSharpFaceOff
{
    class HaarNoseDetector : IHaarDetector
    {
        private Color m_ObjCor;
        protected HaarCascade m_harrDetector;
        protected Size m_MinNoseSize;
        protected MCvAvgComp[][] m_NoseDetected;
        protected Rectangle m_rectBestResult;

        public HaarNoseDetector()
        {
            m_ObjCor = Color.Red;
            m_MinNoseSize = new Size(20, 20);
        }

        public MCvAvgComp[][] NoseDetected
        {
            get
            {
                return m_NoseDetected;
            }
        }

        public Rectangle BestResult
        {
            get
            {
                return m_rectBestResult;
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
        
        public void FilterResult()
        {
            Rectangle rect = new Rectangle(0, 0, 0, 0);
            foreach (MCvAvgComp comp in m_NoseDetected[0])
            {
                if (rect.Y < comp.rect.Y)
                {
                    rect = comp.rect;
                }
            }
            m_rectBestResult = rect;
        }

        public void DetectObj(Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> image)
        {
            if (m_harrDetector == null)
                throw new ArgumentNullException("HaarCascade", "haarCascade not initilized.");
            m_NoseDetected = image.DetectHaarCascade(
                    m_harrDetector,
                    1.1,
                    10,
                    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    m_MinNoseSize);
        }

        public void LoadHaarCascade(string CascadePath)
        {
            m_harrDetector = new HaarCascade(CascadePath);
        }

        public void SetMinObjSize(System.Drawing.Size minSize)
        {
            m_MinNoseSize = minSize;
        }

        public void DrawObj(Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte> image)
        {
            image.Draw(BestResult, new Bgr(m_ObjCor), 2);
            /*
            foreach (MCvAvgComp f in m_NoseDetected[0])
            {
                //draw the mouth detected in the 0th channel with color
                image.Draw(f.rect, new Bgr(Color.Purple), 2);
            }*/
        }
    }
}
