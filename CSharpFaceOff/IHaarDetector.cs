using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace HarrDetector
{
    public interface IHaarDetector
    {
        void DetectFace(Image<Bgr, Byte> image);
        void SetMinObjSize(Size minSize);
        void DrawObj(Image<Bgr, Byte> image);
    }
}
