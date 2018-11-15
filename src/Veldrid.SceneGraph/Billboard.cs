//
// Copyright (c) 2018 Sean Spicer
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Numerics;
using Veldrid.SceneGraph.Util;
using Veldrid.SceneGraph.Viewer;

namespace Veldrid.SceneGraph
{
    public class Billboard : Geode
    {
        public enum Modes
        {
            Screen
        }

        public Modes Mode { get; set; }
        
        public Billboard()
        {
            Mode = Modes.Screen;
        }
        
        public override void Accept(NodeVisitor visitor)
        {
            visitor.Apply(this);
        }
        
       
        public Matrix4x4 ComputeMatrix(Matrix4x4 modelView, Vector3 eyeLocal)
        {
            Matrix4x4 rotate = Matrix4x4.Identity;
            switch (Mode)
            {
                case Modes.Screen:
                    var tmp = modelView.SetTranslation(Vector3.Zero);
                    var canInvert = Matrix4x4.Invert(tmp, out rotate);
                    if (false == canInvert)
                    {
                        rotate = Matrix4x4.Identity;
                    }
                    break;
                default:
                    break;
            }

            return rotate;
        }
    }
}