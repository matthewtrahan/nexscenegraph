﻿//
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
using System.Numerics;

namespace Veldrid.SceneGraph.Viewer
{
    public class Renderer : IGraphicsDeviceOperation
    {
        private DrawVisitor _drawVisitor;
        private Camera _camera;
        
        private DeviceBuffer _projectionBuffer;
        private DeviceBuffer _viewBuffer;
        private DeviceBuffer _worldBuffer;
        private CommandList _commandList;
        private ResourceLayout _resourceLayout;
        private ResourceSet _resourceSet;
        
        private bool _initialized = false;
        
        public Renderer(Camera camera)
        {
            _camera = camera;
            _drawVisitor = new DrawVisitor();
        }

        private void Initialize(GraphicsDevice device, ResourceFactory factory)
        {
            _drawVisitor.GraphicsDevice = device;
            _drawVisitor.ResourceFactory = factory;
            
            _projectionBuffer = factory.CreateBuffer(new BufferDescription(64, BufferUsage.UniformBuffer | BufferUsage.Dynamic));
            _viewBuffer = factory.CreateBuffer(new BufferDescription(64, BufferUsage.UniformBuffer | BufferUsage.Dynamic));
            _worldBuffer = factory.CreateBuffer(new BufferDescription(64, BufferUsage.UniformBuffer | BufferUsage.Dynamic));
            
            _resourceLayout = factory.CreateResourceLayout(new ResourceLayoutDescription(
                new ResourceLayoutElementDescription("Projection", ResourceKind.UniformBuffer, ShaderStages.Vertex),
                new ResourceLayoutElementDescription("View", ResourceKind.UniformBuffer, ShaderStages.Vertex)
            ));
            
            _resourceSet = factory.CreateResourceSet(new ResourceSetDescription(_resourceLayout, _projectionBuffer, _viewBuffer));
            
            _commandList = factory.CreateCommandList();

            _initialized = true;
        }
        
        private void Draw(GraphicsDevice device, ResourceFactory factory)
        {
            if (!_initialized)
            {
                Initialize(device, factory);
            }
            
            
            _drawVisitor.CommandList = _commandList;
            _drawVisitor.ResourceLayout = _resourceLayout;
            _drawVisitor.ResourceSet = _resourceSet;
            
            // Begin() must be called before commands can be issued.
            _commandList.Begin();

            // We want to render directly to the output window.
            _commandList.SetFramebuffer(device.SwapchainFramebuffer);
            
            // TODO Set from Camera color ?
            _commandList.ClearColorTarget(0, RgbaFloat.Black);
            _commandList.ClearDepthStencil(1f);
            
            _drawVisitor.BeginDraw();

            if (_camera.View.GetType() != typeof(Viewer.View))
            {
                throw new InvalidCastException("Camera View type is not correct");
            }

            var view = (Viewer.View) _camera.View;
            view.SceneData?.Accept(_drawVisitor);

            _drawVisitor.EndDraw();
            
            _commandList.End();
            
            device.SubmitCommands(_commandList);
        }

        private void UpdateUniforms(GraphicsDevice device, ResourceFactory factory)
        {
            if (!_initialized)
            {
                Initialize(device, factory);
            }
            
            //device.UpdateBuffer(_projectionBuffer, 0, Matrix4x4.Identity);
            //device.UpdateBuffer(_viewBuffer, 0, Matrix4x4.Identity);
            
            
//            Console.WriteLine("Transformed Coord = {0}", 
//                Vector4.Transform(
//                    Vector4.Transform(
//                        new Vector4(0.75f, 0.75f, 0f, 1f), 
//                        _camera.ViewMatrix), 
//                    _camera.ProjectionMatrix));
            
            device.UpdateBuffer(_projectionBuffer, 0, _camera.ProjectionMatrix);
            device.UpdateBuffer(_viewBuffer, 0, _camera.ViewMatrix);
            
        }

        private void SwapBuffers(GraphicsDevice device)
        {
            device.SwapBuffers();
        }

        public void HandleOperation(GraphicsDevice device, ResourceFactory factory)
        {
            UpdateUniforms(device, factory);
            Draw(device, factory);
            SwapBuffers(device);
        }
    }
}