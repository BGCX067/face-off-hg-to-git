using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
namespace HarrDetector
{
    public class FaceDetector : IHaarDetector
    {
        protected HaarCascade m_harrDetector;
        protected Size m_MinFaceSize;
        protected MCvAvgComp[][] m_FaceDetected;

        public MCvAvgComp[][] FacesDetected
        {
            get
            {
                return m_FaceDetected;
            }
        }
        public FaceDetector()
        {
            m_harrDetector = new HaarCascade(
                @"D:\code\harr\haarcascade_frontalface_alt.xml");
            m_MinFaceSize = new Size(20, 20);
        }

        #region IHaarDetector Members

        public void DetectFace(Image<Bgr, byte> image)
        {
            if (m_harrDetector == null)
                throw new ArgumentNullException("HaarCascade", "haarCascade not initilized.");
            m_FaceDetected = image.DetectHaarCascade(
                    m_harrDetector,
                    1.1,
                    10,
                    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    m_MinFaceSize);
        }
        
        public void SetMinObjSize(Size minSize)
        {
            m_MinFaceSize = minSize;
        }

        public void DrawObj(Image<Bgr, Byte> image)
        {
            foreach (MCvAvgComp f in m_FaceDetected[0])
            {
                //draw the face detected in the 0th channel with blue color
                image.Draw(f.rect, new Bgr(Color.Blue), 2);
            }
        }
        #endregion
    }
}
