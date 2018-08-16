using System;
using System.Runtime.InteropServices;

namespace Nsg.Viewer.OSXWindow
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRenderCommandEncoder
    {
        public readonly IntPtr NativePtr;
        public MTLRenderCommandEncoder(IntPtr ptr) => NativePtr = ptr;
        public bool IsNull => NativePtr == IntPtr.Zero;

        public void setRenderPipelineState(MTLRenderPipelineState pipelineState)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRenderPipelineState, pipelineState.NativePtr);

        public void setVertexBuffer(MTLBuffer buffer, UIntPtr offset, UIntPtr index)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexBuffer,
                buffer.NativePtr,
                offset,
                index);

        public void setFragmentBuffer(MTLBuffer buffer, UIntPtr offset, UIntPtr index)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentBuffer,
                buffer.NativePtr,
                offset,
                index);

        public void setVertexTexture(MTLTexture texture, UIntPtr index)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexTexture, texture.NativePtr, index);
        public void setFragmentTexture(MTLTexture texture, UIntPtr index)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentTexture, texture.NativePtr, index);

        public void setVertexSamplerState(MTLSamplerState sampler, UIntPtr index)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setVertexSamplerState, sampler.NativePtr, index);

        public void setFragmentSamplerState(MTLSamplerState sampler, UIntPtr index)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFragmentSamplerState, sampler.NativePtr, index);

        public void drawPrimitives(
            MTLPrimitiveType primitiveType,
            UIntPtr vertexStart,
            UIntPtr vertexCount,
            UIntPtr instanceCount,
            UIntPtr baseInstance)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawPrimitives0,
                primitiveType, vertexStart, vertexCount, instanceCount, baseInstance);

        public void drawPrimitives(
            MTLPrimitiveType primitiveType,
            UIntPtr vertexStart,
            UIntPtr vertexCount,
            UIntPtr instanceCount)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawPrimitives2,
                primitiveType, vertexStart, vertexCount, instanceCount);

        public void drawPrimitives(MTLPrimitiveType primitiveType, MTLBuffer indirectBuffer, UIntPtr indirectBufferOffset)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawPrimitives1,
                primitiveType, indirectBuffer, indirectBufferOffset);

        public void drawIndexedPrimitives(
            MTLPrimitiveType primitiveType,
            UIntPtr indexCount,
            MTLIndexType indexType,
            MTLBuffer indexBuffer,
            UIntPtr indexBufferOffset,
            UIntPtr instanceCount)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawIndexedPrimitives0,
                primitiveType, indexCount, indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount);

        public void drawIndexedPrimitives(
            MTLPrimitiveType primitiveType,
            UIntPtr indexCount,
            MTLIndexType indexType,
            MTLBuffer indexBuffer,
            UIntPtr indexBufferOffset,
            UIntPtr instanceCount,
            IntPtr baseVertex,
            UIntPtr baseInstance)
            => ObjectiveCRuntime.objc_msgSend(
                NativePtr,
                sel_drawIndexedPrimitives1,
                primitiveType, indexCount, indexType, indexBuffer.NativePtr, indexBufferOffset, instanceCount, baseVertex, baseInstance);

        public void drawIndexedPrimitives(
            MTLPrimitiveType primitiveType,
            MTLIndexType indexType,
            MTLBuffer indexBuffer,
            UIntPtr indexBufferOffset,
            MTLBuffer indirectBuffer,
            UIntPtr indirectBufferOffset)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_drawIndexedPrimitives2,
                primitiveType,
                indexType,
                indexBuffer,
                indexBufferOffset,
                indirectBuffer,
                indirectBufferOffset);

        public unsafe void setViewport(MTLViewport viewport)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setViewport, viewport);

        public unsafe void setViewports(MTLViewport* viewports, UIntPtr count)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setViewports, viewports, count);

        public unsafe void setScissorRect(MTLScissorRect scissorRect)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setScissorRect, scissorRect);

        public unsafe void setScissorRects(MTLScissorRect* scissorRects, UIntPtr count)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setScissorRects, scissorRects, count);

        public void setCullMode(MTLCullMode cullMode)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setCullMode, (uint)cullMode);

        public void setFrontFacing(MTLWinding frontFaceWinding)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFrontFacingWinding, (uint)frontFaceWinding);

        public void setDepthStencilState(MTLDepthStencilState depthStencilState)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthStencilState, depthStencilState.NativePtr);

        public void setDepthClipMode(MTLDepthClipMode depthClipMode)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDepthClipMode, (uint)depthClipMode);

        public void endEncoding() => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_endEncoding);

        public void setStencilReferenceValue(uint stencilReference)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStencilReferenceValue, stencilReference);

        public void setBlendColor(float red, float green, float blue, float alpha)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBlendColor, red, green, blue, alpha);

        public void setTriangleFillMode(MTLTriangleFillMode fillMode)
            => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setTriangleFillMode, (uint)fillMode);

        private static readonly Selector sel_setRenderPipelineState = "setRenderPipelineState:";
        private static readonly Selector sel_setVertexBuffer = "setVertexBuffer:offset:atIndex:";
        private static readonly Selector sel_setFragmentBuffer = "setFragmentBuffer:offset:atIndex:";
        private static readonly Selector sel_setVertexTexture = "setVertexTexture:atIndex:";
        private static readonly Selector sel_setFragmentTexture = "setFragmentTexture:atIndex:";
        private static readonly Selector sel_setVertexSamplerState = "setVertexSamplerState:atIndex:";
        private static readonly Selector sel_setFragmentSamplerState = "setFragmentSamplerState:atIndex:";
        private static readonly Selector sel_drawPrimitives0 = "drawPrimitives:vertexStart:vertexCount:instanceCount:baseInstance:";
        private static readonly Selector sel_drawPrimitives1 = "drawPrimitives:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_drawPrimitives2 = "drawPrimitives:vertexStart:vertexCount:instanceCount:";
        private static readonly Selector sel_drawIndexedPrimitives0 = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:";
        private static readonly Selector sel_drawIndexedPrimitives1 = "drawIndexedPrimitives:indexCount:indexType:indexBuffer:indexBufferOffset:instanceCount:baseVertex:baseInstance:";
        private static readonly Selector sel_drawIndexedPrimitives2 = "drawIndexedPrimitives:indexType:indexBuffer:indexBufferOffset:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_setViewport = "setViewport:";
        private static readonly Selector sel_setViewports = "setViewports:count:";
        private static readonly Selector sel_setScissorRect = "setScissorRect:";
        private static readonly Selector sel_setScissorRects = "setScissorRects:count:";
        private static readonly Selector sel_setCullMode = "setCullMode:";
        private static readonly Selector sel_setFrontFacingWinding = "setFrontFacingWinding:";
        private static readonly Selector sel_setDepthStencilState = "setDepthStencilState:";
        private static readonly Selector sel_setDepthClipMode = "setDepthClipMode:";
        private static readonly Selector sel_endEncoding = "endEncoding";
        private static readonly Selector sel_setStencilReferenceValue = "setStencilReferenceValue:";
        private static readonly Selector sel_setBlendColor = "setBlendColorRed:green:blue:alpha:";
        private static readonly Selector sel_setTriangleFillMode = "setTriangleFillMode:";
    }
}