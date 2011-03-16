using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace HaarDetector
{
    public interface IHaarDetector
    {
        void DetectObj(Image<Bgr, Byte> image);
        void LoadHaarCascade(string CascadePath);
        void SetMinObjSize(Size minSize);
        void DrawObj(Image<Bgr, Byte> image);
    }
}
