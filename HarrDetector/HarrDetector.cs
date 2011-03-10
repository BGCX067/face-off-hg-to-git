using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
namespace HarrDetector
{
    public class HaarBaseDetector : IHaarDetector
    {
        protected HaarCascade harrDetector;
        public HaarBaseDetector()
        {
            harrDetector = new HaarCascade(
                @"D:\code\harr\人脸\haarcascade_frontalface_alt.xml");
        }



        #region IHaarDetector Members

        public void DetectFace(Image<Bgr, byte> image)
        {
            if (harrDetector == null)
                throw new ArgumentNullException("HaarCascade", "haarCascade not initilized.");
            MCvAvgComp[][] facesDetected = image.DetectHaarCascade(
                    harrDetector,
                    1.1,
                    10,
                    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    new Size(20, 20));
        }

        #endregion
    }
}
