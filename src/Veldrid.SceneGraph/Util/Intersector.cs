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

namespace Veldrid.SceneGraph.Util
{
    /// <summary>
    /// Base class for all intersectors
    /// </summary>
    public abstract class Intersector
    {
        public enum IntersectionLimitModes
        {
            NoLimit,
            LimitOnePerDrawable,
            LimitOne,
            LimitNearest
        };
        
        public IntersectionLimitModes IntersectionLimit { get; set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public Intersector()
        {
            IntersectionLimit = IntersectionLimitModes.NoLimit;
        }

        public abstract Intersector Clone(IntersectionVisitor iv);
        
        public abstract void Intersect(IntersectionVisitor iv, Drawable drawable);

        public abstract bool Enter(Node node);

        public abstract void Leave();

        public abstract void Reset();

    }
}