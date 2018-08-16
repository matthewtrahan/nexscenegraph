using System;

namespace Nsg.Viewer.OSXWindow
{
    public struct CAMetalLayer
    {
        public readonly IntPtr NativePtr;

        public CAMetalLayer(IntPtr ptr) => NativePtr = ptr;

        public static CAMetalLayer New()
        {
            var cls = new ObjCClass("CAMetalLayer");
            return cls.AllocInit<CAMetalLayer>();
        }

        public MTLDevice device
        {
            get => ObjectiveCRuntime.objc_msgSend<MTLDevice>(NativePtr, sel_device);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDevice, value);
        }

        public MTLPixelFormat pixelFormat
        {
            get => (MTLPixelFormat)ObjectiveCRuntime.uint_objc_msgSend(NativePtr, sel_pixelFormat);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPixelFormat, (uint)value);
        }

        public Bool8 framebufferOnly
        {
            get => ObjectiveCRuntime.bool8_objc_msgSend(NativePtr, sel_framebufferOnly);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setFramebufferOnly, value);
        }

        public CGSize drawableSize
        {
            get => ObjectiveCRuntime.CGSize_objc_msgSend(NativePtr, sel_drawableSize);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setDrawableSize, value);
        }

        public CGRect frame
        {
            get => ObjectiveCRuntime.CGRect_objc_msgSend(NativePtr, "frame");
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, "setFrame:", value);
        }

        public Bool8 opaque
        {
            get => ObjectiveCRuntime.bool8_objc_msgSend(NativePtr, "isOpaque");
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, "setOpaque:", value);
        }

        public CAMetalDrawable nextDrawable() => ObjectiveCRuntime.objc_msgSend<CAMetalDrawable>(NativePtr, sel_nextDrawable);

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_setDevice = "setDevice:";
        private static readonly Selector sel_pixelFormat = "pixelFormat";
        private static readonly Selector sel_setPixelFormat = "setPixelFormat:";
        private static readonly Selector sel_framebufferOnly = "framebufferOnly";
        private static readonly Selector sel_setFramebufferOnly = "setFramebufferOnly:";
        private static readonly Selector sel_drawableSize = "drawableSize";
        private static readonly Selector sel_setDrawableSize = "setDrawableSize:";
        private static readonly Selector sel_nextDrawable = "nextDrawable";
    }
}