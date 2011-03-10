using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace HarrDetector
{
    public interface IHaarDetector
    {
        void DetectFace(Image<Bgr, Byte> image);
    }
}
